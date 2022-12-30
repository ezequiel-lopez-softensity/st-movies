using st_movies.ViewModels;

namespace st_movies.Views;

public partial class MovieDetailsPage : ContentPage
{
    private readonly MovieDetailsViewModel viewModel;

    public MovieDetailsPage(MovieDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
        this.viewModel = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (!viewModel.MovieId.Equals(viewModel.Movie?.id))
            viewModel.GetMovieDetailsCommand.Execute(viewModel.MovieId);
    }
}