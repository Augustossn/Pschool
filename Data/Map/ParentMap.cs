using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PschoolCrud.Entities;

namespace PschoolCrud.Data.Map
{
	public class ParentMap : IEntityTypeConfiguration<Parent>
	{
		public void Configure(EntityTypeBuilder<Parent> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Name).IsRequired().HasMaxLength(255);

			builder.HasMany(x => x.Students)
				   .WithOne(s => s.Parent)
				   .HasForeignKey(s => s.ParentId);
		}
	}
}
