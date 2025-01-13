using StoresPlace_Front.Settings.SettingsViewModel;
using StoresPlace_Front.Stores.StoresMain;

namespace StoresPlace_Front.Settings;

public partial class pgMySavedStores : ContentPage
{
    StoreViewModel SavedStores = new StoreViewModel();

    public pgMySavedStores()
	{
		InitializeComponent();
	}

    private void RefreshView_Refreshing(object sender, EventArgs e)
    {
        SavedStores.LoadSavedStores();

        refresh.IsRefreshing = false;
    }

 
    private void Button_Clicked(object sender, EventArgs e)
    {
        SavedStores.LoadMoreSavedStores();
    }

    private async void PersonStore_Loaded(object sender, EventArgs e)
    {
      

    }

    private void PersonStore_Appearing(object sender, EventArgs e)
    {
        SavedStores.LoadSavedStores();

        this.BindingContext = SavedStores;

        btnIsVisble.IsVisible = true;
    }
}