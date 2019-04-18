using GameSparks.NET.Services;
using GameSparks.NET.Services.Leaderboards.Requests;
using Leaderboard.Events;
using QuizzicalFBLA.Config;
using QuizzicalFBLA.Helpers;
using QuizzicalFBLA.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace QuizzicalFBLA.ViewModels
{
    public class LeaderBoardViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ScoreItem> Scores { get; set; }

        private bool isBusy, isError, dataAvailable;
        private string errorMessage = "";

        public LeaderBoardViewModel()
        {
        }


        /// <summary>
        /// Gets or sets if the View Model is busy
        /// </summary>
        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; OnPropertyChanged("IsBusy"); }
        }

        /// <summary>
        /// Gets or sets if the View Model generated an error
        /// </summary>
        public bool IsError
        {
            get { return isError; }
            set { isError = value; OnPropertyChanged("IsError"); }
        }

        /// <summary>
        /// Gets or sets if the View Model data is available
        /// </summary>
        public bool DataAvailable
        {
            get { return dataAvailable; }
            set { dataAvailable = value; OnPropertyChanged("DataAvailable"); }
        }

        /// <summary>
        /// Gets or sets if the View Model data is available
        /// </summary>
        public string ErrorMessage
        {
            get { return errorMessage; }
            set { errorMessage = value; OnPropertyChanged("ErrorMessage"); }
        }


        private RelayCommand refreshItemsCommand;
        public ICommand RefreshCommand
        {
            get
            {
                return refreshItemsCommand ?? (refreshItemsCommand = new RelayCommand(async () => await ExecuteLoadItemsCommand()));
            }
        }

        public async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy) return;
            IsBusy = true;

            await Player.Current.AuthenticateGameSparks();

            Scores = new ObservableCollection<ScoreItem>();

            try
            {
                // Load data from GameSparks
                var leaderboardService = new GameSparksLeaderboardsService();

                var leaderboardDataRequest = new LeaderboardDataRequest(null, false, 20, null, 0, 0, false, "best", 0, Player.Current.GameSparksUserID, false, null, null);
                var leaderboard = leaderboardService.LeaderboardDataRequest<LeaderboardDataResponseScoreEvent>(leaderboardDataRequest);  // Or data can just be "dynamic"

                bool success = leaderboard.Error == null;

                // If Successful
                if (success)
                {
                    IsError = false;
                   
                    foreach (LeaderboardDataResponseScoreEvent score in leaderboard.Data)
                    {
                        Scores.Add(new ScoreItem()
                        {
                            Rank = score.Rank,
                            Username = score.UserName,
                            Score = score.Score
                        });
                    }

                    DataAvailable = true;
                }
                else
                {
                    // An error occurred that is stored in response.ErrorMessage
                    ErrorMessage = "Unable to retrieve leaderboard";
                    DataAvailable = false;
                    IsError = true;
                }
            }
            catch (Exception e)
            {
                // An exception occurred
                DataAvailable = false;
            }

            IsBusy = false;
            OnPropertyChanged("Scores");

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
