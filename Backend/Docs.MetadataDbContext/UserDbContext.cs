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
		public DbSet<Enrollment> Enrollments { get; set; }
		public DbSet<Question> Questions { get; set; }
		public DbSet<Answer> Answers { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<CourseStage> CourseStages { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//modelBuilder.Entity<User>().HasData(
			//	new User { },
			//	new User { },
			//	new User { },
			//	new User { });

			//modelBuilder.Entity<Answer>().HasData(
			//	new Answer { },
			//	new Answer { },
			//	new Answer { },
			//	new Answer { });

			modelBuilder.Entity<Role>().HasData(
				new Role
				{
					Id = 1,
					Name = "Admin"
				});

			//modelBuilder.Entity<Rank>().HasData(
			//	new Rank { },
			//	new Rank { },
			//	new Rank { },
			//	new Rank { });

			//modelBuilder.Entity<Course>().HasData(
			//	new Course { },
			//	new Course { },
			//	new Course { },
			//	new Course { });

			//modelBuilder.Entity<Question>().HasData(
			//	new Question { },
			//	new Question { },
			//	new Question { },
			//	new Question { });

			//modelBuilder.Entity<Enrollment>().HasData(
			//	new Enrollment { },
			//	new Enrollment { },
			//	new Enrollment { },
			//	new Enrollment { });
		}
	}
}
