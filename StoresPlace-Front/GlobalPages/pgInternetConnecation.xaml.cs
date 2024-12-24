namespace StoresPlace_Front.GlobalPages;

public partial class pgInternetConnecation : ContentPage
{
	public pgInternetConnecation()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        if (Connectivity.Current.NetworkAccess == NetworkAccess.Internet)
        {
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert(Strings.AppStrings.Internt, Strings.AppStrings.You_don_t_have_access_to_internet, Strings.AppStrings.Ok);
        }
    }

    protected override bool OnBackButtonPressed()
    {
        return true;
    }
}