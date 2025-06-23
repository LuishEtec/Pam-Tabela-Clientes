using ClienteCrudApp.Services;
using ClienteCrudApp.ViewModels;
using ClienteCrudApp.Views;

namespace ClienteCrudApp;

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

        
        builder.Services.AddSingleton<ClienteService>();

        
        builder.Services.AddTransient<CadastroPage>();
        builder.Services.AddTransient<CadastroViewModel>();
        builder.Services.AddTransient<ClientePage>();
        builder.Services.AddTransient<ClientesViewModel>();

        return builder.Build();
    }
}
