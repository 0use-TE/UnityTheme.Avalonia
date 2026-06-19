using Avalonia.Controls;

namespace UnityTheme.Gallery.Views;

public partial class ListsPage : GalleryPageBase
{
    public ListsPage()
    {
        var root = new StackPanel { Spacing = 12 };
        root.Children.Add(CreateTitle("Lists & Trees"));
        root.Children.Add(CreateDescription("Hierarchy and project window style lists with compact row height and blue selection."));

        var listBox = new ListBox
        {
            Height = 140,
            ItemsSource = new[]
            {
                "Main Camera",
                "Directional Light",
                "Player",
                "Environment",
                "Canvas (UI)"
            },
            SelectedIndex = 2
        };

        var tree = new TreeView { Height = 160 };
        var rootItem = new TreeViewItem { Header = "Assets", IsExpanded = true };
        rootItem.Items.Add(new TreeViewItem { Header = "Scenes" });
        rootItem.Items.Add(new TreeViewItem { Header = "Scripts", IsExpanded = true });
        var scripts = (TreeViewItem)rootItem.Items[1]!;
        scripts.Items.Add(new TreeViewItem { Header = "PlayerController.cs" });
        scripts.Items.Add(new TreeViewItem { Header = "GameManager.cs" });
        rootItem.Items.Add(new TreeViewItem { Header = "Prefabs" });
        tree.Items.Add(rootItem);

        var grid = new Grid { ColumnDefinitions = new ColumnDefinitions("*,*"), ColumnSpacing = 12 };
        grid.Children.Add(Wrap("ListBox", listBox, 0));
        grid.Children.Add(Wrap("TreeView", tree, 1));

        root.Children.Add(grid);
        Content = root;
    }

    private static Control Wrap(string title, Control content, int column)
    {
        var section = CreateSection(title, content);
        Grid.SetColumn(section, column);
        return section;
    }
}
