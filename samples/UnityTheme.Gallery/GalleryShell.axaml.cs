using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Styling;

namespace UnityTheme.Gallery;

public partial class GalleryShell : UserControl
{
    public GalleryShell()
    {
        InitializeComponent();
        UpdateThemeButtons(Application.Current?.ActualThemeVariant ?? ThemeVariant.Dark);
    }

    private void OnThemeDarkClick(object? sender, RoutedEventArgs e) =>
        ApplyTheme(ThemeVariant.Dark);

    private void OnThemeLightClick(object? sender, RoutedEventArgs e) =>
        ApplyTheme(ThemeVariant.Light);

    private void ApplyTheme(ThemeVariant variant)
    {
        if (Application.Current is App app)
            app.SetThemeVariant(variant);

        UpdateThemeButtons(variant);
    }

    private void UpdateThemeButtons(ThemeVariant variant)
    {
        DarkThemeButton.IsChecked = variant == ThemeVariant.Dark;
        LightThemeButton.IsChecked = variant == ThemeVariant.Light;
    }
}
