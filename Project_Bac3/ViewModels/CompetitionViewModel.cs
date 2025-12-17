using System;
using System.Collections.Generic;
using Project_Bac3.Models; // N'oubliez pas le using pour accéder au modèle
using System.Collections.ObjectModel;


namespace Project_Bac3.ViewModels
{
    // Il est bon que les ViewModels héritent de ViewModelBase
    // si vous avez besoin de notifier des changements de propriétés.
    public class CompetitionViewModel : ViewModelBase
    {
        private readonly Competition competition;

        public string Name => $"{competition.Name}";
        public string Organisator => $"{competition.Organisator}";
        public List<PlayerViewModel> Player_list => new List<PlayerViewModel>();

        public CompetitionViewModel(Competition Competition)
        {
            competition = Competition;  
        }

        public void UpdateName(string new_name)
        {
            competition.Name = new_name;
            OnPropertyChanged(nameof(Name)); 
        }
        public void UpdatePlayer_List(PlayerViewModel new_player)
        {
            competition.Player_list.Add(new_player);
            OnPropertyChanged(nameof(Player_list)); 
        }
        public void UpdateOrganisator(string new_organisator)
        {
            competition.Organisator = new_organisator;
            OnPropertyChanged(nameof(Organisator)); 
        }
    }
}