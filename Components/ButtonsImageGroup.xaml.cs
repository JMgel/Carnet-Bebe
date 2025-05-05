using System.Diagnostics;
using System.Windows.Input;

namespace Carnet_Bebe.Components;

public partial class ButtonsImageGroup : ContentView
{
	public ButtonsImageGroup()
	{
        InitializeComponent();
        this.BindingContextChanged += (s, e) => Content.BindingContext = BindingContext;
    }

    public static readonly BindableProperty HeaderImageProperty =
        CreateBindableProperty<ImageSource>(nameof(HeaderImage));


    public static readonly BindableProperty Button1ImageProperty =
        CreateBindableProperty<ImageSource>(nameof(Button1Image));

    public static readonly BindableProperty Button1TextProperty =
    CreateBindableProperty<string>(nameof(Button1Text));

    public static readonly BindableProperty Button1CommandProperty = CreateBindableProperty<ICommand>(nameof(Button1Command));

    public static readonly BindableProperty Button2ImageProperty =
  CreateBindableProperty<ImageSource>(nameof(Button2Image));

    public static readonly BindableProperty Button2TextProperty =
 CreateBindableProperty<string>(nameof(Button2Text));
    
    public static readonly BindableProperty Button2CommandProperty =
        CreateBindableProperty<Command>((nameof(Button2Command)));


    public ImageSource HeaderImage
    {
        get => (ImageSource)GetValue(HeaderImageProperty);
        set => SetValue(HeaderImageProperty, value);
    }

    public ImageSource Button1Image
    {
        get => (ImageSource)GetValue(Button1ImageProperty);
        set => SetValue(Button1ImageProperty, value);
    }
    public string Button1Text
    {
        get => (string)GetValue(Button1TextProperty);
        set => SetValue(Button1TextProperty, value);
    }

    public ICommand Button1Command
    {
        get => (ICommand)GetValue(Button1CommandProperty);
        set => SetValue(Button1CommandProperty, value);
    }

    public ImageSource Button2Image
    {

        get => (ImageSource)GetValue(Button2ImageProperty);
        set => SetValue(Button2ImageProperty, value);

    }

    public string Button2Text
    {
        get => (string)GetValue(Button2TextProperty);
        set => SetValue(Button2TextProperty, value);
    }

    public ICommand Button2Command
    {
        get => (ICommand)GetValue(Button2CommandProperty);
        set => SetValue(Button2CommandProperty, value);
    }

    private void Button1_Clicked(object sender, EventArgs e)
    {
        Debug.WriteLine("Click détecté !");
        if (Button1Command?.CanExecute(null) == true)
            Button1Command.Execute(null);
    }
    private static BindableProperty CreateBindableProperty<T>(string propertyName)
    {
        return BindableProperty.Create(propertyName, typeof(T), typeof(ButtonsImageGroup), default(T));
    }

}