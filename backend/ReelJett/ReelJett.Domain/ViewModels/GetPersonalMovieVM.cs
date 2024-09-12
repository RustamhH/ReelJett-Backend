using ReelJett.Domain.DTO;

namespace ReelJett.Domain.ViewModels;

public class GetPersonalMovieVM {

    // Fields

    public int TotalPages { get; set; }
    public List<GetPersonalMovieDTO>? Movies { get; set; }
}