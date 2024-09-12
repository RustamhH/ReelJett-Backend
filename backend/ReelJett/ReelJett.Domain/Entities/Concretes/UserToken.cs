namespace ReelJett.Domain.Entities.Concretes;

public class UserToken : BaseEntity {

    // Columns

    public string Name { get; set; }
    public string Token { get; set; }
    public DateTime ExpireTime { get; set; }

    // Foreign Key

    public string UserId { get; set; }

    // Navigation Properties

    public virtual User? User { get; set; }
}
