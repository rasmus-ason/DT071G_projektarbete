using FlagQuiz.DataServices;
using FlagQuiz.Models;
using System.Diagnostics;
using System.Runtime.CompilerServices;


namespace FlagQuiz.Pages;

[QueryProperty(nameof(Flags), "flags")]
public partial class ManageFlagQuizPage : ContentPage
{
    private readonly IRestDataService _dataService;

    //Init four different countries and their codes - the answer alternatives
    string[] countriesAlternativeArray = new string[4];
    string[] countryCodeAlternativeArray = new string[4];

    //Init array with countries and their codes
    string[] countriesArray;
    string[] countryCodeArray;
    
    //Store length of arrays
    int countList;

    //Create intances
    CorrectAnswer answer = new CorrectAnswer(); //Name of country which is the correct answer
    CorrectCountryCodeAnswer correctcountrycode = new CorrectCountryCodeAnswer(); //Code of country which is the correct answer
    CorrectFlag correctflagURI = new CorrectFlag(); 
    UserClickedAnswer useranswer = new UserClickedAnswer(); //Store user answer
    QuizCounter counter = new QuizCounter(); //Add 1 on correct answer
    QuestionCounter questioncounter = new QuestionCounter(); //Counter on amount of questions 
    QuizResult result = new QuizResult(); //Store result



    public ManageFlagQuizPage(IRestDataService dataService)
	{
		InitializeComponent();

        //Apply it to a readonly instance
        _dataService = dataService;
        BindingContext= this;

        StartQuiz();
    }


    async void StartQuiz()
    {
        //Create new lists
        List<Flags> countryList = new List<Flags>();
        List<Flags> countryCodeList = new List<Flags>();

        //Call method that get all country-details
        countryList = await _dataService.GetAllFlagsAsync();
        countryCodeList = await _dataService.GetAllFlagsAsync();

        //Count array and store as int
        countList = countryList.Count;

        //Update arrays and set how many items can be stored
        countriesArray = new string[countList];
        countryCodeArray = new string[countList];

        //Declare counter variables for loops below
        int j = 0;
        int p = 0;
     
        //Store countries name in array
        foreach (Flags f in countryList)
        {
            //Exclude countries without a flag uri
            if (
                (f.name != "Diego Garcia") && 
                (f.name != "Clipperton Island") &&
                (f.name != "Tristan da Cunha") &&
                (f.name != "United Nations") &&
                (f.name != "U.S. Outlying Islands") &&
                (f.name != "Ascension Island") &&
                (f.name != "Bouvet Island") &&
                (f.name != "Canary Islands") &&
                (f.name != "Ceuta & Melilla") &&
                (f.name != "St. Martin") &&
                (f.name != "Svalbard & Jan Mayen")
            )
                
            {
                countriesArray[j++] = f.name;
            }       
        }

        foreach (Flags f in countryCodeList)
        {
            if (
                (f.code != "DG") &&
                (f.code != "CP") &&
                (f.code != "TA") &&
                (f.code != "UN") &&
                (f.code != "UM") &&
                (f.code != "AC") &&
                (f.code != "BV") &&
                (f.code != "IC") &&
                (f.code != "EA") &&
                (f.code != "MF") &&
                (f.code != "SJ")
            )
                countryCodeArray[p++] = f.code;
        }

        //Set question counter to 1
        questioncounter.questioncounter = 1;

        //Generate first question
        generateQuizQuestion();

    }

    //Run after first question
    async void addQuestionCount()
    {
        //Add 1 to question counter
        questioncounter.questioncounter++;

        //Generate question
        generateQuizQuestion();

    }

    async void generateQuizQuestion()
    {
        if (questioncounter.questioncounter < 11)
        {

            // Create a Random object  
            Random randomCountries = new Random();
            Random correctAnswer = new Random();

            //Print info to user
            QuestionNumberInsert.Text = "Question " + questioncounter.questioncounter.ToString() + "/10";

            //Loopa 4 random countries from array
            for (int k = 0; k < 4; k++)
            {
                // Generate a random index less than the size of the array.  
                int indexCountries = randomCountries.Next(0, countList-12);

                //Push country into array of 4 alternatives
                countriesAlternativeArray[k] = countriesArray[indexCountries];
                countryCodeAlternativeArray[k] = countryCodeArray[indexCountries];

                //Display country on unique button
                if (k == 0) { C0.Text = countriesArray[indexCountries]; };
                if (k == 1) { C1.Text = countriesArray[indexCountries]; };
                if (k == 2) { C2.Text = countriesArray[indexCountries]; };
                if (k == 3) { C3.Text = countriesArray[indexCountries]; };


            }

            // Generate a random index between 0-3  
            int c = correctAnswer.Next(0, 4);

            //Store name of the correct country
            string theAnswer = countriesAlternativeArray[c];

            //Store answer
            answer.answer = theAnswer;

            //Get index of correct coutry from full country array
            //int v = Array.FindIndex(countriesArray, x => x.Contains(answer.answer));

            //Store the correct country code
            correctcountrycode.correctcountrycode = countryCodeAlternativeArray[c];

            displayImage();

        }
        
   
    }

    async void displayImage()
    {
        //Create image uri
        string flagURI = "https://countryflagsapi.com/png/";
        string URI_endpoint = correctcountrycode.correctcountrycode;

        correctflagURI.correctflag = flagURI + URI_endpoint;

        //Print out correct flag
        FlagImage.Source = correctflagURI.correctflag;

       
    }

    //Control user answer
    async void ControlUserAnswer()
    {
        //If correct then add 1 to counter and call method that add 1 to question counter
        if(useranswer.useranswer == answer.answer)
        {      
            counter.counter++;
            addQuestionCount();
        }
        //If wrong only  call method that add 1 to question counter
        else
        {
            addQuestionCount();
        }

        //If question counter exceed 10, then store user combined result and store in user result
        if(questioncounter.questioncounter == 11) 
        {
            int result = counter.counter;

            await Navigation.PushModalAsync(new ManageResultPage(result.ToString()));


        }      

    }

    //Answer buttons function
    async void ClickedCountry0(object sender, EventArgs e)
    {
        string userAnswer = countriesAlternativeArray[0];
        useranswer.useranswer = userAnswer;
        ControlUserAnswer();
    }
    async void ClickedCountry1(object sender, EventArgs e)
    {
        string userAnswer = countriesAlternativeArray[1];
        useranswer.useranswer = userAnswer;
        ControlUserAnswer();
    }
    async void ClickedCountry2(object sender, EventArgs e)
    {
        string userAnswer = countriesAlternativeArray[2];
        useranswer.useranswer = userAnswer;
        ControlUserAnswer();
    }
    async void ClickedCountry3(object sender, EventArgs e)
    {
        string userAnswer = countriesAlternativeArray[3];
        useranswer.useranswer = userAnswer;
        ControlUserAnswer();
    }

    async void ClickedQuit(object sender, EventArgs e)
    {
        int result =  999 ;

        await Navigation.PushModalAsync(new ManageResultPage(result.ToString()));

    }









}

   


    

 

