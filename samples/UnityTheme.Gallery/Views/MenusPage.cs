using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.Layout;

namespace UnityTheme.Gallery.Views;

public partial class MenusPage : GalleryPageBase
{
    public MenusPage()
    {
        var root = new StackPanel { Spacing = 12 };
        root.Children.Add(CreateTitle("Menus"));
        root.Children.Add(CreateDescription("Menu bar and context menu styling for editor toolbars."));

        var menu = new Menu();
        var file = new MenuItem { Header = "File" };
        file.Items.Add(new MenuItem { Header = "New Scene", InputGesture = new KeyGesture(Key.N, KeyModifiers.Control) });
        file.Items.Add(new MenuItem { Header = "Open...", InputGesture = new KeyGesture(Key.O, KeyModifiers.Control) });
        file.Items.Add(new MenuItem { Header = "-" });
        var recent = new MenuItem { Header = "Recent Scenes" };
        recent.Items.Add(new MenuItem { Header = "SampleScene.unity" });
        recent.Items.Add(new MenuItem { Header = "MainMenu.unity" });
        file.Items.Add(recent);
        file.Items.Add(new MenuItem { Header = "Save", InputGesture = new KeyGesture(Key.S, KeyModifiers.Control) });
        menu.Items.Add(file);

        var edit = new MenuItem { Header = "Edit" };
        edit.Items.Add(new MenuItem { Header = "Undo", InputGesture = new KeyGesture(Key.Z, KeyModifiers.Control) });
        edit.Items.Add(new MenuItem { Header = "Redo", InputGesture = new KeyGesture(Key.Y, KeyModifiers.Control) });
        menu.Items.Add(edit);

        var assets = new MenuItem { Header = "Assets" };
        assets.Items.Add(new MenuItem { Header = "Create", IsEnabled = false });
        assets.Items.Add(new MenuItem { Header = "Show in Explorer" });
        menu.Items.Add(assets);

        var contextTarget = new Button
        {
            Content = "Right-click for context menu",
            HorizontalAlignment = HorizontalAlignment.Left
        };
        contextTarget.ContextMenu = new ContextMenu();
        contextTarget.ContextMenu.Items.Add(new MenuItem { Header = "Copy" });
        contextTarget.ContextMenu.Items.Add(new MenuItem { Header = "Paste" });
        contextTarget.ContextMenu.Items.Add(new MenuItem { Header = "-" });
        contextTarget.ContextMenu.Items.Add(new MenuItem { Header = "Delete" });

        root.Children.Add(CreateSection("Menu / MenuItem", menu));
        root.Children.Add(CreateSection("ContextMenu", contextTarget));
        Content = root;
    }
}
