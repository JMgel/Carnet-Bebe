using CarnetBebe.Models;
using CarnetBebe.Services;

namespace CarnetBebe.ViewModels
{
    public class MainViewModel 
    {
        private readonly IDatabaseService _databaseService;

        public Command Button1Command { get; }
        public Command ButtonFallingAsleep { get; }
        public Command ButtonWakingUp { get; }
        public Command ButtonBreastfeedingRight { get; }
        public Command ButtonBreastfeedingLeft { get; }
        public Command ButtonPeeing { get; }
        public Command ButtonPooping { get; }

        public string LabelText = "Bonjour";
        public MainViewModel(IDatabaseService databaseService)
        {
            Button1Command = new Command(ExecuteButton1);
            ButtonFallingAsleep = new Command(AddEntryFallingAsleep);
            ButtonWakingUp = new Command(AddEntryWakingUp);
            ButtonBreastfeedingRight = new Command(AddEntryBreastfeedingRight);
            ButtonBreastfeedingLeft = new Command(AddEntryBreastfeedingLeft);
            ButtonPeeing = new Command(AddEntryPeeing);
            ButtonPooping = new Command(AddEntryPooping);
            _databaseService = databaseService;
        }

        private void AddEntryFallingAsleep()
        {
            _databaseService.SaveEntryAsync(new EventLogEntry(EventType.FallingAsleep));
        }

        private void AddEntryWakingUp()
        {
            _databaseService.SaveEntryAsync(new EventLogEntry(EventType.WakingUp));
        }

        private void AddEntryBreastfeedingRight()
        {
            _databaseService.SaveEntryAsync(new EventLogEntry(EventType.BreastfeedingRight));
        }

        private void AddEntryBreastfeedingLeft()
        {
            _databaseService.SaveEntryAsync(new EventLogEntry(EventType.BreastfeedingLeft));
        }

        private void AddEntryPeeing()
        {
            _databaseService.SaveEntryAsync(new EventLogEntry(EventType.Peeing));
        }

        private void AddEntryPooping()
        {
            _databaseService.SaveEntryAsync(new EventLogEntry(EventType.Pooping));
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
