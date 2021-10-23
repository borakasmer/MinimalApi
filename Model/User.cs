
namespace DevNot2021.Model;
public record User
{
    public int? IdSecurityRole { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }
    public string Gsm { get; set; }
    public long? TotalCompanyNumber { get; set; }
    public bool IsDeleted { get; set; }
    public bool? IsAdmin { get; set; }
    public string FullName { get; set; }
}
