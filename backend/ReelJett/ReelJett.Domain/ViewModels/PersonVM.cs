using ReelJett.Domain.DTO;

namespace ReelJett.Domain.ViewModels;

public class PersonVM
{

    // Fields

    public int TotalPages { get; set; }
    public IList<PersonDTO>? People { get; set; }
}
