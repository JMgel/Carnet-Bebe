﻿using Microsoft.Extensions.Logging;
using CarnetBebe.Services;
using CarnetBebe.ViewModels;
using CarnetBebe.Views;

namespace CarnetBebe
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
               ;

            builder.Services.AddSingleton<IDatabaseService>(provider =>
            {
                return new DatabaseService();
            });
            builder.Services.AddTransient<MainViewModel>();
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<SleepingViewModel>();
            builder.Services.AddTransient<SleepingPage>();
           

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
