using System;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Project_Bac3.Models;
using Project_Bac3.Services;
using Project_Bac3.Views;

namespace Project_Bac3.ViewModels
{
    public partial class HomeWindowViewModel : ViewModelBase
    {
        // This points directly to the list in your Service.
        // No sorting, no extra logic. Just a direct link.
        public ObservableCollection<PlayerViewModel> Players => PlayerService.Instance.Players;

        public HomeWindowViewModel()
        {
            
        }
    }
}
