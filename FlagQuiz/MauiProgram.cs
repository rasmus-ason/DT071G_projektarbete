using FlagQuiz.DataServices;
using FlagQuiz.Pages;

namespace FlagQuiz;

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

		//Om någån gör en req på IRestDataService, ger vi dom RestDataService
		builder.Services.AddSingleton<IRestDataService, RestDataService>();

		//Registera MainPage
        builder.Services.AddSingleton<MainPage>();

		//Registera page
		builder.Services.AddTransient<ManageFlagQuizPage>();

        //Registera page
        builder.Services.AddTransient<ManageResultPage>();

        return builder.Build();
	}
}
