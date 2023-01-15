using FlagQuiz.DataServices;
using FlagQuiz.Models;


namespace FlagQuiz.Pages;


public partial class ManageResultPage : ContentPage
{
    private readonly string res;

    public ManageResultPage(string res)
    {
        InitializeComponent();

        this.res = res;

        DisplayResult();

    }


    //Display user result or if user quit display message
    async void DisplayResult()
    {
        int userResultAnswer = Int32.Parse(res);

        try
        {
            if (userResultAnswer >= 7)
            {
                DisplayResultToUser.Text = "Master Level! Great job, " + res + " correct answers!";
            }
            if ((userResultAnswer >= 4) && (userResultAnswer < 7))
            {
                DisplayResultToUser.Text = "You know some flags, but could need some more practice! " + res + " correct answers!";
            }
            if (userResultAnswer < 4)
            {
                DisplayResultToUser.Text = "Flags aren't your strong side or you just got some tricky ones! But still " + res + " correct answers!";
            }
            //If user quitted
            if (userResultAnswer == 999)
            {
                DisplayResultToUser.Text = "No Worries, you can finish the test another time!";
            }

        }
        //Print result without parse to integer
        catch
        {
            DisplayResultToUser.Text = res + " correct answers!";
        }



    }

    async void OnClickedToQuizPage(object sender, EventArgs e)
    {

           await Shell.Current.GoToAsync(nameof(ManageFlagQuizPage));

    }

    async void ToStartPage(object sender, EventArgs e)
    {

        await Shell.Current.Navigation.PopToRootAsync();

    }

}