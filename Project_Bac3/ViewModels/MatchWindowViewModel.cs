using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Avalonia.Automation;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Project_Bac3.Models;
using Project_Bac3.Services;
namespace Project_Bac3.ViewModels
{
    public partial class MatchWindowViewModel : ViewModelBase
    {
        private List<string> plays = new List<string>{};
        private string current_player ="white";

        [ObservableProperty]private string w_Player = string.Empty;
        [ObservableProperty]private string b_Player = string.Empty;
        [ObservableProperty]private string play = string.Empty;
        [ObservableProperty]private string bg_color = "White";
        [ObservableProperty]private string fg_color = "Black";
        [ObservableProperty]private string w_error = string.Empty;
        [ObservableProperty]private string b_error = string.Empty;
        [ObservableProperty]private bool draw_ = false;

        [ObservableProperty] private string comp_name = string.Empty; 
        [ObservableProperty] private string competitionError = string.Empty;

        [RelayCommand]
        private void Matchbutton()
        {
            PlayerViewModel w_exist = PlayerService.Instance.ExistPlayer(W_Player);
            PlayerViewModel b_exist = PlayerService.Instance.ExistPlayer(B_Player);
            CompetitionViewModel comp = CompetitionService.Instance.ExistCompetition(Comp_name);
            if( Comp_name == "")
            {
                if( w_exist == null ){
                    W_error = "Player does not exist";
                    Console.WriteLine("1");
                    
                }else if ( b_exist == null){
                    B_error = "Player does not exist";
                    Console.WriteLine("2");
                }
                else
                {
                    if(Draw_ == true)
                    {MatchService.Instance.NewMatch(w_exist, b_exist, plays, false, null);}
                    else if (current_player == "white")
                    {
                        MatchService.Instance.NewMatch(w_exist, b_exist, plays, false, null);
                    }
                    else
                    {
                        MatchService.Instance.NewMatch(b_exist, w_exist, plays, false, null);
                    }
                    Console.WriteLine("3");
                    W_Player = B_Player = W_error = B_error = CompetitionError = string.Empty;
                }   
            }else if( comp != null)
            {
                if( w_exist == null ){
                    W_error = "Player does not exist";
                    Console.WriteLine("1");
                    
                }else if ( b_exist == null){
                    B_error = "Player does not exist";
                    Console.WriteLine("2");
                }
                else
                {
                    if(Draw_ == true)
                    {MatchService.Instance.NewMatch(w_exist, b_exist, plays, false, null);}
                    else if (current_player == "white")
                    {
                        MatchService.Instance.NewMatch(w_exist, b_exist, plays, false, null);
                    }
                    else
                    {
                        MatchService.Instance.NewMatch(b_exist, w_exist, plays, false, null);
                    }
                    Console.WriteLine("3");
                    W_Player = B_Player = W_error = B_error = CompetitionError= string.Empty;
                }
            }
            else
            {
                CompetitionError = "Cette Competion n'existe pas";
            }
        }

        [RelayCommand]
        private void Playbutton()
        {
            plays.Add(Play);
            foreach (var e in plays) {Console.Write($"{e} ");}
            Console.WriteLine("");
            if(current_player == "white")
            {
                Bg_color = "White";
                Fg_color = "Black";
                current_player = "black";
            }
            else
            {
                Bg_color = "Black";
                Fg_color = "White";
                current_player = "white";
            }
            Play= string.Empty;
        }
        public MatchWindowViewModel()
        {
            
        }
    }

}