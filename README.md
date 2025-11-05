# WinForms.Fluent

<p align="center">
  <img src="assets/icon.png" alt="WinForms.Fluent Icon" width="128" height="128">
</p>

<p align="center">
  <strong>Modern Windows 11 Fluent Design for WinForms</strong><br>
  Apply Mica, Acrylic, and Tabbed effects with an intuitive, chainable API.
</p>

<p align="center">
  <img src="https://img.shields.io/nuget/v/WinForms.Fluent?style=flat-square" alt="NuGet Version">
  <img src="https://img.shields.io/nuget/dt/WinForms.Fluent?style=flat-square" alt="NuGet Downloads">
  <img src="https://img.shields.io/github/license/evorajhonj/WinForms.Fluent?style=flat-square" alt="License">
</p>

---

## ✨ Features

- 🎯 **One-Line API** - `this.Mica()` applies effects instantly
- 🌓 **Auto Theme Detection** - Automatically detects Windows dark/light mode
- 🎨 **Multiple Effects** - Mica, Acrylic, Tabbed with full-window support
- 🎯 **Apply Target Control** - Choose titlebar-only or full-window effects
- ⚙️ **Chainable Configuration** - Fluent API for complex scenarios
- 🔒 **Type-Safe** - Full IntelliSense, no magic strings
- 📱 **Multi-Target** - .NET 6, 7, 8, 9 (Windows only)
- ⚡ **Zero Boilerplate** - Get modern UI in seconds

---

## 🚀 Installation

```bash
dotnet add package WinForms.Fluent
```

---

## 🎯 Quick Start

### Simplest Form Ever
```csharp
using WinForms.Fluent;

public partial class MainWindow : Form
{
    public MainWindow()
    {
        InitializeComponent();
        this.Mica();  // ← That's it! Auto-detects theme + full window
    }
}
```

---

## 📚 Usage Guide

### Simple Effects (One-Liners)

Perfect for **99% of use cases**:

```csharp
// Auto-detect system theme + apply effect (full window)
this.Mica();                    // Windows 11 Mica effect
this.Acrylic();                 // Transparent Acrylic
this.Tabbed();                  // Tabbed window effect
this.Auto();                    // Same as Mica()

// Force specific theme (full window)
this.Mica(Theme.Dark);          // Dark Mica
this.Acrylic(Theme.Light);      // Light Acrylic
this.Tabbed(Theme.Dark);        // Dark Tabbed

// Apply target control (titlebar only or full window)
this.Mica(Target.TitleBar);     // Titlebar only
this.Mica(Target.FullWindow);   // Full window

// With theme + target
this.Mica(Theme.Dark, Target.FullWindow);
this.Acrylic(Theme.Light, Target.TitleBar);

// Cleanup
this.Reset();                   // Remove all effects
```

**Real Example:**
```csharp
public MainWindow()
{
    InitializeComponent();
    
    // Modern app - auto theme detection, full window
    this.Mica();
}
```

---

### Advanced Configuration

For **custom combinations**:

```csharp
this.Configure()
    .Acrylic()                  // Backdrop type
    .Dark()                     // Theme
    .Transparency()             // Enable transparency
    .Apply();
```

**More Examples:**

```csharp
// Light Mica, full window
this.Configure()
    .Mica()
    .Light()
    .ToFullWindow()
    .Apply();

// Tabbed with auto theme, titlebar only
this.Configure()
    .Tabbed()
    .Auto()
    .ToTitleBar()
    .Apply();

// Dark, no backdrop
this.Configure()
    .None()
    .Dark()
    .Apply();

// Acrylic dialog with transparency
this.Configure()
    .Acrylic()
    .Auto()
    .Transparency()
    .ToFullWindow()
    .Apply();
```

---

## 📖 Complete API Reference

### Simple Methods

| Method | Effect | Theme | Target |
|--------|--------|-------|--------|
| `this.Mica()` | Mica | Auto-detect | Full Window |
| `this.Mica(Theme.Dark)` | Mica | Dark | Full Window |
| `this.Mica(Theme.Light)` | Mica | Light | Full Window |
| `this.Mica(Target.TitleBar)` | Mica | Auto-detect | TitleBar |
| `this.Mica(Theme.Dark, Target.FullWindow)` | Mica | Dark | Full Window |
| `this.Acrylic()` | Acrylic | Auto-detect | Full Window |
| `this.Acrylic(Theme.Dark)` | Acrylic | Dark | Full Window |
| `this.Tabbed()` | Tabbed | Auto-detect | Full Window |
| `this.Tabbed(Theme.Light)` | Tabbed | Light | Full Window |
| `this.Auto()` | Mica | Auto-detect | Full Window |
| `this.Reset()` | None | - | - |

### Configuration Methods

**Backdrop Types:**
```csharp
.Mica()              // Main window backdrop
.Acrylic()           // Transient/dialog backdrop
.Tabbed()            // Tabbed window backdrop
.AutoBackdrop()      // Let DWM auto-decide
.None()              // Disable backdrop
```

**Theme:**
```csharp
.Auto()              // Auto-detect from Windows
.Dark()              // Force dark theme
.Light()             // Force light theme
```

**Apply Target:**
```csharp
.ToTitleBar()        // Apply only to titlebar
.ToFullWindow()      // Apply to entire window (default)
```

**Transparency:**
```csharp
.Transparency()      // Enable transparency
.NoTransparency()    // Disable transparency (default)
```

**Apply:**
```csharp
.Apply()             // Explicitly apply configuration
// OR auto-applies on last method (.Transparency()/.NoTransparency())
```

---

## 🎨 Theme Constants

```csharp
using WinForms.Fluent;

// ❌ Confusing
this.Mica(true);                // What does true mean?

// ✅ Crystal Clear
this.Mica(Theme.Dark);          // Intent is obvious
this.Mica(Theme.Light);         // No ambiguity
```

---

## 🎯 Apply Target Enum

```csharp
using WinForms.Fluent;

// Apply only to titlebar (theme only)
this.Mica(Target.TitleBar);

// Apply to full window (backdrop + theme)
this.Mica(Target.FullWindow);   // Default

// In configuration
this.Configure()
    .Mica()
    .Dark()
    .ToTitleBar()      // Titlebar only
    .Apply();

this.Configure()
    .Acrylic()
    .Auto()
    .ToFullWindow()    // Full window (default)
    .Apply();
