using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Project_Bac3.Models;
using Project_Bac3.Services;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System; // Required for StringComparison

namespace Project_Bac3.ViewModels
{
    public partial class HomeWindowViewModel : ViewModelBase
    {
        public ObservableCollection<PlayerViewModel> Players => PlayerService.Instance.Players;
        public ObservableCollection<PlayerViewModel> Filtered_Players { get; } = new();

        [ObservableProperty] 
        private string searchText = "";
        [ObservableProperty] 
        private bool isEditing = false;
        [ObservableProperty] 
        private PlayerViewModel selectedPlayer;

        [ObservableProperty] 
        private string editName = "";
        [ObservableProperty] 
        private int editAge = 0;
        [ObservableProperty] 
        private string editContact = "";
        [ObservableProperty] 
        private string editDescription = "";

        public HomeWindowViewModel()
        {
            UpdateFilter();
        }


        [RelayCommand]
        public void UpdateFilter()
        {
            Filtered_Players.Clear();
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                foreach (var p in Players) Filtered_Players.Add(p);
            }
            else
            {
                var query = SearchText.Trim();
                var matches = Players.Where(p => 
                    p.Name != null && 
                    p.Name.Contains(query, StringComparison.OrdinalIgnoreCase));
                foreach (var p in matches) Filtered_Players.Add(p);
            }
        }

        // --- START EDITING ---
        [RelayCommand]
        public void StartEdit(PlayerViewModel player)
        {
            SelectedPlayer = player;
            
            // Copy all data to buffers
            EditName = player.Name;
            EditAge = int.Parse(player.Age); // Assuming Age is string in ViewModel but int in Model
            EditContact = player.Contact;
            EditDescription = player.Description;

            IsEditing = true;
        }

        // --- SAVE CHANGES ---
        [RelayCommand]
        public void SaveEdit()
        {
            if (SelectedPlayer != null)
            {
                // Call your custom update methods
                SelectedPlayer.UpdateName(EditName);
                SelectedPlayer.UpdateAge(EditAge);
                SelectedPlayer.UpdateContact(EditContact);
                SelectedPlayer.UpdateDescription(EditDescription);
            }
            IsEditing = false;
            SelectedPlayer = null;
        }

        [RelayCommand]
        public void CancelEdit()
        {
            IsEditing = false;
            SelectedPlayer = null;
        }
    }
}