using System;
using System.Collections.Generic;
using System.Text;

namespace QuizzicalFBLA.Models
{
  //Navigation Menu elements
    public enum MenuItemType
    {
        Play,
        About,
        TermsOfService,
        BugReporting
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
