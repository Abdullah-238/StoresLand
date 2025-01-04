using StoresPlace.Global;
using StoresPlace_Front.Strings;
using StoresPlace_Front.Global;
using StoresLand_API.Persons;
using StoresLand_API;
namespace StoresPlace_Front.AppSettings;

public partial class pgProfile : ContentPage
{
    Person customer = clsGlobal.CurrentUser;

    public pgProfile()
	{
		InitializeComponent();

        this.BindingContext = customer;
	}

   

    private async void btCreate_Clicked(object sender, EventArgs e)
    {
        if (!clsValidation.ValidateEmail(enEmail.Text))
        {
            await DisplayAlert(AppStrings.Email, AppStrings.Please_Enter_Valid_Email, AppStrings.Ok);

            return;
        }


        if (string.IsNullOrEmpty(enEmail.Text) || string.IsNullOrEmpty(enName.Text) || string.IsNullOrEmpty(enPhone.Text))
        {
            await DisplayAlert(null, AppStrings.Please_fill_all_fields_before_continue, AppStrings.Ok);

            return;
        }

        if (await clsPerson.IsPersonExistsByEmail(enEmail.Text.Trim()) && customer.Email != enEmail.Text)
        {
            await DisplayAlert(AppStrings.Email, AppStrings.Please_enter_another_email_this_email_is_Exist, AppStrings.Ok);
            return;
        }

        if (await clsPerson.IsPersonExistsByPhone(enPhone.Text.Trim()) && customer.Phone != enPhone.Text)
        {
            await DisplayAlert(AppStrings.Phone, AppStrings.Please_enter_another_phone_this_phone_is_Exist, AppStrings.Ok);
            return;
        }

        if (enPhone.Text.Trim().Length < 9 || !enPhone.Text.StartsWith("5"))
        {
            await DisplayAlert(AppStrings.Phone, AppStrings.Please_Enter_Valid_Phone, AppStrings.Ok);
            return;
        }


            customer.Phone = enPhone.Text.Trim();
            customer.Email = enEmail.Text.Trim();
            customer.Name = enName.Text.Trim();

           
            if (!string.IsNullOrEmpty(enPassword.Text))
            {
                if (enPassword.Text.Length < 8)
                {
                    await DisplayAlert(AppStrings.Password, AppStrings.please_enter_a_valid_password, AppStrings.Ok);
                    return;
                }
                else
                    customer.Password = clsUtil.ComputeHash(enPassword.Text.Trim());
            }
            else
                customer.Password = clsGlobal.CurrentUser.Password;

        var person = await clsPerson.UpdatePerson(customer.PersonID, customer);

        if (person != null)
		{
            clsGlobal.CurrentUser = customer;

            MyTool.MyToast(AppStrings.Data_Saved_Successfully);

            Preferences.Default.Remove(clsAppConstants.Email);
            Preferences.Default.Remove(clsAppConstants.Password);

            Preferences.Default.Set(clsAppConstants.Email, clsUtil.Encrypt(customer.Email));
            Preferences.Default.Set(clsAppConstants.Password, clsUtil.Encrypt(customer.Password));

        }
        else
		{
            await DisplayAlert(AppStrings.Error, AppStrings.Data_saved_failed, AppStrings.Ok);

            MyTool.MyToast(AppStrings.Data_saved_failed);

        }

    }

    private async void  ContentPage_Loaded(object sender, EventArgs e)
    {
       //if (clsGlobal.CurrentUser != null)
       // {
       //     enPhone.Text =            customer.Phone;
       //     enEmail.Text =            customer.Email;
       //     enName.Text =             customer.Namee;
       //     //imgCustomerImage.Source = customer.Photo ;
       // }

        if (clsGlobal.CurrentUser == null)
        {
            btCreate.IsEnabled = false;

            this.IsVisible = false;

            await DisplayAlert(AppStrings.Sign_in, AppStrings.Please_sign_in_to_Complete_process, AppStrings.Ok);

            await Shell.Current.GoToAsync("..");

            return;
        }

    }


}