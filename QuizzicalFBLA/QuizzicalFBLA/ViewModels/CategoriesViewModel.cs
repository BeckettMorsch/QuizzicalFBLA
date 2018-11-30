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
        //private ObservableCollection<Categories> Category { get; set; }
        private ObservableCollection<QuestionItem> Questions { get; set; }
        private static int numberCorrect = 0;

        private CategoriesViewModel()
        {
            //Category = new ObservableCollection<Categories>();
            Questions = new ObservableCollection<QuestionItem>();
            //LoadCommand = new Command(async () => await ExecuteLoadItemsCommand());
            //LoadCommand = new Command(async () => await ExecuteLoadPlayerCommand());
        }

        public void Reset()
        {
            Questions.Clear();

            // TODO: Load all the questions
            Questions.Add(new QuestionItem
            {
                QuestionNum = 1,
                Question = "This is question 1 and it is a test",
                Answer1 = "Apple",
                Answer2 = "Banana",
                Answer3 = "Cantaloupe",
                Answer4 = "Dog",
                Category = "Category 1",
                CorrectAnswer = 1
            }
                );
            Questions.Add(new QuestionItem
            {
                QuestionNum = 2,
                Question = "This is question 2 and it is a test",
                Answer1 = "SKT T1",
                Answer2 = "UR MUM",
                Answer3 = "GAY",
                Answer4 = "NO u",
                Category = "Category 2",
                CorrectAnswer = 2
            }
                );
            Questions.Add(new QuestionItem
            {
                QuestionNum = 3,
                Question = "This is question 3 and it is a test",
                Answer1 = "T1",
                Answer2 = "MUM",
                Answer3 = "GY",
                Answer4 = "NO",
                Category = "Category 3",
                CorrectAnswer = 3
            }
                            );

            //Questions = JsonConvert.Deserialize<List<QuestionItem>>(content);

            CurrentQuestion = 0;
            OnPropertyChanged("Count");
            //numberCorrect = 0;
            Message = "Perfect";
            ShowQuestion = true;

        }

        public static CategoriesViewModel Current
        {
            get
            {
                if (current == null)
                    current = new CategoriesViewModel();

                return current;
            }
        }

        public QuestionItem Question
        {
            get
            {
                return Questions[currentQuestion];
            }
        }

        public int CurrentQuestion
        {
            get { return currentQuestion; }
            set
            {
                currentQuestion = value;
                OnPropertyChanged("CurrentQuestion");
                OnPropertyChanged("Question");
            }
        }

        public int Count
        {
            get {
                return Questions.Count;
            }
        }

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

        public bool ShowAnswer
        {
            get { return !showQuestion; }
        }

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

        public int NumberCorrect
            {
                set { numberCorrect++; }
                get { return numberCorrect; }
            }
        public int ResetCorrect
        {
            set { numberCorrect = 0; }
            get {return numberCorrect = 0; }
        }

        public void OnPropertyChanged (string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
