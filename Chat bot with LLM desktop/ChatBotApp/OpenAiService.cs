using OpenAI.Chat;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatBotApp
{
    public class OpenAiService
    {
        private readonly ChatClient _client;

        public OpenAiService(string apiKey)
        {
            _client = new ChatClient(model: "gpt-4o-mini", apiKey: apiKey);
        }

        public async Task<string> GetResponseAsync(List<ChatMessage> history)
        {
            var messages = new List<OpenAI.Chat.ChatMessage>();
            
            foreach (var msg in history)
            {
                if (msg.Role == "User")
                    messages.Add(new UserChatMessage(msg.Text));
                else
                    messages.Add(new AssistantChatMessage(msg.Text));
            }

            ChatCompletion completion = await _client.CompleteChatAsync(messages);
            return completion.Content[0].Text;
        }
    }
}
