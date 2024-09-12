namespace ReelJett.Domain.Entities.Concretes;

public class Rating : BaseEntity {

    // Columns

    public string Source { get; set; }
    public string Value { get; set; }

    // Foreign Key

    public string MovieId { get; set; }

    // Navigation Properties

    public virtual Movie Movie { get; set; }
}