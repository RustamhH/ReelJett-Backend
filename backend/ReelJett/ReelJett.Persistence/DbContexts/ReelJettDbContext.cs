using Microsoft.EntityFrameworkCore;
using ReelJett.Domain.Entities.Concretes;
using ReelJett.Persistence.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ReelJett.Persistence.DbContexts;

public class ReelJettDbContext : IdentityDbContext<User> {

    // Constructor

    public ReelJettDbContext(DbContextOptions<ReelJettDbContext> options) : base(options) { }

    // Methods

    protected override void OnModelCreating(ModelBuilder builder) {
        builder.ApplyConfiguration(new UserConfiguration());
        builder.ApplyConfiguration(new MovieConfiguration());

        base.OnModelCreating(builder);
    }

    // Tables

    public virtual DbSet<Room> Rooms { get; set; }
    public virtual DbSet<Movie> Movies { get; set; }
    public virtual DbSet<Rating> Ratings { get; set; }
    public virtual DbSet<Comment> Comments { get; set; }
    public virtual DbSet<UserLikes> UserLikes { get; set; }
    public virtual DbSet<UserViews> UserViews { get; set; }
    public virtual DbSet<UserToken> UserTokens { get; set; }
    public virtual DbSet<WatchList> WatchLists { get; set; }
    public virtual DbSet<HistoryList> HistoryLists { get; set; }
    public virtual DbSet<CommentLikes> CommentsLikes { get; set; }
    public virtual DbSet<PersonalMovie> PersonalMovies { get; set; }
    public virtual DbSet<ProffesionalMovie> ProffesionalMovies { get; set; }
}
