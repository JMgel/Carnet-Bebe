using CarnetBebe.Services;

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
        }

        private void OnCounterClicked(object sender, EventArgs e)
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
