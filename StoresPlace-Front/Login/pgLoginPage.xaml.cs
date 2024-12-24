using StoresPlace_Front.Strings;
using StoresPlace_Front.Global;
using System.Net.Mail;
using RestSharp;
using StoresLand_API.Persons;
using StoresLand_API;


namespace StoresPlace_Front;

public partial class pgLoginPage : ContentPage
{
    public pgLoginPage()
    {
        InitializeComponent();

        enEmail_TextChanged(null, null);
    }

    private void enEmail_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (string.IsNullOrEmpty(enEmail.Text) || string.IsNullOrEmpty(enPassword.Text))
        {
            btLogin.IsEnabled = false;
        }
        else
            btLogin.IsEnabled = true;
    }





    private async void btLogin_Clicked(object sender, EventArgs e)
    {



        if (!clsValidation.ValidateEmail(enEmail.Text))
        {

            await DisplayAlert(AppStrings.Email, AppStrings.Please_Enter_Valid_Email, AppStrings.Ok);

            return;
        }

        if (enPassword.Text.Length < 8)
        {

            await DisplayAlert(AppStrings.Password, AppStrings.please_enter_a_valid_password, AppStrings.Ok);


            return;
        }

        Person Customer = await clsPerson.FindPersonByEmailAndPassword(enEmail.Text.Trim(), clsUtil.ComputeHash(enPassword.Text.Trim()));

        if (Customer != null)
        {


            ctvActiveIndector1.IsRunning = true;

            await Task.Delay(10);

            clsGlobal.CurrentUser = Customer;

            Preferences.Default.Remove(clsAppConstants.Email);
            Preferences.Default.Remove(clsAppConstants.Password);

            Preferences.Default.Set(clsAppConstants.Email, clsUtil.Encrypt(Customer.Email));
            Preferences.Default.Set(clsAppConstants.Password, clsUtil.Encrypt(Customer.Password));

            Application.Current.MainPage = new AppShell();


        }
        else
        {

            await DisplayAlert(AppStrings.Password, AppStrings.Email_or_password_not_correct_please_check_then_try_again, AppStrings.Ok);

        }

    }


    private async void Button_Clicked(object sender, EventArgs e)
    {


        await Navigation.PushAsync(new pgLogUp());

        Navigation.RemovePage(this);

    }


    private void Button_Clicked_1(object sender, EventArgs e)
    {
        //LoadingIndicator.IsVisible = true;
        //LoadingIndicator.IsRunning = true;

        //this.IsBusy = true;

        Application.Current.MainPage = new AppShell();



    }


}