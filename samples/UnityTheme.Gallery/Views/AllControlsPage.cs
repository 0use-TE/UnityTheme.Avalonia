using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Layout;

namespace UnityTheme.Gallery.Views;

/// <summary>
/// Complete catalog of every core control that has Unity-specific styling.
/// </summary>
public partial class AllControlsPage : GalleryPageBase
{
    public AllControlsPage()
    {
        var catalog = new StackPanel { Spacing = 12 };
        catalog.Children.Add(CreateTitle("All Adapted Controls"));
        catalog.Children.Add(CreateDescription(
            "Every core Avalonia control with Unity-specific styling. " +
            "Use the sidebar categories for focused demos; this page is the full checklist."));

        catalog.Children.Add(CreateSection("Button",
            Row(
                new Button { Content = "Default" },
                new Button { Content = "Accent", Classes = { "accent" } },
                new Button { Content = "Disabled", IsEnabled = false })));

        catalog.Children.Add(CreateSection("ToggleButton",
            Row(
                new ToggleButton { Content = "Off" },
                new ToggleButton { Content = "On", IsChecked = true })));

        catalog.Children.Add(CreateSection("SplitButton / DropDownButton",
            Row(new SplitButton { Content = "Build" }, new DropDownButton { Content = "Layers" })));

        catalog.Children.Add(CreateSection("CheckBox",
            Stack(
                new CheckBox { Content = "Enabled", IsChecked = true },
                new CheckBox { Content = "Unchecked" },
                new CheckBox { Content = "Disabled", IsEnabled = false })));

        catalog.Children.Add(CreateSection("RadioButton",
            Stack(
                new RadioButton { Content = "Option A", GroupName = "all", IsChecked = true },
                new RadioButton { Content = "Option B", GroupName = "all" })));

        catalog.Children.Add(CreateSection("ToggleSwitch",
            InlineToggle("HDR", true)));

        catalog.Children.Add(CreateSection("Label",
            new Label { Content = "Inspector field label" }));

        catalog.Children.Add(CreateSection("TextBox",
            Stack(
                new TextBox { PlaceholderText = "Placeholder", MaxWidth = 280 },
                new TextBox { Text = "With value", MaxWidth = 280 },
                new TextBox { Text = "Read only", IsReadOnly = true, MaxWidth = 280 })));

        catalog.Children.Add(CreateSection("ComboBox / ComboBoxItem",
            new ComboBox
            {
                MaxWidth = 280,
                PlaceholderText = "Select shader",
                ItemsSource = new[] { "Standard", "Unlit/Color", "UI/Default" },
                SelectedIndex = 0
            }));

        catalog.Children.Add(CreateSection("NumericUpDown / ButtonSpinner",
            new NumericUpDown { MaxWidth = 280, Value = 1.5m, Increment = 0.1m, FormatString = "F2" }));

        catalog.Children.Add(CreateSection("AutoCompleteBox",
            new AutoCompleteBox
            {
                MaxWidth = 280,
                PlaceholderText = "Search components",
                ItemsSource = new[] { "Transform", "Rigidbody", "Collider" }
            }));

        catalog.Children.Add(CreateSection("Slider",
            new Slider { MaxWidth = 280, Minimum = 0, Maximum = 100, Value = 60 }));

        catalog.Children.Add(CreateSection("ProgressBar",
            new ProgressBar { MaxWidth = 280, Minimum = 0, Maximum = 100, Value = 45, ShowProgressText = true }));

        catalog.Children.Add(CreateSection("ListBox / ListBoxItem",
            new ListBox
            {
                MaxWidth = 280,
                Height = 100,
                ItemsSource = new[] { "Main Camera", "Player", "Environment" },
                SelectedIndex = 1
            }));

        catalog.Children.Add(CreateSection("TreeView / TreeViewItem", CreateSampleTree()));

        catalog.Children.Add(CreateSection("Menu / MenuItem", CreateSampleMenu()));

        catalog.Children.Add(CreateSection("TabControl / TabItem", CreateSampleTabs()));

        catalog.Children.Add(CreateSection("Expander",
            new Expander
            {
                MaxWidth = 320,
                Header = "Transform",
                IsExpanded = true,
                Content = new TextBox { Text = "0, 0, 0", Margin = new Thickness(0, 4, 0, 0) }
            }));

        catalog.Children.Add(CreateSection("GroupBox",
            new GroupBox
            {
                MaxWidth = 320,
                Header = "Mesh Renderer",
                Content = new CheckBox { Content = "Cast Shadows", IsChecked = true, Margin = new Thickness(0, 4, 0, 0) }
            }));

        catalog.Children.Add(CreateSection("Separator", new Separator { MaxWidth = 320 }));

        catalog.Children.Add(CreateSection("GridSplitter", CreateSampleSplitGrid()));

        catalog.Children.Add(CreateSection("SplitView", CreateSampleSplitView()));

        catalog.Children.Add(CreateSection("DatePicker",
            new DatePicker { MaxWidth = 320 }));

        catalog.Children.Add(CreateSection("TimePicker",
            new TimePicker { MaxWidth = 320 }));

        catalog.Children.Add(CreateSection("ScrollViewer / ScrollBar", CreateScrollDemo()));

        Content = new ScrollViewer
        {
            HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled,
            Content = catalog
        };
    }

