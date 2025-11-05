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
- 🎨 **Multiple Effects** - Mica, Acrylic, Tabbed, and more
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
        this.Mica();  // ← That's it! Auto-detects theme
    }
}
```

---

## 📚 Usage Guide

### Simple Effects (One-Liners)

Perfect for **99% of use cases**:

```csharp
// Auto-detect system theme + apply effect
this.Mica();                    // Windows 11 Mica effect
this.Acrylic();                 // Transparent Acrylic
this.Tabbed();                  // Tabbed window effect
this.Auto();                    // Same as Mica()

// Force specific theme
this.Mica(Theme.Dark);          // Dark Mica
this.Acrylic(Theme.Light);      // Light Acrylic

// Cleanup
this.Reset();                   // Remove all effects
```

**Real Example:**
```csharp
public MainWindow()
{
    InitializeComponent();
    
    // Modern app - auto theme detection
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
// Light Mica
this.Configure()
    .Mica()
    .Light()
    .Apply();

// Tabbed with auto theme
this.Configure()
    .Tabbed()
    .Auto()
    .Apply();

// Dark, no backdrop
this.Configure()
    .None()
    .Dark()
    .Apply();

// Acrylic dialog
this.Configure()
    .Acrylic()
    .Auto()
    .Transparency()
    .Apply();
```

---

## 📖 Complete API Reference

### Simple Methods

| Method | Effect | Theme |
|--------|--------|-------|
| `this.Mica()` | Mica | Auto-detect |
| `this.Mica(Theme.Dark)` | Mica | Dark |
| `this.Mica(Theme.Light)` | Mica | Light |
| `this.Acrylic()` | Acrylic | Auto-detect |
| `this.Acrylic(Theme.Dark)` | Acrylic | Dark |
| `this.Tabbed()` | Tabbed | Auto-detect |
| `this.Auto()` | Mica | Auto-detect |
| `this.Reset()` | None | - |

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

**Transparency:**
```csharp
.Transparency()      // Enable transparency
.NoTransparency()    // Disable transparency
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

## 💡 Common Use Cases

### 1️⃣ Modern App (Most Common)
```csharp
public MainWindow()
{
    InitializeComponent();
    this.Mica();  // Auto-detects theme, done!
}
```

### 2️⃣ Transparent Dialog
```csharp
public SettingsDialog()
{
    InitializeComponent();
    
    this.Configure()
        .Acrylic()
        .Auto()
        .Transparency()
        .Apply();
}
```

### 3️⃣ Dark Splash Screen
```csharp
public SplashScreen()
{
    InitializeComponent();
    this.Mica(Theme.Dark);  // Always dark
}
```

### 4️⃣ Tabbed Application
```csharp
public MainWindow()
{
    InitializeComponent();
    
    this.Configure()
        .Tabbed()
        .Auto()
        .Apply();
}
```

### 5️⃣ Respond to System Theme Changes
```csharp
private void Form_SystemColorsChanged(object sender, EventArgs e)
{
    // Re-apply with new system theme
    this.Configure()
        .Mica()
        .Auto()
        .Apply();
}
```

---

## 🎯 Effect Guide

| Effect | Best For | Transparency | Notes |
|--------|----------|--------------|-------|
| **Mica** | Main windows, primary UI | No | Default choice for most apps |
| **Acrylic** | Dialogs, menus, temporary windows | Yes | More subtle than Mica |
| **Tabbed** | Tabbed interfaces, multi-doc apps | No | Optimized for tabbed UI |
| **Auto** | Let DWM decide | Varies | Good fallback |

---

## 🔄 Application Patterns

### Pattern 1: Immediate Application (Most Common)
```csharp
// Auto-applies when transparency method called
this.Configure()
    .Mica()
    .Dark()
    .Transparency();    // ✅ Applies automatically
```

### Pattern 2: Explicit Application
```csharp
// Manual Apply() for full control
this.Configure()
    .Mica()
    .Dark()
    .Apply();          // ✅ Explicit apply
```

### Pattern 3: Build & Reuse
```csharp
// Build config, apply/modify multiple times
var config = this.Configure().Mica().Dark();

config.Apply();                    // Apply
config.Transparency().Apply();     // Modify & apply
config.Light().Apply();            // Change & apply again
```

---

## 🎓 Learning Path

1. **Start** → Use one-liners (`this.Mica()`)
2. **Add Theme** → Try `Theme.Dark` / `Theme.Light`
3. **Explore** → Experiment with `.Configure()` chaining
4. **Master** → Mix patterns for your use case

---

## 📋 Supported Frameworks

| Framework | Version | Status |
|-----------|---------|--------|
| .NET Framework | 4.8 | ✅ Supported |
| .NET | 6.0 (LTS) | ✅ Supported |
| .NET | 7.0 | ✅ Supported |
| .NET | 8.0 (LTS) | ✅ Supported |
| .NET | 9.0 | ✅ Supported |

**Note:** Windows only (uses Windows 11 Fluent Design APIs)

---

## 🏗️ Architecture

```
WinForms.Fluent
├── FluentExtensions      ← Simple one-liner methods
├── FluentConfig          ← Chainable configuration
├── FluentApply           ← Core effect application
├── FluentRegistry        ← System theme detection
├── FluentImport          ← Windows API bindings
└── FluentSymbol          ← Icon/symbol utilities
```

---

## 🤝 Contributing

Found a bug or have a feature request? 

- 📧 [Issues](https://github.com/evorajhonj/WinForms.Fluent/issues)
- 💬 [Discussions](https://github.com/evorajhonj/WinForms.Fluent/discussions)
- 🔗 [Pull Requests](https://github.com/evorajhonj/WinForms.Fluent/pulls)

---

## 📄 License

MIT License - see [LICENSE](LICENSE) for details

---

## 🔗 Links

- **GitHub**: [https://github.com/evorajhonj/WinForms.Fluent](https://github.com/evorajhonj/WinForms.Fluent)
- **NuGet**: [https://www.nuget.org/packages/WinForms.Fluent](https://www.nuget.org/packages/WinForms.Fluent)

---

## 🎯 Quick Reference Card

```csharp
// ⚡ Instant Effects
this.Mica();                        // Modern Mica
this.Acrylic();                     // Transparent Acrylic
this.Tabbed();                      // Tabbed UI
this.Auto();                        // Auto everything
this.Reset();                       // Remove effects

// 🎨 With Theme Control
this.Mica(Theme.Dark);              // Dark Mica
this.Acrylic(Theme.Light);          // Light Acrylic
this.Tabbed(Theme.Dark);            // Dark Tabbed

// ⚙️ Advanced Chaining
this.Configure()
    .Acrylic()
    .Dark()
    .Transparency()
    .Apply();

// 🔄 Reusable Config
var cfg = this.Configure().Mica().Light();
cfg.Apply();
cfg.Transparency().Apply();
```

---

<p align="center">
  Made with ❤️ for WinForms developers
</p>
