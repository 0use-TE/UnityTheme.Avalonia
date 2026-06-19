using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media;

namespace UnityTheme.Gallery.Views;

public partial class OverviewPage : GalleryPageBase
{
    private static readonly (string Category, string[] Controls)[] Catalog =
    [
        ("Actions", ["Button", "ToggleButton", "SplitButton", "DropDownButton"]),
        ("Selection", ["CheckBox", "RadioButton", "ToggleSwitch"]),
        ("Text & Input", ["Label", "TextBox", "ComboBox", "ComboBoxItem", "NumericUpDown", "ButtonSpinner", "AutoCompleteBox"]),
        ("Value", ["Slider", "ProgressBar"]),
        ("Lists", ["ListBox", "ListBoxItem", "TreeView", "TreeViewItem"]),
        ("Menus", ["Menu", "MenuItem", "ContextMenu"]),
        ("Layout", ["TabControl", "TabItem", "Expander", "GroupBox", "Separator", "GridSplitter", "SplitView"]),
        ("Date & Time", ["DatePicker", "TimePicker"]),
        ("Chrome", ["ScrollViewer", "ScrollBar"])
    ];

    public OverviewPage()
    {
        var root = new StackPanel { Spacing = 12 };
        root.Children.Add(CreateTitle("Unity Theme for Avalonia"));
        root.Children.Add(CreateDescription(
            "Inspired by the Unity Editor — dark-first, compact controls, and sharp borders " +
            "designed for industrial and professional tools. Open **All Controls** for the complete catalog."));

        var stats = new Grid
        {
            ColumnDefinitions = new ColumnDefinitions("*,*,*"),
            ColumnSpacing = 8
        };

        stats.Children.Add(CreateStatCard(0, "28", "Adapted controls"));
        stats.Children.Add(CreateStatCard(1, "20px", "Control min height"));
        stats.Children.Add(CreateStatCard(2, "12px", "Base font size"));

        root.Children.Add(stats);
        root.Children.Add(CreateSection("Adapted control catalog", CreateCatalogGrid()));
        root.Children.Add(CreateSection("Quick preview", CreateQuickPreview()));
        Content = root;
    }

    private static Control CreateCatalogGrid()
    {
        var rows = (Catalog.Length + 1) / 2;
        var rowDefs = new RowDefinitions(string.Join(',', Enumerable.Repeat("Auto", rows)));

        var grid = new Grid
        {
            ColumnDefinitions = new ColumnDefinitions("*,*"),
            RowDefinitions = rowDefs,
            ColumnSpacing = 12,
            RowSpacing = 8
        };

        for (var i = 0; i < Catalog.Length; i++)
        {
            var (category, controls) = Catalog[i];

            var panel = new StackPanel { Spacing = 2 };
            panel.Children.Add(new TextBlock
            {
                Text = category,
                FontWeight = FontWeight.SemiBold,
                FontSize = 11
            });
            panel.Children.Add(new TextBlock
            {
                Text = string.Join(" · ", controls),
                Opacity = 0.7,
                FontSize = 11,
                TextWrapping = TextWrapping.Wrap
            });

            Grid.SetColumn(panel, i % 2);
            Grid.SetRow(panel, i / 2);
            grid.Children.Add(panel);
        }

        return grid;
    }

    private static Control CreateStatCard(int column, string value, string label)
    {
        var panel = new StackPanel { Spacing = 2, HorizontalAlignment = HorizontalAlignment.Center };
        panel.Children.Add(new TextBlock { Text = value, FontSize = 18, FontWeight = FontWeight.Bold, HorizontalAlignment = HorizontalAlignment.Center });
        panel.Children.Add(new TextBlock { Text = label, Opacity = 0.6, FontSize = 11, HorizontalAlignment = HorizontalAlignment.Center });

        var border = new Border
        {
            Padding = new Thickness(12, 8),
            Background = Application.Current?.FindResource("UnityToolbarBackgroundBrush") as IBrush,
            Child = panel
        };
        Grid.SetColumn(border, column);
        return border;
    }

    private static Control CreateQuickPreview()
    {
        return new StackPanel
        {
            Spacing = 8,
            Children =
            {
                new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                    Spacing = 6,
                    Children =
                    {
                        new Button { Content = "Default" },
                        new Button { Content = "Accent", Classes = { "accent" } },
                        new Button { Content = "Disabled", IsEnabled = false }
                    }
                },
                new TextBox { PlaceholderText = "Search assets...", Width = 280 },
                new ComboBox { Width = 200, PlaceholderText = "Layer", ItemsSource = new[] { "Default", "UI", "Effects" } },
                new ProgressBar { Value = 65, ShowProgressText = true, Minimum = 0, Maximum = 100 }
            }
        };
    }
}
