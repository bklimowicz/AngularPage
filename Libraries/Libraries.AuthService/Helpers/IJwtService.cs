namespace Libraries.AuthService.Helpers
{
    public interface IJwtService
    {
        string Generate(int id);
    }
}