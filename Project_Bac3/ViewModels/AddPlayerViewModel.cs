using System;
using System.Runtime.Serialization;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Project_Bac3.Models;
using Project_Bac3.Services;


namespace Project_Bac3.ViewModels
{
    public partial class AddPlayerWindowViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string name = string.Empty;


        [ObservableProperty]
        private string age = string.Empty; 


        [ObservableProperty]
        private string contact = string.Empty;


        [ObservableProperty]
        private string description = string.Empty;


        [ObservableProperty]
        private int eloRating = 1000;


        [RelayCommand]
        private void AddPlayer()
        {
            var player = new Player
            {
                Name = Name,
                Age = int.TryParse(Age, out int ageValue) ? ageValue : 0,
                Contact = Contact,
                Description = Description,
                EloRating = EloRating
            };
            Console.WriteLine($"{Name}");
            PlayerService.Instance.AddPlayer(player);
            // TODO: Add player to list or save
            // Clear form
            Name = string.Empty;
            Age = string.Empty;
            Contact = string.Empty;
            Description = string.Empty;
            EloRating = 400;
        }
    }
}