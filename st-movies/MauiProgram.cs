using Microsoft.Extensions.Logging;
using st_movies.Services;
using st_movies.ViewModels;
using st_movies.Views;

namespace st_movies;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<MovieService>();

        builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddTransient<MovieDetailsViewModel>();

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddTransient<MovieDetailsPage>();

        return builder.Build();
	}
}
