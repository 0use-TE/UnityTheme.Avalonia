using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media;

namespace UnityTheme.Gallery.Views;

public class GalleryPageBase : UserControl
{
    protected static TextBlock CreateTitle(string text) =>
        new()
        {
            Text = text,
            FontSize = 16,
            FontWeight = FontWeight.SemiBold,
            Margin = new Thickness(0, 0, 0, 4)
        };

    protected static TextBlock CreateDescription(string text) =>
        new()
        {
            Text = text,
            Opacity = 0.65,
            TextWrapping = TextWrapping.Wrap,
            Margin = new Thickness(0, 0, 0, 16)
        };

    protected static IBrush ThemeBrush(string key) =>
        Application.Current?.FindResource(key) as IBrush ?? Brushes.Transparent;

    protected static Border CreateSection(string title, Control content)
    {
        var panel = new StackPanel { Spacing = 8 };
        panel.Children.Add(new TextBlock
        {
            Text = title,
            FontSize = 11,
            Opacity = 0.55,
            LetterSpacing = 0.5
        });
        panel.Children.Add(content);

        return new Border
        {
            Background = Application.Current?.FindResource("UnityPanelBackgroundBrush") as IBrush,
            BorderBrush = Application.Current?.FindResource("UnityBorderBrush") as IBrush,
            BorderThickness = new Thickness(1),
            CornerRadius = new CornerRadius(1),
            Padding = new Thickness(12),
            Child = panel
        };
    }
}
