using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Styling;
using UnityTheme.Gallery.Views;

namespace UnityTheme.Gallery;

public partial class GalleryShell : UserControl
{
    private readonly Dictionary<string, Control> _pages = new(StringComparer.Ordinal);

    public GalleryShell()
    {
        InitializeComponent();
        UpdateThemeButtons(Application.Current?.ActualThemeVariant ?? ThemeVariant.Dark);
        NavigationList.SelectedIndex = 1;
        Navigate("AllControls");
    }

    private void OnNavigationSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (NavigationList.SelectedItem is ListBoxItem { Tag: string tag })
        {
            Navigate(tag);
        }
    }

    private void Navigate(string pageKey)
    {
        if (!_pages.TryGetValue(pageKey, out var page))
        {
            page = pageKey switch
            {
                "Overview" => new OverviewPage(),
                "AllControls" => new AllControlsPage(),
                "Buttons" => new ButtonsPage(),
                "Inputs" => new InputsPage(),
                "Selection" => new SelectionPage(),
                "Lists" => new ListsPage(),
                "Menus" => new MenusPage(),
                "Layout" => new LayoutPage(),
                "Inspector" => new InspectorPage(),
                _ => new OverviewPage()
            };
            _pages[pageKey] = page;
        }

        PageHost.Content = page;
    }

    private void OnThemeDarkClick(object? sender, RoutedEventArgs e) =>
        ApplyTheme(ThemeVariant.Dark);

    private void OnThemeLightClick(object? sender, RoutedEventArgs e) =>
        ApplyTheme(ThemeVariant.Light);

    private void ApplyTheme(ThemeVariant variant)
    {
        if (Application.Current is App app)
        {
            app.SetThemeVariant(variant);
        }

        UpdateThemeButtons(variant);
    }

    private void UpdateThemeButtons(ThemeVariant variant)
    {
        DarkThemeButton.IsChecked = variant == ThemeVariant.Dark;
        LightThemeButton.IsChecked = variant == ThemeVariant.Light;
    }
}
