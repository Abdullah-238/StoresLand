using StoresLand_API;
using StoresLand_API.Persons;
using StoresPlace_Front.Global;
using StoresPlace_Front.Strings;

namespace StoresPlace_Front.Login;

public partial class pgResetPassword : ContentPage
{
    int Count = 0; 
    public pgResetPassword()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        if (!clsValidation.ValidateEmail(enEmail.Text))
        {
            await DisplayAlert(AppStrings.Email, AppStrings.Please_Enter_Valid_Email, AppStrings.Ok);
            return;
        }

        if (string.IsNullOrEmpty(enEmail.Text))
        {
            await DisplayAlert(null, AppStrings.Please_fill_all_fields_before_continue, AppStrings.Ok);
            return;
        }

        if (!await clsPerson.IsPersonExistsByEmail(enEmail.Text.Trim()))
        {
            await DisplayAlert(AppStrings.Email, AppStrings.Please_Enter_Valid_Email, AppStrings.Ok);
            return;
        }
          


        DateTime dtCash = Preferences.Default.Get(clsAppConstants.LastTimeRestPassword, DateTime.Now);

        ctvActiveIndector1.IsRunning = true;

        await Task.Delay(100);


        Random random = new Random();

        int randomInt = random.Next(1000, 9999);

        string TempCode = randomInt.ToString();

        string Message = $"We received a request to reset your password. please use the following Temporary Code : {TempCode}  \n\n" +
              $"·ﬁœ  ·ﬁÌ‰« ÿ·»« ·≈⁄«œ…  ⁄ÌÌ‰ ﬂ·„… «·„—Ê— «·Œ«’… »ﬂ " + $"«·—Ã«¡ ≈œŒ«· «·—„“ «· «·Ì · €ÌÌ— ﬂ·„… «·„—Ê— : {TempCode}";



        clsUtil.Send_Message(Message, "ResetPassword", enEmail.Text.Trim());

        ctvActiveIndector1.IsRunning = false;

        await DisplayAlert(AppStrings.Done, AppStrings.code_has_been_sent_Please_check_your_email, AppStrings.Ok);

        Preferences.Default.Set(clsAppConstants.LastTimeRestPassword, DateTime.Now);

        await Navigation.PushAsync(new pgResetPsswordAndChangePassword(TempCode, enEmail.Text.Trim()));

        ctvActiveIndector1.IsRunning = false;

        btnSend.IsEnabled = false;

       





    }
}