    private static Panel Row(params Control[] items)
    {
        var panel = new StackPanel { Orientation = Orientation.Horizontal, Spacing = 6 };
        foreach (var item in items)
        {
            panel.Children.Add(item);
        }

        return panel;
    }

    private static Panel Stack(params Control[] items)
    {
        var panel = new StackPanel { Spacing = 4 };
        foreach (var item in items)
        {
            panel.Children.Add(item);
        }

        return panel;
    }

    private static Control InlineToggle(string label, bool isChecked) =>
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

    private static TreeView CreateSampleTree()
    {
        var tree = new TreeView { MaxWidth = 280, Height = 120 };
        var root = new TreeViewItem { Header = "Assets", IsExpanded = true };
        root.Items.Add(new TreeViewItem { Header = "Scenes" });
        root.Items.Add(new TreeViewItem { Header = "Scripts" });
        tree.Items.Add(root);
        return tree;
    }

    private static Menu CreateSampleMenu()
    {
        var menu = new Menu();
        var file = new MenuItem { Header = "File" };
        file.Items.Add(new MenuItem { Header = "New Scene", InputGesture = new KeyGesture(Key.N, KeyModifiers.Control) });
        file.Items.Add(new MenuItem { Header = "Open...", InputGesture = new KeyGesture(Key.O, KeyModifiers.Control) });
        file.Items.Add(new MenuItem { Header = "-" });
        file.Items.Add(new MenuItem { Header = "Save", InputGesture = new KeyGesture(Key.S, KeyModifiers.Control) });
        menu.Items.Add(file);

        var edit = new MenuItem { Header = "Edit" };
        edit.Items.Add(new MenuItem { Header = "Undo", InputGesture = new KeyGesture(Key.Z, KeyModifiers.Control) });
        menu.Items.Add(edit);
        return menu;
    }

    private static TabControl CreateSampleTabs()
    {
        var tabs = new TabControl { MaxWidth = 360, Height = 100 };
        tabs.Items.Add(new TabItem
        {
            Header = "Scene",
            Content = new TextBlock { Text = "Scene content", Margin = new Thickness(8), VerticalAlignment = VerticalAlignment.Center }
        });
        tabs.Items.Add(new TabItem
        {
            Header = "Game",
            Content = new TextBlock { Text = "Game content", Margin = new Thickness(8), VerticalAlignment = VerticalAlignment.Center }
        });
        tabs.Items.Add(new TabItem { Header = "Console" });
        return tabs;
    }

    private static Grid CreateSampleSplitGrid()
    {
        var grid = new Grid { MaxWidth = 360, Height = 72 };
        grid.ColumnDefinitions = new ColumnDefinitions("*,Auto,*");
        grid.Children.Add(new Border
        {
            Background = ThemeBrush("UnityPanelBackgroundBrush"),
            Child = new TextBlock { Text = "Left", Margin = new Thickness(6), VerticalAlignment = VerticalAlignment.Center }
        });
        var splitter = new GridSplitter { Width = 4 };
        Grid.SetColumn(splitter, 1);
        grid.Children.Add(splitter);
        var right = new Border
        {
            Background = ThemeBrush("UnityInputBackgroundBrush"),
            Child = new TextBlock { Text = "Right", Margin = new Thickness(6), VerticalAlignment = VerticalAlignment.Center }
        };
        Grid.SetColumn(right, 2);
        grid.Children.Add(right);
        return grid;
    }

    private static SplitView CreateSampleSplitView()
    {
        return new SplitView
        {
            MaxWidth = 360,
            Height = 72,
            IsPaneOpen = true,
            OpenPaneLength = 100,
            DisplayMode = SplitViewDisplayMode.Inline,
            Pane = new TextBlock { Text = "Pane", Margin = new Thickness(6), VerticalAlignment = VerticalAlignment.Top },
            Content = new TextBlock { Text = "Content", Margin = new Thickness(6), VerticalAlignment = VerticalAlignment.Top }
        };
    }

    private static ScrollViewer CreateScrollDemo()
    {
        var items = new StackPanel { Spacing = 2 };
        for (var i = 1; i <= 12; i++)
        {
            items.Children.Add(new TextBlock { Text = $"Scroll item {i}" });
        }

        return new ScrollViewer
        {
            MaxWidth = 280,
            Height = 80,
            Content = items
        };
    }
}
