using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAiYoda10.Configuration
{
    public class ConstantSettings : ISettings
    {
        /*public string AzureSearchEndPoint { get => "https://samsungopenaistuvk.openai.azure.com/"; }
        public string AzureSearchKey { get => "9c7014b5a21e428599dddeedce03b50e"; }*/
        public string AzureOpenAiEndPoint { get => "https://samsungopenaistuvk.openai.azure.com/"; }
        public string AzureOpenAiKey { get => "394f2e2fdb7849168204ecae2a65adb4"; }
    }
}
