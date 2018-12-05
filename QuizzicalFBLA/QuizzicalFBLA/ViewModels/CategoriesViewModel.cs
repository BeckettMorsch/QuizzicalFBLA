using QuizzicalFBLA.Models;
using QuizzicalFBLA.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace QuizzicalFBLA.ViewModels 
{
    public class CategoriesViewModel : INotifyPropertyChanged
    {
        private static CategoriesViewModel current = null;
        private int currentQuestion = 0;

        private ObservableCollection<QuestionItem> Questions { get; set; }
        private static int numberCorrect = 0;

        private CategoriesViewModel()
        {

            Questions = new ObservableCollection<QuestionItem>();

        }

        public void Reset()
        {
            Questions.Clear();

            //Load all the questions into the collection of Questions
            Questions.Add(new QuestionItem
            {
                Question = "What are the 3 C’s of Business?",
                Answer1 = "Capital, Capacity, Character",
                Answer2 = "Capital, Charity, Capacity",
                Answer3 = "Currency, Charity, Capacity",
                Answer4 = "Charity, Capital, Currency",
                Category = "Business Skills",
                CorrectAnswer = 1
            }
                );
            Questions.Add(new QuestionItem
            {
                
                Question = "Where was 2017 NLC held?",
                Answer1 = "Baltimore, MD",
                Answer2 = "Anaheim, CA",
                Answer3 = "Los Angeles, CA",
                Answer4 = "Nashville, TN",
                Category = "FBLA History",
                CorrectAnswer = 2
            }
                );
           Questions.Add(new QuestionItem
            {
                
                Question = "What Insurance company sponsors FBLA",
                Answer1 = "State Farm",
                Answer2 = "Progressive",
                Answer3 = "Geico",
                Answer4 = "AAA",
                Category = "FBLA National Sponsors/Partners",
                CorrectAnswer = 3
            }
                ); 
            Questions.Add(new QuestionItem
            {              
                Question = "What is a formal proposal by a member suggesting that the assembly take a certain action?",
                Answer1 = "Main Motion",
                Answer2 = "Motion",
                Answer3 = "Adjourn",
                Answer4 = "Appeal",
                Category = "Basic Parliamentary Procedure",
                CorrectAnswer = 2
            }
                            );
            Questions.Add(new QuestionItem
            {                
                Question = "Who is the current FBLA president?",
                Answer1 = "Eu Ro Wang",
                Answer2 = "Galadriel Coury",
                Answer3 = "Ty Rickard",
                Answer4 = "Ethan Fahie",
                Category = "National Officers",
                CorrectAnswer = 1
            }
                );
            Questions.Add(new QuestionItem
            {
                Question = "What is the ability to make decisions on your own called?",
                Answer1 = "Integrity",
                Answer2 = "Honesty",
                Answer3 = "Initiative",
                Answer4 = "Management",
                Category = "Business Skills",
                CorrectAnswer = 3
            }
                );
            Questions.Add(new QuestionItem
            {
                Question = "What Year was FBLA Founded?",
                Answer1 = "1935",
                Answer2 = "1936",
                Answer3 = "1937",
                Answer4 = "1938",
                Category = "FBLA History",
                CorrectAnswer = 3
            }
                );
            Questions.Add(new QuestionItem
            {
                Question = "Which one of these Colleges does NOT offer a scholarship for FLBA?",
                Answer1 = "Arizona State University",
                Answer2 = "Barton College",
                Answer3 = "Catawba College",
                Answer4 = "Ohio State University",
                Category = "FBLA National Sponsors/Partners",
                CorrectAnswer = 4
            }
                );
            Questions.Add(new QuestionItem
            {
                Question = "What is it called to cancel or countermand a previous action?",
                Answer1 = "Rescind",
                Answer2 = "Appeal",
                Answer3 = "Motion",
                Answer4 = "Commit",
                Category = "Basic Parliamentary Procedure",
                CorrectAnswer = 1
            }
                );
            Questions.Add(new QuestionItem
            {
                Question = "How many national officers are there?",
                Answer1 = "8",
                Answer2 = "9",
                Answer3 = "10",
                Answer4 = "11",
                Category = "National Officers",
                CorrectAnswer = 2
            }
                );
            Questions.Add(new QuestionItem
            {
                Question = "What is the term that describes protecting investments through risk management?",
                Answer1 = "Responsibility",
                Answer2 = "Financing",
                Answer3 = "Capital",
                Answer4 = "Placement",
                Category = "Business Skills",
                CorrectAnswer = 2
            }
                );
            Questions.Add(new QuestionItem
            {
                Question = "Who is the founder of FBLA?",
                Answer1 = "Hamden Forkner",
                Answer2 = "Jason Felton",
                Answer3 = "Beverly Klein",
                Answer4 = "Anthony Gonella",
                Category = "FBLA History",
                CorrectAnswer = 1
            }
                );
            Questions.Add(new QuestionItem
            {
                Question = "What phone company sponsors FBLA?",
                Answer1 = "T-Mobile",
                Answer2 = "Cricket Wireless",
                Answer3 = "Verizon",
                Answer4 = "Metro PCS",
                Category = "FBLA National Sponsors/Partners",
                CorrectAnswer = 3
            }
                );
            Questions.Add(new QuestionItem
            {
                Question = "Who is the presiding officer that remains impartial and moderates?",
                Answer1 = "Treasure",
                Answer2 = "Vice President",
                Answer3 = "Chair",
                Answer4 = "Advisor",
                Category = "Basic Parliamentary Procedure",
                CorrectAnswer = 3
            }
                );
            Questions.Add(new QuestionItem
            {
                Question = "FBLA is comprised of how many administrative regions?",
                Answer1 = "3",
                Answer2 = "4",
                Answer3 = "5",
                Answer4 = "6",
                Category = "National Officers",
                CorrectAnswer = 3
            }
                );
            Questions.Add(new QuestionItem
            {
                Question = "To market products successfully in another country, companies must research the country's...",
                Answer1 = "Customs, Tastes, Cost",
                Answer2 = "Customs, Cost, language",
                Answer3 = "Language, Tastes, Cost",
                Answer4 = "Language, Customs, Tastes",
                Category = "Business Skills",
                CorrectAnswer = 4
            }
                );
            Questions.Add(new QuestionItem
            {
                Question = "What are FBLA’s colors?",
                Answer1 = "Blue & Yellow",
                Answer2 = "White & Gold",
                Answer3 = "Blue & Black",
                Answer4 = "Blue & Gold",
                Category = "FBLA History",
                CorrectAnswer = 4
            }
                );
            Questions.Add(new QuestionItem
            {
                Question = "What credit card company sponsors FBLA?",
                Answer1 = "Master Card",
                Answer2 = "Visa",
                Answer3 = "Chase",
                Answer4 = "PayPal",
                Category = "FBLA National Sponsors/Partners",
                CorrectAnswer = 2
            }
                );
            Questions.Add(new QuestionItem
            {
                Question = "What assists the assembly in treating or disposing of a main motion?",
                Answer1 = "Main Motion",
                Answer2 = "Privileged Motion",
                Answer3 = "Motion",
                Answer4 = "Subsidiary Motion",
                Category = "Basic Parliamentary Procedure",
                CorrectAnswer = 4
            }
                );
            Questions.Add(new QuestionItem
            {
                Question = "What is the color of the blazer the national officers wear?",
                Answer1 = "Gold",
                Answer2 = "Black",
                Answer3 = "Brown",
                Answer4 = "Navy Blue",
                Category = "National Officers",
                CorrectAnswer = 4
            }
                );
            Questions.Add(new QuestionItem
            {
                Question = "Which term refers to the actual amount of money you earn or receive during a given period of time?",
                Answer1 = "Income",
                Answer2 = "Capital",
                Answer3 = "Financing",
                Answer4 = "Direct Deposit",
                Category = "Business Skills",
                CorrectAnswer = 1
            }
                );
            Questions.Add(new QuestionItem
            {
                Question = "What two words start each stanza in the FBLA creed?",
                Answer1 = "We Believe",
                Answer2 = "I Believe",
                Answer3 = "Will Believe",
                Answer4 = "I Want",
                Category = "FBLA History",
                CorrectAnswer = 2
            }
                );
            Questions.Add(new QuestionItem
            {
                Question = "Who is one supposed to contact about sponsorship, exhibiting, and advertising?",
                Answer1 = "Christian Mohan",
                Answer2 = "Jean Buckley",
                Answer3 = "Hamden Forkner",
                Answer4 = "Jason Felton",
                Category = "FBLA National Sponsors/Partners",
                CorrectAnswer = 2
            }
                );
            Questions.Add(new QuestionItem
            {
                Question = "What is the term used to suggest names to be considered for office?",
                Answer1 = "Nominate",
                Answer2 = "Suggest",
                Answer3 = "Ask For",
                Answer4 = "Debate",
                Category = "Basic Parliamentary Procedure",
                CorrectAnswer = 1
            }
                );
            Questions.Add(new QuestionItem
            {
                Question = "The National Secretary is responsible for proofreading and finalizing the compiled team...",
                Answer1 = "Summary Reports",
                Answer2 = "Finance Reports",
                Answer3 = "Grade Reports",
                Answer4 = "Points Reports",
                Category = "National Officers",
                CorrectAnswer = 1
            }
                );

            //Assigns the questions a number
            int qnum = 1;

            foreach (QuestionItem q in Questions)
                q.QuestionNum = qnum++;

            

            //Resets all of the variables
            CurrentQuestion = 0;
            OnPropertyChanged("Count");            
            Message = "Perfect";
            ShowQuestion = true;
            NumberCorrect = 0;
        }

        //Creates an instance of the CategoriesViewModel
        public static CategoriesViewModel Current
        {
            get
            {
                if (current == null)
                    current = new CategoriesViewModel();

                return current;
            }
        }

        //Provides the list of questions to other classes
        public QuestionItem Question
        {
            get
            {
                return Questions[currentQuestion];
            }
        }

        //Provides the Question Page with the question
        public int CurrentQuestion
        {
            get { return currentQuestion; }
            set
            {
                currentQuestion = value;
                OnPropertyChanged("CurrentQuestion");
                OnPropertyChanged("Question");
                OnPropertyChanged("QuestionNumber");
            }
        }

        //Provides other classes with the count variable
        public int Count
        {
            get {
                return Questions.Count;
            }
        }

        //Outputs what question is to be shown
        private bool showQuestion = true;
        public bool ShowQuestion
        {
            get { return showQuestion; }
            set {
                showQuestion = value;
                OnPropertyChanged("ShowQuestion");
                OnPropertyChanged("ShowAnswer");
            }
        }

        //Notifies the Question Page to show the result
        public bool ShowAnswer
        {
            get { return !showQuestion; }
        }

        //Updates the message that is to be displayed after the player chooses and answer
        public string message = "ASDKJFLD";
        public string Message
        {
            set
            {
                message = value;
                OnPropertyChanged("Message");
            }
            get { return message; }
        }

        //Outputs the count of how many questions the user got correct
        public int NumberCorrect
            {
                set
                {
                    numberCorrect = value;
                    OnPropertyChanged("NumberCorrect");
                }
                get { return numberCorrect; }
            }

        public string QuestionNumber
        {
            get
            {
                return "Question #" + Questions[CurrentQuestion].QuestionNum;
            }
        }

        public void OnPropertyChanged (string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
