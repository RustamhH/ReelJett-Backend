namespace ReelJett.Domain.Entities.Concretes;

public class PersonalMovie : BaseEntity {

    // Columns

    public bool IsPublished { get; set; }
    public string MovieLink { get; set; }
    public string Description { get; set; }
    public DateTime UploadDate { get; set; }

    // Foreign Key

    public string UserId { get; set; }
    public string MovieId { get; set; }

    // Navigation Properties

    public virtual User User { get; set; }
    public virtual Movie Movie { get; set; }
}