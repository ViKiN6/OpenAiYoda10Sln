using OpenAiYoda10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAiYoda10.Views.Templates
{
    public class ChatMessageTemplateSelector : DataTemplateSelector
    {
        public DataTemplate? InboundTemplate { get; set; }
        public DataTemplate? OutboundTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return ((ChatMessage)item).MessageType == Enums.ChatMessageTypeEnum.Inbound ? InboundTemplate : OutboundTemplate;
        }
    }
}
