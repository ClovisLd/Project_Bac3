using System;
using System.Collections.Generic;
using Project_Bac3.Models; // N'oubliez pas le using pour accéder au modèle

namespace Project_Bac3.ViewModels
{
    // Il est bon que les ViewModels héritent de ViewModelBase
    // si vous avez besoin de notifier des changements de propriétés.
    public class CompetitionViewModel : ViewModelBase
    {
        private readonly Competition competition;

        public string Name => $"{competition.Name}";
        public List<PlayerViewModel> Player_list => competition.Player_list;
        public string Organisator => $"{competition.Organisator}";

        public CompetitionViewModel(Competition Competition)
        {
            competition = Competition;
        }
    }
}