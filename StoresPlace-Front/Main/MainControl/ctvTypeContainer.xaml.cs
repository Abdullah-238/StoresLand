
namespace StoresPlace_Front.Main.Controls;

public partial class ctvTypeContainer : ContentView
{
    public static readonly BindableProperty IconProperty = BindableProperty.Create(nameof(Icon), typeof(ImageSource), typeof(ctvTypeContainer));
    public ImageSource Icon
    {
        get => (ImageSource)GetValue(ctvTypeContainer.IconProperty);

        set => SetValue(ctvTypeContainer.IconProperty, value);
    }


    public static readonly BindableProperty CardTitleProperty = BindableProperty.Create(nameof(CardTitle), typeof(string), typeof(ctvTypeContainer), string.Empty);

    public string CardTitle
    {

        get => (string)GetValue(ctvTypeContainer.CardTitleProperty);
        set => SetValue(ctvTypeContainer.CardTitleProperty, value);
    }


    // ...

    public ctvTypeContainer()
	{
		InitializeComponent();

        this.BindingContext = This;

    }
}