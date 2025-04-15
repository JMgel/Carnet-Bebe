using Carnet_Bebe.ViewModels;
using CarnetBebe.Services;
using System.ComponentModel;
using System.Diagnostics;

namespace CarnetBebe.View
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        private readonly IDatabaseService _databaseService;

        public MainPage(IDatabaseService databaseService)
        {
            InitializeComponent();
            _databaseService = databaseService;
            BindingContext = new MainViewModel(); 
       
        }
        public void OnCounterClicked()
        {
            count++;

            //if (count == 1)
            //    CounterBtn.Text = $"Clicked {count} time";
            //else
            //    CounterBtn.Text = $"Clicked {count} times";

            //SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
