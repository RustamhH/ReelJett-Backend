﻿namespace ReelJett.Domain.DTO;

public class MovieDTO {
    public bool adult { get; set; }
    public string backdrop_path { get; set; }
    public IList<int> genre_ids { get; set; }
    public int id { get; set; }
    public string original_language { get; set; }
    public string original_title { get; set; }
    public string overview { get; set; }
    public double popularity { get; set; }
    public string poster_path { get; set; }
    public string release_date { get; set; }
    public string title { get; set; }
    public bool video { get; set; }
    public double vote_average { get; set; }
    public int vote_count { get; set; }
}

public class MovieData {
    public int page { get; set; }
    public IList<MovieDTO> results { get; set; }
}