using StoresPlace.Global;
using StoresPlace_Front.Strings;
using StoresPlace_Front.Global;
using StoresLand_API.Persons;
using StoresLand_API;


namespace StoresPlace_Front;

public partial class pgLogUp : ContentPage
{
	public pgLogUp()
	{
		InitializeComponent();
	}

  

    private async void btCreate_Clicked(object sender, EventArgs e)
    {

        if (string.IsNullOrEmpty(enEmail.Text) || string.IsNullOrEmpty(enPassword.Text)        ||
            string.IsNullOrEmpty(enName.Text)  || string.IsNullOrEmpty(enPhone.Text)    || 
            string.IsNullOrEmpty(EnRePassword.Text))
        {
            await DisplayAlert(null, AppStrings.Please_fill_all_fields_before_continue, AppStrings.Ok);

            return;
        }

        if (!clsValidation.ValidateEmail(enEmail.Text))
        {
            await DisplayAlert(AppStrings.Email, AppStrings.Please_Enter_Valid_Email, AppStrings.Ok);

            return;
        }


        if (await clsPerson.IsPersonExistsByEmail(enEmail.Text.Trim()))
        {
            await DisplayAlert(AppStrings.Email, AppStrings.Please_enter_another_email_this_email_is_Exist, AppStrings.Ok);

            return;
        }

        if (await clsPerson.IsPersonExistsByPhone(enPhone.Text.Trim()))
        {
            await DisplayAlert(AppStrings.Phone, AppStrings.Please_enter_another_phone_this_phone_is_Exist, AppStrings.Ok);
            return;
        }

        if (enPhone.Text.Trim().Length < 9 || !enPhone.Text.StartsWith("5"))
        {
            await DisplayAlert(AppStrings.Phone, AppStrings.Please_Enter_Valid_Phone, AppStrings.Ok);
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
     
        if (!ckTerms.IsChecked)
        {
            await DisplayAlert(AppStrings.Terms_Conditions, AppStrings.Accept_Terms, AppStrings.Ok);
            return;
        }


        Person person = await clsPerson.AddPerson(new Person(null, enName.Text, enPhone.Text, enEmail.Text, clsUtil.ComputeHash(enPassword.Text),true));


        if (person != null )
        {
            ctvActiveIndector1.IsRunning = true;

            await Task.Delay(10);

            Preferences.Default.Remove(clsAppConstants.Email);
            Preferences.Default.Remove(clsAppConstants.Password);

            Preferences.Default.Set(clsAppConstants.Email,clsUtil.Encrypt( person.Email));
            Preferences.Default.Set(clsAppConstants.Password,clsUtil.Encrypt(person.Password));


            clsGlobal.CurrentUser = person;

            Application.Current.MainPage = new AppShell();

        }
        else
        {
            await DisplayAlert(AppStrings.Error, AppStrings.Cant_Complete_your_register, AppStrings.Ok);
            return;
        }
    }

    private async void btSignIn_Clicked(object sender, EventArgs e)
    {

        await Navigation.PushAsync(new pgLoginPage());

        Navigation.RemovePage(this);

        
    }

    private void btContinue_Clicked(object sender, EventArgs e)
    {
        Application.Current.MainPage = new AppShell();

    }
}
