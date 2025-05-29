using CarnetBebe.ViewModels;

namespace CarnetBebe.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel viewmodel)
        {
            InitializeComponent();
            BindingContext = viewmodel;
        }
    }
}
