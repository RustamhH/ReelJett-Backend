namespace ReelJett.Domain.Entities.Concretes;

public class Room : BaseEntity {

    // Columns

    public string Name { get; set; }
    public string MovieUrl { get; set; }
    public string PosterUrl { get; set; }

    // Foreign Key

    public string UserId { get; set; }

    // Navigation Properties

    public virtual User User { get; set; }
    public virtual ICollection<User> Users { get; set; }
}
