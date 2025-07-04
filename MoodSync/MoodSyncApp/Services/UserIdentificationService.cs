using MoodSyncApp.Models;

namespace MoodSyncApp.Services
{
    public interface IUserIdentificationService
    {
        Task<UserIdentificationResult> IdentifyUserAsync(string imageData);
        Task<List<MockContact>> GetMockContactsAsync();
    }

    public class UserIdentificationResult
    {
        public bool UserRecognized { get; set; }
        public MockContact? IdentifiedUser { get; set; }
        public double Confidence { get; set; }
        public string Message { get; set; } = "";
        public MoodType SuggestedMood { get; set; }
        public string SuggestedMoodReason { get; set; } = "";
    }

    public class MockContact
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public string Avatar { get; set; } = "";
        public string Relationship { get; set; } = "";
        public string LastSeenContext { get; set; } = "";
        public DateTime LastSeen { get; set; }
        public List<string> RecentActivities { get; set; } = new();
        public string CurrentStatus { get; set; } = "";
        public MoodType TypicalMood { get; set; }
    }

    public class MockUserIdentificationService : IUserIdentificationService
    {
        private readonly Random _random = new();
        private readonly List<MockContact> _mockContacts = new()
        {
            new MockContact
            {
                Id = 1,
                Name = "Sarah Johnson",
                Email = "sarah.johnson@email.com",
                Avatar = "👩‍💼",
                Relationship = "Colleague",
                LastSeenContext = "Team meeting yesterday",
                LastSeen = DateTime.Now.AddDays(-1),
                RecentActivities = { "Finished quarterly report", "Started new marketing project", "Attended leadership training" },
                CurrentStatus = "Working on Q3 planning",
                TypicalMood = MoodType.Happy
            },
            new MockContact
            {
                Id = 2,
                Name = "Mike Chen",
                Email = "mike.chen@email.com", 
                Avatar = "👨‍💻",
                Relationship = "Close Friend",
                LastSeenContext = "Coffee last weekend",
                LastSeen = DateTime.Now.AddDays(-3),
                RecentActivities = { "Launched new app", "Started gym routine", "Planning vacation" },
                CurrentStatus = "Preparing for product demo",
                TypicalMood = MoodType.Happy
            },
            new MockContact
            {
                Id = 3,
                Name = "Emma Wilson",
                Email = "emma.wilson@email.com",
                Avatar = "👩‍🎨",
                Relationship = "Family Friend",
                LastSeenContext = "Family dinner last month",
                LastSeen = DateTime.Now.AddDays(-8),
                RecentActivities = { "Art exhibition opening", "Freelance design work", "Moved to new apartment" },
                CurrentStatus = "Working on client website",
                TypicalMood = MoodType.Neutral
            },
            new MockContact
            {
                Id = 4,
                Name = "Alex Rodriguez",
                Email = "alex.rodriguez@email.com",
                Avatar = "🧑‍🔬",
                Relationship = "Study Buddy",
                LastSeenContext = "Library study session",
                LastSeen = DateTime.Now.AddDays(-2),
                RecentActivities = { "Passed midterm exams", "Research paper submission", "Lab experiments" },
                CurrentStatus = "Preparing for final exams",
                TypicalMood = MoodType.Tired
            },
            new MockContact
            {
                Id = 5,
                Name = "You",
                Email = "you@email.com",
                Avatar = "😊",
                Relationship = "Self",
                LastSeenContext = "Right now!",
                LastSeen = DateTime.Now,
                RecentActivities = { "Building MoodSync app", "Learning new technologies", "Workshop preparation" },
                CurrentStatus = "Testing face detection feature",
                TypicalMood = MoodType.Happy
            }
        };

        public Task<List<MockContact>> GetMockContactsAsync()
        {
            return Task.FromResult(_mockContacts);
        }

        public Task<UserIdentificationResult> IdentifyUserAsync(string imageData)
        {
            // Simulate processing delay
            Task.Delay(800);

            // 85% chance of recognizing someone
            var recognitionSuccess = _random.NextDouble() > 0.15;
            
            if (!recognitionSuccess)
            {
                return Task.FromResult(new UserIdentificationResult
                {
                    UserRecognized = false,
                    Message = "Face detected but not recognized. You can still select your mood manually.",
                    SuggestedMood = MoodType.Neutral
                });
            }

            // Randomly select a contact (bias towards "You" for demo)
            var selectedContact = _random.NextDouble() > 0.3 
                ? _mockContacts.First(c => c.Name == "You") 
                : _mockContacts[_random.Next(_mockContacts.Count)];

            var confidence = 0.75 + (_random.NextDouble() * 0.25); // 75-100% confidence

            // Generate contextual mood suggestion
            var (suggestedMood, reason) = GenerateContextualMoodSuggestion(selectedContact);

            var result = new UserIdentificationResult
            {
                UserRecognized = true,
                IdentifiedUser = selectedContact,
                Confidence = confidence,
                Message = GenerateWelcomeMessage(selectedContact),
                SuggestedMood = suggestedMood,
                SuggestedMoodReason = reason
            };

            return Task.FromResult(result);
        }

        private (MoodType mood, string reason) GenerateContextualMoodSuggestion(MockContact contact)
        {
            // Create contextual suggestions based on contact data
            var suggestions = new List<(MoodType, string)>();

            if (contact.Name == "You")
            {
                suggestions.AddRange(new[]
                {
                    (MoodType.Happy, "You're building something awesome! 🚀"),
                    (MoodType.Happy, "Great progress on your workshop! 📚"),
                    (MoodType.Neutral, "Focused work mode detected 💻"),
                    (MoodType.Tired, "Time for a coding break? ☕")
                });
            }
            else
            {
                // Base on their recent activities and typical mood
                if (contact.RecentActivities.Any(a => a.Contains("exam") || a.Contains("work")))
                {
                    suggestions.Add((MoodType.Tired, $"Looks like {contact.Name} has been busy with work/studies"));
                }
                
                if (contact.RecentActivities.Any(a => a.Contains("new") || a.Contains("launch")))
                {
                    suggestions.Add((MoodType.Happy, $"Exciting new projects for {contact.Name}!"));
                }

                if (contact.LastSeen < DateTime.Now.AddDays(-7))
                {
                    suggestions.Add((MoodType.Neutral, $"Haven't seen {contact.Name} in a while"));
                }

                // Fallback to their typical mood
                suggestions.Add((contact.TypicalMood, $"Based on {contact.Name}'s usual mood patterns"));
            }

            return suggestions[_random.Next(suggestions.Count)];
        }

        private string GenerateWelcomeMessage(MockContact contact)
        {
            if (contact.Name == "You")
            {
                var selfMessages = new[]
                {
                    "Welcome back! 👋 How are you feeling today?",
                    "Hey there! 😊 Ready to check in your mood?", 
                    "Good to see you! 🌟 Let's track how you're doing",
                    "Hello! 👋 Time for your daily mood check-in"
                };
                return selfMessages[_random.Next(selfMessages.Length)];
            }
            else
            {
                var relationshipMessages = contact.Relationship.ToLower() switch
                {
                    "colleague" => $"Hi {contact.Name}! 👋 Hope work is going well",
                    "close friend" => $"Hey {contact.Name}! 🤗 Great to see you", 
                    "family friend" => $"Hello {contact.Name}! 😊 Nice to see you again",
                    "study buddy" => $"Hi {contact.Name}! 📚 How are the studies going?",
                    _ => $"Hello {contact.Name}! 👋 Good to see you"
                };

                return relationshipMessages;
            }
        }
    }
}
