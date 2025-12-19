using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Project_Bac3.Models;
using Project_Bac3.ViewModels;

namespace Project_Bac3.Services
{
    public class CompetitionService
    {
        // --- Singleton Pattern ---
        private static CompetitionService? _instance;
        public static CompetitionService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CompetitionService();
                return _instance;
            }
        }

        public ObservableCollection<CompetitionViewModel> Competitions { get; }

        private CompetitionService()
        {
            Competitions = new ObservableCollection<CompetitionViewModel>();
            
        }


        public void AddCompetition(CompetitionViewModel competition)
        {
            Competitions.Add(competition);
        }

        public void RemoveCompetition(CompetitionViewModel competition)
        {
            if (Competitions.Contains(competition))
            {
                Competitions.Remove(competition);
            }
        }

        public CompetitionViewModel ExistCompetition(string competionname)
        {
            foreach(var competition in Competitions)
            {
                if(competition.Name == competionname)
                {
                    return competition;
                }
            }
            return null;
        }
    }
}