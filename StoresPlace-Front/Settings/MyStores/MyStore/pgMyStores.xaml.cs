using Microsoft.Maui.Controls;
using StoresPlace_Front.Settings.SettingsViewModel;
using System.Globalization;

namespace StoresPlace_Front.Settings.MyStores;

public partial class pgMyStores : ContentPage
{

    clsMyStoreViewModel clsMyStoreViewModel = new clsMyStoreViewModel();
	public pgMyStores()
    {
        InitializeComponent();
    }

    private void RefreshView_Refreshing(object sender, EventArgs e)
    {
        clsMyStoreViewModel.Load();

        refresh.IsRefreshing = false;
    }


    private void PersonStore_Appearing(object sender, EventArgs e)
    {
        clsMyStoreViewModel.Load();

        this.BindingContext = clsMyStoreViewModel;
    }
}