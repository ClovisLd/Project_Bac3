using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Security.Cryptography.X509Certificates;
using Project_Bac3.Models;
using Project_Bac3.ViewModels;

namespace Project_Bac3.Services
{
    // This is a simple shared container that holds your players list
    // Both ViewModels will use THIS SAME list
    public class PlayerService
    {
        // Singleton pattern - ensures only ONE instance exists in your app
        private static PlayerService? _instance;
        public static PlayerService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new PlayerService();
                return _instance;
            }
        }

        // THE list of players - shared across your entire app
        public ObservableCollection<PlayerViewModel> Players { get; }



        // Private constructor - can only be called once by Instance
        private PlayerService()
        {
            Players = new ObservableCollection<PlayerViewModel>
            {
                new PlayerViewModel(new Player{Name="zefze", Age=43, Contact="zefzef", Description="zefzef", EloRating=444})
            };
        }

        public ObservableCollection<PlayerViewModel> GetPlayerList()
        {
            return Players;
        }
        // Simple method to add a player to the list
        public void AddPlayer(PlayerViewModel player)
        {
            bool added = false;
            for(int i=0; i < Players.Count; i++)
            {   
                if (player.EloRating > Players[i].EloRating)
                {
                    Players.Insert(i, player);
                    added = true;
                    break;
                }
            }

            if (!added)
            {
                Players.Add(player);
            }
        }

        public void RemovePlayer(PlayerViewModel player)
        {
            Players.Remove(player);
        }

        public PlayerViewModel ExistPlayer(String playername)
        {
            foreach(var player in Players)
            {
                if (player.Name == playername)
                {
                    return player;
                }
            }
            return null;
        }
    }
}