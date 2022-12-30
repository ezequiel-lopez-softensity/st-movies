using st_movies.ViewModels;

namespace st_movies.Views;

public partial class MovieDetailsPage : ContentPage
{
	public MovieDetailsPage(MovieDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        MovieDetailsViewModel viewModel = (MovieDetailsViewModel)BindingContext;
        await viewModel.GetMovieDetails(viewModel.MovieId);
    }
}