namespace StoresPlace_Front.AppSettings.Control;

public partial class ctvSettings : ContentView
{
    public static readonly BindableProperty IconProperty = BindableProperty.Create(nameof(Icon), typeof(ImageSource), typeof(ctvSettings));
    public ImageSource Icon
    {
        get => (ImageSource)GetValue(IconProperty);

        set => SetValue(IconProperty, value);
    }


    public static readonly BindableProperty CardTitleProperty = BindableProperty.Create(nameof(CardTitle), typeof(string), typeof(ctvSettings), string.Empty);

    public string CardTitle
    {

        get => (string)GetValue(CardTitleProperty);
        set => SetValue(CardTitleProperty, value);
    }
    public ctvSettings()
	{
		InitializeComponent();

        BindingContext = This;

    }
}