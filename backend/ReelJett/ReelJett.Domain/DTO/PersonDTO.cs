namespace ReelJett.Domain.DTO;


public class PersonDTO
{
    public bool adult { get; set; }
    public int gender { get; set; }
    public int id { get; set; }
    public string known_for_department { get; set; }
    public string name { get; set; }
    public string original_name { get; set; }
    public double popularity { get; set; }
    public string profile_path { get; set; }
    public IList<MovieDTO> known_for { get; set; }
}

public class PersonData
{
    public int page { get; set; }
    public IList<PersonDTO> results { get; set; }
}