using System;
using Project_Bac3.Models; // N'oubliez pas le using pour accéder au modèle

namespace Project_Bac3.ViewModels
{
    // Il est bon que les ViewModels héritent de ViewModelBase
    // si vous avez besoin de notifier des changements de propriétés.
    public class PlayerViewModel : ViewModelBase
    {
        private readonly Player player;

        // Une propriété pour afficher le nom complet
        public string Name => $"{player.Name}";
        public string Age => $"{player.Age}";
        public string Contact => $"{player.Contact}";
        public string Description => $"{player.Description}";
        public int EloRating => player.EloRating;

        public PlayerViewModel(Player Player)
        {
            player = Player;
        }

        public Player Model => player;

        public void UpdateName(string new_name)
        {
            player.Name = new_name;
            OnPropertyChanged(nameof(Name)); 
        }
        public void UpdateAge(int new_age)
        {
            player.Age = new_age;
            OnPropertyChanged(nameof(Age)); 
        }
        public void UpdateContact(string new_contact)
        {
            player.Contact = new_contact;
            OnPropertyChanged(nameof(Contact)); 
        }
        public void UpdateDescription(string new_description)
        {
            player.Description = new_description;
            OnPropertyChanged(nameof(Description)); 
        }
        public void UpdateElo(int new_rating)
        {
            player.EloRating = new_rating;
            OnPropertyChanged(nameof(EloRating)); 
        }

    }
}