using Microsoft.Extensions.Logging;

namespace AgendaSQLite;

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
            });

        // Registrar DatabaseService como Singleton (una sola instancia compartida)
        builder.Services.AddSingleton<DatabaseService>(provider =>
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "contacts.db3");
            return new DatabaseService(dbPath);
        });

        // Registrar ViewModel y páginas para inyección de dependencias
        builder.Services.AddSingleton<ContactsViewModel>();
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddTransient<ContactDetailPage>();

        return builder.Build();
    }
}