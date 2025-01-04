using StoresLand_API.Persons;
using StoresLand_API;
using StoresPlace_Front.Strings;

namespace StoresPlace_Front.Login;

public partial class pgResetPsswordAndChangePassword : ContentPage
{
    int Count = 0;
	string _tempCode = string.Empty;
    string _email = string.Empty;

    public pgResetPsswordAndChangePassword(string TempCode , string Email)
	{
		InitializeComponent();

        _tempCode = TempCode;
        _email = Email;
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {

        if (Count > 20)
        {
            await DisplayAlert(null, AppStrings.Please_try_again_later, AppStrings.Ok);
            return;
        }

        Count++;



        if (string.IsNullOrEmpty(enCode.Text))
        {
            await DisplayAlert(null, AppStrings.Please_fill_all_fields_before_continue, AppStrings.Ok);
            return;
        }

        if (enCode.Text.Trim() != _tempCode.Trim())
        {
            await DisplayAlert(AppStrings.Password, AppStrings.please_enter_a_valid_password, AppStrings.Ok);
            return;
        }

        btnSendCode.IsEnabled = false;
        enCode.IsEnabled = false;
        enPassword.IsEnabled = true;
        EnRePassword.IsEnabled = true;
        btnUpdatePassword.IsEnabled = true;
    }
    private async void Button_Clicked(object sender, EventArgs e)
    {
      
        if (string.IsNullOrEmpty(enPassword.Text) || string.IsNullOrEmpty(EnRePassword.Text))
        {
            await DisplayAlert(null, AppStrings.Please_fill_all_fields_before_continue, AppStrings.Ok);

            return;
        }

        if (enPassword.Text.Length < 8)
        {
            await DisplayAlert(AppStrings.Password, AppStrings.please_enter_a_valid_password, AppStrings.Ok);
            return;
        }

        if (enPassword.Text != EnRePassword.Text)
        {
            await DisplayAlert(AppStrings.Password, AppStrings.Password_not_matched, AppStrings.Ok);
            return;
        }

        ctvActiveIndector1.IsRunning = true;

        bool isUpdated = await clsPerson.UpdatePass(_email, clsUtil.ComputeHash(enPassword.Text));

        if (isUpdated)
        {

            ctvActiveIndector1.IsRunning = false;

            await DisplayAlert(AppStrings.Password, AppStrings.Data_Saved_Successfully, AppStrings.Ok);

            btnUpdatePassword.IsEnabled = false;
        }

        else
        {
            await DisplayAlert(AppStrings.Error, AppStrings.Data_saved_failed, AppStrings.Ok);
            return;
        }
    }

   
}