using Avalonia.Controls;

namespace UnityTheme.Gallery.Views;

public partial class InputsPage : GalleryPageBase
{
    public InputsPage()
    {
        var root = new StackPanel { Spacing = 12 };
        root.Children.Add(CreateTitle("Inputs"));
        root.Children.Add(CreateDescription("Compact 20px controls sharing Unity input colors, borders, and focus accent."));

        var aligned = new StackPanel { Spacing = 6, MaxWidth = 280 };
        aligned.Children.Add(new Label { Content = "Same width & height" });
        aligned.Children.Add(new TextBox { Text = "TextBox" });
        aligned.Children.Add(new ComboBox
        {
            ItemsSource = new[] { "ComboBox item" },
            SelectedIndex = 0
        });
        aligned.Children.Add(new NumericUpDown { Value = 42, Minimum = 0, Maximum = 100 });
        aligned.Children.Add(new AutoCompleteBox
        {
            PlaceholderText = "AutoCompleteBox",
            ItemsSource = new[] { "Material", "Mesh", "MonoBehaviour" }
        });
        root.Children.Add(CreateSection("Aligned inputs", aligned));

        var form = new StackPanel { Spacing = 8, MaxWidth = 360 };
        form.Children.Add(new TextBox { PlaceholderText = "Object name" });
        form.Children.Add(new TextBox { Text = "Transform.localPosition", IsReadOnly = true });
        form.Children.Add(new TextBox { PlaceholderText = "Multi-line notes", AcceptsReturn = true, Height = 72 });
        form.Children.Add(new NumericUpDown { Value = 1.0m, Increment = 0.1m, FormatString = "F2", Width = 120 });
        form.Children.Add(new ComboBox
        {
            PlaceholderText = "Shader",
            ItemsSource = new[] { "Standard", "Unlit/Color", "UI/Default" },
            SelectedIndex = 0
        });
        form.Children.Add(new Slider { Minimum = 0, Maximum = 100, Value = 42 });
        form.Children.Add(new ProgressBar { Value = 72, Minimum = 0, Maximum = 100, ShowProgressText = true });

        root.Children.Add(CreateSection("Property fields", form));
        Content = root;
    }
}
