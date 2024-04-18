using Azure.AI.OpenAI;
using OpenAiYoda10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAiYoda10.Services.Interfaces
{
    public interface OpenAIYodaAssistant
    {
        ChatResponseMessage GetCompletion(IList<ChatMessage> chatInboundHistory, ChatMessage userMessage);
    }
}
