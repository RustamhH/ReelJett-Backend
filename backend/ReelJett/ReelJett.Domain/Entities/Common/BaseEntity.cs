using ReelJett.Domain.Entities.Abstracts;

public abstract class BaseEntity : IBaseEntity {

    // Columns

    public bool IsDeleted { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public DateTime LastModifiedAt { get; set; } = DateTime.Now;
}