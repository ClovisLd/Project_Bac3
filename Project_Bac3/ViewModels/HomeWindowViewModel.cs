using System;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Project_Bac3.Models;
using Project_Bac3.Services;
using Project_Bac3.Views;
using System.Linq;

namespace Project_Bac3.ViewModels
{
    public partial class HomeWindowViewModel : ViewModelBase
    {
        // This points directly to the list in your Service.
        // No sorting, no extra logic. Just a direct link.
        public ObservableCollection<PlayerViewModel> Players => PlayerService.Instance.Players;

        public ObservableCollection<PlayerViewModel> Filtered_Players { get; } = new();

        [ObservableProperty]
        private string searchText = "";
        
        public HomeWindowViewModel()
        {
            UpdateFilter();
        }
        
        [RelayCommand]
        public void UpdateFilter()
        {
            // 1. Clear the current view
            Filtered_Players.Clear();

            // 2. Check if search is empty
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                // Add everyone back
                foreach (var player in Players)
                {
                    Filtered_Players.Add(player);
                }
            }
            else
            {
                // 3. Search logic (Case Insensitive)
                var query = SearchText.Trim();
                
                var matches = Players.Where(p => 
                    p.Name != null && 
                    p.Name.Contains(query, StringComparison.OrdinalIgnoreCase));

                foreach (var player in matches)
                {
                    Filtered_Players.Add(player);
                }
            }

            Console.WriteLine($"Search for '{SearchText}' found {Filtered_Players.Count} results.");
        }
    }
}
