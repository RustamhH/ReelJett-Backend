namespace ReelJett.Domain.Entities.Concretes;

public class Movie : BaseEntity {

    // Columns

    public string Title { get; set; }
    public int Runtime { get; set; } = 0;
    public double Rating { get; set; } = 0;
    public int LikeCount { get; set; } = 0;
    public int ViewCount { get; set; } = 0;
    public string Poster { get; set; } = "";
    public int DislikeCount { get; set; } = 0;
    public string Year { get; set; } = "2024";
    public string Categories { get; set; } = "";

    // Navigation Property

    public virtual PersonalMovie? PersonalMovie { get; set; }
    public virtual ICollection<Comment>? Comments { get; set; }
    public virtual ProffesionalMovie? ProffesionalMovie { get; set; }
    public virtual ICollection<UserViews>? UserViews { get; set; }
    public virtual ICollection<UserLikes>? UserLikes { get; set; }
}
