using Microsoft.EntityFrameworkCore;
using ReelJett.Domain.Entities.Concretes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ReelJett.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User> {
    public void Configure(EntityTypeBuilder<User> builder) {
        
        // Relations

        builder.HasOne(p => p.Room).WithMany(p => p.Users).HasForeignKey(p => p.RoomId).OnDelete(DeleteBehavior.NoAction);
        builder.HasMany(p => p.Rooms).WithOne(p => p.User).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.NoAction);
    }
}
