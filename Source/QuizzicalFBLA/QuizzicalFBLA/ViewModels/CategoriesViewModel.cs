using QuizzicalFBLA.Models;
using QuizzicalFBLA.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Linq;

namespace QuizzicalFBLA.ViewModels 
{
    public class CategoriesViewModel : INotifyPropertyChanged
    {
        private static CategoriesViewModel current = null;
        private int currentQuestion = 0;

        public List<QuestionItem> QuestionPool;

        private ObservableCollection<QuestionItem> Questions { get; set; }
        public ObservableCollection<String> Categories { get; set; }

        private static int numberCorrect = 0, totalPoints = 0;

        private CategoriesViewModel()
        {

            Questions = new ObservableCollection<QuestionItem>();

            QuestionPool = new List<QuestionItem>();


            //Load all the questions into the collection of Questions
            QuestionPool.Add(new QuestionItem
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
            QuestionPool.Add(new QuestionItem
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
            QuestionPool.Add(new QuestionItem
            {

                Question = "What Insurance company sponsors FBLA?",
                Answer1 = "State Farm",
                Answer2 = "Progressive",
                Answer3 = "Geico",
                Answer4 = "AAA",
                Category = "FBLA National Sponsors/Partners",
                CorrectAnswer = 3
            }
                 );
            QuestionPool.Add(new QuestionItem
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
            QuestionPool.Add(new QuestionItem
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
            QuestionPool.Add(new QuestionItem
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
            QuestionPool.Add(new QuestionItem
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
            QuestionPool.Add(new QuestionItem
            {
                Question = "Which one of these Colleges does NOT offer a scholarship for FBLA?",
                Answer1 = "Arizona State University",
                Answer2 = "Barton College",
                Answer3 = "Catawba College",
                Answer4 = "Ohio State University",
                Category = "FBLA National Sponsors/Partners",
                CorrectAnswer = 4
            }
                );
            QuestionPool.Add(new QuestionItem
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
            QuestionPool.Add(new QuestionItem
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
            QuestionPool.Add(new QuestionItem
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
            QuestionPool.Add(new QuestionItem
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
            QuestionPool.Add(new QuestionItem
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
            QuestionPool.Add(new QuestionItem
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
            QuestionPool.Add(new QuestionItem
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
            QuestionPool.Add(new QuestionItem
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
            QuestionPool.Add(new QuestionItem
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
            QuestionPool.Add(new QuestionItem
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
            QuestionPool.Add(new QuestionItem
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
            QuestionPool.Add(new QuestionItem
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
            QuestionPool.Add(new QuestionItem
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
            QuestionPool.Add(new QuestionItem
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
            QuestionPool.Add(new QuestionItem
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
            QuestionPool.Add(new QuestionItem
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
            QuestionPool.Add(new QuestionItem
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

            QuestionPool.Add(new QuestionItem
            {
                Question = "What happens when consumers increase their borrowing?",
                Answer1 = "Interest rates tend to increase",
                Answer2 = "Interest rates tend to decrease",
                Answer3 = "Interest rates stay the same",
                Answer4 = "Does not affect interest rates",
                Category = "Business Skills",
                CorrectAnswer = 1
            }
                            );

            QuestionPool.Add(new QuestionItem
            {
                Question = "What do savers get for depositing their money?",
                Answer1 = "Capital",
                Answer2 = "Interest",
                Answer3 = "Stock",
                Answer4 = "Equity",
                Category = "Business Skills",
                CorrectAnswer = 2
            }
                            );

            QuestionPool.Add(new QuestionItem
            {
                Question = "Discount customers are _____?",
                Answer1 = "Loyal customers",
                Answer2 = "Eager to spend money",
                Answer3 = "Customers that ONLY shop online",
                Answer4 = "Price cautious and make their decisions based on sales",
                Category = "Business Skills",
                CorrectAnswer = 4
            }
                            );

            QuestionPool.Add(new QuestionItem
            {
                Question = "Which customers make up the highest percentage of sales in most companies?",
                Answer1 = "Need-based customers",
                Answer2 = "Loyal customers",
                Answer3 = "Wandering customers",
                Answer4 = "Timely customers",
                Category = "Business Skills",
                CorrectAnswer = 2
            }
                            );

            QuestionPool.Add(new QuestionItem
            {
                Question = "Why is having a CRM important to a business?",
                Answer1 = "It reduces the cost of data processing",
                Answer2 = "It helps them attract customers and increase profits",
                Answer3 = "It improves employee productivity",
                Answer4 = "Helps them meet short term revenue goals",
                Category = "Business Skills",
                CorrectAnswer = 2
            }
                            );

            QuestionPool.Add(new QuestionItem
            {
                Question = "A person who risk both time and money to start and manage a business?",
                Answer1 = "Overachiever",
                Answer2 = "Supervisor",
                Answer3 = "Entrepreneur",
                Answer4 = "Narcissist",
                Category = "Business Skills",
                CorrectAnswer = 3
            }
                            );

            QuestionPool.Add(new QuestionItem
            {
                Question = "What is inflation?",
                Answer1 = "The cost of producing services or goods",
                Answer2 = "A situation in which price increases are slowing",
                Answer3 = "A general rise in the prices of goods and services over time",
                Answer4 = "None of the above",
                Category = "Business Skills",
                CorrectAnswer = 1
            }
                            );

            QuestionPool.Add(new QuestionItem
            {
                Question = "Gathering primary data by asking people questions about their knowledge, attitudes, preferences, and buying behavior?",
                Answer1 = "Survey research",
                Answer2 = "Supplier selection",
                Answer3 = "Causal research",
                Answer4 = "Consumer market",
                Category = "Business Skills",
                CorrectAnswer = 1
            }
                            );

            QuestionPool.Add(new QuestionItem
            {
                Question = "What is a business buying situation in which the buyer purchases a product or service for the first time called?",
                Answer1 = "Attitude",
                Answer2 = "Culture",
                Answer3 = "Needs",
                Answer4 = "New Task",
                Category = "Business Skills",
                CorrectAnswer = 4
            }
                            );

            QuestionPool.Add(new QuestionItem
            {
                Question = "What is turning marketing strategies and plans into marketing actions to accomplish strategic marketing objectives called?",
                Answer1 = "Marketing Implementation",
                Answer2 = "Habitual buying behavior",
                Answer3 = "Market segment",
                Answer4 = "Marketing intermediaries",
                Category = "Business Skills",
                CorrectAnswer = 1
            }
                            );

            QuestionPool.Add(new QuestionItem
            {
                Question = "What is a business buying situation in which the buyer routinely reorders something without any modifications called?",
                Answer1 = "Motive",
                Answer2 = "Market segment",
                Answer3 = "Straight rebuy",
                Answer4 = "Strategic planning",
                Category = "Business Skills",
                CorrectAnswer = 1
            }
                            );

            QuestionPool.Add(new QuestionItem
            {
                Question = "The stage of the buyer decision process in which the consumer uses information to evaluate alternative brands in the choice set",
                Answer1 = "Proposal solicitation",
                Answer2 = "Alternative evaluation",
                Answer3 = "Supplier search",
                Answer4 = "Order-routine Specification",
                Category = "Business Skills",
                CorrectAnswer = 2
            }
                            );

            QuestionPool.Add(new QuestionItem
            {
                Question = "The systematic design, collection, analysis, and reporting of data relevant to a specific marketing situation facing an organization",
                Answer1 = "Production concept",
                Answer2 = "Marketing research",
                Answer3 = "Supplier development",
                Answer4 = "Market development",
                Category = "Business Skills",
                CorrectAnswer = 2
            }
                            );

            QuestionPool.Add(new QuestionItem
            {
                Question = "Company growth by offering modified or new products to current market segments",
                Answer1 = "Product Specification",
                Answer2 = "Product development",
                Answer3 = "Motive",
                Answer4 = "Marketing management",
                Category = "Business Skills",
                CorrectAnswer = 2
            }
                            );

            QuestionPool.Add(new QuestionItem
            {
                Question = "The stage of the buyer decision process in which the consumer uses information to evaluate alternative brands in the choice set",
                Answer1 = "Proposal solicitation",
                Answer2 = "Alternative evaluation",
                Answer3 = "Supplier search",
                Answer4 = "Order- routine specification",
                Category = "Business Skills",
                CorrectAnswer = 2
            }
                            );

            QuestionPool.Add(new QuestionItem
            {
                Question = "FBLA annual membership tops 200,000 for the first time in what year?",
                Answer1 = "1989",
                Answer2 = "1994",
                Answer3 = "1991",
                Answer4 = "1987",
                Category = "FBLA History",
                CorrectAnswer = 4
            }
                );

            QuestionPool.Add(new QuestionItem
            {
                Question = "The grand opening of the FBLA-PBL National Center was held in what year?",
                Answer1 = "1991",
                Answer2 = "1990",
                Answer3 = "1994",
                Answer4 = "1979",
                Category = "FBLA History",
                CorrectAnswer = 1
            }
                );

            QuestionPool.Add(new QuestionItem
            {
                Question = "In what year was the National Center Mortgage retired?",
                Answer1 = "1940",
                Answer2 = "2001",
                Answer3 = "1991",
                Answer4 = "1987",
                Category = "FBLA History",
                CorrectAnswer = 2
            }
                );

            QuestionPool.Add(new QuestionItem
            {
                Question = "Where was the 2012 FBLA National Leadership Conference held?",
                Answer1 = "Iowa",
                Answer2 = "Johnson City, Tennessee",
                Answer3 = "San Antonio",
                Answer4 = "Anaheim, California",
                Category = "FBLA History",
                CorrectAnswer = 3
            }
                );

            QuestionPool.Add(new QuestionItem
            {
                Question = "Where was the first local FBLA chapter organized in the U.S.?",
                Answer1 = "Johnson City, Tennessee",
                Answer2 = "Iowa and Indiana",
                Answer3 = "San Antonio, Texas",
                Answer4 = "Anaheim California",
                Category = "FBLA History",
                CorrectAnswer = 1
            }
                );

            QuestionPool.Add(new QuestionItem
            {
                Question = "By the end of 1942, how many more chapters joined FBLA?",
                Answer1 = "17",
                Answer2 = "39",
                Answer3 = "38",
                Answer4 = "23",
                Category = "FBLA History",
                CorrectAnswer = 2
            }
                );

            QuestionPool.Add(new QuestionItem
            {
                Question = "Edward D. Miller retired as president in which year?",
                Answer1 = "1958",
                Answer2 = "1999",
                Answer3 = "2002",
                Answer4 = "2001",
                Category = "FBLA History",
                CorrectAnswer = 4
            }
                );

            QuestionPool.Add(new QuestionItem
            {
                Question = "Who became FBLA’s first full-time executive director in 1973?",
                Answer1 = "Edward D. Miller",
                Answer2 = "Jean Buckley",
                Answer3 = "Hamden L. Forkner",
                Answer4 = "Eric B. Diller",
                Category = "FBLA History",
                CorrectAnswer = 1
            }
                );

            QuestionPool.Add(new QuestionItem
            {
                Question = "What year was the organization dubbed /“Future Business Leaders of America/”?",
                Answer1 = "1987",
                Answer2 = "1969",
                Answer3 = "1947",
                Answer4 = "1940",
                Category = "FBLA History",
                CorrectAnswer = 4
            }
                );

            QuestionPool.Add(new QuestionItem
            {
                Question = "Who reactivated the Mu Alpha Rho chapter of PBL at Penn State?",
                Answer1 = "Matthew Hawkins",
                Answer2 = "Phil Goldfeder",
                Answer3 = "Jean Buckley",
                Answer4 = "Hamden L Forkner",
                Category = "FBLA History",
                CorrectAnswer = 1
            }
                );

            QuestionPool.Add(new QuestionItem
            {
                Question = "When did Matthew Hawkins reactivate the Mu Alpha Rho chapter of Phi Beta Lambda at Penn State?",
                Answer1 = "2006",
                Answer2 = "1973",
                Answer3 = "1987",
                Answer4 = "2002",
                Category = "FBLA History",
                CorrectAnswer = 1
            }
                );

            QuestionPool.Add(new QuestionItem
            {
                Question = "Who proposed that a national organization was needed for business clubs in high schools and colleges?",
                Answer1 = "Phil Goldfeder",
                Answer2 = "Edward D. Miller",
                Answer3 = "Hamden L Forkner",
                Answer4 = "Matthew Hawkins",
                Category = "FBLA History",
                CorrectAnswer = 3
            }
                );

            QuestionPool.Add(new QuestionItem
            {
                Question = "Who was appointed as the second chief executive officer and president in 1997?",
                Answer1 = "Matthew Hawkins",
                Answer2 = "Edward D. Miller",
                Answer3 = "Phil Goldfeder",
                Answer4 = "Jean Buckley",
                Category = "FBLA History",
                CorrectAnswer = 4
            }
                );

            QuestionPool.Add(new QuestionItem
            {
                Question = "Where is the FBLA-PBL National Center located?",
                Answer1 = "Reston, Virginia",
                Answer2 = "Phoenix, Arizona",
                Answer3 = "Dallas, Texas",
                Answer4 = "Philadelphia, Pennsylvania",
                Category = "FBLA History",
                CorrectAnswer = 1
            }
                );

            QuestionPool.Add(new QuestionItem
            {
                Question = "Where was the National Center for FBLA established?",
                Answer1 = "Iowa",
                Answer2 = "Tennessee",
                Answer3 = "Washington D.C.",
                Answer4 = "Maine",
                Category = "FBLA History",
                CorrectAnswer = 3
            }
                );

            QuestionPool.Add(new QuestionItem
            {
                Question = "Who sponsored the proposal for FBLA?",
                Answer1 = "The National Education Association Center in D.C.",
                Answer2 = "University of Northern Iowa",
                Answer3 = "National Council for Business Education",
                Answer4 = "University of Tennessee",
                Category = "FBLA National Sponsors/Partners",
                CorrectAnswer = 3
            }
                );

            QuestionPool.Add(new QuestionItem
            {
                Question = "How many different college sponsors does FBLA have?",
                Answer1 = "22",
                Answer2 = "16",
                Answer3 = "15",
                Answer4 = "14",
                Category = "FBLA National Sponsors/Partners",
                CorrectAnswer = 3
            }
                );

            QuestionPool.Add(new QuestionItem
            {
                Question = "February is known as what month for FBLA?",
                Answer1 = "National Career and Technical Education month",
                Answer2 = "National Business Student month",
                Answer3 = "National Computer Science and Engineering month",
                Answer4 = "National Leadership and Communication month",
                Category = "FBLA National Sponsors/Partners",
                CorrectAnswer = 1
            }
                );

            QuestionPool.Add(new QuestionItem
            {
                Question = "What day is February 14 in regards to FBLA?",
                Answer1 = "Business attire",
                Answer2 = "Pride",
                Answer3 = "Leadership",
                Answer4 = "Communication",
                Category = "FBLA National Sponsors/Partners",
                CorrectAnswer = 2
            }
                );

            QuestionPool.Add(new QuestionItem
            {
                Question = "November is known as what month for FBLA?",
                Answer1 = "Prematurity Awareness month",
                Answer2 = "National Leadership and Communication month",
                Answer3 = "National Career and Technical Education Month",
                Answer4 = "National Computer and Engineering month",
                Category = "FBLA National Sponsors/Partners",
                CorrectAnswer = 1
            }
                );

            QuestionPool.Add(new QuestionItem
            {
                Question = "What three events does NJ FBLA sponsor?",
                Answer1 = "RCE’s,SLC, and BTDM",
                Answer2 = "SFLC,RCE’s, and SLC",
                Answer3 = "SLC, BTDM, and ABE",
                Answer4 = "MAD,BTDM, and SFLC",
                Category = "FBLA National Sponsors/Partners",
                CorrectAnswer = 2
            }
                );


            QuestionPool.Add(new QuestionItem
            {
                Question = "When is American Enterprise Day?",
                Answer1 = "January 7",
                Answer2 = "November 7",
                Answer3 = "February 22",
                Answer4 = "November 15",
                Category = "FBLA National Sponsors/Partners",
                CorrectAnswer = 4
            }
                );

            QuestionPool.Add(new QuestionItem
            {
                Question = "When is National Community Service Day?",
                Answer1 = "February 22",
                Answer2 = "December 4",
                Answer3 = "February 15",
                Answer4 = "August 29",
                Category = "FBLA National Sponsors/Partners",
                CorrectAnswer = 3
            }
                );

            QuestionPool.Add(new QuestionItem
            {
                Question = "What charitable organization does FBLA primarily support?",
                Answer1 = "March of Dimes",
                Answer2 = "Alex’s Lemonade Stand",
                Answer3 = "Lauren's First and Goal",
                Answer4 = "American Red Cross",
                Category = "FBLA National Sponsors/Partners",
                CorrectAnswer = 1
            }
                );
            QuestionPool.Add(new QuestionItem
            {
                Question = "When is the March of Dimes World Prematurity Day?",
                Answer1 = "November 19",
                Answer2 = "June 30",
                Answer3 = "November 17",
                Answer4 = "May 13",
                Category = "FBLA National Sponsors/Partners",
                CorrectAnswer = 3
            }
                );
            QuestionPool.Add(new QuestionItem
            {
                Question = "What month is FBLA-PBL Week held?",
                Answer1 = "December",
                Answer2 = "June",
                Answer3 = "May",
                Answer4 = "February",
                Category = "FBLA National Sponsors/Partners",
                CorrectAnswer = 4
            }
                );

            QuestionPool.Add(new QuestionItem
            {
                Question = "Which of the following is not an official publication of FBLA-PBL?",
                Answer1 = "Tomorrow's Business Leader",
                Answer2 = "FBLA Adviser Hotline",
                Answer3 = "Business Leaders of Tomorrow",
                Answer4 = "The PBL Business Leader",
                Category = "FBLA National Sponsors/Partners",
                CorrectAnswer = 2
            }
                );

            QuestionPool.Add(new QuestionItem
            {
                Question = "The land for the FBLA-PBL National Center was purchased through a grant from the",
                Answer1 = "General Motors Corporation",
                Answer2 = "Conrad Hilton Foundation",
                Answer3 = "McDonald's Corporation",
                Answer4 = "Ford Motor Company Foundation",
                Category = "FBLA National Sponsors/Partners",
                CorrectAnswer = 2
            }
                );

            QuestionPool.Add(new QuestionItem
            {
                Question = "What is FBLA-PBL's official parliamentary authority?",
                Answer1 = "Robert's Rules of Order",
                Answer2 = "Robert's Rules of Order - Newly Revised",
                Answer3 = "The Chapter Management Handbook",
                Answer4 = "The Meeting Guide",
                Category = "FBLA National Sponsors/Partners",
                CorrectAnswer = 2
            }
                );


            QuestionPool.Add(new QuestionItem
            {
                Question = "What are the three categories of competitive events?",
                Answer1 = "Individual, Group, and Chapter",
                Answer2 = "Chapter, Member, and Team",
                Answer3 = "Individual, Team, and Chapter",
                Answer4 = "Group, Member, and Team",
                Category = "Basic Parliamentary Procedure",
                CorrectAnswer = 3
            }
                );

            QuestionPool.Add(new QuestionItem
            {
                Question = "What is the official national website address?",
                Answer1 = "www.fbla-pbl.org",
                Answer2 = "www.fbla-pbl.com",
                Answer3 = "www.fbla.org",
                Answer4 = "www.fbla-pbl.net",
                Category = "Basic Parliamentary Procedure",
                CorrectAnswer = 1
            }
                );


            QuestionPool.Add(new QuestionItem
            {
                Question = "FBLA middle level membership is open to students in what grades?",
                Answer1 = "9-12",
                Answer2 = "7-12",
                Answer3 = "8-9",
                Answer4 = "5-9",
                Category = "Basic Parliamentary Procedure",
                CorrectAnswer = 4
            }
                );


            QuestionPool.Add(new QuestionItem
            {
                Question = "To qualify for the competitive events program for FBLA, dues must be received in the National Center by what date?",
                Answer1 = "April 1",
                Answer2 = "March 1",
                Answer3 = "April 15",
                Answer4 = "March 15",
                Category = "Basic Parliamentary Procedure",
                CorrectAnswer = 2
            }
                );


            QuestionPool.Add(new QuestionItem
            {
                Question = "The chapter officer that presides over and conducts meetings is typically the",
                Answer1 = "Secretary",
                Answer2 = "President",
                Answer3 = "Treasurer",
                Answer4 = "Parliamentarian",
                Category = "Basic Parliamentary Procedure",
                CorrectAnswer = 2
            }
                );


            QuestionPool.Add(new QuestionItem
            {
                Question = "When will the term of office begin for a National Officer",
                Answer1 = "At the close of the National Leadership Conference in which they were elected",
                Answer2 = "At the beginning of the new school year",
                Answer3 = "At the beginning of the National Fall Leadership Conferences",
                Answer4 = "Immediately upon election",
                Category = "Basic Parliamentary Procedure",
                CorrectAnswer = 1
            }
                );


            QuestionPool.Add(new QuestionItem
            {
                Question = "In debate, each member has the right to speak __________ on a motion.",
                Answer1 = "Twice",
                Answer2 = "Once",
                Answer3 = "Three times",
                Answer4 = "Four times",
                Category = "Basic Parliamentary Procedure",
                CorrectAnswer = 1
            }
                );

            QuestionPool.Add(new QuestionItem
            {
                Question = "The Parliamentary Procedure Event is named after",
                Answer1 = "Hollis and Kitty Guy",
                Answer2 = "Dorothy L. Travis",
                Answer3 = "Lorraine Missling",
                Answer4 = "Hamden Forkner",
                Category = "Basic Parliamentary Procedure",
                CorrectAnswer = 2
            }
                );


            QuestionPool.Add(new QuestionItem
            {
                Question = "FBLA-PBL is divided into _______ administrative regions",
                Answer1 = "Four",
                Answer2 = "Five",
                Answer3 = "Six",
                Answer4 = "Seven",
                Category = "Basic Parliamentary Procedure",
                CorrectAnswer = 2
            }
                );


            QuestionPool.Add(new QuestionItem
            {
                Question = "The Gold Seal Award of Merit is named after",
                Answer1 = "Jean Buckley",
                Answer2 = "Hamden Forkner",
                Answer3 = "Hollis and Kitty Guy",
                Answer4 = "Dorothy Travis",
                Category = "Basic Parliamentary Procedure",
                CorrectAnswer = 3
            }
                );


            QuestionPool.Add(new QuestionItem
            {
                Question = "The three words on the FBLA and PBL emblems are",
                Answer1 = "Service, Education, and Leadership",
                Answer2 = "Service, Leadership, and Prosperity",
                Answer3 = "Service, Education, and Progress",
                Answer4 = "Progress, Leadership, and Education",
                Category = "Basic Parliamentary Procedure",
                CorrectAnswer = 3
            }
                );

            QuestionPool.Add(new QuestionItem
            {
                Question = "There are ___ FBLA districts in South Carolina.",
                Answer1 = "4",
                Answer2 = "10",
                Answer3 = "2",
                Answer4 = "11",
                Category = "Basic Parliamentary Procedure",
                CorrectAnswer =1 
            }
                );

            QuestionPool.Add(new QuestionItem
            {
                Question = "How many FBLA goals are there?",
                Answer1 = "10",
                Answer2 = "21",
                Answer3 = "9",
                Answer4 = "7",
                Category = "Basic Parliamentary Procedure",
                CorrectAnswer = 3
            }
                );


            QuestionPool.Add(new QuestionItem
            {
                Question = "The initialism for Future Business Leaders of America is __________.",
                Answer1 = "FBLA",
                Answer2 = "FLA",
                Answer3 = "FBA",
                Answer4 = "FBLA-PBL",
                Category = "Basic Parliamentary Procedure",
                CorrectAnswer = 1
            }
                );


            QuestionPool.Add(new QuestionItem
            {
                Question = "The FBLA State Conference is usually held in which months?",
                Answer1 = "November or December",
                Answer2 = "April or May",
                Answer3 = "March or April",
                Answer4 = "June or July",
                Category = "Basic Parliamentary Procedure",
                CorrectAnswer = 3
            }
                );


            QuestionPool.Add(new QuestionItem
            {
                Question = "Who is the Central Section State VP?",
                Answer1 = "LIsa Weeks",
                Answer2 = "Asad Hussain",
                Answer3 = "Alyssa Herrera",
                Answer4 = "Stephanie Shi",
                Category = "National Officers",
                CorrectAnswer = 3
            }
                );

            QuestionPool.Add(new QuestionItem
            {
                Question = "Who is the National Treasurer?",
                Answer1 = "Grace Ramstad",
                Answer2 = "Asad Hussain",
                Answer3 = "Stephanie Shi",
                Answer4 = "Ashtyn Rottinghaus",
                Category = "National Officers",
                CorrectAnswer = 4
            }
                );


            QuestionPool.Add(new QuestionItem
            {
                Question = "The president serves on the",
                Answer1 = "Board of Directors",
                Answer2 = "Leadership team",
                Answer3 = "Communication Team",
                Answer4 = "None of the above",
                Category = "National Officers",
                CorrectAnswer = 1
            }
                );


            QuestionPool.Add(new QuestionItem
            {
                Question = "Who is the parliamentarian of the Inland Section?",
                Answer1 = "Frances Song",
                Answer2 = "Samantha Noor",
                Answer3 = "Ashlee Fong",
                Answer4 = "Alvin Li",
                Category = "National Officers",
                CorrectAnswer = 2
            }
                );

            QuestionPool.Add(new QuestionItem
            {
                Question = "Who is the VP of programs in the Inland Section?",
                Answer1 = "Stacy M, Nahas",
                Answer2 = "Ashlee Fong",
                Answer3 = "Frances Song",
                Answer4 = "Karen Heslep",
                Category = "National Officers",
                CorrectAnswer = 2
            }
                );


            QuestionPool.Add(new QuestionItem
            {
                Question = "Who is the Bay Section State VP?",
                Answer1 = "Stephanie Shi",
                Answer2 = "Lydia Zhong",
                Answer3 = "Christopher Lee",
                Answer4 = "Jeremy Xue",
                Category = "National Officers",
                CorrectAnswer = 4
            }
                );


            QuestionPool.Add(new QuestionItem
            {
                Question = "Who is the Northern Section State VP?",
                Answer1 = "Asad Hussain",
                Answer2 = "Alyssa Herrera",
                Answer3 = "Stephanie Shi",
                Answer4 = "Zachary Yim",
                Category = "National Officers",
                CorrectAnswer = 4
            }
                );


            QuestionPool.Add(new QuestionItem
            {
                Question = "Who is the state chair/adviser/chair-elect?",
                Answer1 = "Lydia Zhong",
                Answer2 = "Lisa Weeks",
                Answer3 = "Naomi Jung",
                Answer4 = "Alyssa Herrera",
                Category = "National Officers",
                CorrectAnswer = 2
            }
                );


            QuestionPool.Add(new QuestionItem
            {
                Question = "Who is the Inland Section president?",
                Answer1 = "Mr. Lee Lara",
                Answer2 = "Alvin Li",
                Answer3 = "Frances Song",
                Answer4 = "Karen Sun",
                Category = "National Officers",
                CorrectAnswer = 4
            }
                );



            QuestionPool.Add(new QuestionItem
            {
                Question = "Who is SMT: ML Coordinator and Staff-Assistant?",
                Answer1 = "Mr. Bruce Boncal",
                Answer2 = "Mr. Luke Skerpon",
                Answer3 = "Mr. Neal Rob",
                Answer4 = "Mrs. Lydia Zhong",
                Category = "National Officers",
                CorrectAnswer = 1
            }
                );
            QuestionPool.Add(new QuestionItem
            {
                Question = "Who is the current NJ state adviser?",
                Answer1 = "Scott Mueller",
                Answer2 = "Gabriel Silveria",
                Answer3 = "Ms.Megan Fishwick",
                Answer4 = "Edward Miller",
                Category = "National Officers",
                CorrectAnswer = 3
            }
                );

            QuestionPool.Add(new QuestionItem
            {
                Question = "Who was the 2016-2017 NJ state president?",
                Answer1 = "Edward Miller",
                Answer2 = "Gabriel Silveria",
                Answer3 = "Rich Biller",
                Answer4 = "Andrew Gonzales",
                Category = "National Officers",
                CorrectAnswer = 2
            }
                );

            QuestionPool.Add(new QuestionItem
            {
                Question = "Who was the 2016-2017 NJ membership VP",
                Answer1 = "Jake Mansure",
                Answer2 = "Rich Biller",
                Answer3 = "Vanessa Ting",
                Answer4 = "Gabriel Silveira",
                Category = "National Officers",
                CorrectAnswer = 1
            }
                );


            QuestionPool.Add(new QuestionItem
            {
                Question = "A _____ calls attention to a violation of parliamentary procedure",
                Answer1 = "Point of order",
                Answer2 = "Suspend the rules",
                Answer3 = "Roll call",
                Answer4 = "Call to order",
                Category = "National Officers",
                CorrectAnswer = 1
            }
                );

            QuestionPool.Add(new QuestionItem
            {
                Question = "What officer counts the votes and records them during an election",
                Answer1 = "Secretary",
                Answer2 = "President",
                Answer3 = "Vice President",
                Answer4 = "Treasurer",
                Category = "National Officers",
                CorrectAnswer = 1
            }
                );



            List<String> cats = new List<string>();
            foreach (QuestionItem q in QuestionPool)
            {
                if (!cats.Contains(q.Category))
                {
                    cats.Add(q.Category);
                }
            }
            cats.Sort();
            cats.Insert(0, "All Categories");

            Categories = new ObservableCollection<string>(cats);

        }

        private static Random rng = new Random();

        public void Shuffle<T>(IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public void Reset(int count = 5)
        {
            Questions.Clear();

            Shuffle(QuestionPool);
            List<QuestionItem> Quiz = new List<QuestionItem>(QuestionPool.Take(count));
            
            foreach (QuestionItem item in Quiz)
            {
                Questions.Add(item);
            }

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
            TotalPoints = 0;
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

        //Updates the message that is to be displayed after the player chooses an answer
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

        public string EndAnimation
        {
            get
            {
                double average = (double)NumberCorrect / Questions.Count;
                EndAnimationScale = 1.2;

                if (average < 0.5)
                {
                    EndAnimationScale = 0.8;
                    return "3227-error-404-facebook-style.json"; 
                }

                return "star.json";
            }
        }

        public double EndAnimationScale { get; set; } = 1.2;

        public string Heading
        {
            get {
                string message = "Congrats!";

                double average = (double)NumberCorrect / Questions.Count;

                if (average < 0.5)
                {
                    message = "Too bad!";
                }

                return message;
            }
        }


        public string EndMessage
        {
            get { return "You scored " + NumberCorrect + " out of " + Count + " and earned " + TotalPoints + " points!"  ; }
        }


        //Outputs the count of how many questions the user got correct
        public int NumberCorrect
            {
                set
                {
                    numberCorrect = value;
                    OnPropertyChanged("NumberCorrect");
                    OnPropertyChanged("EndAnimation");
                    OnPropertyChanged("EndAnimationScale");
                    OnPropertyChanged("Heading");
                    OnPropertyChanged("EndMessage");
                }
                get { return numberCorrect; }
            }

        public int TotalPoints
        {
            set
            {
                totalPoints = value;
                OnPropertyChanged("EndAnimation");
                OnPropertyChanged("EndAnimationScale");
                OnPropertyChanged("Heading");
                OnPropertyChanged("TotalPoints");
                OnPropertyChanged("EndMessage");
            }
            get { return totalPoints; }
        }

        public string QuestionNumber
        {
            get
            {
                return "Question " + Questions[CurrentQuestion].QuestionNum + " / " + Count;
            }
        }

        public void OnPropertyChanged (string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
