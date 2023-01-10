using FlagQuiz.DataServices;
using FlagQuiz.Models;
using FlagQuiz.Pages;
using Microsoft.Maui.Controls;
using System.Diagnostics;


namespace FlagQuiz;

public partial class MainPage : ContentPage
{

    private readonly IRestDataService _dataService;

	//Skapa en instans av classen IRestDataService, ger den namnet dataService
    public MainPage(IRestDataService dataService)
	{
		InitializeComponent();

		//Apply it to a readonly instance
		_dataService = dataService;

	}

    //Route user to quiz
    async void OnClickedToQuizPage(object sender, EventArgs e)
    {
        Debug.WriteLine("----> Start Quiz Button Clicked");

        //Add navigation parameter, definerar data som kan skickas till the target page
        var navigationParameter = new Dictionary<string, object>()
        {
            //Specify the string, send a new Flags object
            { nameof(Flags), new Flags() }
        };

        //Pass it to the selected page, pass with the navigationParameter
        await Shell.Current.GoToAsync(nameof(ManageFlagQuizPage), navigationParameter);

    }

   

    
}


