using System;
using Libraries.AuthService.Models;

namespace Libraries.AuthService.Data
{
	public interface IUserRepository
	{
		User Create(User user);
		User GetByEmail(string email);
	}
}

