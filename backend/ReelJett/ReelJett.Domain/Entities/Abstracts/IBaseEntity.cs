namespace ReelJett.Domain.Entities.Abstracts;

public interface IBaseEntity {

    // Columns

    public string Id { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime LastModifiedAt { get; set; }
}
