namespace StoresPlace_Front.GlobalPages;

public partial class pgUpdatePage : ContentPage
{
	public pgUpdatePage()
	{
		InitializeComponent();
	}

    protected override bool OnBackButtonPressed()
    {
        return true;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
       var storeUrl = DeviceInfo.Platform == DevicePlatform.iOS
           ? "https://apps.apple.com/us/app/your-app-id"
           : "https://play.google.com/store/apps/details?id=com.yourcompany.yourapp";

       await Launcher.OpenAsync(storeUrl);
    }
}