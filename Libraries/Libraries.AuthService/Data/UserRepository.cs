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
            var isUserInDb = _context.Users.FirstOrDefault(p => p.Email == user.Email);

            if (isUserInDb is User) throw new ArgumentException("User already exists");

            _context.Users.Add(user);

            user.Id = _context.SaveChanges();

            return user;
        }

        public User GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(p => p.Email == email);
        }
    }
}

