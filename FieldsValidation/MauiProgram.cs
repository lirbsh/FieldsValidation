using Microsoft.Extensions.Logging;

namespace FieldsValidation
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
                    fonts.AddFont("MaterialSymbolsRounded.ttf", "SymbolsRounded");
                    fonts.AddFont("MaterialSymbolsOutlined.ttf", "SymbolsOutlined");
                    fonts.AddFont("MaterialSymbolsSharp.ttf", "SymbolsSharp");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
