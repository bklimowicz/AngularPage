using Libraries.SqlDBConnector.Models;
using Microsoft.EntityFrameworkCore;

namespace Libraries.SqlDBConnector.Data
{
    public interface IUserContext
    {
        DbSet<User> Users { get; set; }

        int SaveChanges();
    }
}