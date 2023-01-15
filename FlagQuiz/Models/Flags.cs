using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlagQuiz.Models
{
     
    public class Flags 
    {
        public string name { get; set; }
        public string code { get; set; }

    }
    

    //Blueprint for a datatype (datatype = name of instance)
    public class CorrectAnswer
    {
     
        //member
        public string answer { get; set; }

    }

    public class CorrectFlag
    {

        public string correctflag { get; set; }

    }

    public class CorrectCountryCodeAnswer
    {

        public string correctcountrycode { get; set; }

    }

    public class UserClickedAnswer
    { 

        public string useranswer { get; set; }

    }



    public class QuizCounter
    {
     
       public int counter { get; set; }

    }

    public class QuestionCounter
    {
        public int questioncounter { get; set; }

    }

    public class QuizResult
    {
        public int result { get; set; }

    }


}

