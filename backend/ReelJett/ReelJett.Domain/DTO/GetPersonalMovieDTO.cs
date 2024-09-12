namespace ReelJett.Domain.DTO;

public class GetPersonalMovieDTO {

    // -- Fields --

    // Self
    public string Id { get; set; }
    public string PublishDate { get; set; }
    public string Poster { get; set; }
    public string Description { get; set; }
    public string Link { get; set; }

    // User
    public string PublisherName { get; set; }
    public string PublisherPhoto { get; set; }

    // Movie
    public string Title { get; set; }
    public int ViewCount { get; set; }
    public int LikeCount { get; set; }
    public int DislikeCount { get; set; }
}