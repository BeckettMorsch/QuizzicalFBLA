using System;
using System.Collections.Generic;
using System.Text;

namespace QuizzicalFBLA.Models
{
    public class ScoreItem
    {
        public int Rank { get; set; }
        public string RankStr { get; set; }
        public string Username { get; set; }
        public int Score { get; set; }
        public string ScoreString {
            get {
                return Score.ToString("N0");
            }
        }
    }
}
