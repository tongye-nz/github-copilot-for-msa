namespace MoodSyncApp.Models
{
    public class MoodEntry
    {
        public int Id { get; set; }
        public string UserId { get; set; } = "user1"; // Simplified for demo
        public MoodType MoodValue { get; set; }
        public string? Note { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UserName { get; set; } = "You";
    }

    public enum MoodType
    {
        Happy = 1,      // 😊
        Neutral = 2,    // 😐
        Sad = 3,        // 😔
        Angry = 4,      // 😠
        Tired = 5       // 😴
    }

    public static class MoodExtensions
    {
        public static string GetEmoji(this MoodType mood)
        {
            return mood switch
            {
                MoodType.Happy => "😊",
                MoodType.Neutral => "😐",
                MoodType.Sad => "😔",
                MoodType.Angry => "😠",
                MoodType.Tired => "😴",
                _ => "😐"
            };
        }

        public static string GetDescription(this MoodType mood)
        {
            return mood switch
            {
                MoodType.Happy => "Happy/Great",
                MoodType.Neutral => "Neutral/Okay",
                MoodType.Sad => "Sad/Down",
                MoodType.Angry => "Frustrated/Angry",
                MoodType.Tired => "Tired/Exhausted",
                _ => "Neutral"
            };
        }

        public static string GetWeatherIcon(this MoodType mood)
        {
            return mood switch
            {
                MoodType.Happy => "☀️",
                MoodType.Neutral => "⛅",
                MoodType.Sad => "🌧️",
                MoodType.Angry => "⛈️",
                MoodType.Tired => "🌫️",
                _ => "⛅"
            };
        }
    }
}
