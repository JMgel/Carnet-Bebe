using CarnetBebe.ViewModels;

namespace CarnetBebe.View
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
