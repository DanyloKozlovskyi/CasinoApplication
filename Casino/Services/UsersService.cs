using AutoMapper;
using Casino.DataAccess.Dtos;
using Casino.DataAccess.MenuVoting.DataAccess;
using Casino.DataAccess.Models;
using Casino.Util;
using Microsoft.EntityFrameworkCore;

namespace Casino.Services
{
	public class UsersService : IUsersService
	{
		private readonly CasinoDbContext dbContext;
		private readonly IMapper mapper;

		public UsersService(CasinoDbContext db)
		{
			dbContext = db;

			var map = new MapperConfiguration
			(
				mc => mc.AddProfile(new MappingProfile())
			);
			mapper = map.CreateMapper();
		}
		public async Task<User> AddUser(UserCreate? userCreate)
		{
			if (userCreate == null)
				throw new ArgumentNullException(nameof(UserCreate));

			User user = mapper.Map<User>(userCreate);
			await dbContext.AddAsync(user);
			await dbContext.SaveChangesAsync();
			return user;
		}

		public async Task<bool> DeleteUser(Guid? id)
		{
			if (id == null)
				throw new ArgumentNullException(nameof(id));

			User? user = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
			if (user == null)
				return false;

			dbContext.Users.Remove(user);
			await dbContext.SaveChangesAsync();

			return true;
		}

		public async Task<User?> GetUserById(Guid? id)
		{
			if (id == null)
				throw new ArgumentNullException(nameof(id));

			return await dbContext.Users.FirstOrDefaultAsync(c => c.Id == id);
		}

		public async Task<ICollection<User>> GetUsers()
		{
			return await dbContext.Users.ToListAsync();
		}

		public async Task<User> UpdateUser(User user)
		{
			User? matchingUser = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == user.Id);

			if (matchingUser == null)
				throw new ArgumentNullException(nameof(user));

			matchingUser = mapper.Map<User>(user);

			await dbContext.SaveChangesAsync();

			return user;
		}

		public async Task<bool> UserExists(Guid id)
		{
			return await dbContext.Users.AnyAsync(x => x.Id == id);
		}
	}
}
