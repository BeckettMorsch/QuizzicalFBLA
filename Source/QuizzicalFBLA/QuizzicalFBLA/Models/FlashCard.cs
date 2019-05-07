using QuizzicalFBLA.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace QuizzicalFBLA.Models
{
    public class FlashCard : BaseViewModel
    {

        QuestionItem question = new QuestionItem();
        public QuestionItem Question
        {
            get { return question; }
            set { SetProperty(ref question, value); }
        }

        public string QuestionNumberText { get; set; } = "Question 1 of 1";

        bool flipped = false;
        public bool Flipped
        {
            get { return flipped; }
            set { SetProperty(ref flipped, value); }
        }

    }
}
