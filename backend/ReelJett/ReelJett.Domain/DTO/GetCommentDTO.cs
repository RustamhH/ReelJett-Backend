namespace ReelJett.Domain.DTO;

public class GetCommentDTO {

    // Fields

    public string Id { get; set; }
    public int LikeCount { get; set; }
    public string Content { get; set; }
    public string Username { get; set; }
    public string SendingDate { get; set; }
    public string ProfilePhoto { get; set; }
}