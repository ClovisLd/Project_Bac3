using CommunityToolkit.Mvvm.ComponentModel;
using Project_Bac3.Models; // N'oubliez pas le using pour accéder au modèle

namespace Project_Bac3.ViewModels
{
    // Il est bon que les ViewModels héritent de ViewModelBase
    // si vous avez besoin de notifier des changements de propriétés.
    public class MatchViewModel : ViewModelBase
    {
        private readonly Match match;

        // Une propriété pour afficher le nom complet
        

        public MatchViewModel(Match fmatch)
        {
            match= fmatch;
        }
    }
}