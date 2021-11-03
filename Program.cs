var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("SQLDBConnection");
builder.Services.AddDbContext<DevNotContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddScoped<IZipService, ZipService>();

builder.Services.AddDataProtection();
builder.Services.AddCors();

var serviceProvider = builder.Services.BuildServiceProvider();
var _provider = serviceProvider.GetService<IDataProtectionProvider>();

var protector = _provider.CreateProtector(builder.Configuration["Protector_Key"]);

var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new DevNotMapper(protector));
});
IMapper autoMapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(autoMapper);

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateActor = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Issuer"],
        ValidAudience = builder.Configuration["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["SigningKey"]))
    };
});

builder.Services.AddSingleton<ITokenService>(new TokenService(builder));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
  {
    {
      new OpenApiSecurityScheme
      {
        Reference = new OpenApiReference
        {
          Type = ReferenceType.SecurityScheme,
          Id = "Bearer"
        },
        Scheme = "oauth2",
        Name = "Bearer",
        In = ParameterLocation.Header,

      },
      new List<string>()
    }});
});


var app = builder.Build();

app.UseAuthorization();
app.UseAuthentication();

app.UseCors(p =>
{
    p.AllowAnyOrigin();
    p.WithMethods("GET");
    p.AllowAnyHeader();
});

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1"));
}

app.MapGet("/", () => "Hello World!");

app.MapGet("/GetRoles", (Func<List<Role>>)(() => new()
{
    new(1, "Admin", 1),
    new(2, "User", 1),
    new(3, "Worker", 1)
}));

app.MapGet("/GetTop5UserPermisions", async (DevNotContext context, IZipService service) =>
{
    var userList = await context.DbUser.Where(du => du.IdSecurityRole != null).
    Select(u => $"{u.Name} {u.LastName}").Take(5).ToListAsync();

    var roleList = await (from role in context.DbSecurityRole
                          join user in context.DbUser
                          on role.IdSecurityRole equals user.IdSecurityRole
                          select role.SecurityRoleName).Take(5).ToListAsync();

    var IdUserList = await context.DbUser.Where(du => du.IdSecurityRole != null).
     Select(db => db.IdUser.ToString()).Take(5).ToListAsync();

    var actionList = await context.DbSecurityUserAction.Where(a => a.IdSecurityController == 2 &&
    IdUserList.Contains(a.IdUser.ToString())).Select(u => u.ActionNumberTotal).Take(5).ToListAsync();

    return service.ZipResult(userList, roleList, actionList);
});

app.MapPost("/InsertUser", async (DevNotContext context, User user,IMapper mapper) =>
{
    //var model = autoMapper.Map<DbUser>(user);
    var model = mapper.Map<DbUser>(user);
    context.DbUser.Add(model);
    await context.SaveChangesAsync();
    return new OkResult();
});

app.MapGet("/GetAllUsersByName/{name}", [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)] async (HttpContext http, DevNotContext context, string name) =>
{
    var sqlQuery = context.DbUser.Where(u => u.UserName.Contains(name)).ToQueryString();
    System.Diagnostics.Debug.WriteLine(sqlQuery);

    var model = await context.DbUser.Where(u => u.UserName.Contains(name)).ToListAsync();
    var result = autoMapper.Map<List<User>>(model);

    //result.ForEach(user => { user.PasswordHash = user.PasswordHash == null ? "" : protector.Unprotect(user.PasswordHash); });
    return result;
});//.RequireAuthorization();

app.MapPost("/login", [AllowAnonymous] async (DevNotContext _context, HttpContext http, ITokenService service, Login login) =>
{
    if (!string.IsNullOrEmpty(login.UserName) &&
      !string.IsNullOrEmpty(login.Password))
    {
        var userModel = await _context.DbUser.Where(u => u.UserName == login.UserName && u.Password == login.Password).FirstOrDefaultAsync();
        if (userModel == null)
        {
            http.Response.StatusCode = 401;
            await http.Response.WriteAsJsonAsync(new { Message = "Yor Are Not Authorized!" });
            return;
        }

        var token = service.GetToken(userModel);
        await http.Response.WriteAsJsonAsync(new { token = token });
        return;
    }
});

//app.Urls.Add("https://localhost:1923");
app.Run();
