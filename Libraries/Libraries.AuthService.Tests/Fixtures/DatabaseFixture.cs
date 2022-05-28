using System;
using Libraries.AuthService.Data;
using Libraries.AuthService.Models;
using Microsoft.EntityFrameworkCore;

namespace Libraries.AuthService.Tests.Fixtures
{
	public class DatabaseFixture
	{
        readonly string ConnectionString = @"server=localhost;user=sa;password=Fortuna2022!;database=LibrariesAuth.Test";

        private static readonly object _lock = new();
        private static bool _databaseInitialized;

        public DatabaseFixture()
		{
            lock (_lock)
            {
                if (!_databaseInitialized)
                {
                    using (var context = CreateContext())
                    {
                        context.Database.EnsureDeleted();
                        context.Database.EnsureCreated();

                        context.AddRange(
                            new User { Email = "test@test.com", Id = 1, Name = "test", Password = BCrypt.Net.BCrypt.HashPassword("test") }
                            );
                        context.SaveChanges();
                    }

                    _databaseInitialized = true;
                }
            }
        }

        public UserContext CreateContext()
        => new UserContext(
            new DbContextOptionsBuilder<UserContext>()
                .UseSqlServer(ConnectionString)
                .Options);
    }
}

