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
        
        private static MatchService? instance;
        public static MatchService Instance
        {
            get
            {
                if (instance == null)
                    instance = new MatchService();
                return instance;
            }
        }


        public ObservableCollection<MatchViewModel> Matches { get; }



        // Private constructor - can only be called once by Instance
        private MatchService()
        {
            Matches = new ObservableCollection<MatchViewModel>{};
        }

        public void NewMatch(PlayerViewModel player1, PlayerViewModel player2, List<String> Plays, bool draw_, CompetitionViewModel comp)
        {
            Console.WriteLine($"{player1.Name} et {player2.Name}");
            PlayerService.Instance.RemovePlayer(player1);
            PlayerService.Instance.RemovePlayer(player2);

            double actualScore1;
            double actualScore2;
            const int K = 64;
            
            double r1 = player1.EloRating;
            double r2 = player2.EloRating;

            double expected1 = 1.0 / (1.0 + Math.Pow(10, (r2 - r1) / 400.0));
            double expected2 = 1.0 / (1.0 + Math.Pow(10, (r1 - r2) / 400.0));

            if (draw_){actualScore1 = actualScore2 = 0.5;}
            else
            {
                actualScore1 = 1.0;
                actualScore2 = 0;
            }

            player1.UpdateElo((int)Math.Round(r1 + K * (actualScore1 - expected1)));
            player2.UpdateElo((int)Math.Round(r2 + K * (actualScore2 - expected2)));

            PlayerService.Instance.AddPlayer(player1);
            PlayerService.Instance.AddPlayer(player2);

            if(comp == null)
            {
                Matches.Add(new MatchViewModel(new Match{Winning_player=player1.Name, Loosing_player=player2.Name, Plays=Plays}));
            }
            else
            {
                comp.UpdateMatch_List(new MatchViewModel(new Match{Winning_player=player1.Name, Loosing_player=player2.Name, Plays=Plays}));
            }

        }
    }
}