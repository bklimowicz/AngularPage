using Libraries.AuthService.Models;
using Microsoft.EntityFrameworkCore;

namespace Libraries.AuthService.Data
{
    public interface IUserContext
    {
        DbSet<User> Users { get; set; }

        int SaveChanges();
    }
}