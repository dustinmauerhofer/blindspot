using Microsoft.Maui.Graphics.Text;
using MyBlindSpot.Classes;
using MyBlindSpot.ViewModel;


namespace MyBlindSpot;

public partial class AddItemPage : ContentPage
{
    StorageInformation storageInformation;
    public AddItemPage(StorageInformation st)
    {
        InitializeComponent();
        storageInformation = st;
        var loadedStorages = APICalls.LoadStorages();

        SetGridLayout(loadedStorages.Count());

        //only for testing purpse
        if(loadedStorages.Count() == 0)
            loadedStorages.Add(new StorageField("",10, 10));
        //


        foreach (var storage in loadedStorages)
        {
            Border loadedLabel = new Border
            {
                HeightRequest = 200,
                StrokeThickness = 0,

                Content = new StackLayout
                {
                    new Image
                    {
                        HeightRequest=100,
                        Source="fridge.png" //hier sollte man eig das passende bild zum storagetyp ausgeben
                    },
                    new Label
                    {
                        FontSize=25,
                        Text=storage.Name,
                        HorizontalOptions= LayoutOptions.Center,
                        TextColor= Colors.Black,
                        FontFamily="BlackItalic",

                    },
                    new Button
                    {
                        Text="Add",
                        Margin = new Thickness(20,10,20,0),
                        FontFamily="BlackItalic",
                        BackgroundColor=Color.FromHex("#CCCCCC"),
                        TextColor=Colors.Black,
                        FontSize=22,
                        Command = new Command(() => SendItem(storage))
                    }
                }
            };

            mainGrid.Children.Add(loadedLabel);
        }

    }

    public void SendItem(StorageField sf)
    {
        Navigation.PushAsync(new ChoosePlace(storageInformation,sf));
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

    private void Back_Click(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}