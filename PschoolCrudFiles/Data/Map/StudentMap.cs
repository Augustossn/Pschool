using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PschoolCrud.Entities;

namespace PschoolCrud.Data.Map
{
	public class StudentMap : IEntityTypeConfiguration<Student>
	{
		public void Configure(EntityTypeBuilder<Student> builder)
		{
            builder.HasKey(x => x.StudentId);
            builder.Property(x => x.StudentName).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ParentId);

            builder.HasOne(x => x.Parent)
                .WithMany(p => p.Students)
                .HasForeignKey(x => x.ParentId)
                .OnDelete(DeleteBehavior.SetNull);
        }
	}
}
