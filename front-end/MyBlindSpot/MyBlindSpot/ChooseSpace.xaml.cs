using MyBlindSpot.Classes;
using System.Xml.XPath;
using static System.Net.Mime.MediaTypeNames;

namespace MyBlindSpot;

public partial class ChooseSpace : ContentPage
{
    private List<CustomFrame> customFrames = new List<CustomFrame>();   

    public ChooseSpace()
    {
        InitializeComponent();
        int storageId = 0; // muss über die klasse gesetzt werden !!!!!! also die choosespace klasse
        var storage = APICalls.LoadSpecificStorage(storageId);
        CreateStorageInGrid(storage);
    }

    private void CreateStorageInGrid(Storage s)
    {
        int xcord = s.XCord;
        int ycord = s.YCord;

        storageGrid.RowDefinitions.Clear();
        storageGrid.ColumnDefinitions.Clear();

        // Create Grid
        for (int i = 0; i < xcord; i++)
        {
            storageGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
        }

        for (int i = 0; i < ycord; i++)
        {
            storageGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
        }

        // Add Storage Fields

        for (int row = 0; row < storageGrid.RowDefinitions.Count; row++)
        {
            for (int col = 0; col < storageGrid.ColumnDefinitions.Count; col++)
            {

                CustomFrame frame = new CustomFrame
                {
                    BackgroundColor = Colors.Transparent,
                    HeightRequest = 280,
                    WidthRequest = 150,
                    BorderColor = Colors.Transparent,
                    Margin = -30,
                    Content = new Border
                    {
                        StrokeThickness = 3,
                        Stroke = Colors.Black,
                        BackgroundColor = Color.FromHex("#42BBFF"),
                        Content = new StackLayout
                        {
                            VerticalOptions = LayoutOptions.Center,
                            Spacing = 10,
                            Children = {
                                new Label
                                {
                                    HorizontalOptions = LayoutOptions.Center,
                                    VerticalOptions = LayoutOptions.Center,
                                    FontSize = 50,
                                    Text = "+",
                                    TextColor = Colors.Black,
                                    FontFamily="BlackItalic"
                                }
                            
                            }
                        }
                    }
                };

                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += Tapped_Left; // muss noch eingebaut werden um die Farben zu ändern
                frame.GestureRecognizers.Add(tapGestureRecognizer);

                // Add the label to the grid
                Grid.SetRow(frame, row);
                frame.Row = row;
                Grid.SetColumn(frame, col);
                frame.Column = col;
                storageGrid.Children.Add(frame);
            }
        }

    }

    private void Tapped_Left(object sender, TappedEventArgs e)
    {
        if (sender is CustomFrame tappedFrame && tappedFrame.Content is Border border)
        {
             
            if(border.BackgroundColor == Colors.Gray)
            {
                border.BackgroundColor = Color.FromHex("#42BBFF");
                //Delete from List
                customFrames.Remove(tappedFrame);
                return;
            }
            border.BackgroundColor = Colors.Gray;
            //Add to List
            customFrames.Add(tappedFrame);
        }
    }


    private async void ContinueToFrontBack_Clicked(object sender, EventArgs e)
    {
        (int, int) location = GetProductLocation();
        Navigation.PushAsync(new ChooseFrontBack(location));
    }

    private (int, int) GetProductLocation()
    {
        //TODO !!!
        //verarbeite die information der ausgewählten labels so, dass sie dann vom backend gelesen werden können
        throw new NotImplementedException();
    }

    private void Camera_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new TempCamera());
    }

    private void Storage_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new StoragePage());
    }

    private void Back_Tapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new ChoosePlace());
    }
}