using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using Project_Bac3.Models;
using Project_Bac3.ViewModels;

namespace Project_Bac3.Services
{
    public class MatchService
    {
        
        private static MatchService? _instance;
        public static MatchService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MatchService();
                return _instance;
            }
        }


        public ObservableCollection<Match> Matches { get; }



        // Private constructor - can only be called once by Instance
        private MatchService()
        {
            Matches = new ObservableCollection<Match>{};
        }

        public void NewMatch(PlayerViewModel player1, PlayerViewModel player2, List<String> Plays, double color)
        {
            PlayerService.Instance.RemovePlayer(player1);
            PlayerService.Instance.RemovePlayer(player2);

        }
    }
}