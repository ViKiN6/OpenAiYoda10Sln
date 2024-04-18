using OpenAiYoda10.Views;


namespace OpenAiYoda10
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            RegisterRoutes();
        }
        private void RegisterRoutes()
        {
            Routing.RegisterRoute("loadsheddingquestion", typeof(OpenAIQuestionPage));
            Routing.RegisterRoute("loadsheddinganswer", typeof(OpenAIAnswerPage));
        }
    }
}
