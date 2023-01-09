using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using st_movies.Models;
using st_movies.Services;

namespace st_movies.ViewModels;

[QueryProperty("MovieId", "movieId")]
public partial class MovieDetailsViewModel : BaseViewModel
{
    [ObservableProperty]
    private Movie movie;
    [ObservableProperty]
    private int movieId;
    private readonly MovieService movieService;

    public MovieDetailsViewModel(MovieService movieService)
	{
        this.movieService = movieService;
        Title = " ";
    }

    [RelayCommand]
    public async Task GetMovieDetails(int movieId)
    {
        Movie = await movieService.GetMovieDetails(movieId);
        Title += $"{Movie.title} ({Movie.release_year})";
    }
}
