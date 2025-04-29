using SQLite;

namespace CarnetBebe.Models
{
    public enum EventType
    {
        FallingAsleep,
        WakingUp,
        BreastfeedingRight,
        BreastfeedingLeft,
        Peeing,
        Pooping,
    }
    public class EventLogEntry
    {
        public EventLogEntry() { }
        public EventLogEntry(EventType type)
        {
            EventType = type;
            Timestamp = DateTime.Now;
        }

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public EventType EventType { get; set; }
        public string ImageSource => ImagePaths[EventType];

        private static readonly Dictionary<EventType, string> ImagePaths = new Dictionary<EventType, string>
        {
        { EventType.FallingAsleep, "angrypoo" },
        { EventType.WakingUp, "angrypoo" },
        { EventType.BreastfeedingRight, "angrypoo" },
        { EventType.BreastfeedingLeft, "angrypoo" },
        { EventType.Peeing, "angrypoo" },
        { EventType.Pooping, "angrypoo" }
        };
    }
}
