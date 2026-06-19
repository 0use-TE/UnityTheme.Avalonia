# UnityTheme.Avalonia

Avalonia theme that looks like the **Unity Editor** — dark, compact, high density. No FluentTheme dependency.

![License](https://img.shields.io/badge/license-MIT-blue.svg)
![Avalonia](https://img.shields.io/badge/Avalonia-12.0.4-purple.svg)
![.NET](https://img.shields.io/badge/.NET_8+-512BD4.svg)

## Try it

Online gallery (WASM): **[0use.net/UnityTheme.Avalonia](https://0use.net/UnityTheme.Avalonia/)**

Run locally:

```bash
# Desktop — .NET 8
dotnet run --project samples/UnityTheme.Gallery.Desktop

# Browser — .NET 10 + wasm-tools
dotnet workload install wasm-tools
dotnet run --project samples/UnityTheme.Gallery.Browser
```

## Use in your app

The theme targets `net8.0`. Reference it from a **.NET 8 or .NET 10** Avalonia app — both work fine.

```bash
dotnet add YourApp.csproj reference path/to/src/UnityTheme.Avalonia/UnityTheme.Avalonia.csproj
```

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

Handy brushes:

| Resource | Dark | Use for |
|----------|------|---------|
| `UnityPanelBackgroundBrush` | `#282828` | Panels, lists |
| `UnityInputBackgroundBrush` | `#191919` | Text fields |
| `UnityToolbarBackgroundBrush` | `#3C3C3C` | Toolbars |
| `UnitySelectionBrush` | `#2C5D87` | Selection |
| `HighlightBrush` | `#478BF5` | Accent, focus |

## What's in the box

- Unity Pro colors, 12px font, 20px controls, 1px corners
- 28+ core controls styled (Button, TextBox, ListBox, TabControl, DatePicker, SplitView, …)
- Light / dark via `RequestedThemeVariant`
- Only depends on the core `Avalonia` package

ColorPicker, DataGrid, TreeDataGrid etc. are **not** included.

## Repo layout

```
src/UnityTheme.Avalonia/          Theme library (net8.0)
samples/UnityTheme.Gallery/       Gallery UI
samples/UnityTheme.Gallery.Desktop/   Desktop app (net8.0)
samples/UnityTheme.Gallery.Browser/   WASM app (net10.0-browser)
```

Browser sample needs .NET 10 because Avalonia 12's Browser package does. The theme itself doesn't.

## Build

```bash
dotnet build UnityTheme.Avalonia.slnx
```

## License

MIT — see [LICENSE](LICENSE).

Control templates started from [Avalonia.Themes.Simple](https://github.com/AvaloniaUI/Avalonia/tree/master/src/Avalonia.Themes.Simple).
