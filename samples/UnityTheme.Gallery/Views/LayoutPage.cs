using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;

namespace UnityTheme.Gallery.Views;

public partial class LayoutPage : GalleryPageBase
{
    public LayoutPage()
    {
        var root = new StackPanel { Spacing = 12 };
        root.Children.Add(CreateTitle("Layout"));
        root.Children.Add(CreateDescription("Tabs, splitters, date/time pickers, and grouped panels — dockable editor building blocks."));

        var tabs = new TabControl { Height = 160 };
        tabs.Items.Add(new TabItem
        {
            Header = "Scene",
            Content = new Border
            {
                Background = ThemeBrush("UnityInputBackgroundBrush"),
                Child = new TextBlock { Text = "Scene View", Margin = new Thickness(8), VerticalAlignment = VerticalAlignment.Center }
            }
        });
        tabs.Items.Add(new TabItem
        {
            Header = "Game",
            Content = new Border
            {
                Background = ThemeBrush("UnityInputBackgroundBrush"),
                Child = new TextBlock { Text = "Game View", Margin = new Thickness(8), VerticalAlignment = VerticalAlignment.Center }
            }
        });
        tabs.Items.Add(new TabItem { Header = "Asset Store" });

        var splitGrid = new Grid { Height = 120 };
        splitGrid.ColumnDefinitions = new ColumnDefinitions("*,Auto,*");
        splitGrid.Children.Add(new Border
        {
            Background = ThemeBrush("UnityPanelBackgroundBrush"),
            Child = new TextBlock { Text = "Hierarchy", Margin = new Thickness(8), VerticalAlignment = VerticalAlignment.Top }
        });
        var splitter = new GridSplitter { Width = 4, HorizontalAlignment = HorizontalAlignment.Stretch };
        Grid.SetColumn(splitter, 1);
        splitGrid.Children.Add(splitter);
        splitGrid.Children.Add(new Border
        {
            Background = ThemeBrush("UnityInputBackgroundBrush"),
            Child = new TextBlock { Text = "Inspector", Margin = new Thickness(8), VerticalAlignment = VerticalAlignment.Top }
        });
        Grid.SetColumn(splitGrid.Children[2], 2);

        var splitView = new SplitView
        {
            Height = 120,
            IsPaneOpen = true,
            OpenPaneLength = 120,
            DisplayMode = SplitViewDisplayMode.Inline,
            Pane = new Border
            {
                Background = ThemeBrush("UnityPanelBackgroundBrush"),
                Child = new TextBlock { Text = "Project", Margin = new Thickness(8), VerticalAlignment = VerticalAlignment.Top }
            },
            Content = new Border
            {
                Background = ThemeBrush("UnityInputBackgroundBrush"),
                Child = new TextBlock { Text = "Assets", Margin = new Thickness(8), VerticalAlignment = VerticalAlignment.Top }
            }
        };

        var pickers = new StackPanel { Spacing = 8, MaxWidth = 320 };
        pickers.Children.Add(new DatePicker());
        pickers.Children.Add(new TimePicker());

        var group = new Expander
        {
            Header = "Rendering",
            IsExpanded = true,
            Content = new StackPanel
            {
                Spacing = 4,
                Children =
                {
                    new CheckBox { Content = "Occlusion Culling", IsChecked = true },
                    new CheckBox { Content = "Fog" }
                }
            }
        };

        root.Children.Add(CreateSection("TabControl", tabs));
        root.Children.Add(CreateSection("GridSplitter", splitGrid));
        root.Children.Add(CreateSection("SplitView", splitView));
        root.Children.Add(CreateSection("DatePicker / TimePicker", pickers));
        root.Children.Add(CreateSection("GroupBox",
            new GroupBox
            {
                MaxWidth = 320,
                Header = "Physics",
                Content = new StackPanel
                {
                    Spacing = 4,
                    Margin = new Thickness(0, 4, 0, 0),
                    Children =
                    {
                        new CheckBox { Content = "Use Gravity", IsChecked = true },
                        new CheckBox { Content = "Is Kinematic" }
                    }
                }
            }));
        root.Children.Add(CreateSection("ScrollViewer / ScrollBar", CreateScrollDemo()));
        root.Children.Add(new Separator { Margin = new Thickness(0, 4) });
        root.Children.Add(CreateSection("Expander", group));
        Content = root;
    }

    private static ScrollViewer CreateScrollDemo()
    {
        var items = new StackPanel { Spacing = 2 };
        for (var i = 1; i <= 10; i++)
        {
            items.Children.Add(new TextBlock { Text = $"Log entry {i}" });
        }

        return new ScrollViewer { MaxWidth = 320, Height = 72, Content = items };
    }
}
