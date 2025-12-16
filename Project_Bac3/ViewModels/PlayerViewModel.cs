using System;
using Project_Bac3.Models; // N'oubliez pas le using pour accéder au modèle

namespace Project_Bac3.ViewModels
{
    // Il est bon que les ViewModels héritent de ViewModelBase
    // si vous avez besoin de notifier des changements de propriétés.
    public class PlayerViewModel : ViewModelBase
    {
        private readonly Player _player;

        // Une propriété pour afficher le nom complet
        public string Name => $"{_player.Name}";
        public string Age => $"{_player.Age}";
        public string Contact => $"{_player.Contact}";
        public string Description => $"{_player.Description}";
        public int EloRating => _player.EloRating;

        public PlayerViewModel(Player player)
        {
            _player = player;
        }

        public void UpdateName(string new_name)
        {
            _player.Name = new_name;
            OnPropertyChanged(nameof(Name)); 
        }
        public void UpdateAge(int new_age)
        {
            _player.Age = new_age;
            OnPropertyChanged(nameof(Age)); 
        }
        public void UpdateContact(string new_contact)
        {
            _player.Contact = new_contact;
            OnPropertyChanged(nameof(Contact)); 
        }
        public void UpdateDescription(string new_description)
        {
            _player.Description = new_description;
            OnPropertyChanged(nameof(Description)); 
        }
        public void UpdateElo(int new_rating)
        {
            _player.EloRating = new_rating;
            OnPropertyChanged(nameof(EloRating)); 
        }

    }
}