namespace st_movies.Models;

public class Movie
{
    public bool adult { get; set; }
    public string backdrop_path
    {
        get => $"https://image.tmdb.org/t/p/original{_backdrop_path}";
        set { _backdrop_path = value; }
    }
    public BelongsToCollection belongs_to_collection { get; set; }
    public int budget { get; set; }
    public List<Genre> genres { get; set; }
    public string homepage { get; set; }
    public int id { get; set; }
    public string imdb_id { get; set; }
    public string original_language { get; set; }
    public string original_title { get; set; }
    public string overview { get; set; }
    public double popularity { get; set; }
    public string poster_path
    {
        get => $"https://image.tmdb.org/t/p/original{_poster_path}";
        set { _poster_path = value; }
    }
    public List<ProductionCompany> production_companies { get; set; }
    public List<ProductionCountry> production_countries { get; set; }
    public string release_date { get; set; }
    public int revenue { get; set; }
    public int runtime { get; set; }
    public List<SpokenLanguage> spoken_languages { get; set; }
    public string status { get; set; }
    public string tagline { get; set; }
    public string title { get; set; }
    public bool video { get; set; }
    public double vote_average { get; set; }
    public int vote_count { get; set; }
    public List<int> genre_ids { get; set; }

    public string thumbnail_poster_path => $"https://image.tmdb.org/t/p/w92{_poster_path}";
    public string thumbnail_backdrop_path => $"https://image.tmdb.org/t/p/w300{_backdrop_path}";
    public string short_overview => overview.Length > 100 ? overview.Substring(0,100) + "..." : overview;

    private string _backdrop_path;
    private string _poster_path;
}
