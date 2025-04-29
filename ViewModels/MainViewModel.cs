using CarnetBebe.Services;

namespace CarnetBebe.ViewModels
{
    public class MainViewModel 
    {
        private readonly IDatabaseService _databaseService;
        public Command Button1Command { get; }
        public Command Button2Command { get; }

        public MainViewModel(IDatabaseService databaseService)
        {
            Button1Command = new Command(ExecuteButton1);
            Button2Command = new Command(ExecuteButton2);
            _databaseService = databaseService;
        }


        private void ExecuteButton1()
        {
            //Test
        }

        private void ExecuteButton2()
        {
            //Test2
        }
    }
}
