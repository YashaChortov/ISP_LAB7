using CommunityToolkit.Maui;
using ContestManager.Application;
using ContestManager.Persistence;
using ContestManager.Persistence.Data;
using ContestManager.UI.Converters;
using ContestManager.UI.Pages;
using ContestManager.UI.ViewModels;
using ContestManager.UI1.Pages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace ContestManager.UI;

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

        // Загрузка конфигурации
        var assembly = Assembly.GetExecutingAssembly();
        using var stream = assembly.GetManifestResourceStream("ContestManager.UI.appsettings.json");
        builder.Configuration.AddJsonStream(stream);

        // Настройка базы данных
        var connStr = builder.Configuration.GetConnectionString("SqliteConnection");
        string dataDirectory = FileSystem.Current.AppDataDirectory + "/";
        connStr = string.Format(connStr, dataDirectory);

        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlite(connStr)
            .Options;

        // Регистрация сервисов
        builder.Services
            .AddApplication()
            .AddPersistence(options)
            .RegisterPages()
            .RegisterViewModels();

        // Регистрация конвертеров
        builder.Services.AddSingleton<ScoreToColorConverter>();

        return builder.Build();
    }

    private static IServiceCollection RegisterPages(this IServiceCollection services)
    {
        services
            .AddTransient<ContestsPage>()
            .AddTransient<ParticipantDetailsPage>();
        return services;
    }

    private static IServiceCollection RegisterViewModels(this IServiceCollection services)
    {
        services
            .AddTransient<ContestsViewModel>()
            .AddTransient<ParticipantDetailsViewModel>();
        return services;
    }
}