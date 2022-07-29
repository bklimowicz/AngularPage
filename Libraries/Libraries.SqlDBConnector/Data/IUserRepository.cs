using Libraries.SqlDBConnector.Models;

namespace Libraries.SqlDBConnector.Data
{
    public interface IUserRepository
    {
        User? Create(User user);
        User? GetByEmail(string email);
        User? GetById(int id);
    }
}

