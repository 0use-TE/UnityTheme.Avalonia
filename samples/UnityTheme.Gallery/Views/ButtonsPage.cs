using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Layout;

namespace UnityTheme.Gallery.Views;

public partial class ButtonsPage : GalleryPageBase
{
    public ButtonsPage()
    {
        var root = new StackPanel { Spacing = 12 };
        root.Children.Add(CreateTitle("Buttons"));
        root.Children.Add(CreateDescription("Flat toolbar-style buttons with subtle borders, matching Unity editor controls."));

        var row1 = new StackPanel { Orientation = Orientation.Horizontal, Spacing = 6 };
        row1.Children.Add(new Button { Content = "Play" });
        row1.Children.Add(new Button { Content = "Pause" });
        row1.Children.Add(new Button { Content = "Step" });
        row1.Children.Add(new Button { Content = "Accent", Classes = { "accent" } });
        row1.Children.Add(new Button { Content = "Disabled", IsEnabled = false });

        var row2 = new StackPanel { Orientation = Orientation.Horizontal, Spacing = 6 };
        row2.Children.Add(new ToggleButton { Content = "Wireframe" });
        row2.Children.Add(new ToggleButton { Content = "Gizmos", IsChecked = true });
        row2.Children.Add(new SplitButton { Content = "Build" });
        row2.Children.Add(new DropDownButton { Content = "Layers" });

        root.Children.Add(CreateSection("Standard", row1));
        root.Children.Add(CreateSection("Toggle & Split", row2));
        Content = root;
    }
}
