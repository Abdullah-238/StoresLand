using StoresLand_API.Persons;
using StoresPlace.Global;
using StoresPlace_Front.Strings;

namespace StoresPlace_Front.AppSettings;

public partial class pgAppSettings : ContentPage
{
	public pgAppSettings()
	{
		InitializeComponent();

        _LoadMode();


    }

    void _LoadMode()
    {
        string Mode = Preferences.Default.Get("Mode", "");


        switch(Mode)
        {
            case "Default":
                ckDefulatMode.IsChecked = true;
                    break;
            case "Dark":
                ckDarkMode.IsChecked = true;
                break;
            case "Light":
                ckLigthMode.IsChecked = true;
                break;
            default:
                ckDefulatMode.IsChecked = true;
                break; 
        }
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {

        if (clsGlobal.CurrentUser == null)
        {

            this.IsVisible = false;

            await DisplayAlert(AppStrings.Sign_in, AppStrings.Please_sign_in_to_Complete_process, AppStrings.Ok);

            await Shell.Current.GoToAsync("..");

            return;
        }


        Task<bool> ConfirmCancel = DisplayAlert(AppStrings.Delete_Account, AppStrings.Are_you_sure_you_want_to_delete_your_account, AppStrings.Yes, AppStrings.Cancel);


        await ConfirmCancel;

        if (ConfirmCancel.Result)
        {
            if (await clsPerson.DeletePerson(clsGlobal.CurrentUser.PersonID))
            {
                Preferences.Default.Remove("Email");
                Preferences.Default.Remove("Password");

                MyTool.MyToast(AppStrings.User_Deleted_Successfully);

                clsGlobal.CurrentUser = null;

                App.Current.MainPage = new NavigationPage(new pgIntroUser());

            }

            else
                await DisplayAlert(AppStrings.Ok, AppStrings.User_was_not_deleted_Successfully_please_contact_with_us, AppStrings.Ok);

        }
    }

    private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        Preferences.Default.Remove("Mode");

        Application.Current.UserAppTheme = AppTheme.Dark;

        MyTool.MyToast(AppStrings.Dark);

        Preferences.Default.Set("Mode", "Dark");
    }


    private void ckLigthMode_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        Preferences.Default.Remove("Mode");

        Application.Current.UserAppTheme = AppTheme.Light;

        MyTool.MyToast(AppStrings.Light);

        Preferences.Default.Set("Mode", "Light");
    }

    private void ckDefulatMode_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        Preferences.Default.Remove("Mode");

        Application.Current.UserAppTheme = AppTheme.Unspecified;

        MyTool.MyToast(AppStrings.Default);

        Preferences.Default.Set("Mode", "Default");
    }

  
}