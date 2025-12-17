using System;
using System.Collections.Generic;
using System.Numerics;
using Project_Bac3.ViewModels;

namespace Project_Bac3.Models
{
    public class MatchViewModel : ViewModelBase
    {
        public string Winning_player {get; set;} = string.Empty;
        public string Loosing_player {get; set;} = string.Empty;
        public List<String> Plays {get; set;} = new List<string>();
    }
}