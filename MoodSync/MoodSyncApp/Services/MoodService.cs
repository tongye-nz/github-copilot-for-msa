using MoodSyncApp.Models;

namespace MoodSyncApp.Services
{
    public interface IMoodService
    {
        Task<List<MoodEntry>> GetMoodHistoryAsync(string userId);
        Task<MoodEntry> AddMoodEntryAsync(MoodEntry entry);
        Task<MoodEntry?> GetTodaysMoodAsync(string userId);
        Task<List<MoodEntry>> GetFriendsMoodsAsync();
    }

    public class MoodService : IMoodService
    {
        private static readonly List<MoodEntry> _moodEntries = new()
        {
            new MoodEntry { Id = 1, UserId = "user1", MoodValue = MoodType.Happy, Note = "Great day at work!", CreatedAt = DateTime.Today.AddDays(-2), UserName = "You" },
            new MoodEntry { Id = 2, UserId = "user1", MoodValue = MoodType.Neutral, Note = "Just okay", CreatedAt = DateTime.Today.AddDays(-1), UserName = "You" },
            new MoodEntry { Id = 3, UserId = "friend1", MoodValue = MoodType.Sad, Note = "Feeling a bit down", CreatedAt = DateTime.Today, UserName = "Sarah" },
            new MoodEntry { Id = 4, UserId = "friend2", MoodValue = MoodType.Happy, Note = "Amazing weekend!", CreatedAt = DateTime.Today, UserName = "Mike" },
            new MoodEntry { Id = 5, UserId = "friend3", MoodValue = MoodType.Tired, Note = "Long week", CreatedAt = DateTime.Today, UserName = "Emma" }
        };

        public Task<List<MoodEntry>> GetMoodHistoryAsync(string userId)
        {
            var history = _moodEntries
                .Where(m => m.UserId == userId)
                .OrderByDescending(m => m.CreatedAt)
                .ToList();
            return Task.FromResult(history);
        }

        public Task<MoodEntry> AddMoodEntryAsync(MoodEntry entry)
        {
            entry.Id = _moodEntries.Max(m => m.Id) + 1;
            entry.CreatedAt = DateTime.Now;
            entry.UserId = "user1"; // Simplified for demo
            entry.UserName = "You";
            
            // Remove today's entry if it exists
            var existingToday = _moodEntries.FirstOrDefault(m => 
                m.UserId == entry.UserId && m.CreatedAt.Date == DateTime.Today);
            if (existingToday != null)
            {
                _moodEntries.Remove(existingToday);
            }
            
            _moodEntries.Add(entry);
            return Task.FromResult(entry);
        }

        public Task<MoodEntry?> GetTodaysMoodAsync(string userId)
        {
            var todaysMood = _moodEntries
                .FirstOrDefault(m => m.UserId == userId && m.CreatedAt.Date == DateTime.Today);
            return Task.FromResult(todaysMood);
        }

        public Task<List<MoodEntry>> GetFriendsMoodsAsync()
        {
            var friendsMoods = _moodEntries
                .Where(m => m.UserId != "user1" && m.CreatedAt.Date == DateTime.Today)
                .OrderBy(m => m.UserName)
                .ToList();
            return Task.FromResult(friendsMoods);
        }
    }
}
