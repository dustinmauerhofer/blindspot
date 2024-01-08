using MyBlindSpot.Classes;

namespace MyBlindSpot;

public partial class ChoosePlace : ContentPage
{
    CustomFrame lastFrame = null;
    StorageInformation storageInformation;
    StorageField storageField;
	public ChoosePlace(StorageInformation st,StorageField sf)
	{
		InitializeComponent();
        storageInformation = st;
        storageField = sf;
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        int xcord = storageField.XCord;
        int ycord = storageField.YCord;

        selectionGrid.RowDefinitions.Clear();
        selectionGrid.ColumnDefinitions.Clear();

        // Create Grid
        for (int i = 0; i < xcord; i++)
        {
            selectionGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
        }

        for (int i = 0; i < ycord; i++)
        {
            selectionGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
        }

        // Add Storage Fields

        for (int row = 0; row < selectionGrid.RowDefinitions.Count; row++)
        {
            for (int col = 0; col < selectionGrid.ColumnDefinitions.Count; col++)
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
                tapGestureRecognizer.Tapped += Tapped_Left;
                frame.GestureRecognizers.Add(tapGestureRecognizer);

                // Add the label to the grid
                Grid.SetRow(frame, row);
                frame.Row = row;
                Grid.SetColumn(frame, col);
                frame.Column = col;
                selectionGrid.Children.Add(frame);
            }
        }
    }

    private void Tapped_Left(object sender, TappedEventArgs e)
    {
        if (sender is CustomFrame tappedFrame && tappedFrame.Content is Border border)
        {

            if (border.BackgroundColor == Colors.Gray)
            {
                border.BackgroundColor = Color.FromHex("#42BBFF");
                
                return;
            }

            if (lastFrame == null)
                lastFrame = tappedFrame;
            
            if(lastFrame != tappedFrame)
            {
                if (lastFrame.Content is Border lastBorder)
                {
                    lastBorder.BackgroundColor = Color.FromHex("#42BBFF");
                }
                lastFrame = tappedFrame;
            }

            border.BackgroundColor = Colors.Gray;

            storageInformation.Location =(tappedFrame.Column, tappedFrame.Row);
        }
    }

    private void ContinueToSpace_Clicked(object sender, EventArgs e)
    {
        
        Navigation.PushAsync(new ChooseSpace(storageInformation));
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
        Navigation.PushAsync(new CreateStoragePage());
    }
}