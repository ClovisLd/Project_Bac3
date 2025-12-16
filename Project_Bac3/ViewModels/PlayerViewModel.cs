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
        public string Description => $"{_player.Description}";
        public int EloRating => _player.EloRating;

        public PlayerViewModel(Player player)
        {
            _player = player;
        }

        public void UpdateElo(int newRating)
        {
            _player.EloRating = newRating;
            
            // CORRECTION: Use OnPropertyChanged()
            OnPropertyChanged(nameof(EloRating)); 
        }
    }
}