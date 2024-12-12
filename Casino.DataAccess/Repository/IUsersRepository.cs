using Casino.DataAccess.Dtos;
using Casino.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.DataAccess.Repository
{
	public interface IUsersRepository
	{
		Task<User> AddUser(User user);
		Task<ICollection<User>> GetUsers();
		Task<User?> GetUserById(Guid id);
		Task<User> UpdateUser(User user);
		Task DeleteUser(Guid id);
		Task<bool> UserExists(Guid id);
	}
}
