---
title: UnityTheme.Avalonia
layout: default
---

# UnityTheme.Avalonia

Unity Editor–inspired theme for [Avalonia UI](https://avaloniaui.net/).

**Compact · Dark-first · Zero FluentTheme dependency**

## Features

- Standalone theme library — depends only on the core `Avalonia` package (v12+)
- Unity Pro color palette and 20px compact control density
- 28+ styled core controls with an interactive gallery sample

## Get started

```bash
git clone https://github.com/YOUR_USERNAME/UnityTheme.Avalonia.git
cd UnityTheme.Avalonia
dotnet run --project samples/UnityTheme.Gallery
```

Apply in your app:

```xml
<Application xmlns:unity="using:UnityTheme.Avalonia" RequestedThemeVariant="Dark">
  <Application.Styles>
    <unity:UnityTheme />
  </Application.Styles>
</Application>
```

## Documentation

Full documentation lives in the repository [README](https://github.com/YOUR_USERNAME/UnityTheme.Avalonia).

## License

[MIT License](https://github.com/YOUR_USERNAME/UnityTheme.Avalonia/blob/main/LICENSE)
