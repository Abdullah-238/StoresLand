
using StoresPlace.Global;
using StoresPlace;
using System.Globalization;

namespace StoresPlace_Front;

public partial class pgIntroUser : ContentPage
{
    public class Intro
    {
        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string Image { get; set; }

        public Intro(string title, string subTitle , string image)
        {
            this.Title = title;
            this.SubTitle = subTitle;
            this.Image = image;
        }
    }

    List<Intro> intro = new List<Intro>();
    
    public pgIntroUser()
    {
        InitializeComponent();

        _LoadIntroDetiles();
    }

   



    void _LoadIntroDetiles()
    {
        if (CultureInfo.CurrentCulture.Name.StartsWith("ar"))
        {


            intro = new List<Intro>
            {
            new Intro("«Õ’· ⁄·Ï «·⁄—Ê÷ Ê«·Œ’Ê„« " , "«—÷ «·„ «Ã— Ì⁄—÷ ·ﬂ √ÕœÀ «·⁄—Ê÷ Ê«·—„Ê“ «· —ÊÌÃÌ… ⁄‘«‰  ” „ ⁄ »√›÷· «·Œ’Ê„«  Ê«·’›ﬁ« " , "done_all"),
            new Intro("«·ﬂ· ›Ì Ê«Õœ" , "«—÷ «·„ «Ã— Ì⁄—÷ ·ﬂ ﬂ· «·„ «Ã— «·√Ê‰ ·«Ì‰ Ê«·„Õ·Ì…° Êﬂ„«‰ «·√”— «·„‰ Ã… „⁄  ’‰Ì›«   ”«⁄œﬂ ›Ì «·Ê’Ê· ··√›÷·" , "done_all"),
            new Intro("«›÷· «·’›ﬁ« " , "«ﬂ ‘› «·¬‰ √›÷· «·„ «Ã— «·„⁄—Ê÷… ··»Ì⁄° «·›—’… ﬁœ«„ﬂ „⁄ «—÷ «·„ «Ã—" , "")
            };
        }
        else
            intro = new List<Intro>
            {
            new Intro("offers and discounts" , "Stores land offers the latest deals and promo codes, ensuring you get the best discounts and exclusive offers." , "done_all"),
            new Intro("All in one" , "Stores land provides a comprehensive directory of all online, local stores, and home-based businesses, with various categories for easy browsing.", "done_all"),
            new Intro("Best deals","Discover the best opportunities to buy unique stores, everything you need is available in Stores land","")
            };

        //clvIntro.ItemsSource = intro; 
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new pgLogUp());
    }

    private async void btLogin_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new pgLoginPage());
    }

    private void Continue_Clicked(object sender, EventArgs e)
    {
        Application.Current.MainPage = new AppShell();
    }
}