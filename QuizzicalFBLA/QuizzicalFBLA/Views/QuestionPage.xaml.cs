using QuizzicalFBLA.Config;
using QuizzicalFBLA.Services;
using QuizzicalFBLA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuizzicalFBLA.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuestionPage : ContentPage
    {
        CategoriesViewModel vm;

        public QuestionPage()
        {
            InitializeComponent();

            //Allows this content page to use the CategoriesViewModel
            this.BindingContext = vm = CategoriesViewModel.Current;
        }

        //Processes if the answer chosen is the correct one
        public async void HandleAnswer(int answerNum)
        {
            await Task.Delay(0);

            vm.ShowQuestion = false;
            
            if (vm.Question.CorrectAnswer == answerNum)
            {

                vm.Message = "You are Correct!";
                vm.NumberCorrect++;
            }
            else
            {
                vm.Message = "You are Incorrect!\n The correct answer was ";

                switch(vm.Question.CorrectAnswer)
                {
                    case 1: vm.Message += vm.Question.Answer1 + "."; break;
                    case 2: vm.Message += vm.Question.Answer2 + "."; break;
                    case 3: vm.Message += vm.Question.Answer3 + "."; break;
                    case 4: vm.Message += vm.Question.Answer4 + "."; break;
                }
            }

        }

        //Tracks which answer is chosen
        private void Button1Clicked(object sender, EventArgs e)
        {
            HandleAnswer(1);
        }

        private void Button2Clicked(object sender, EventArgs e)
        {
            HandleAnswer(2);
        }

        private void Button3Clicked(object sender, EventArgs e)
        {
            HandleAnswer(3);
        }

        private void Button4Clicked(object sender, EventArgs e)
        {
            HandleAnswer(4);
        }

        //Loads the next question or brings the player to the end page if the quiz is over
        private async void NextQuestion(object sender, EventArgs e)
        {
            vm.ShowQuestion = true;

            if (vm.CurrentQuestion < vm.Count - 1)
            {
                vm.CurrentQuestion++;
            }
            else
            {
                await Player.Current.RegisterScore(vm.NumberCorrect);

                //Show ending page
                MasterDetailPage mdp = (MasterDetailPage)Application.Current.MainPage;
                mdp.Detail = new NavigationPage(new EndPage());
            }
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IBugReporter>().Trigger();
        }
    }
}