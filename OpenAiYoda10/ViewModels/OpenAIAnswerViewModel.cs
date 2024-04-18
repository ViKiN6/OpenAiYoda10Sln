using OpenAiYoda10.Models;

namespace OpenAiYoda10.ViewModels
{
	[QueryProperty(nameof(Response), "Response")]
    public class OpenAIAnswerViewModel : BaseViewModel
    {
		private ChatMessage _questionResponseModel;

		public ChatMessage Response
		{
			get { return _questionResponseModel; }
			set { _questionResponseModel = value;

				OnPropertyChanged();
			}
		}

		public OpenAIAnswerViewModel()
		{
        }
    }
}
