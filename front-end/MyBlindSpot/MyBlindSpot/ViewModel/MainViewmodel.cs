using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlindSpot.ViewModel
{
    public partial class MainViewmodel : ObservableObject
    {
        // [ObservableProperty]

        [RelayCommand]
        async Task Tap(string s)
        {
            await Shell.Current.GoToAsync("StorageViewmodel");
        }
    }
}
