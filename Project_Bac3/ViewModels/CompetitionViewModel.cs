using System;
using System.Collections.Generic;
using Project_Bac3.Models; // N'oubliez pas le using pour accéder au modèle
using System.Collections.ObjectModel;
using System.Linq; // <--- REQUIRED for .Select()


namespace Project_Bac3.ViewModels
{
    // Il est bon que les ViewModels héritent de ViewModelBase
    // si vous avez besoin de notifier des changements de propriétés.
    public class CompetitionViewModel : ViewModelBase
    {
        private readonly Competition competition;

        public string Name => $"{competition.Name}";
        public string Organisator => $"{competition.Organisator}";
        public ObservableCollection<MatchViewModel> Match_list {get;}
        public ObservableCollection<PlayerViewModel> Player_list { get; }
        

        public CompetitionViewModel(Competition Competition)
        {
            competition = Competition;  
            Player_list = new ObservableCollection<PlayerViewModel>(competition.Player_list);
            Match_list = new ObservableCollection<MatchViewModel>(Competition.Match_list);
        }
        public Competition Model => competition;

        public void UpdateName(string new_name)
        {
            competition.Name = new_name;
            OnPropertyChanged(nameof(Name)); 
        }
        public void UpdatePlayer_List(PlayerViewModel new_player)
        {
            competition.Player_list.Add(new_player);
            Player_list.Add(new_player);
        }
        public void UpdateMatch_List(MatchViewModel new_match)
        {
            competition.Match_list.Add(new_match);
            Match_list.Add(new_match);
        }
        public void UpdateOrganisator(string new_organisator)
        {
            competition.Organisator = new_organisator;
            OnPropertyChanged(nameof(Organisator)); 
        }
    }
}