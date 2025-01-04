using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Internals;

namespace StoresPlace_Front.StoresForSell;

public partial class pgStoresForSellPreMain : ContentPage
{
	public pgStoresForSellPreMain()
	{
		InitializeComponent();
	}

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        contentPage.Opacity = 0;

        LoadingIndicator.IsVisible = true;
        LoadingIndicator.IsRunning = true;

        clsGlobal.TypeID = 1;

        await Shell.Current.GoToAsync($"StoresForSellMain/StoresForSell");
    }

    private async void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
    {
        contentPage.Opacity = 0;

        LoadingIndicator.IsVisible = true;
        LoadingIndicator.IsRunning = true;

        clsGlobal.TypeID = 1;

       // await Shell.Current.GoToAsync($"StoresForSellMain/StoresForSell");
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        LoadingIndicator.IsVisible = false;
        LoadingIndicator.IsRunning = false;
        contentPage.Opacity = 100;
    }
}