using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PschoolCrud.Data.Map;
using PschoolCrud.Entities;

namespace PschoolCrud.Data
{
    public class PschoolContext : DbContext
    {
        public PschoolContext(DbContextOptions<PschoolContext> options) 
            : base(options)
        {  
        }

        public DbSet<Parent> Parents { get; set; }
        public DbSet<Student> Students { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new ParentMap());
            modelBuilder.ApplyConfiguration(new StudentMap());
			base.OnModelCreating(modelBuilder);
		}
	}
}
