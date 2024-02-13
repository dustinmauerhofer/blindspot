using Microsoft.Maui.Graphics.Text;
using MyBlindSpot.Classes;

namespace MyBlindSpot;

public partial class InsideStorage : ContentPage
{
    UserInformation info;
    StorageField storageField;

    public InsideStorage(UserInformation user, StorageField sf)
    {
        InitializeComponent();
        user = info;
        storageField = sf;
        PullNewItems();
    }

    private void PullNewItems()
    {
        var items = APICalls.LoadeItems(1, info);
        var labels = new List<String>();
        var title = new Grid();
        title.Add(new Label()
        {
            Text = "YOUR ITEMS",
            HorizontalTextAlignment = TextAlignment.Center,
            FontSize = 50,
            TextColor = Color.FromRgba("#42BBFF"),
            FontFamily = "BlackItalic",
        });

        var addButton = new Button() { Text = "ADD ITEM" };
        var deleteButton = new Button() { Text = "DELETE" };

        var footer = new Grid() { ColumnDefinitions = { new ColumnDefinition(), new ColumnDefinition() } };
        footer.Add(addButton);
        footer.Add(deleteButton, 1, 0);

        var takeMeBackbtn = new Button()
        {
            Text = "TAKE ME BACK",

            WidthRequest = 300,
            HeightRequest = 70,
            FontSize = 30,
            Margin = new Thickness(30, 50, 30, 50),
            BackgroundColor = Color.FromRgba("#42BBFF"),            
        };
        takeMeBackbtn.Clicked += async (sender, args) => { await Navigation.PopAsync(); };

        var navigation = new Grid();
        navigation.Add(takeMeBackbtn);


        var listView = new ListView();

        foreach (var item in items)
            labels.Add(item.Name);

        listView.ItemsSource = labels;


        //Java.Lang.IllegalStateException Nachricht = The specified child already has a parent. You must call removeView() on the child's parent first

        

        Content = new StackLayout
        {
            Children = { title, listView, footer, navigation}
        };

        var layout = Content as StackLayout;

        //foreach (var item in layout.Children)
        //{
        //    Console.WriteLine(item);
        //}
    }
}