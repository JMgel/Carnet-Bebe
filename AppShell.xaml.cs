﻿using CarnetBebe.Views;

namespace CarnetBebe
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(SleepingPage), typeof(SleepingPage));
        }
    }
}
