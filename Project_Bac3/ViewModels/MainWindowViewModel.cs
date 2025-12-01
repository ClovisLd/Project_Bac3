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
        private void NavigateToAddPLayer()
        {
            CurrentViewModel = new AddPlayerWindowViewModel();
        }

        [RelayCommand]
        private void NavigateToMatch()
        {
            CurrentViewModel = new MatchWindowViewModel();
        }
        
        public string Greeting { get; } = "Welcome to Avalonia!";
    }
}