using System;
using System.Collections.Generic;
using System.Text;

namespace QuizzicalFBLA.Models
{
    public class QuestionItem
    {
      //Every element that a question contains
        public string Question { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }
        public int CorrectAnswer { get; set; }
        public int QuestionNum { get; set; }
        public string Category { get; set; }
    }
}
