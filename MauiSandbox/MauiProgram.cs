using CommunityToolkit.Maui;
using MauiSandbox.Services;
using MauiSandbox.View;
using MauiSandbox.ViewModel;
using Syncfusion.Maui.Core.Hosting;
//using MauiSandbox.View;

namespace MauiSandbox;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureSyncfusionCore()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Metropolis-Black.otf", "MetropolisBlack");
                fonts.AddFont("Metropolis-Light.otf", "MetropolisLight");
                fonts.AddFont("Metropolis-Medium.otf", "MetropolisMedium");
                fonts.AddFont("Metropolis-Regular.otf", "MetropolisRegular");
                fonts.AddFont("MaterialIcons-Regular.ttf", "MaterialIcons");
            });

        builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);

        builder.Services.AddSingleton<BookService>();

        builder.Services.AddSingleton<BooksViewModel>();
        builder.Services.AddSingleton<AddCharacterViewModel>();
        builder.Services.AddTransient<BookDetailsViewModel>();
        builder.Services.AddSingleton<ActivityViewModel>();

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<AddCharacterForm>();
        builder.Services.AddTransient<DetailsPage>();
        builder.Services.AddTransient<ActivityPage>();

        return builder.Build();
	}
}
