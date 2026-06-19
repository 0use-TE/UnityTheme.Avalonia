using System;
using Avalonia.Markup.Xaml;
using Avalonia.Styling;

namespace UnityTheme.Avalonia;

/// <summary>
/// Standalone Unity Editor inspired theme for Avalonia — no FluentTheme dependency.
/// </summary>
public class UnityTheme : Styles
{
    public UnityTheme(IServiceProvider? sp = null)
    {
        AvaloniaXamlLoader.Load(sp, this);
    }
}
