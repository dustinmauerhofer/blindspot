using CommunityToolkit.Mvvm.ComponentModel;

namespace MyBlindSpot.ViewModel;

public partial class StorageViewmodel : ObservableObject
{
    [ObservableProperty]
    string text;
}