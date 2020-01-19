using System;
using System.Collections.Generic;
using System.Text;
using Docs.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Docs.MetadataDbContext
{
	public class UserDbContext : DbContext
	{
		public UserDbContext()
		{
		}

		public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer("Server=.;Database=ManOfCulture;Trusted_Connection=true;");
			}

		}

		public DbSet<User> Users { get; set; }
		public DbSet<Rank> Ranks { get; set; }
		public DbSet<Role> Roles { get; set; }
		public DbSet<Enrollment> Enrolments { get; set; }
		public DbSet<Author> Authors { get; set; }
		public DbSet<Question> Questions { get; set; }
		public DbSet<Answer> Answers { get; set; }
		public DbSet<Course> Courses { get; set; }
	}
}
