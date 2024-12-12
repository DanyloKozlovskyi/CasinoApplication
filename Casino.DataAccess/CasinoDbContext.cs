using Casino.DataAccess.Models;
using Casino.DataAccess.Models.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Casino.DataAccess
{
	namespace MenuVoting.DataAccess
	{
		public class CasinoDbContext : DbContext
		{
			public DbSet<User> Users { get; set; }

			public CasinoDbContext(DbContextOptions options) : base(options)
			{

			}

			protected override void OnModelCreating(ModelBuilder modelBuilder)
			{
				base.OnModelCreating(modelBuilder);

				modelBuilder.ApplyConfiguration(new UserConfiguration());
			}
		}
	}
}
