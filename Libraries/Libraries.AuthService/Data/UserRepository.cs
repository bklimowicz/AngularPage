using System;
using Libraries.AuthService.Models;

namespace Libraries.AuthService.Data
{
	public class UserRepository : IUserRepository
	{
        private readonly IUserContext _context;

		public UserRepository(IUserContext context)
		{
            _context = context;
		}

        public User Create(User user)
        {
            _context.Users.Add(user);

            user.Id = _context.SaveChanges();

            return user;
        }
    }
}

