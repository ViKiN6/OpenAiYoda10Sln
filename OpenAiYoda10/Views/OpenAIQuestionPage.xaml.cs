using OpenAiYoda10.ViewModels;

namespace	OpenAiYoda10.Views;

public partial class OpenAIQuestionPage : ContentPage
{
    OpenAIQuestionViewModel _viewModel;

	public OpenAIQuestionPage(OpenAIQuestionViewModel vm)
	{
		InitializeComponent();

		_viewModel = vm;

        BindingContext = _viewModel;
	}
}