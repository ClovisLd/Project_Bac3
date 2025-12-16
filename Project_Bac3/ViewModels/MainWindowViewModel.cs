using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Project_Bac3.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        private object? currentViewModel;

        public MainWindowViewModel()
        {
            // Set initial view
            CurrentViewModel = new HomeWindowViewModel();
        }

        [RelayCommand]
        private void NavigateToHome()
        {
            CurrentViewModel = new HomeWindowViewModel();
        }

        [RelayCommand]
        private void NavigateToAddPlayer()
        {
            CurrentViewModel = new AddPlayerWindowViewModel();
        }

        [RelayCommand]
        private void NavigateToMatch()
        {
            CurrentViewModel = new MatchWindowViewModel();
        }

        [RelayCommand]
        public void NavigateToCompetition()
        {
            CurrentViewModel = new CompetitionWindowViewModel();
        }
        
        public string Greeting { get; } = "Welcome to Avalonia!";
    }
}