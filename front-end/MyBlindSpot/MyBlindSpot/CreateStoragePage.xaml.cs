using MyBlindSpot.Classes;
using MyBlindSpot.ViewModel;

namespace MyBlindSpot;

public partial class CreateStoragePage : ContentPage
{
    private List<CustomFrame> customFrames = new List<CustomFrame>();

    public CreateStoragePage()
    {
        InitializeComponent();
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        int xcord = 5;
        int ycord = 5;

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
                tapGestureRecognizer.Tapped += Tapped_Left;
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
    public CreateStoragePage(CreateStorageVM vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    private void StorageDone_Clicked(object sender, EventArgs e)
    {
        // Add Storage to Database Logic
        SaveStorage();
        Navigation.PushAsync(new StoragePage());
    }

    private void SaveStorage()
    {

        int id = 1;
        int MaxX = 0;
        int MaxY = 0;

        //getting max X, Y (very inefficent) O(N)

        foreach (var frame in customFrames)
        {
            if (frame.Column > MaxY)
            {
                MaxY = frame.Column;
            }
            if(frame.Row > MaxX)
            {
                MaxX = frame.Row;
            }
        }

        APICalls.SaveStorage(id, new StorageField(MaxX,MaxY));
    }

    private void Tapped_Left(object sender, TappedEventArgs e)
    {
        if (sender is CustomFrame tappedFrame && tappedFrame.Content is Border border)
        {

            if (border.BackgroundColor == Colors.Gray)
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
}
