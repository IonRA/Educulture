using System;
using System.Collections.Generic;
using System.Text;
using Docs.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Docs.MetadataDbContext
{
	public class AssessmentDbContext : DbContext
	{
		public AssessmentDbContext()
		{
		}

		public AssessmentDbContext(DbContextOptions<AssessmentDbContext> options) : base(options)
		{
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer("Server=.;Database=ManOfCulture;Trusted_Connection=true;");
			}
			
		}
		

		public DbSet<Question> Questions { get; set; }
		public  DbSet<Answer> Answers { get; set; }
		public DbSet<Course> Courses { get; set; }

	}
}
