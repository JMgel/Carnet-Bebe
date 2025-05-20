using CarnetBebe.Models;
using SQLite;
using System.Diagnostics;

namespace CarnetBebe.Services
{
    public interface IDatabaseService
    {
        public EventLogEntry[] GetEntries();
        public EventLogEntry[] GetDailyEntries();
        public EventLogEntry[] GetDailyEntries(EventType eventType);
        public EventLogEntry GetMoreRecentEntry(EventType eventType);
        public int SaveEntry(EventLogEntry entry);
        public int DeleteEntry(EventLogEntry entry);
    }


    public class DatabaseService : IDatabaseService
    {
        private const string DBName = "EventLogEntriesDB.db";
        private static readonly string s_DBPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DBName);
        private readonly SQLiteConnection _databaseConnection;
        private readonly static Dictionary<EventType, EventType> s_complementaryEventDictionnary = new()
        {
        {EventType.Peeing, EventType.Pooping },
        {EventType.Pooping, EventType.Peeing },
        {EventType.WakingUp, EventType.FallingAsleep },
        {EventType.FallingAsleep, EventType.WakingUp },
        {EventType.BreastfeedingLeft, EventType.BreastfeedingRight },
        {EventType.BreastfeedingRight, EventType.BreastfeedingLeft }
        };
        public DatabaseService()
        {
            _databaseConnection = new SQLiteConnection(s_DBPath);
            _databaseConnection.CreateTable<EventLogEntry>();
        }

        public EventLogEntry[] GetDailyEntries()
        {
            DateTime today = DateTime.Now.Date;
            DateTime tomorrow = today.AddDays(1);
            try
            {
                var collectedData = _databaseConnection.Table<EventLogEntry>().Where(e => e.Timestamp >= today && e.Timestamp < tomorrow).OrderByDescending(e => e.Timestamp);

                return collectedData.ToArray();
            }
            catch (SQLiteException ex)
            {
                Debug.WriteLine($"Database error: {ex}");

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unexpected error: {ex}");
            }
            return Array.Empty<EventLogEntry>();
        }
        public EventLogEntry[] GetDailyEntries(EventType eventType)
        {
            EventType complementaryEvent = s_complementaryEventDictionnary[eventType];
            DateTime today = DateTime.Now.Date;
            DateTime tomorrow = today.AddDays(1);
            try
            {
                var collectedData = _databaseConnection.Table<EventLogEntry>().Where(e => e.Timestamp >= today && e.Timestamp < tomorrow
                && (e.EventType == eventType || e.EventType == complementaryEvent));

                return collectedData.ToArray();
            }
            catch (SQLiteException ex)
            {
                Debug.WriteLine($"Database error: {ex}");
              
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unexpected error: {ex}");
            }
            return Array.Empty<EventLogEntry>();
        }

        public EventLogEntry GetMoreRecentEntry(EventType eventType)
        {
            EventType complementaryEvent = s_complementaryEventDictionnary[eventType];
            var moreRecentEntry =_databaseConnection.Table<EventLogEntry>().Where(e => e.EventType == eventType || e.EventType == complementaryEvent).OrderByDescending(e => e.Timestamp).Take(1).FirstOrDefault();
            if (moreRecentEntry == null) 
            {
                moreRecentEntry = EventLogEntry.DefaultEvent;
            }

            return moreRecentEntry;
        }

        public EventLogEntry[] GetEntries()
        {
            return _databaseConnection.Table<EventLogEntry>().ToArray();
        }

        public int SaveEntry(EventLogEntry entry)
        {
            return _databaseConnection.Insert(entry);
        }

        public int DeleteEntry(EventLogEntry entry)
        {
            return _databaseConnection.Delete(entry);
        }
    }
}
