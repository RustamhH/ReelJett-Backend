using ReelJett.Domain.DTO;

namespace ReelJett.Domain.ViewModels;

public class MovieVM {

    // Fields

    public int TotalPages { get; set; }
    public IList<MovieDTO>? Movies { get; set; }
}
