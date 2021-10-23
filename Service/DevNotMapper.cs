namespace DevNot2021.Model;
public class DevNotMapper : Profile
{
    public DevNotMapper(IDataProtector provider)
    {
        CreateMap<DbUser, User>().
          ForMember(u => u.FullName, opt => opt.MapFrom(u2 => u2.Name + " " + u2.LastName)).
          ForMember(u => u.PasswordHash, opt => opt.MapFrom(u2 => provider.Unprotect(u2.PasswordHash)));
        CreateMap<User, DbUser>().
          ForMember(u => u.PasswordHash, opt => opt.MapFrom(u2 => provider.Protect(u2.Password)));
    }
}

