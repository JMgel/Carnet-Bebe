using CarnetBebe.Models;
using SQLite;

namespace CarnetBebe.Services
{

    public interface IDatabaseService
    {
        public Task<List<EventLogEntry>> GetEntriesAsync();
        public Task<int> SaveEntryAsync(EventLogEntry entry);
        public Task<int> DeleteEntryAsync(EventLogEntry entry);
    }


    public class DatabaseService : IDatabaseService
    {
        private const string DBName = "EventLogEntriesDB.db";
        private static readonly string s_DBPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DBName);
        private readonly SQLiteAsyncConnection _databaseConnection;

        public DatabaseService()
        {
            _databaseConnection = new SQLiteAsyncConnection(s_DBPath);
            _databaseConnection.CreateTableAsync<EventLogEntry>().Wait();
        }

        public Task<List<EventLogEntry>> GetEntriesAsync()
        {
            return _databaseConnection.Table<EventLogEntry>().ToListAsync();
        }

        public Task<int> SaveEntryAsync(EventLogEntry entry)
        {
            return _databaseConnection.InsertAsync(entry);
        }

        public Task<int> DeleteEntryAsync(EventLogEntry entry)
        {
            return _databaseConnection.DeleteAsync(entry);
        }
    }
}
