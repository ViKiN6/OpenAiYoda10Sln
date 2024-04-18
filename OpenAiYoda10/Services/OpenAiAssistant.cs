using Azure;
using Azure.AI.OpenAI;
using OpenAiYoda10.Configuration;
using OpenAiYoda10.Models;
using OpenAiYoda10.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAiYoda10.Services
{
    public class OpenAiAssistant : OpenAIYodaAssistant
    {
        private ISettings _settings;
        private const string AssistantBehaviorDescription = "Greetings, young Padawan. How may I assist you today?";

        public OpenAiAssistant(ISettings settings)
        {
            _settings = settings;
        }

        private IList<ChatRequestMessage> BuildChatContext(IList<ChatMessage> chatInboundHistory, ChatMessage userMessage )
        {
            var chatContext = new List<ChatRequestMessage>();

            chatContext.Add(new ChatRequestSystemMessage(AssistantBehaviorDescription));
            
            foreach (var chatMessage in chatInboundHistory)
                chatContext.Add(new ChatRequestAssistantMessage(chatMessage.MessageBody));

            chatContext.Add(new ChatRequestUserMessage(userMessage.MessageBody));

            return chatContext;

        }

        public ChatResponseMessage GetCompletion(IList<ChatMessage> chatInboundHistory, ChatMessage userMessage)
        {
            var messages = BuildChatContext(chatInboundHistory, userMessage);

            var client = new OpenAIClient(new Uri(_settings.AzureOpenAiEndPoint), new AzureKeyCredential(_settings.AzureOpenAiKey));
            string deploymentName = "ChatGPTVK";
          //  string searchIndex = "index";

            var chatCompletionsOptions = new ChatCompletionsOptions()
            {
                AzureExtensionsOptions = new AzureChatExtensionsOptions()
                {
                    Extensions = 
        {
            new AzureSearchChatExtensionConfiguration()
            {
               /* SearchEndpoint = new Uri(_settings.AzureSearchEndPoint),
                Authentication = new OnYourDataApiKeyAuthenticationOptions(_settings.AzureSearchKey),

                IndexName = searchIndex,*/
            },
                    }
                },
                DeploymentName = deploymentName
            };

            foreach (var message in messages)
                chatCompletionsOptions.Messages.Add(message);

            Response<ChatCompletions> response = client.GetChatCompletions(chatCompletionsOptions);

            ChatResponseMessage responseMessage = response.Value.Choices[0].Message;

            return responseMessage;

        }



    }
}
