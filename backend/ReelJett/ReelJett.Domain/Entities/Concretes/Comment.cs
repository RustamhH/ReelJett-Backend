namespace ReelJett.Domain.Entities.Concretes;

public class Comment : BaseEntity {

    // Columns

    public string Content { get; set; }
    public int LikeCount { get; set; } = 0;

    // Foreign Key

    public string UserId { get; set; }
    public string MovieId { get; set; }

    // Navigation Properties

    public virtual User User { get; set; }
    public virtual Movie Movie { get; set; }

    public virtual ICollection<CommentLikes> CommentLikes { get; set; }
}