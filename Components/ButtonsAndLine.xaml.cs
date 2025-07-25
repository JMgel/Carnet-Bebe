using System.Windows.Input;

namespace CarnetBebe.Components;

public partial class ButtonsAndLine : ContentView
{
    public ButtonsAndLine()
    {
        InitializeComponent();
    }

    public static readonly BindableProperty LabelText1Property = CreateBindableProperty<string>(nameof(LabelText1));

    public static readonly BindableProperty LabelText2Property = CreateBindableProperty<string>(nameof(LabelText2));

    public static readonly BindableProperty Button1ImageProperty =
        CreateBindableProperty<ImageSource>(nameof(Button1Image));

    public static readonly BindableProperty Button1TextProperty = CreateBindableProperty<string>(nameof(Button1Text));

    public static readonly BindableProperty Button1CommandProperty = CreateBindableProperty<Command>(nameof(Button1Command));

    public static readonly BindableProperty Button2ImageProperty = CreateBindableProperty<ImageSource>(nameof(Button2Image));

    public static readonly BindableProperty Button2TextProperty =  CreateBindableProperty<string>(nameof(Button2Text));

    public static readonly BindableProperty Button2CommandProperty = CreateBindableProperty<Command>((nameof(Button2Command)));

    public string LabelText1
    {
        get => (string)GetValue(LabelText1Property);
        set => SetValue(LabelText1Property, value);
    }
    public string LabelText2
    {
        get => (string)GetValue(LabelText2Property);
        set => SetValue(LabelText2Property, value);
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

    private static BindableProperty CreateBindableProperty<T>(string propertyName)
    {
        return BindableProperty.Create(propertyName, typeof(T), typeof(ButtonsAndLine), default(T));
    }
}