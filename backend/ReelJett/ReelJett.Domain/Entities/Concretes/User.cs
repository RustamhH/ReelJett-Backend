using Microsoft.AspNetCore.Identity;
using ReelJett.Domain.Entities.Abstracts;

namespace ReelJett.Domain.Entities.Concretes;

public class User : IdentityUser, IBaseEntity {

    // Columns

    public string Lastname { get; set; }
    public string Firstname { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime LastModifiedAt { get; set; } = DateTime.Now;
    public string ?ProfilePhoto { get; set; }

    // Foreign Key

    public string? RoomId { get; set; }

    // Navigation Properties

    public virtual Room? Room { get; set; }
    public virtual WatchList? WatchList { get; set; }
    public virtual HistoryList? HistoryList { get; set; }
    public virtual ICollection<Room>? Rooms { get; set; }
    public virtual ICollection<Comment>? Comments { get; set; }
    public virtual ICollection<UserLikes>? UserLikes { get; set; }
    public virtual ICollection<UserViews>? UserViews { get; set; }
    public virtual ICollection<UserToken>? UserTokens { get; set; }
    public virtual ICollection<PersonalMovie>? ForYouMovies { get; set; }
}
