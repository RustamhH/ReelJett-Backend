namespace ReelJett.Domain.Entities.Concretes;

public class CommentLikes : BaseEntity {

    // Foreign Keys
    
    public string CommentId { get; set; }
    public string UserId { get; set; }

    // Navigation Property

    public virtual Comment Comment { get; set; }
}