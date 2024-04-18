using CommunityToolkit.Maui;
using OpenAiYoda10.Configuration;
using OpenAiYoda10.Services;
using OpenAiYoda10.Services.Interfaces;
using OpenAiYoda10.ViewModels;
using OpenAiYoda10.Views;
using Microsoft.Extensions.Logging;

namespace OpenAiYoda10
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.RegisterServices()
               .RegisterViewModels()
               .RegisterViews();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
        public static MauiAppBuilder RegisterServices(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<OpenAIYodaAssistant, OpenAiAssistant>();
            mauiAppBuilder.Services.AddTransient<ISettings, ConstantSettings>();

            // More services registered here.

            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<OpenAIQuestionViewModel>();
            mauiAppBuilder.Services.AddSingleton<OpenAIAnswerViewModel>();

            // More view-models registered here.

            return mauiAppBuilder;
        }

        public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddSingleton<OpenAIQuestionPage>();
            mauiAppBuilder.Services.AddSingleton<OpenAIAnswerPage>();

            // More views registered here.

            return mauiAppBuilder;
        }
    }
}

