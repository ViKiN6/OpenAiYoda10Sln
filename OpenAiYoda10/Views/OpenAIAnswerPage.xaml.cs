using OpenAiYoda10.ViewModels;

namespace OpenAiYoda10.Views;

public partial class OpenAIAnswerPage : ContentPage
{
    OpenAIAnswerViewModel _viewModel;

    public OpenAIAnswerPage(OpenAIAnswerViewModel vm)
	{
        _viewModel = vm;

        InitializeComponent();

        BindingContext = _viewModel;
	}
}