namespace AuthApi.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionText { get; set; } = string.Empty;
        public string OptionA { get; set; } = string.Empty;
        public string OptionB { get; set; } = string.Empty;
        public string OptionC { get; set; } = string.Empty;
        public string OptionD { get; set; } = string.Empty;
        public string CorrectAnswer { get; set; } = string.Empty; // A, B, C, or D
        public int CategoryId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
    }
}
