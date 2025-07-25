﻿namespace ReelJett.Domain.DTO;

public class Result {

    // Fields

    public string iso_639_1 { get; set; }
    public string iso_3166_1 { get; set; }
    public string name { get; set; }
    public string key { get; set; }
    public string published_at { get; set; }  
    public string site { get; set; }
    public int size { get; set; }
    public string type { get; set; }
    public bool official { get; set; }
    public string id { get; set; }
}

public class VideoDTO {

    // Fields

    public int id { get; set; }
    public IList<Result> results { get; set; }
}