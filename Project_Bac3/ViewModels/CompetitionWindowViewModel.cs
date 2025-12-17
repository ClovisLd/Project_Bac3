using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized; // Required for CollectionChanged
using System.Linq; // Required for Search filtering
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Project_Bac3.Models;
using Project_Bac3.Services;

namespace Project_Bac3.ViewModels
{
    public partial class CompetitionWindowViewModel : ViewModelBase
    {
        // 1. DATA SOURCES
        // We get Competitions from YOUR Service
        public ObservableCollection<CompetitionViewModel> Competitions => CompetitionService.Instance.Competitions;
        
        // We get Players from PlayerService (so we can choose who to add to the competition)
        public ObservableCollection<PlayerViewModel> AllPlayers => PlayerService.Instance.Players;

        // 2. FILTERED LIST (This is what the UI displays)
        public ObservableCollection<CompetitionViewModel> FilteredCompetitions { get; } = new();

        public ObservableCollection<PlayerViewModel> Player_list { get; }

        // 3. SEARCH & STATE
        [ObservableProperty] private string searchText = "";
        [ObservableProperty] private bool isEditing = false;
        [ObservableProperty] private CompetitionViewModel selectedCompetition;

        // 4. EDIT BUFFERS (Temporary variables for the textboxes)
        [ObservableProperty] private string editName = "";
        [ObservableProperty] private string editOrganisator = "";
        
        // The player selected in the ComboBox to be added
        [ObservableProperty] private PlayerViewModel? playerToAdd;

        public CompetitionWindowViewModel()
        {
            // Initial load
            UpdateFilter();

            // Live Update: If a competition is added/removed in the Service, update the screen
            Competitions.CollectionChanged += OnCompetitionsChanged;
        }

        private void OnCompetitionsChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            UpdateFilter();
        }

        // --- SEARCH LOGIC ---
        [RelayCommand]
        public void UpdateFilter()
        {
            FilteredCompetitions.Clear();

            if (string.IsNullOrWhiteSpace(SearchText))
            {
                foreach (var c in Competitions) FilteredCompetitions.Add(c);
            }
            else
            {
                var query = SearchText.Trim();
                // Case-insensitive search on Name
                var matches = Competitions.Where(c => 
                    c.Name != null && 
                    c.Name.Contains(query, StringComparison.OrdinalIgnoreCase));
                
                foreach (var c in matches) FilteredCompetitions.Add(c);
            }
        }

        

        [RelayCommand]
        public void StartCreate()
        {
            // 1. Create a blank Model
            var newModel = new Competition 
            { 
                Name = "New Competition", 
                Organisator = "",
                Player_list = new List<PlayerViewModel>()
            };

            // 2. Create a ViewModel for it
            var newVM = new CompetitionViewModel(newModel);

            // 3. Set it as "Selected" so the popup binds to it
            SelectedCompetition = newVM;

            // 4. Clear buffers so the textboxes start empty
            EditName = "";
            EditOrganisator = "";

            // 5. Open the popup
            IsEditing = true;
        }

        // --- EXISTING EDIT COMMAND ---
        [RelayCommand]
        public void StartEdit(CompetitionViewModel competition)
        {
            SelectedCompetition = competition;
            
            // Load existing data
            EditName = competition.Name;
            EditOrganisator = competition.Organisator;
            
            IsEditing = true;
        }

        // --- UPDATED SAVE COMMAND ---
        [RelayCommand]
        public void SaveEdit()
        {
            if (SelectedCompetition != null)
            {
                // 1. Update the values in the object
                if (SelectedCompetition.Name != EditName) 
                    SelectedCompetition.UpdateName(EditName);
                
                if (SelectedCompetition.Organisator != EditOrganisator) 
                    SelectedCompetition.UpdateOrganisator(EditOrganisator);

                // 2. CHECK: Is this a NEW competition? 
                // If the global list doesn't have it, we must add it now.
                if (!Competitions.Contains(SelectedCompetition))
                {
                    CompetitionService.Instance.AddCompetition(SelectedCompetition);
                }
            }

            IsEditing = false;
            SelectedCompetition = null;
            PlayerToAdd = null;
        }

        // --- EDIT MODE: ADD PLAYER SUB-LOGIC ---
        [RelayCommand]
        public void AddPlayerToCompetition()
        {
            if (SelectedCompetition != null && PlayerToAdd != null)
            {
                // Check if the player is already in the list to avoid duplicates (optional but recommended)
                // We use .Any() because Player_list is a List<PlayerViewModel>
                bool alreadyExists = SelectedCompetition.Player_list.Any(p => p == PlayerToAdd);

                if (!alreadyExists)
                {
                    // USE YOUR SPECIFIC METHOD
                    SelectedCompetition.UpdatePlayer_List(PlayerToAdd);
                }

                // Reset the ComboBox selection
                PlayerToAdd = null; 
            }
        }

        // --- EDIT MODE: CANCEL ---
        [RelayCommand]
        public void CancelEdit()
        {
            IsEditing = false;
            SelectedCompetition = null;
            PlayerToAdd = null;
        }
    }
}