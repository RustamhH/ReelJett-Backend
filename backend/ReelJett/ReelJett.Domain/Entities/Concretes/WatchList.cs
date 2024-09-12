namespace ReelJett.Domain.Entities.Concretes;

public class WatchList : BaseEntity {

    // Foreign Key

    public string UserId { get; set; }

    // Navigation Properties

    public virtual User User { get; set; }
    public virtual ICollection<MovieItem> Movies { get; set; }
}