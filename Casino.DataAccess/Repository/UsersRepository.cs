using Casino.DataAccess.Dtos;
using Casino.DataAccess.MenuVoting.DataAccess;
using Casino.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casino.DataAccess.Repository
{
	public class UsersRepository : IUsersRepository
	{
		private readonly CasinoDbContext dbContext;

		public UsersRepository(CasinoDbContext db)
		{
			dbContext = db;
		}
		public async Task<User> AddUser(User user)
		{
			await dbContext.AddAsync(user);
			await dbContext.SaveChangesAsync();
			return user;
		}

		public async Task DeleteUser(Guid id)
		{
			User? user = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

			dbContext.Users.Remove(user);
			await dbContext.SaveChangesAsync();
		}

		public async Task<User?> GetUserById(Guid id)
		{
			return await dbContext.Users.FirstOrDefaultAsync(c => c.Id == id);
		}

		public async Task<ICollection<User>> GetUsers()
		{
			return await dbContext.Users.ToListAsync();
		}

		public async Task<User> UpdateUser(User user)
		{
			User? matchingUser = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == user.Id);

			matchingUser.FirstName = user.FirstName;
			matchingUser.LastName = user.LastName;
			matchingUser.Email = user.Email;
			matchingUser.PhoneNumber = user.PhoneNumber;

			await dbContext.SaveChangesAsync();

			return user;
		}

		public async Task<bool> UserExists(Guid id)
		{
			return await dbContext.Users.AnyAsync(x => x.Id == id);
		}
	}
}
