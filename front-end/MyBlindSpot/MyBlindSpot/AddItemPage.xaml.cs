using Microsoft.Maui.Graphics.Text;
using MyBlindSpot.Classes;
using MyBlindSpot.ViewModel;


namespace MyBlindSpot;

public partial class AddItemPage : ContentPage
{
    public AddItemPage()
    {
        InitializeComponent();

        var loadedStorages = APICalls.LoadStorages();

        SetGridLayout(loadedStorages.Count());
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
                        Command = new Command(() => ItemAdded_Click(this,new EventArgs()))
                    }
                }
            };

            mainGrid.Children.Add(loadedLabel);
        }

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

    private void ItemAdded_Click(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ChoosePlace());
    }
}