namespace Carnet_Bebe.Components;

public partial class ButtonsImageGroup : ContentPage
{
	public ButtonsImageGroup()
	{
        InitializeComponent();
        BindingContext = this;
	}

    public static readonly BindableProperty HeaderImageProperty =
        BindableProperty.Create(nameof(HeaderImage), typeof(ImageSource), typeof(ButtonsImageGroup));

    public static readonly BindableProperty Button1ImageProperty =
        BindableProperty.Create(nameof(Button1Image), typeof(ImageSource), typeof(ButtonsImageGroup));

    // Ajoutez toutes les propriétés nécessaires...

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


}