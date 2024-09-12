using System.ComponentModel.DataAnnotations.Schema;

namespace ReelJett.Domain.Entities.Concretes;

public class UserLikes : BaseEntity {

    // Columns

    public bool IsLike { get; set; }

    // Foreign Keys

    public string? UserId { get; set; }
    public string? MovieId { get; set; }

    //Navigation Properties

    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; }

    [ForeignKey(nameof(MovieId))]
    public virtual Movie Movie { get; set; }
}
