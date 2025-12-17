using System.Runtime.InteropServices.Marshalling;
using CommunityToolkit.Mvvm.ComponentModel;
using Project_Bac3.Models; // N'oubliez pas le using pour accéder au modèle

namespace Project_Bac3.ViewModels
{
    // Il est bon que les ViewModels héritent de ViewModelBase
    // si vous avez besoin de notifier des changements de propriétés.
    public class MatchViewModel: ViewModelBase
    {
        private readonly Match match;

        // Une propriété pour afficher le nom complet
        public string Winning_player => $"{match.Winning_player}";
        public string Loosing_player => $"{match.Loosing_player}";
        

        public MatchViewModel(Match Match)
        {
            match = Match;
        }
    }
}