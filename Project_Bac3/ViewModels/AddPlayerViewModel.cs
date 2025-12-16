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
        private int age = 0; 

        [ObservableProperty]
        private string contact = string.Empty;

        [ObservableProperty]
        private string description = string.Empty;

        [ObservableProperty]
        private int eloRating = 400;

        [ObservableProperty]
        private string error_ = string.Empty;

        [RelayCommand]
        private void AddPlayer()
        {

            
            var player = new Player
            {
                Name = Name,
                Age = Age,
                Contact = Contact,
                Description = Description,
                EloRating = EloRating
            };
            Console.WriteLine($"{Name}");
            if (PlayerService.Instance.ExistPlayer(Name)!=null)
            {
                Error_ = "Ce joueur exist deja";
            }
            else
            {
                PlayerService.Instance.AddPlayer(new PlayerViewModel(player));

                Name = string.Empty;
                Age = 0;
                Contact = string.Empty;
                Description = string.Empty;
                EloRating = 400;
            }
        }
    }
}