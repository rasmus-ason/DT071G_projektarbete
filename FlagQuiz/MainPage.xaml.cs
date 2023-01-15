using FlagQuiz.DataServices;
using FlagQuiz.Models;
using FlagQuiz.Pages;
using Microsoft.Maui.Controls;
using System.Diagnostics;


namespace FlagQuiz;

public partial class MainPage : ContentPage
{

    public MainPage()
	{

		InitializeComponent();

	}

    //Route user to quiz
    async void OnClickedToQuizPage(object sender, EventArgs e)
    {
        Debug.WriteLine("----> Start Quiz Button Clicked");

        await Shell.Current.GoToAsync(nameof(ManageFlagQuizPage));

    }

   

    
}


