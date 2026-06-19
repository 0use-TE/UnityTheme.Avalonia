# UnityTheme.Avalonia

Standalone [Avalonia UI](https://avaloniaui.net/) theme inspired by the **Unity Editor** — compact, dark-first, and built for professional tools that need high information density.

- **Zero FluentTheme dependency** — only the core `Avalonia` NuGet package
- **Unity Pro palette** — dark `#383838` surfaces, `#191919` inputs, `#478BF5` accent
- **Compact density** — 12px font, 20px control height, 1px corners
- **28+ adapted core controls** — buttons, inputs, lists, tabs, splitters, date/time pickers, and more

![License](https://img.shields.io/badge/license-MIT-blue.svg)
![Avalonia](https://img.shields.io/badge/Avalonia-12.0.4-purple.svg)
![.NET](https://img.shields.io/badge/.NET-8.0-512BD4.svg)

## Preview

Run the gallery to explore every styled control and switch between dark / light themes:

```bash
git clone https://github.com/YOUR_USERNAME/UnityTheme.Avalonia.git
cd UnityTheme.Avalonia
dotnet run --project samples/UnityTheme.Gallery
```

> Replace `YOUR_USERNAME` with your GitHub username after publishing the repository.

## Quick start

### 1. Reference the theme project

```bash
dotnet add YourApp.csproj reference path/to/UnityTheme.Avalonia/src/UnityTheme.Avalonia/UnityTheme.Avalonia.csproj
```

### 2. Apply in `App.axaml`

```xml
<Application xmlns="https://github.com/avaloniaui"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:unity="using:UnityTheme.Avalonia"
             x:Class="YourApp.App"
             RequestedThemeVariant="Dark">
  <Application.Styles>
    <unity:UnityTheme />
  </Application.Styles>
</Application>
```

### 3. Use Unity semantic brushes (optional)

```xml
<Border Background="{DynamicResource UnityPanelBackgroundBrush}"
        BorderBrush="{DynamicResource UnityBorderBrush}" />
```

| Resource | Dark | Usage |
|----------|------|-------|
| `UnityPanelBackgroundBrush` | `#282828` | Panels, lists |
| `UnityInputBackgroundBrush` | `#191919` | Text fields |
| `UnityToolbarBackgroundBrush` | `#3C3C3C` | Toolbars |
| `UnitySelectionBrush` | `#2C5D87` | List / tree selection |
| `HighlightBrush` | `#478BF5` | Accent, focus ring |

## Project structure

```
UnityTheme.Avalonia/
├── src/UnityTheme.Avalonia/     Theme library
│   ├── Accents/Base.xaml        Colors, tokens, light/dark palettes
│   ├── Controls/                Per-control themes (~74 templates)
│   └── Strings/                 Invariant strings for pickers/menus
├── samples/UnityTheme.Gallery/  Interactive component gallery
├── Directory.Packages.props     Central package versions (Avalonia 12.0.4)
└── UnityTheme.Avalonia.slnx
```

## Adapted controls

| Category | Controls |
|----------|----------|
| Actions | Button, ToggleButton, SplitButton, DropDownButton |
| Selection | CheckBox, RadioButton, ToggleSwitch |
| Input | Label, TextBox, ComboBox, NumericUpDown, AutoCompleteBox |
| Value | Slider, ProgressBar |
| Lists | ListBox, TreeView (+ items) |
| Menus | Menu, MenuItem, ContextMenu |
| Layout | TabControl, Expander, GroupBox, Separator, GridSplitter, SplitView |
| Date & time | DatePicker, TimePicker |
| Chrome | ScrollViewer, ScrollBar |

Separate Avalonia packages (ColorPicker, DataGrid, TreeDataGrid, etc.) are **not** included — only core `Avalonia` controls.

## Architecture

Follows the same standalone pattern as [Avalonia.Themes.Simple](https://github.com/AvaloniaUI/Avalonia/tree/master/src/Avalonia.Themes.Simple):

- `UnityTheme` extends `Styles` (not `FluentTheme`)
- Full control templates with Unity color and density overrides
- Shared tokens: `UnityControlMinHeight`, `UnityControlPadding`, `UnityControlCornerRadius`

## Build

Requirements: [.NET 8 SDK](https://dotnet.microsoft.com/download)

```bash
dotnet build UnityTheme.Avalonia.slnx
```

## Gallery pages

| Page | Contents |
|------|----------|
| All Controls | Full catalog of every adapted control |
| Buttons | Button variants, toggles, split buttons |
| Inputs | Text fields, combo box, slider, progress |
| Selection | CheckBox, RadioButton, ToggleSwitch |
| Lists & Trees | ListBox, TreeView |
| Menus | Menu bar, context menu |
| Layout | Tabs, splitters, date/time pickers |
| Inspector | Expander-based property panel demo |

## Local Avalonia source (optional)

If you keep a local clone of the [Avalonia repository](https://github.com/AvaloniaUI/Avalonia) for reference, place it in an `Avalonia/` folder next to the solution. **This folder is git-ignored** and is not part of the published package.

## Contributing

Issues and pull requests are welcome. Please keep changes focused and match the existing compact Unity style.

## License

[MIT](LICENSE) — see [LICENSE](LICENSE) for details.

## Acknowledgements

- [Avalonia UI](https://avaloniaui.net/) — cross-platform UI framework
- Control templates derived from [Avalonia.Themes.Simple](https://github.com/AvaloniaUI/Avalonia/tree/master/src/Avalonia.Themes.Simple)
