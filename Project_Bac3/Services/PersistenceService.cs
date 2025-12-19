using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Project_Bac3.Models;
using Project_Bac3.ViewModels;

namespace Project_Bac3.Services
{
    // A wrapper class to structure our JSON file
    public class SaveData
    {
        public List<Player> Players { get; set; } = new();
        public List<Match> Matches { get; set; } = new();
        public List<Competition> Competitions { get; set; } = new();
    }

    public static class PersistenceService
    {
        // Path: %AppData%/Local/app_data.json
        private static string FilePath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"project_bac3_data.json");

        public static void Save()
        {
            try
            {
                var data = new SaveData
                {
                    // Grab the raw Models from each ViewModel list
                    Players = PlayerService.Instance.Players.Select(vm => vm.Model).ToList(),
                    Matches = MatchService.Instance.Matches.Select(vm => vm.Model).ToList(),
                    Competitions = CompetitionService.Instance.Competitions.Select(vm => vm.Model).ToList()
                };

                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(data, options);
                File.WriteAllText(FilePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving data: {ex.Message}");
            }
        }

        public static void Load()
        {
            if (!File.Exists(FilePath)) return;

            try
            {
                string json = File.ReadAllText(FilePath);
                var data = JsonSerializer.Deserialize<SaveData>(json);

                if (data == null) return;

                // Load Players
                PlayerService.Instance.Players.Clear();
                foreach (var p in data.Players)
                    PlayerService.Instance.AddPlayer(new PlayerViewModel(p));

                // Load Matches
                MatchService.Instance.Matches.Clear();
                foreach (var m in data.Matches)
                    MatchService.Instance.Matches.Add(new MatchViewModel(m));

                // Load Competitions
                CompetitionService.Instance.Competitions.Clear();
                foreach (var c in data.Competitions)
                    CompetitionService.Instance.AddCompetition(new CompetitionViewModel(c));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading data: {ex.Message}");
            }
        }
    }
}