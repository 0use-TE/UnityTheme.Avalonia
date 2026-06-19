using Avalonia;
using System;

namespace UnityTheme.Gallery.Desktop;

internal static class Program
{
    [STAThread]
    public static void Main(string[] args) =>
        BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);

    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<UnityTheme.Gallery.App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();
}
