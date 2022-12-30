using st_movies.Models;
using System.Text.Json;

namespace st_movies.Services;

public class MovieService
{
    private const string apiKey = "ddc113f857599594c6f74ac475da1278";
    HttpClient httpClient;

	public MovieService()
	{
        var httpClientHandler = new HttpClientHandler();

        httpClientHandler.ServerCertificateCustomValidationCallback =
        (message, cert, chain, errors) => { return true; };

        httpClient = new HttpClient(httpClientHandler);
    }

	public async Task<PagedResponse<Movie>> SearchMovies(string searchText, int page)
	{
		var movieList = new PagedResponse<Movie>();
        var url = $"https://api.themoviedb.org/3/search/movie?query={searchText}&api_key={apiKey}&page={page}";
        
        var response = await httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            using (var responseStream = await response.Content.ReadAsStreamAsync())
            {
                var data = await JsonSerializer.DeserializeAsync<PagedResponse<Movie>>(responseStream);
                movieList = data;
            }
        }

        return movieList;
	}

    public async Task<Movie> GetMovieDetails(int movieId)
    {
        var movie = new Movie();
        var url = $"https://api.themoviedb.org/3/movie/{movieId}?api_key={apiKey}";

        var response = await httpClient.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            using (var responseStream = await response.Content.ReadAsStreamAsync())
            {
                var data = await JsonSerializer.DeserializeAsync<Movie>(responseStream);
                movie = data;
            }
        }

        return movie;
    }
}
