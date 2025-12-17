using System;
using System.Collections.Generic;
namespace Project_Bac3.Models
{
    public class Match
    {
        public string Winning_player {get; set;} = string.Empty;
        public string Loosing_player {get; set;} = string.Empty;
        public List<String> Plays {get; set;} = new List<string>();
    }
}