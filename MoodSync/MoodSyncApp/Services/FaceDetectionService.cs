using MoodSyncApp.Models;

namespace MoodSyncApp.Services
{
    public interface IFaceDetectionService
    {
        Task<FaceDetectionResult> DetectFaceAndEmotionAsync(string imageData);
        Task<UserIdentificationResult> IdentifyUserAsync(string imageData);
        Task<bool> InitializeCameraAsync();
    }

    public class FaceDetectionResult
    {
        public bool FaceDetected { get; set; }
        public string DetectedEmotion { get; set; } = "neutral";
        public double Confidence { get; set; }
        public MoodType SuggestedMood { get; set; }
        public string Message { get; set; } = "";
    }

    public class MockFaceDetectionService : IFaceDetectionService
    {
        private readonly Random _random = new();
        private readonly string[] _emotions = { "happy", "sad", "angry", "surprised", "neutral", "tired" };
        private readonly IUserIdentificationService _userIdentificationService;
        private readonly string[] _happyMessages = {
            "You're glowing today! ✨",
            "That smile is contagious! 😊",
            "Looking fantastic!",
            "Radiating positive energy!"
        };
        private readonly string[] _sadMessages = {
            "Sending you virtual hugs 🤗",
            "It's okay to have tough days",
            "You're stronger than you know",
            "Remember, this too shall pass"
        };

        public MockFaceDetectionService(IUserIdentificationService userIdentificationService)
        {
            _userIdentificationService = userIdentificationService;
        }

        public Task<bool> InitializeCameraAsync()
        {
            // Mock initialization - always succeeds
            return Task.FromResult(true);
        }

        public async Task<UserIdentificationResult> IdentifyUserAsync(string imageData)
        {
            // Delegate to user identification service
            return await _userIdentificationService.IdentifyUserAsync(imageData);
        }

        public Task<FaceDetectionResult> DetectFaceAndEmotionAsync(string imageData)
        {
            // Simulate processing delay
            Task.Delay(500);

            // Mock face detection (90% success rate)
            var faceDetected = _random.NextDouble() > 0.1;
            
            if (!faceDetected)
            {
                return Task.FromResult(new FaceDetectionResult
                {
                    FaceDetected = false,
                    Message = "Please look directly at the camera"
                });
            }

            // Mock emotion detection
            var emotion = _emotions[_random.Next(_emotions.Length)];
            var confidence = 0.7 + (_random.NextDouble() * 0.3); // 70-100% confidence

            var result = new FaceDetectionResult
            {
                FaceDetected = true,
                DetectedEmotion = emotion,
                Confidence = confidence,
                SuggestedMood = MapEmotionToMood(emotion),
                Message = GetMessageForEmotion(emotion)
            };

            return Task.FromResult(result);
        }

        private MoodType MapEmotionToMood(string emotion)
        {
            return emotion.ToLower() switch
            {
                "happy" => MoodType.Happy,
                "sad" => MoodType.Sad,
                "angry" => MoodType.Angry,
                "surprised" => MoodType.Happy,
                "tired" => MoodType.Tired,
                _ => MoodType.Neutral
            };
        }

        private string GetMessageForEmotion(string emotion)
        {
            return emotion.ToLower() switch
            {
                "happy" => _happyMessages[_random.Next(_happyMessages.Length)],
                "sad" => _sadMessages[_random.Next(_sadMessages.Length)],
                "angry" => "Take a deep breath, you've got this 💪",
                "surprised" => "Something exciting happening? 🎉",
                "tired" => "Rest is productive too 😴",
                _ => "Looking good! How are you feeling?"
            };
        }
    }
}
