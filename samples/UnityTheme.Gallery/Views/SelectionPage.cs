using Avalonia.Controls;
using Avalonia.Layout;

namespace UnityTheme.Gallery.Views;

public partial class SelectionPage : GalleryPageBase
{
    public SelectionPage()
    {
        var root = new StackPanel { Spacing = 12 };
        root.Children.Add(CreateTitle("Selection"));
        root.Children.Add(CreateDescription("Checkboxes, radio buttons, and toggles at compact sizes for dense tool panels."));

        var checks = new StackPanel { Spacing = 2 };
        checks.Children.Add(new CheckBox { Content = "Static", IsChecked = true });
        checks.Children.Add(new CheckBox { Content = "Auto Sync Transforms" });
        checks.Children.Add(new CheckBox { Content = "Disabled", IsEnabled = false });

        var radios = new StackPanel { Spacing = 2 };
        radios.Children.Add(new RadioButton { Content = "Perspective", GroupName = "cam", IsChecked = true });
        radios.Children.Add(new RadioButton { Content = "Orthographic", GroupName = "cam" });

        var toggles = new StackPanel { Spacing = 2 };
        toggles.Children.Add(CreateInlineToggle("Post Processing", true));
        toggles.Children.Add(CreateInlineToggle("HDR", false));

        var grid = new Grid { ColumnDefinitions = new ColumnDefinitions("*,*"), ColumnSpacing = 12 };
        grid.Children.Add(WrapSection("CheckBox", checks, 0));
        grid.Children.Add(WrapSection("RadioButton", radios, 1));

        root.Children.Add(grid);
        root.Children.Add(CreateSection("ToggleSwitch", toggles));
        Content = root;
    }

    private static Control CreateInlineToggle(string label, bool isChecked) =>
        new StackPanel
        {
            Orientation = Orientation.Horizontal,
            Spacing = 6,
            Children =
            {
                new TextBlock { Text = label, VerticalAlignment = VerticalAlignment.Center },
                new ToggleSwitch { OffContent = "", OnContent = "", IsChecked = isChecked }
            }
        };

    private static Control WrapSection(string title, Control content, int column)
    {
        var section = CreateSection(title, content);
        Grid.SetColumn(section, column);
        return section;
    }
}
