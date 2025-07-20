using CarnetBebe.Models;
using CarnetBebe.Services;
using CarnetBebe.Views;
using System.ComponentModel;

namespace CarnetBebe.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        #region Command
        public Command ButtonFallingAsleep { get; }
        public Command ButtonWakingUp { get; }
        public Command ButtonBreastfeedingRight { get; }
        public Command ButtonBreastfeedingLeft { get; }
        public Command ButtonPeeing { get; }
        public Command ButtonPooping { get; }

        public Command DeleteEventCommand { get; }

        public Command GoToSleepingPageCommand { get; }
        public Command ResetTimeCommand { get; }
        #endregion

        #region Labels

        private string _lastBreastFeedingInfo = string.Empty;
        private string _dailyAmoutOfBreastFeeding = string.Empty;
        private string _lastSleepingInfo = DateTime.Now.Hour.ToString();
        private string _dailyAwakeTime = "0";
        private string _timeLastDiaper = string.Empty;
        private string _dailyAmoutOfDiaper = string.Empty;
        private EventLogEntry[] _allEvents = [];
        private TimeSpan _selectedTime = DateTime.Now - DateTime.Today;

        public string LastBreastFeedingInfo
        {
            get => _lastBreastFeedingInfo;
            set
            {
                if (_lastBreastFeedingInfo != value)
                {
                    _lastBreastFeedingInfo = value;
                    OnPropertyChanged(nameof(LastBreastFeedingInfo));
                }
            }
        }

        public string DailyAmoutOfBreastFeeding
        {
            get => _dailyAmoutOfBreastFeeding;
            set
            {
                if (_dailyAmoutOfBreastFeeding != value)
                {
                    _dailyAmoutOfBreastFeeding = value;
                    OnPropertyChanged(nameof(DailyAmoutOfBreastFeeding));
                }
            }
        }

        public string LastSleepingInfo
        {
            get => _lastSleepingInfo;
            set
            {
                if (_lastSleepingInfo != value)
                {
                    _lastSleepingInfo = value;
                    OnPropertyChanged(nameof(LastSleepingInfo));
                }
            }
        }

        public string DailyAwakeTime
        {
            get => _dailyAwakeTime;
            set
            {
                if (_dailyAwakeTime != value)
                {
                    _dailyAwakeTime = value;
                    OnPropertyChanged(nameof(DailyAwakeTime));
                }
            }
        }

        public string TimeLastDiaper
        {
            get => _timeLastDiaper;
            set
            {
                if (_timeLastDiaper != value)
                {
                    _timeLastDiaper = value;
                    OnPropertyChanged(nameof(TimeLastDiaper));
                }
            }
        }

        public string DailyAmoutOfDiaper
        {
            get => _dailyAmoutOfDiaper;
            set
            {
                if (_dailyAmoutOfDiaper != value)
                {
                    _dailyAmoutOfDiaper = value;
                    OnPropertyChanged(nameof(DailyAmoutOfDiaper));
                }
            }
        }

        #endregion

        public EventLogEntry[] AllEvents
        {
            get => _allEvents;
            set
            {
                if (_allEvents != value)
                {
                    _allEvents = value;
                    OnPropertyChanged(nameof(AllEvents));
                }
            }
        }

        public TimeSpan SelectedTime
        {
            get => _selectedTime;
            set
            {
                if (_selectedTime != value)
                {
                    _selectedTime = value;
                    OnPropertyChanged(nameof(SelectedTime));
                }
            }
        }

        private readonly IDatabaseService _databaseService;

        public MainViewModel(IDatabaseService databaseService)
        {
            ButtonFallingAsleep = new Command(AddEntryFallingAsleep);
            ButtonWakingUp = new Command(AddEntryWakingUp);
            ButtonBreastfeedingRight = new Command(AddEntryBreastfeedingRight);
            ButtonBreastfeedingLeft = new Command(AddEntryBreastfeedingLeft);
            ButtonPeeing = new Command(AddEntryPeeing);
            ButtonPooping = new Command(AddEntryPooping);
            GoToSleepingPageCommand = new Command(async ()=> await GoToSleepingPageClicked());
            _databaseService = databaseService;
            DeleteEventCommand = new Command<EventLogEntry>(DeleteEvent);
            ResetTimeCommand = new Command(ResetTime);
            AllEvents = _databaseService.GetDailyEntries().OrderByDescending(e => e.Timestamp).ToArray();
            UpdatesAllLabels();
        }
        private void ResetTime()
        {
            SelectedTime = DateTime.Now - DateTime.Today;
        }
        private void AddEntryFallingAsleep()
        {
            HandleNewEntry(EventType.FallingAsleep);
        }

        private void AddEntryWakingUp()
        {
            HandleNewEntry(EventType.WakingUp);
        }

        private void AddEntryBreastfeedingRight()
        {
            HandleNewEntry(EventType.BreastfeedingRight);
        }

        private void AddEntryBreastfeedingLeft()
        {
            HandleNewEntry(EventType.BreastfeedingLeft);
        }

        private void AddEntryPeeing()
        {
            HandleNewEntry(EventType.Peeing);
        }

        private void AddEntryPooping()
        {
            HandleNewEntry(EventType.Pooping);
        }

        private void HandleNewEntry(EventType eventType)
        {
            AddEntry(eventType);
            UpdatesLabels(eventType);
            AllEvents = _databaseService.GetDailyEntries();
        }
        private void AddEntry(EventType evenType)
        {
            _databaseService.SaveEntry(new EventLogEntry(evenType, SelectedTime));
        }

        #region Update Labels
        private void UpdatesAllLabels()
        {
            UpdateSleepingLabels();
            UpdateBreastFeedingLabels();
            UpdateDiapersLabels();
        }
        private void UpdatesLabels(EventType eventType)
        {
            switch (eventType)
            {
                case EventType.FallingAsleep:
                case EventType.WakingUp:
                    UpdateSleepingLabels();
                    break;
                case EventType.BreastfeedingRight:
                case EventType.BreastfeedingLeft:
                    UpdateBreastFeedingLabels();
                    break;
                case EventType.Peeing:
                case EventType.Pooping:
                    UpdateDiapersLabels();
                    break;
            }
        }
        private void UpdateSleepingLabels()
        {
            var dailyEntries = _databaseService.GetDailyEntries(EventType.WakingUp).OrderBy(e=> e.Timestamp).ToArray();
            if (dailyEntries != null && dailyEntries.Length > 0)
            {
                int totalDaily = dailyEntries.Length;
                var moreRecent = dailyEntries[totalDaily-1];
                LastSleepingInfo = $"{moreRecent.Timestamp:HH:mm}";
                TimeSpan allAwakeTime = TimeSpan.Zero;
                for (int i = 0; i < totalDaily-1; i += 2)
                {
                    var diff = dailyEntries[i + 1].Timestamp - dailyEntries[i].Timestamp; allAwakeTime += diff;
                }
                DailyAwakeTime = Math.Round(allAwakeTime.TotalMinutes).ToString();
            }
        }
        private void UpdateBreastFeedingLabels()
        {
            var dailyBreastFeeding = _databaseService.GetDailyEntries(EventType.BreastfeedingLeft);
            if (dailyBreastFeeding != null && dailyBreastFeeding.Length > 0)
            {
                var moreRecent = dailyBreastFeeding.Max(e => e.Timestamp);
                LastBreastFeedingInfo = $"{moreRecent:HH:mm}";
                int totalDaily = dailyBreastFeeding.Length;
                int leftAmout = dailyBreastFeeding.Count(d => d.EventType == EventType.BreastfeedingLeft);

                DailyAmoutOfBreastFeeding = $"{leftAmout} + {totalDaily - leftAmout} = {totalDaily}";
            }
        }
        private void UpdateDiapersLabels()
        {
            var dailyDiapers = _databaseService.GetDailyEntries(EventType.Peeing);

            if (dailyDiapers != null && dailyDiapers.Length > 0)
            {
                var moreRecent = dailyDiapers.Max(e => e.Timestamp);
                TimeLastDiaper = $"{moreRecent:HH:mm}";
                int totalDaily = dailyDiapers.Length;
                int peeingAmount = dailyDiapers.Count(d => d.EventType == EventType.Peeing);

                DailyAmoutOfDiaper = $"{peeingAmount} + {totalDaily - peeingAmount} = {totalDaily}";
            }
        }
        #endregion
        private void DeleteEvent(EventLogEntry eventToDelete)
        {
            if (AllEvents.Contains(eventToDelete))
            {
                if (_databaseService.DeleteEntry(eventToDelete) > 0)
                {
                    AllEvents = _databaseService.GetDailyEntries();
                    UpdatesAllLabels();
                }
            }
        }
        private async Task GoToSleepingPageClicked()
        {
            await Shell.Current.GoToAsync(nameof(SleepingPage));
        }
        
    }
}
