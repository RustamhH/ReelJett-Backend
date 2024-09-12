using System.ComponentModel.DataAnnotations.Schema;

namespace ReelJett.Domain.Entities.Concretes;

public class UserViews : BaseEntity {

    // Fields

    public string? UserId { get; set; }
    public string? MovieId { get; set; }

    //Navigation Properties

    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; }

    [ForeignKey(nameof(MovieId))]
    public virtual Movie Movie { get; set; }
}
