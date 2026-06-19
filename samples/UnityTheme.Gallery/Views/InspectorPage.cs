using Avalonia;
using Avalonia.Controls;
using Avalonia.Layout;
using Avalonia.Media;

namespace UnityTheme.Gallery.Views;

public partial class InspectorPage : GalleryPageBase
{
    public InspectorPage()
    {
        var root = new StackPanel { Spacing = 12 };
        root.Children.Add(CreateTitle("Inspector Panel"));
        root.Children.Add(CreateDescription(
            "Expander headers styled like Unity Inspector sections — compact, collapsible property groups."));

        var inspector = new StackPanel { Spacing = 0, MaxWidth = 420 };

        var transform = new Expander { Header = "Transform", IsExpanded = true };
        transform.Content = CreatePropertyGrid(new (string, string)[]
        {
            ("Position", "0, 1.5, 0"),
            ("Rotation", "0, 45, 0"),
            ("Scale", "1, 1, 1")
        });
        inspector.Children.Add(transform);

        var mesh = new Expander { Header = "Mesh Renderer", IsExpanded = true };
        mesh.Content = CreatePropertyGrid(new (string, string)[]
        {
            ("Cast Shadows", "On"),
            ("Receive Shadows", "On"),
            ("Material", "Standard")
        });
        inspector.Children.Add(mesh);

        var physics = new Expander { Header = "Rigidbody", IsExpanded = false };
        physics.Content = CreatePropertyGrid(new (string, string)[]
        {
            ("Mass", "1"),
            ("Drag", "0"),
            ("Use Gravity", "True")
        });
        inspector.Children.Add(physics);

        root.Children.Add(CreateSection("Player (Inspector)", inspector));
        Content = root;
    }

    private static Control CreatePropertyGrid((string Label, string Value)[] rows)
    {
        var grid = new Grid
        {
            ColumnDefinitions = new ColumnDefinitions("120,*"),
            RowDefinitions = new RowDefinitions(string.Join(',', Enumerable.Repeat("Auto", rows.Length)))
        };

        for (var i = 0; i < rows.Length; i++)
        {
            var (label, value) = rows[i];

            var labelBlock = new TextBlock
            {
                Text = label,
                Opacity = 0.7,
                VerticalAlignment = VerticalAlignment.Center,
                Margin = new Thickness(0, 2)
            };
            Grid.SetRow(labelBlock, i);
            Grid.SetColumn(labelBlock, 0);
            grid.Children.Add(labelBlock);

            var valueBox = new TextBox
            {
                Text = value,
                Margin = new Thickness(0, 1),
                MinHeight = 20
            };
            Grid.SetRow(valueBox, i);
            Grid.SetColumn(valueBox, 1);
            grid.Children.Add(valueBox);
        }

        return grid;
    }
}
