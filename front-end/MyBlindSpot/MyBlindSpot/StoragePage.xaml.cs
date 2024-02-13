using MyBlindSpot.Classes;
using MyBlindSpot.ViewModel;
using System.Xml.XPath;


namespace MyBlindSpot;

public partial class StoragePage : ContentPage
{
    UserInformation info;
    public StoragePage(UserInformation user)
    {
        InitializeComponent();
        info = user;
        LoadStorages();
    }

    private void LoadStorages()
    {
        List<StorageField> storageFields = APICalls.LoadStorages(info);
        CreateGird(storageFields);

    }

    private void CreateGird(List<StorageField> storages)
    {
        storagesGrid.Children.Clear();

        for (int i = 1; i < storages.Count; i++)
        {
            storagesGrid.RowDefinitions.Add(new RowDefinition());
        }

        for (int i = 1; i < storages.Count; i++)
        {
          
            Border border = new Border
            {
                HeightRequest = 250,
                StrokeThickness = 0,
                Padding = new Thickness(0, 10, 0, 10),
                Content = new StackLayout
            {
            new Label
            {
                Text = "FRIDGE",
                FontSize = 25,
                HorizontalOptions = LayoutOptions.Center,
                TextColor = Colors.Black,
                FontFamily = "BlackItalic",
            },
            new Image
            {
                Source = "fridge.png",
                HeightRequest = 100
            },
            new Button
            {
                Text = "OPEN",
                WidthRequest = 80,
                HeightRequest = 40,
                Command = new Command(() => RedirectPage(storages[i-1]))
            }}};



            border.SetValue(Grid.RowProperty, i);
            storagesGrid.Children.Add(border);
        }


    }

    private void RedirectPage(StorageField sf)
    {
        Console.WriteLine();
        InsideStorage insideStorage = new InsideStorage(info, sf);
        Navigation.PushAsync(insideStorage);
    }

    public StoragePage(StorageViewmodel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    private void AddNewStorage_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new CreateStoragePage(info));
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        // Back to Main
        Navigation.PushAsync(new StartPage(info));
    }

    private void YourStorages_Click(object sender, EventArgs e)
    {
        Navigation.PushAsync(new StoragePage(info));
    }

    private void Camera_Click(object sender, EventArgs e)
    {
        Navigation.PushAsync(new TempCamera(info));
    }

    private void SpecificStorage_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new EditStoragePage(info));
    }

    private void ScanYourProducts_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ScanProductsPage(info));
    }

    // TAPPED EVENTS FOR THE RIGHT HOTBAR
    private void Camera_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new LoginPage()); // CHANGE
    }

    private void Storage_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new LoginPage()); // CHANGE
    }

    private void Back_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new LoginPage()); // CHANGE!
    }

    void Button_Clicked_1(System.Object sender, System.EventArgs e)
    {
    }
}