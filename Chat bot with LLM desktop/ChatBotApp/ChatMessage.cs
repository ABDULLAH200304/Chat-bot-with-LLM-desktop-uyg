namespace ChatBotApp
{
    public class ChatMessage
    {
        public string Role { get; set; } // "User" or "Assistant"
        public string Text { get; set; }
        public DateTime Timestamp { get; set; }

        public ChatMessage(string role, string text)
        {
            Role = role;
            Text = text;
            Timestamp = DateTime.Now;
        }
    }
}
