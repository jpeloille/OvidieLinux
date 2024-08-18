using Avalonia;
using Avalonia.ReactiveUI;
using System;
using System.Globalization;
using System.Threading;
using Ovidie.EntityModel.SqlServer.Context;

namespace Ovidie;

sealed class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args) => BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);

    public static OvidieDbContext DbContext = new OvidieDbContext();
    
    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-fr");
        
        return AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace()
            .UseReactiveUI();
    
    } 
}