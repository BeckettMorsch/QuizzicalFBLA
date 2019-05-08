using System;
using System.Collections.Generic;
using System.Text;

namespace QuizzicalFBLA.Models
{
    public class Board
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public Lottie.Forms.AnimationView Animation { get; set; }
        public Xamarin.Forms.Color BackgroundColor { get; set; }
    }
}
