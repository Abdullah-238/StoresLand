
using StoresPlace_Front.Global;


//using StoresPlace.Login;
using StoresPlace_Front.Strings;

namespace StoresPlace_Front;

public partial class pgSettings : ContentPage
{

    public pgSettings()
	{
		InitializeComponent();


        Settings.BindingContext =  clsGlobal.CurrentUser;
	}

    private  void Button_Clicked(object sender, EventArgs e)
    {

       
        Preferences.Default.Remove(clsAppConstants.Email);
        Preferences.Default.Remove(clsAppConstants.Password);

        clsGlobal.CurrentUser = null;

        Connectivity.ConnectivityChanged -= clsGlobal. CheckInitialConnectivity;


        App.Current.MainPage = new NavigationPage(new pgIntroUser());
        
    }

   

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {

        if (clsGlobal.CurrentUser == null)
        {
            await AppShell.Current.DisplayAlert(AppStrings.Error, AppStrings.Please_sign_in_to_Complete_process, AppStrings.Ok);
            return;
        }


        ctvActiveIndector1.IsRunning = true;

        await Shell.Current.GoToAsync("Profile");
    }

    private async void TapGestureRecognizer_Tapped_1(object sender, TappedEventArgs e)
    {
        if (clsGlobal.CurrentUser == null)
        {
            await AppShell.Current.DisplayAlert(AppStrings.Error, AppStrings.Please_sign_in_to_Complete_process, AppStrings.Ok);
            return;
        }


        ctvActiveIndector1.IsRunning = true;

        await Shell.Current.GoToAsync("MyStores");
    }

    private async void TapGestureRecognizer_Tapped_2(object sender, TappedEventArgs e)
    {
        if (clsGlobal.CurrentUser == null)
        {
            await AppShell.Current.DisplayAlert(AppStrings.Error, AppStrings.Please_sign_in_to_Complete_process, AppStrings.Ok);
            return;
        }


        ctvActiveIndector1.IsRunning = true;

        await Shell.Current.GoToAsync("Complain");
    }

    private async void TapGestureRecognizer_Tapped_3(object sender, TappedEventArgs e)
    {
        if (clsGlobal.CurrentUser == null)
        {
            await AppShell.Current.DisplayAlert(AppStrings.Error, AppStrings.Please_sign_in_to_Complete_process, AppStrings.Ok);
            return;
        }


        ctvActiveIndector1.IsRunning = true;

        await Shell.Current.GoToAsync($"ItemsPrice");
    }

    private async void TapGestureRecognizer_Tapped_4(object sender, TappedEventArgs e)
    {

        if (clsGlobal.CurrentUser == null)
        {
            await AppShell.Current.DisplayAlert(AppStrings.Error, AppStrings.Please_sign_in_to_Complete_process, AppStrings.Ok);
            return;
        }

        ctvActiveIndector1.IsRunning = true;

        await Shell.Current.GoToAsync("AppSettings");
    }

    private void Settings_Appearing(object sender, EventArgs e)
    {
        ctvActiveIndector1.IsRunning = false;

        if (clsGlobal.CurrentUser == null)
        {
            btnSignIn.Text = AppStrings.Sign_in;
        }

    }

    private async void TapGestureRecognizer_Tapped_5(object sender, TappedEventArgs e)
    {
        if (clsGlobal.CurrentUser == null)
        {
            await AppShell.Current.DisplayAlert(AppStrings.Error, AppStrings.Please_sign_in_to_Complete_process, AppStrings.Ok);
            return;
        }

        ctvActiveIndector1.IsRunning = true;

        await Shell.Current.GoToAsync($"AddNewStore");
    }

    private async void TapGestureRecognizer_Tapped_6(object sender, TappedEventArgs e)
    {
        if (clsGlobal.CurrentUser == null)
        {
            await AppShell.Current.DisplayAlert(AppStrings.Error, AppStrings.Please_sign_in_to_Complete_process, AppStrings.Ok);
            return;
        }
        ctvActiveIndector1.IsRunning = true;

        await Shell.Current.GoToAsync($"MySavedStores");
    }
}