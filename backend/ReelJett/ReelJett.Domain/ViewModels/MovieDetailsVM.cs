namespace ReelJett.Domain.ViewModels;

public class MovieDetailsVM {

    // Columns

    public string Title { get; set; }
    public int Runtime { get; set; } = 0;
    public int LikeCount { get; set; } = 0;
    public int ViewCount { get; set; } = 0;
    public int DislikeCount { get; set; } = 0;
    public string Categories { get; set; } = "";
}
