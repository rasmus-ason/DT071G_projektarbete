using FlagQuiz.Pages;

namespace FlagQuiz;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        //Initierar routing
        Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));

        Routing.RegisterRoute(nameof(ManageFlagQuizPage), typeof(ManageFlagQuizPage));

        Routing.RegisterRoute(nameof(ManageResultPage), typeof(ManageResultPage));
    }
}
