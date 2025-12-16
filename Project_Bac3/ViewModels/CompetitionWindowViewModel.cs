using System;
using System.Runtime.Serialization;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Project_Bac3.Models;
using Project_Bac3.Services;

namespace Project_Bac3.ViewModels
{
    public partial class CompetitionWindowViewModel : ViewModelBase
    {
        [ObservableProperty]
        private string hello = "hello wolrd";
        
    }
}