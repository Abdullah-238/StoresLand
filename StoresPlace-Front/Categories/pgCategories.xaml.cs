using StoresPlace_Front.Stores;
using System.Globalization;

namespace StoresPlace_Front.Categories;

public partial class pgCategories : ContentPage
{
    CategoriesViewModel Categories = new CategoriesViewModel();
	public pgCategories()
	{
		InitializeComponent();

        BindingContext = Categories;
    }

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
        Categories.Load();
    }

}