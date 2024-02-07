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
        PullItems();
	}

    private void PullItems()
    {
		var items = APICalls.LoadeItems(1,info);

		for (int i = 0; i < items.Count; i++)
		{
			itemGrid.RowDefinitions.Add(new RowDefinition());
		}
		for (int i = 0;i < items.Count; i++) 
		{
			Label lb =new Label();
			lb.Text = items[i].Name;

			lb.SetValue(Grid.RowProperty,i);
			itemGrid.Add(lb);
		}
    }
}