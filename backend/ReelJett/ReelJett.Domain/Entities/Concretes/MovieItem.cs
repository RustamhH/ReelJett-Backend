namespace ReelJett.Domain.Entities.Concretes;

public class MovieItem : BaseEntity {

    // Foreign Key

    public string MovieId { get; set; }
    public string? WatchListId { get; set;}
    public string? HistoryListId { get; set; }

    // Navigation Properties

    public virtual Movie Movie { get; set; }
    public virtual WatchList? WatchList {  get; set; }
    public virtual HistoryList? HistoryList { get; set; }
}