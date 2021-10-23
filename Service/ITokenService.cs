namespace DevNot2021.Services;
public interface ITokenService
{
    string GetToken(DbUser user);
}
