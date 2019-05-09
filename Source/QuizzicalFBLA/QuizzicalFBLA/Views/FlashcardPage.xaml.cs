using MLToolkit.Forms.SwipeCardView.Core;
using QuizzicalFBLA.Controls;
using QuizzicalFBLA.Models;
using QuizzicalFBLA.Services;
using QuizzicalFBLA.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QuizzicalFBLA.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FlashcardPage : ContentPage
	{
        private ObservableCollection<FlashCard> _cardItems = new ObservableCollection<FlashCard>();

        public ObservableCollection<FlashCard> CardItems
        {
            get => _cardItems;
            set
            {
                _cardItems = value;
                OnPropertyChanged("CardItems");
            }
        }

        public FlashcardPage(string category)
        {
            InitializeComponent();

            Reset(category);

            this.BindingContext = this;
            Deck.Swiped += OnSwiped;
            
		}


        public void Reset(string selectedCategory = "All Categories")
        {
            int count = 1;
            List<QuestionItem> pool;

            if (selectedCategory == "All Categories")
                pool = CategoriesViewModel.Current.QuestionPool;
            else
                pool = CategoriesViewModel.Current.QuestionPool.Where(q => q.Category == selectedCategory).ToList();

            CardItems.Clear();
            foreach (QuestionItem question in pool)
            {
                CardItems.Add(new FlashCard()
                {
                    QuestionNumberText = "Question " + count + " of " + pool.Count,
                    Question = question,
                    Flipped = false
                });

                count++;
            }
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IBugReporter>().Trigger();
        }

        private void OnSwiped(object sender, SwipedCardEventArgs e)
        {
            XFFlipView card = (XFFlipView)sender;

            switch (e.Direction)
            {
                case SwipeCardDirection.None:
                    break;
                case SwipeCardDirection.Right:
                    card.IsFlipped = !card.IsFlipped;
                    break;
                case SwipeCardDirection.Left:
                    card.IsFlipped = !card.IsFlipped;
                    break;
                case SwipeCardDirection.Up:
                    card.Animate = false;
                    card.IsFlipped = false;
                    card.Animate = true;
                    break;
                case SwipeCardDirection.Down:
                    card.Animate = false;
                    card.IsFlipped = false;
                    card.Animate = true;
                    break;
            }
        }
        
    }
}