namespace StoresPlace_Front.Global.GlobalControl;

public partial class ctvActiveIndector : ContentView
{

    public static readonly BindableProperty IsRunningProperty
        = BindableProperty.Create(nameof(IsRunning), typeof(bool), typeof(ctvActiveIndector));
    public bool IsRunning
    {
        get => (bool)GetValue(ctvActiveIndector.IsRunningProperty);

        set => SetValue(ctvActiveIndector.IsRunningProperty, value);
    }

    public ctvActiveIndector()
	{
		InitializeComponent();

        this.BindingContext = This;

    }
}