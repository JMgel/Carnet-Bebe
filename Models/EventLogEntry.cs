using CarnetBebe.Services;
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
            ImageSource = GetImagePath(EventType);
        }
        public static EventLogEntry DefaultEvent = new EventLogEntry
        {
            Id = 0,
            Timestamp = DateTime.MinValue,
            EventType = EventType.FallingAsleep,
        };


        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Indexed]
        public DateTime Timestamp { get; set; }
        [Indexed]
        public EventType EventType { get; set; }
        public string? ImageSource { get; init; }


        private static string GetImagePath(EventType eventType)
        {
            switch (eventType)
            {
                case EventType.FallingAsleep:
                    return ImagePaths.FallingAsleepPath;
                case EventType.WakingUp:
                    return ImagePaths.WakingUpPath;
                case EventType.BreastfeedingRight:
                    return ImagePaths.BreastfeedingRightPath;
                case EventType.BreastfeedingLeft:
                    return ImagePaths.BreastfeedingLeftPath;
                case EventType.Peeing:
                    return ImagePaths.PeeingPath;
                case EventType.Pooping:
                    return ImagePaths.PoopingPath;
                default:
                    throw new ArgumentOutOfRangeException(nameof(eventType), eventType, null);

            }
        }
    }
}
