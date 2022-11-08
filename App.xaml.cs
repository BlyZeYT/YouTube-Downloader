﻿namespace YouTubeDownloaderV2;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using YouTubeDownloaderV2.Services;

public sealed partial class App : Application
{
    public static IHost? AppHost { get; private set; }

    public App()
    {
        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NzQzNDUxQDMyMzAyZTMzMmUzMG1PbERFdHFidVJqczF3bUpYTzZCSWZWaFdueFZKTEdiOHc5NlJkR3Y4bVU9");

        AppHost = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddSingleton<MainWindow>();
                services.AddTransient<IYouTubeClient, YouTubeClient>();
            })
            .Build();
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        await AppHost!.StartAsync();

        AppHost.Services.GetRequiredService<MainWindow>().Show();
        
        base.OnStartup(e);
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        await AppHost!.StopAsync();
        
        base.OnExit(e);
    }
}