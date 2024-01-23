using MyBlindSpot.Classes;
using MyBlindSpot.ViewModel;


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
        foreach (var storage in storages)
        {

            Border border = new Border
            {
                HeightRequest = 150,
                StrokeThickness = 0,
                Padding = new Thickness(0, 10, 0, 10),
                Content = new StackLayout
                {
                    new Image
                    {
                        Source = "fridge.png",
                        HeightRequest = 100
                    },
                    new Label
                    {
                        Text = "FRIDGE",
                        FontSize = 25,
                        HorizontalOptions = LayoutOptions.Center,
                        TextColor = Colors.Black,
                        FontFamily = "BlackItalic"
                    }
                }
            };

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += Open;
            border.GestureRecognizers.Add(tapGestureRecognizer);


            storagesGrid.Add(border);
        }
    }

    public StoragePage(StorageViewmodel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    private void Open(object sender, EventArgs e)
    {

        if (sender is Border border && border.BindingContext is StorageField storage)
        {

            Navigation.PushAsync(new InsideStorage(info,storage));
        }
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
}