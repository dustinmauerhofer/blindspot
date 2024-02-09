using Microsoft.Maui.Graphics.Text;
using MyBlindSpot.Classes;
using MyBlindSpot.ViewModel;


namespace MyBlindSpot;

public partial class AddItemPage : ContentPage
{
    StorageInformation storageInformation;
    UserInformation info;
    public AddItemPage(StorageInformation st, UserInformation user)
    {
        InitializeComponent();
        storageInformation = st;
        info = user;
        var loadedStorages = APICalls.LoadStorages(info);

        SetGridLayout(loadedStorages.Count());

        //only for testing purpse
        if (loadedStorages.Count() == 0)
            loadedStorages.Add(new StorageField("", 4, 4));
        //


        foreach (var storage in loadedStorages)
        {
            Border loadedLabel = new Border
            {
                HeightRequest = 200,
                WidthRequest = 150,
                StrokeThickness = 0,
                HorizontalOptions = LayoutOptions.Center,

                Content = new StackLayout
                {
                    new Image
                    {
                        HeightRequest=100,
                        Source="fridge.png", //hier sollte man eig das passende bild zum storagetyp ausgeben

                    },
                    new Label
                    {
                        FontSize=20,
                        Text="TEST", // Text=storage.Name läd keinen Namen rein, deshalb wurde das Label auch nicht angezeigt. – Vincent
                        HorizontalOptions= LayoutOptions.Center,
                        TextColor= Colors.Black,
                        FontFamily="BlackItalic",
                        Margin=10,

                    },
                    new Button
                    {
                        Text="Add",
                        WidthRequest=80,
                        HeightRequest=45,
                        FontFamily="BlackItalic",
                        BackgroundColor=Color.FromHex("#CCCCCC"),
                        TextColor=Colors.Black,
                        FontSize=18,
                        Command = new Command(() => SendItem(storage))
                    }
                }
            };

            mainGrid.Children.Add(loadedLabel);
        }

    }

    public void SendItem(StorageField sf)
    {
        Navigation.PushAsync(new ChoosePlace(storageInformation, sf, info));
    }

    private void SetGridLayout(int v)
    {
        int numberOfItems = v;

        mainGrid.RowDefinitions.Clear();
        mainGrid.ColumnDefinitions.Clear();

        for (int i = 0; i < numberOfItems; i++)
        {
            mainGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
        }

        for (int i = 0; i < numberOfItems; i++)
        {
            mainGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
        }


    }

    public AddItemPage(AddItemVM vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    private void Back_Click(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}