using st_movies.Views;

namespace st_movies;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(MovieDetailsPage), typeof(MovieDetailsPage));
	}
}
