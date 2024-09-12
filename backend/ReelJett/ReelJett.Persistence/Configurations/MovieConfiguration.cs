using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ReelJett.Domain.Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReelJett.Persistence.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {

            // Relations

            builder.HasMany(m=>m.UserLikes).WithOne(uv=>uv.Movie).HasForeignKey(f=>f.MovieId).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(m=>m.UserViews).WithOne(uv=>uv.Movie).HasForeignKey(f=>f.MovieId).OnDelete(DeleteBehavior.Cascade);
        }
    }

}
