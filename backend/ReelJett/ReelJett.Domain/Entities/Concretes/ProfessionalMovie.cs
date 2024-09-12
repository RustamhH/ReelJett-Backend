namespace ReelJett.Domain.Entities.Concretes;

public class ProffesionalMovie : BaseEntity {

    // Fields

    public string? TRDublaj { get; set; }
    public string? TRAltyazi { get; set; }
    public string? MultipleUrl { get; set; }

    // Foreign Key

    public string MovieId { get; set; }

    // Navigation Property

    public virtual Movie Movie { get; set; }
}