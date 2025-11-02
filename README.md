# Evora.FluentForms

> Modern Fluent Design System for Windows Forms - Apply Mica, Acrylic, and backdrop effects with ease

[![.NET](https://img.shields.io/badge/.NET-6.0+-512BD4?logo=dotnet)](https://dotnet.microsoft.com/)
[![Windows](https://img.shields.io/badge/Windows-11+-0078D4?logo=windows)](https://www.microsoft.com/windows)
[![License](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)

---

## 📚 Table of Contents

- [Features](#-features)
- [Installation](#-installation)
- [Quick Start](#-quick-start)
- [Complete API Reference](#-complete-api-reference)
- [Step-by-Step Guide](#-step-by-step-guide)
- [Usage Examples](#-usage-examples)
- [Advanced Topics](#-advanced-topics)
- [Troubleshooting](#-troubleshooting)
- [Requirements](#-requirements)
- [Migration Guide](#-migration-from-libmaterial-v1x)
- [FAQ](#-frequently-asked-questions)
- [Contributing](#-contributing)
- [License](#-license)

---

## ✨ Features

- 🎨 **Fluent Design Effects** - Mica, Acrylic, and Tabbed Window backdrop support
- 🌓 **Automatic Theme Detection** - Seamless light/dark mode switching
- 🚀 **Simple API** - One-line setup with `Fluent.ApplyMica(this)`
- 🔧 **Extension Methods** - Intuitive Form extensions
- 📦 **Zero Dependencies** - Pure Win32 DWM API integration
- ⚡ **Windows 11 Native** - Full DwmSetWindowAttribute support
- 🎯 **Beginner Friendly** - Easy to learn and use
- 📖 **Well Documented** - Comprehensive guides and examples

---

## 📦 Installation

### Option 1: .NET CLI (Recommended)

```bash
dotnet add package Evora.FluentForms
```

### Option 2: NuGet Package Manager

```powershell
Install-Package Evora.FluentForms
```

### Option 3: Visual Studio

1. Right-click on your project → **Manage NuGet Packages**
2. Search for `Evora.FluentForms`
3. Click **Install**

---

## 🚀 Quick Start

### Your First Fluent Form (30 seconds)

1. **Add the using directive:**

```csharp
using Evora.FluentForms;
```

2. **Apply Mica effect in your Form constructor:**

```csharp
public partial class MainForm : Form
{
    public MainForm()
    {
     InitializeComponent();
        Fluent.ApplyMica(this);  // That's it!
    }
}
```

3. **Handle theme changes (recommended):**

```csharp
protected override void OnSystemColorsChanged(EventArgs e)
{
    base.OnSystemColorsChanged(e);
    this.UpdateTheme();
}
```

**Done!** Run your application and see the beautiful Mica effect! 🎉

---

## 📖 Complete API Reference

### 1. Fluent Class (Static Methods)

The `Fluent` class provides simple static methods for quick setup.

#### Apply Effects

| Method | Description | When to Use |
|--------|-------------|-------------|
| `Fluent.ApplyMica(form)` | Applies Mica backdrop effect | Main windows, long-lived windows |
| `Fluent.ApplyAcrylic(form)` | Applies Acrylic backdrop effect | Dialogs, popups, transient windows |
| `Fluent.ApplyTabbedWindow(form)` | Applies tabbed window effect | Windows with tab controls |
| `Fluent.RemoveEffects(form)` | Removes all effects | When you need to disable effects |

**Example:**
```csharp
// Apply Mica to main window
Fluent.ApplyMica(this);

// Apply Acrylic to dialog
Fluent.ApplyAcrylic(myDialog);

// Remove all effects
Fluent.RemoveEffects(this);
```

#### Theme Detection

| Method | Returns | Description |
|--------|---------|-------------|
| `Fluent.IsDarkMode()` | `bool` | Returns `true` if Windows is in dark mode |
| `Fluent.IsLightMode()` | `bool` | Returns `true` if Windows is in light mode |

**Example:**
```csharp
if (Fluent.IsDarkMode())
{
    // Apply dark theme customizations
  this.ForeColor = Color.White;
}
else
{
    // Apply light theme customizations
    this.ForeColor = Color.Black;
}
```

#### Color Utilities

| Method | Returns | Description |
|--------|---------|-------------|
| `Fluent.GetAccentColor()` | `Color` | Gets Windows accent color |
| `Fluent.GetColorizationColor()` | `Color` | Gets Windows colorization color |

**Example:**
```csharp
Color accent = Fluent.GetAccentColor();
myButton.BackColor = accent;  // Match Windows accent color
```

---

### 2. Extension Methods

Extension methods provide a fluent API directly on Form objects.

#### Apply Effects

| Method | Description | Parameters |
|--------|-------------|------------|
| `form.ApplyAuto()` | Applies all effects with auto theme | `backdropType` (optional) |
| `form.ApplyMicaEffect()` | Applies backdrop effect only | `backdropType` (optional) |
| `form.ApplyTheme(bool)` | Applies light/dark theme | `useDarkMode` |
| `form.ApplyTransparency(bool)` | Applies transparent background | `useDarkMode` |
| `form.UpdateTheme()` | Updates theme from system | None |

**Example:**
```csharp
// Automatic - easiest way
this.ApplyAuto();

// Manual control
this.ApplyMicaEffect();
this.ApplyTheme(true);  // Dark mode
this.ApplyTransparency(true);

// Update when system theme changes
this.UpdateTheme();
```

#### Remove Effects

| Method | Description |
|--------|-------------|
| `form.RemoveAuto()` | Removes all effects |
| `form.RemoveMicaEffect()` | Removes backdrop only |
| `form.RemoveTransparency()` | Removes transparency only |

**Example:**
```csharp
// Remove everything
this.RemoveAuto();

// Remove selectively
this.RemoveMicaEffect();
this.RemoveTransparency();
```

---

## 🎓 Step-by-Step Guide

### Step 1: Create a New WinForms Project

```bash
dotnet new winforms -n MyFluentApp
cd MyFluentApp
```

### Step 2: Install Evora.FluentForms

```bash
dotnet add package Evora.FluentForms
```

### Step 3: Open Form1.cs and Add Using

```csharp
using Evora.FluentForms;  // Add this line
```

### Step 4: Apply Mica Effect

```csharp
public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        
        // Add this line
        Fluent.ApplyMica(this);
    }
}
```

### Step 5: Handle Theme Changes

```csharp
public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
      Fluent.ApplyMica(this);
    }
    
    // Add this method
    protected override void OnSystemColorsChanged(EventArgs e)
    {
        base.OnSystemColorsChanged(e);
        this.UpdateTheme();
    }
}
```

### Step 6: Run Your App

```bash
dotnet run
```

**Congratulations!** 🎉 You now have a beautiful Fluent Design window!

---

## 🎯 Usage Examples

### Example 1: Basic Mica Window

The simplest way to add Mica effect to your main window.

```csharp
using Evora.FluentForms;

public class MainWindow : Form
{
    public MainWindow()
    {
        InitializeComponent();
 
        // Apply Mica effect
        Fluent.ApplyMica(this);
    }
    
    // Update theme when Windows theme changes
    protected override void OnSystemColorsChanged(EventArgs e)
    {
      base.OnSystemColorsChanged(e);
        this.UpdateTheme();
    }
}
```

**When to use:** Main application windows that stay open for a long time.

---

### Example 2: Acrylic Dialog

Perfect for dialogs, popups, and temporary windows.

```csharp
using Evora.FluentForms;

public class SettingsDialog : Form
{
    public SettingsDialog()
    {
        InitializeComponent();
        
        // Apply Acrylic effect (lighter, more transparent)
     Fluent.ApplyAcrylic(this);
 }
    
    protected override void OnSystemColorsChanged(EventArgs e)
    {
        base.OnSystemColorsChanged(e);
        this.UpdateTheme();
    }
}
```

**When to use:** Dialogs, settings windows, popups, message boxes.

---

### Example 3: Extension Methods

Using the fluent API for more control.

```csharp
using Evora.FluentForms;

public class MyForm : Form
{
    public MyForm()
    {
        InitializeComponent();
        
        // Apply all effects automatically
        this.ApplyAuto();
   
        // Or apply individually:
  // this.ApplyMicaEffect();
        // this.ApplyTheme(Fluent.IsDarkMode());
        // this.ApplyTransparency(Fluent.IsDarkMode());
    }
    
    protected override void OnSystemColorsChanged(EventArgs e)
    {
        base.OnSystemColorsChanged(e);
        this.UpdateTheme();
    }
}
```

**When to use:** When you want a fluent API style or need more control.

---

### Example 4: Manual Theme Control

Full control over dark/light theme with a toggle button.

```csharp
using Evora.FluentForms;

public class CustomThemeForm : Form
{
    private bool _isDarkMode = true;
    private Button btnToggleTheme;
    
 public CustomThemeForm()
 {
        InitializeComponent();
     
  // Setup toggle button
        btnToggleTheme = new Button { Text = "Toggle Theme" };
        btnToggleTheme.Click += (s, e) => ToggleTheme();
     this.Controls.Add(btnToggleTheme);
        
    // Apply initial theme
        ApplyCustomTheme();
    }
    
    private void ApplyCustomTheme()
    {
        this.ApplyMicaEffect();
      this.ApplyTheme(_isDarkMode);
        this.ApplyTransparency(_isDarkMode);
        
        // Custom styling based on theme
        if (_isDarkMode)
   {
            btnToggleTheme.Text = "☀️ Light Mode";
        }
        else
        {
            btnToggleTheme.Text = "🌙 Dark Mode";
        }
    }
    
    private void ToggleTheme()
    {
        _isDarkMode = !_isDarkMode;
      ApplyCustomTheme();
    }
}
```

**When to use:** Apps with manual theme switching, custom theme logic.

---

### Example 5: Detecting Windows Theme

React to Windows theme and customize your UI accordingly.

```csharp
using Evora.FluentForms;

public class ThemedForm : Form
{
    public ThemedForm()
    {
    InitializeComponent();
 
        // Check Windows theme
    if (Fluent.IsDarkMode())
        {
            ApplyDarkCustomizations();
        }
        else
      {
            ApplyLightCustomizations();
   }
        
        // Apply Mica effect
      this.ApplyAuto();
}
    
    private void ApplyDarkCustomizations()
    {
 this.BackColor = Color.FromArgb(32, 32, 32);
        this.ForeColor = Color.White;
   // Add more dark theme customizations
    }
    
    private void ApplyLightCustomizations()
    {
        this.BackColor = Color.FromArgb(243, 243, 243);
  this.ForeColor = Color.Black;
        // Add more light theme customizations
    }
    
    protected override void OnSystemColorsChanged(EventArgs e)
    {
        base.OnSystemColorsChanged(e);
        
   // Reapply customizations when theme changes
        if (Fluent.IsDarkMode())
        {
ApplyDarkCustomizations();
        }
  else
        {
     ApplyLightCustomizations();
        }
    
        this.UpdateTheme();
    }
}
```

**When to use:** Apps that need to match Windows theme with custom styling.

---

### Example 6: Using Windows Accent Colors

Match Windows accent color for a cohesive look.

```csharp
using Evora.FluentForms;

public class AccentColorForm : Form
{
    private Panel accentPanel;
    private Button accentButton;
    
    public AccentColorForm()
    {
      InitializeComponent();
   
        // Create controls with accent color
 accentPanel = new Panel
        {
            BackColor = Fluent.GetAccentColor(),
            Dock = DockStyle.Top,
 Height = 50
        };
        
        accentButton = new Button
  {
            Text = "Accent Button",
        BackColor = Fluent.GetAccentColor(),
  ForeColor = Color.White,
 FlatStyle = FlatStyle.Flat
        };
        
   this.Controls.Add(accentPanel);
        this.Controls.Add(accentButton);
  
 // Apply Mica
        Fluent.ApplyMica(this);
    }
    
    protected override void OnSystemColorsChanged(EventArgs e)
    {
        base.OnSystemColorsChanged(e);
        
        // Update accent colors when they change
        Color newAccent = Fluent.GetAccentColor();
        accentPanel.BackColor = newAccent;
        accentButton.BackColor = newAccent;
        
        this.UpdateTheme();
    }
}
```

**When to use:** Apps that want to match Windows accent color for branding consistency.

---

### Example 7: Removing Effects Dynamically

Add or remove effects at runtime.

```csharp
using Evora.FluentForms;

public class DynamicEffectsForm : Form
{
    private CheckBox chkEnableEffects;
    
    public DynamicEffectsForm()
    {
        InitializeComponent();
        
        // Create checkbox
 chkEnableEffects = new CheckBox
        {
       Text = "Enable Fluent Effects",
            Checked = true,
            Location = new Point(20, 20)
        };
        chkEnableEffects.CheckedChanged += ChkEnableEffects_CheckedChanged;
   this.Controls.Add(chkEnableEffects);
        
    // Initially enabled
 Fluent.ApplyMica(this);
    }
    
    private void ChkEnableEffects_CheckedChanged(object sender, EventArgs e)
    {
        if (chkEnableEffects.Checked)
{
            // Enable effects
            Fluent.ApplyMica(this);
        }
        else
 {
    // Disable effects
      Fluent.RemoveEffects(this);
        }
    }
    
  protected override void OnSystemColorsChanged(EventArgs e)
    {
      base.OnSystemColorsChanged(e);
        if (chkEnableEffects.Checked)
        {
            this.UpdateTheme();
        }
    }
}
```

**When to use:** Apps that let users toggle effects, or need to enable/disable effects dynamically.

---

## 🔬 Advanced Topics

### Using Low-Level APIs

For advanced scenarios, you can use the low-level APIs directly.

```csharp
using Evora.FluentForms;

public class AdvancedForm : Form
{
    public AdvancedForm()
    {
        InitializeComponent();
    
        // Low-level API for maximum control
 bool isDarkMode = !LibRegistry.GetAppUseLightTheme();
        
        LibApply.Apply_Backdrop_Effect(
            this.Handle,
       LibImport.DwmSystemBackdropTypeFlgs.DWMSBT_MAINWINDOW
        );
        
    LibApply.Apply_Light_Theme(this.Handle, isDarkMode);
     LibApply.Apply_Transparent_Form(this.Handle, isDarkMode);
    }
}
```

### Backdrop Types Explained

| Type | Constant | Description | Best For |
|------|----------|-------------|----------|
| **Mica** | `DWMSBT_MAINWINDOW` | Solid, performance-optimized | Main windows |
| **Acrylic** | `DWMSBT_TRANSIENTWINDOW` | Semi-transparent, blurred | Dialogs, popups |
| **Tabbed** | `DWMSBT_TABBEDWINDOW` | Optimized for tabs | Tabbed interfaces |
| **None** | `DWMSBT_NONE` | No effect | Disable effects |
| **Auto** | `DWMSBT_AUTO` | System decides | Let Windows choose |

### Custom Backdrop Type

```csharp
// Apply specific backdrop type
this.ApplyAuto(LibImport.DwmSystemBackdropTypeFlgs.DWMSBT_TRANSIENTWINDOW);

// Or
this.ApplyMicaEffect(LibImport.DwmSystemBackdropTypeFlgs.DWMSBT_TABBEDWINDOW);
```

---

## 🐛 Troubleshooting

### Issue: Effects not showing

**Possible causes:**
1. Not running on Windows 11
2. Effects applied before window handle created
3. Windows settings disabled transparency

**Solution:**
```csharp
public MyForm()
{
    InitializeComponent();  // Call this FIRST
    
    // Then apply effects (handle must be created)
    Fluent.ApplyMica(this);
}
```

### Issue: Theme not updating

**Problem:** Theme doesn't change when Windows theme changes.

**Solution:** Always override `OnSystemColorsChanged`:
```csharp
protected override void OnSystemColorsChanged(EventArgs e)
{
    base.OnSystemColorsChanged(e);  // Don't forget base call
    this.UpdateTheme();
}
```

### Issue: Window looks wrong in dark mode

**Problem:** Text or controls not visible in dark mode.

**Solution:** Set `ForeColor` and customize controls:
```csharp
if (Fluent.IsDarkMode())
{
    this.ForeColor = Color.White;
    // Customize other controls
}
```

### Issue: Performance problems

**Problem:** Mica effect causes performance issues.

**Solution:** Use Acrylic or remove effects on low-end systems:
```csharp
try
{
    Fluent.ApplyMica(this);
}
catch
{
    // Fallback to no effects on error
}
```

---

## 📋 Requirements

### Minimum Requirements

- **Operating System:** Windows 11 (22000 or higher)
- **Framework:** .NET 6.0 or higher
- **Application Type:** Windows Forms (WinForms)
- **Visual Studio:** 2022 or later (recommended)

### Compatibility Notes

| Feature | Windows 11 | Windows 10 | Older |
|---------|------------|------------|-------|
| Mica Effect | ✅ Full | ❌ No | ❌ No |
| Acrylic Effect | ✅ Full | ❌ No | ❌ No |
| Theme Detection | ✅ Yes | ✅ Yes | ⚠️ Partial |
| Accent Colors | ✅ Yes | ✅ Yes | ✅ Yes |

> **Note:** On Windows 10 and older, effects will gracefully fail and your app will still work, just without the backdrop effects.

---

## 🔄 Migration from LibMaterial v1.x

### Quick Migration (2 minutes)

**Step 1:** Update namespace
```csharp
// Old
using LibMaterial;

// New
using Evora.FluentForms;
```

**Step 2:** Update class name
```csharp
// Old
Material.ApplyMica(this);

// New
Fluent.ApplyMica(this);
```

**Step 3:** Update extension method (optional)
```csharp
// Old
this.ApplyMaterial();

// New
this.ApplyAuto();
```

### Complete Migration Table

| Old (LibMaterial) | New (Evora.FluentForms) |
|-------------------|------------------------|
| `Material.ApplyMica()` | `Fluent.ApplyMica()` |
| `Material.ApplyAcrylic()` | `Fluent.ApplyAcrylic()` |
| `Material.IsDarkMode()` | `Fluent.IsDarkMode()` |
| `Material.GetAccentColor()` | `Fluent.GetAccentColor()` |
| `this.ApplyMaterial()` | `this.ApplyAuto()` |
| `this.RemoveMaterial()` | `this.RemoveAuto()` |

### Backward Compatibility

The original low-level APIs are still available:
```csharp
// These still work in v2.0+
LibApply.Apply_Backdrop_Effect(handle, type);
LibRegistry.GetAppUseLightTheme();
LibImport.DwmSystemBackdropTypeFlgs.DWMSBT_MAINWINDOW
```

---

## ❓ Frequently Asked Questions

### Q: Does this work on Windows 10?

**A:** The library works on Windows 10, but Mica and Acrylic effects require Windows 11. On Windows 10, the effects will be ignored, and your app will still function normally.

### Q: Do I need to install any dependencies?

**A:** No! Evora.FluentForms has zero dependencies. It uses only Win32 APIs built into Windows.

### Q: Can I use this in WPF or other frameworks?

**A:** Currently, Evora.FluentForms is designed specifically for Windows Forms. For WPF, consider using native WPF backdrop support.

### Q: Will this affect my app's performance?

**A:** Mica and Acrylic effects are GPU-accelerated by Windows, so impact is minimal. Mica is more performant than Acrylic.

### Q: Can I customize the blur amount or transparency?

**A:** The effects are controlled by Windows DWM and cannot be customized. However, you can use `TransparencyKey` for additional effects.

### Q: Does this work with dark/light theme automatically?

**A:** Yes! Use `this.UpdateTheme()` in `OnSystemColorsChanged` to automatically update when Windows theme changes.

### Q: Can I use this in commercial applications?

**A:** Yes! Evora.FluentForms is MIT licensed, so you can use it in commercial projects for free.

### Q: How do I contribute or report bugs?

**A:** Visit our [GitHub repository](https://github.com/famliars/LibMaterial) to report issues or submit pull requests.

---

## 🤝 Contributing

We welcome contributions! Here's how you can help:

### Ways to Contribute

- 🐛 **Report Bugs** - Found a bug? [Open an issue](https://github.com/famliars/LibMaterial/issues)
- ✨ **Suggest Features** - Have an idea? We'd love to hear it!
- 📖 **Improve Documentation** - Help make our docs even better
- 🔧 **Submit Pull Requests** - Fix bugs or add features
- 💬 **Share Your Projects** - Show us what you've built!

### Development Setup

```bash
# Clone the repository
git clone https://github.com/famliars/LibMaterial.git

# Navigate to directory
cd LibMaterial/Evora.FluentForms

# Restore dependencies
dotnet restore

# Build
dotnet build

# Run tests (if available)
dotnet test
```

---

## 📄 License

**MIT License** - Copyright (c) 2023-2024 Evora

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

---

## 🙏 Credits

This project is based on the original [LibMaterial](https://github.com/Simple-2021/LibMaterial) by Simple-2021.

Enhanced, rebranded, and modernized as **Evora.FluentForms** with:

- 🎨 Simplified API design
- 📖 Comprehensive documentation
- 🚀 Modern naming conventions
- 🔧 Extension method support
- 🎓 Beginner-friendly approach
- ✨ Improved developer experience

---

## 📞 Support

- 📧 **Issues:** [GitHub Issues](https://github.com/famliars/LibMaterial/issues)
- 📖 **Documentation:** You're reading it!
- 💬 **Discussions:** [GitHub Discussions](https://github.com/famliars/LibMaterial/discussions)

---

## ⭐ Star This Project

If you find Evora.FluentForms useful, please give it a star on GitHub! ⭐

It helps others discover the project and motivates us to keep improving it.

[⭐ Star on GitHub](https://github.com/famliars/LibMaterial)

---

## 🎉 Thank You!

Thank you for using Evora.FluentForms! We hope it makes your Windows Forms applications more beautiful and modern.

**Made with ❤️ for the Windows Forms community**
