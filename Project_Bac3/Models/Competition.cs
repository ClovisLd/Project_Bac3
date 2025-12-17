using System.Collections.Generic;
using Project_Bac3.Models;
using Project_Bac3.ViewModels;

namespace Project_Bac3.Models
{
    public class Competition
    {
        public string Name {get; set;} = string.Empty;
        public List<PlayerViewModel> Player_list {get; set;} = new List<PlayerViewModel>();
        public string Organisator {get; set;} = string.Empty;
        public List<MatchViewModel> Match_list {get; set;} = new List<MatchViewModel>();
    }
}