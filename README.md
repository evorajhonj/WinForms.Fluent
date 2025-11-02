# Evora.FluentForms

> Bring Windows 11 Fluent Design to your WinForms applications with just one line of code

[![.NET](https://img.shields.io/badge/.NET-8.0+-512BD4?logo=dotnet)](https://dotnet.microsoft.com/)
[![Windows](https://img.shields.io/badge/Windows-11+-0078D4?logo=windows)](https://www.microsoft.com/windows)
[![License](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)
[![NuGet](https://img.shields.io/nuget/v/Evora.FluentForms.svg)](https://www.nuget.org/packages/Evora.FluentForms/)

A modern .NET library that brings Windows 11 Fluent Design System effects to WinForms applications. Apply **Mica**, **Acrylic**, and **Tabbed Window** backdrop materials with automatic theme detection and a clean, intuitive API.

---

## 📚 Table of Contents

- [✨ Features](#-features)
- [🎯 Why Evora.FluentForms?](#-why-evorafluentforms)
- [📦 Installation](#-installation)
- [🚀 Quick Start](#-quick-start)
- [🎨 Choosing Your Backdrop Style](#-choosing-your-backdrop-style)
- [📖 Core Concepts](#-core-concepts)
- [🎨 API Reference](#-api-reference)
- [💡 Usage Examples](#-usage-examples)
- [🔧 Advanced Usage](#-advanced-usage)
- [🐛 Troubleshooting](#-troubleshooting)
- [❓ FAQ](#-faq)
- [📋 Requirements](#-requirements)
- [🤝 Contributing](#-contributing)
- [📄 License](#-license)

---

## ✨ Features

- 🎨 **Three Backdrop Effects** - Mica, Acrylic, and Tabbed Window materials
- 🌓 **Automatic Theme Detection** - Seamless light/dark mode switching
- 🚀 **One-Line Setup** - `Fluent.ApplyMica(this)` - that's it!
- 🔧 **Extension Methods** - Fluent API with intuitive method chaining
- 🎯 **Windows Accent Colors** - Access and use system accent colors
- 📦 **Zero Dependencies** - Pure Win32 DWM API integration
- ⚡ **Windows 11 Native** - Full `DwmSetWindowAttribute` support
- 🎓 **Beginner Friendly** - Clear documentation and examples

---

## 🎯 Why Evora.FluentForms?

Evora.FluentForms makes it incredibly easy to give your WinForms applications a modern Windows 11 look:

**Without Evora.FluentForms:**
```csharp
// Complex P/Invoke declarations
[DllImport("dwmapi.dll")]
static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

// Manual backdrop setup
int backdropType = 2; // What does 2 mean?
DwmSetWindowAttribute(this.Handle, 38, ref backdropType, sizeof(int));

// Manual theme detection from registry
var key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize");
bool isDark = (int)key.GetValue("AppsUseLightTheme") == 0;

// Apply colors manually
this.BackColor = isDark ? Color.FromArgb(32, 32, 32) : Color.FromArgb(243, 243, 243);
```

**With Evora.FluentForms:**
```csharp
using Evora.FluentForms;

public MyForm()
{
    InitializeComponent();
    Fluent.ApplyMica(this);  // Done! ✨
}
```

---

## 📦 Installation

### Using .NET CLI (Recommended)

```bash
dotnet add package Evora.FluentForms
```

### Using NuGet Package Manager

```powershell
Install-Package Evora.FluentForms
```

### Using Visual Studio

1. Right-click your project → **Manage NuGet Packages**
2. Search for **Evora.FluentForms**
3. Click **Install**

---

## 🚀 Quick Start

### Your First Fluent Form (3 Steps)

**Step 1:** Add the using directive
```csharp
using Evora.FluentForms;
```

**Step 2:** Apply Mica effect in your form constructor
```csharp
public partial class MainForm : Form
{
    public MainForm()
    {
 InitializeComponent();
   Fluent.ApplyMica(this);  // ✨ That's it!
    }
}
```

**Step 3:** Handle system theme changes (recommended)
```csharp
protected override void OnSystemColorsChanged(EventArgs e)
{
    base.OnSystemColorsChanged(e);
    this.UpdateTheme();  // Auto-update when Windows theme changes
}
```

**Run your app** and enjoy the beautiful Mica effect! 🎉

---

## 🎨 Choosing Your Backdrop Style

Evora.FluentForms offers **three backdrop styles**. Choose the one that fits your window type:

### 1️⃣ Mica (Recommended for Main Windows)

```csharp
// Using static method
Fluent.ApplyMica(this);

// OR using extension method
this.ApplyAuto();  // Defaults to Mica
```

**Best for:** Main application windows, long-lived UI
**Visual:** Subtle, opaque texture with desktop wallpaper tinting
**Performance:** Excellent ⚡

---

### 2️⃣ Acrylic (For Dialogs & Popups)

```csharp
// Using static method
Fluent.ApplyAcrylic(this);

// OR using extension method with explicit type
this.ApplyAuto(LibImport.DwmSystemBackdropTypeFlgs.DWMSBT_TRANSIENTWINDOW);
```

**Best for:** Settings dialogs, popups, flyouts, temporary windows
**Visual:** Blurred, semi-transparent with more translucency
**Performance:** Good 👍

---

### 3️⃣ Tabbed Window (For Multi-Tab Interfaces)

```csharp
// Using static method
Fluent.ApplyTabbedWindow(this);

// OR using extension method with explicit type
this.ApplyAuto(LibImport.DwmSystemBackdropTypeFlgs.DWMSBT_TABBEDWINDOW);
```

**Best for:** Applications with TabControl, multi-document interfaces
**Visual:** Optimized backdrop for tabbed layouts
**Performance:** Excellent ⚡

---

### Quick Comparison

| Style | Method | When to Use |
|-------|--------|-------------|
| **Mica** | `Fluent.ApplyMica(this)` | Main windows that stay open |
| **Acrylic** | `Fluent.ApplyAcrylic(this)` | Temporary windows, dialogs |
| **Tabbed** | `Fluent.ApplyTabbedWindow(this)` | Windows with tabs |

---

## 📖 Core Concepts

### What are Backdrop Effects?

Backdrop effects are translucent materials that blend your window with the desktop background, creating depth and visual hierarchy.

| Effect | Best For | Visual Style | Performance |
|--------|----------|--------------|-------------|
| **Mica** | Main windows, long-lived UI | Subtle, opaque texture | Excellent ⚡ |
| **Acrylic** | Dialogs, popups, flyouts | Blurred, translucent | Good 👍 |
| **Tabbed** | Multi-tab interfaces | Optimized for tabs | Excellent ⚡ |

### Theme Detection

Evora.FluentForms automatically detects Windows theme (light/dark mode) and applies appropriate colors:

```csharp
// Check current theme
if (Fluent.IsDarkMode())
{
    // Windows is in dark mode
}

if (Fluent.IsLightMode())
{
    // Windows is in light mode
}
```

### How It Works

1. **Backdrop Material** - Applied via DWM (Desktop Window Manager)
2. **Theme Detection** - Reads from Windows Registry
3. **Transparency** - Sets form `TransparencyKey` for effect visibility
4. **Auto-Update** - Responds to `OnSystemColorsChanged` events

---

## 🎨 API Reference

### Fluent Static Class

The main entry point with simple static methods:

#### Apply Effects

```csharp
// Apply Mica effect (for main windows)
Fluent.ApplyMica(form);

// Apply Acrylic effect (for dialogs)
Fluent.ApplyAcrylic(form);

// Apply Tabbed Window effect
Fluent.ApplyTabbedWindow(form);

// Remove all effects
Fluent.RemoveEffects(form);
```

#### Theme Detection

```csharp
// Check Windows theme
bool isDark = Fluent.IsDarkMode();
bool isLight = Fluent.IsLightMode();
```

#### Color Utilities

```csharp
// Get Windows accent color
Color accent = Fluent.GetAccentColor();

// Get Windows colorization color
Color colorization = Fluent.GetColorizationColor();
```

---

### Extension Methods

Fluent API for Form objects:

#### Apply Effects

```csharp
// Apply all effects automatically (Mica + Theme + Transparency)
this.ApplyAuto();

// Apply specific backdrop (Mica, Acrylic, or Tabbed)
this.ApplyMicaEffect();
this.ApplyMicaEffect(LibImport.DwmSystemBackdropTypeFlgs.DWMSBT_TRANSIENTWINDOW); // Acrylic

// Apply theme manually
this.ApplyTheme(useDarkMode: true);

// Apply transparency
this.ApplyTransparency(useDarkMode: true);

// Update theme from current system settings
this.UpdateTheme();
```

#### Remove Effects

```csharp
// Remove all effects
this.RemoveAuto();

// Remove specific effects
this.RemoveMicaEffect();
this.RemoveTransparency();
```

---

## 💡 Usage Examples

### Example 1: Basic Mica Window

Perfect for main application windows.

```csharp
using Evora.FluentForms;

public class MainWindow : Form
{
    public MainWindow()
    {
    InitializeComponent();
     
        // Apply Mica effect with auto theme detection
        Fluent.ApplyMica(this);
    }
    
    protected override void OnSystemColorsChanged(EventArgs e)
    {
        base.OnSystemColorsChanged(e);
    this.UpdateTheme();
    }
}
```

---

### Example 2: Acrylic Dialog

Ideal for settings dialogs, popups, and temporary windows.

```csharp
using Evora.FluentForms;

public class SettingsDialog : Form
{
    public SettingsDialog()
    {
        InitializeComponent();
    
        // Acrylic provides more transparency
 Fluent.ApplyAcrylic(this);
    }
    
    protected override void OnSystemColorsChanged(EventArgs e)
    {
base.OnSystemColorsChanged(e);
        this.UpdateTheme();
    }
}
```

---

### Example 3: Tabbed Window

Optimized for applications with tab controls.

```csharp
using Evora.FluentForms;

public class TabbedWindow : Form
{
    private TabControl tabControl;
    
    public TabbedWindow()
    {
        InitializeComponent();
        
        // Setup tabs
        tabControl = new TabControl { Dock = DockStyle.Fill };
        this.Controls.Add(tabControl);

        // Apply tabbed window effect
      Fluent.ApplyTabbedWindow(this);
    }
  
    protected override void OnSystemColorsChanged(EventArgs e)
    {
     base.OnSystemColorsChanged(e);
        this.UpdateTheme();
    }
}
```

---

### Example 4: Switching Backdrop Styles Dynamically

Change backdrop effect at runtime based on window state.

```csharp
using Evora.FluentForms;

public class DynamicBackdropForm : Form
{
    private ComboBox cmbBackdropStyle;
    
  public DynamicBackdropForm()
  {
   InitializeComponent();
        
        // Setup dropdown
        cmbBackdropStyle = new ComboBox
  {
  DropDownStyle = ComboBoxStyle.DropDownList,
     Location = new Point(20, 20),
Width = 200
        };
  cmbBackdropStyle.Items.AddRange(new[] { "Mica", "Acrylic", "Tabbed", "None" });
        cmbBackdropStyle.SelectedIndex = 0;
        cmbBackdropStyle.SelectedIndexChanged += OnBackdropChanged;
        this.Controls.Add(cmbBackdropStyle);
        
        // Apply initial effect
  Fluent.ApplyMica(this);
    }
    
    private void OnBackdropChanged(object sender, EventArgs e)
    {
        switch (cmbBackdropStyle.SelectedItem?.ToString())
        {
            case "Mica":
       Fluent.ApplyMica(this);
      break;
  case "Acrylic":
                Fluent.ApplyAcrylic(this);
        break;
   case "Tabbed":
  Fluent.ApplyTabbedWindow(this);
         break;
     case "None":
              Fluent.RemoveEffects(this);
        break;
      }
    }
    
    protected override void OnSystemColorsChanged(EventArgs e)
    {
        base.OnSystemColorsChanged(e);
        if (cmbBackdropStyle.SelectedItem?.ToString() != "None")
        {
   this.UpdateTheme();
    }
    }
}
```

---

### Example 5: Using Extension Methods

More control with fluent API.

```csharp
using Evora.FluentForms;

public class CustomForm : Form
{
    public CustomForm()
    {
        InitializeComponent();
        
        // Option 1: Auto (easiest) - defaults to Mica
        this.ApplyAuto();

        // Option 2: Specify backdrop type with extension method
     // this.ApplyAuto(LibImport.DwmSystemBackdropTypeFlgs.DWMSBT_TRANSIENTWINDOW);  // Acrylic
        // this.ApplyAuto(LibImport.DwmSystemBackdropTypeFlgs.DWMSBT_TABBEDWINDOW); // Tabbed
        
        // Option 3: Manual control
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

---

### Example 6: Manual Theme Toggle

Add a dark/light mode switch.

```csharp
using Evora.FluentForms;

public class ThemedForm : Form
{
    private bool _isDarkMode = true;
    private Button btnToggle;
    
    public ThemedForm()
    {
        InitializeComponent();
        
   // Setup toggle button
      btnToggle = new Button 
  { 
            Text = "☀️ Light Mode",
 Location = new Point(20, 20)
        };
        btnToggle.Click += (s, e) => ToggleTheme();
        this.Controls.Add(btnToggle);
        
 // Apply initial theme
        ApplyCustomTheme();
    Fluent.ApplyMica(this);
    }
    
    private void ApplyCustomTheme()
    {
        this.ApplyMicaEffect();
        this.ApplyTheme(_isDarkMode);
        this.ApplyTransparency(_isDarkMode);
   
        btnToggle.Text = _isDarkMode ? "☀️ Light Mode" : "🌙 Dark Mode";
    }
    
    private void ToggleTheme()
    {
        _isDarkMode = !_isDarkMode;
     ApplyCustomTheme();
    }
}
```

---

### Example 7: Using Windows Accent Color

Match your app's colors with Windows accent color.

```csharp
using Evora.FluentForms;

public class AccentColorForm : Form
{
    private Panel headerPanel;
    private Button accentButton;
    
    public AccentColorForm()
  {
   InitializeComponent();
  
        // Get Windows accent color
        Color accent = Fluent.GetAccentColor();
        
        // Apply to header
     headerPanel = new Panel
  {
         BackColor = accent,
            Dock = DockStyle.Top,
Height = 60
        };
        
        // Apply to button
        accentButton = new Button
   {
         Text = "Action Button",
      BackColor = accent,
   ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat
        };
     
        this.Controls.Add(headerPanel);
  this.Controls.Add(accentButton);
        
    Fluent.ApplyMica(this);
    }
    
    protected override void OnSystemColorsChanged(EventArgs e)
    {
   base.OnSystemColorsChanged(e);
   
        // Update accent color when it changes
        Color newAccent = Fluent.GetAccentColor();
        headerPanel.BackColor = newAccent;
      accentButton.BackColor = newAccent;
      
        this.UpdateTheme();
    }
}
```

---

### Example 8: Dynamic Effect Toggle

Enable/disable effects at runtime.

```csharp
using Evora.FluentForms;

public class DynamicForm : Form
{
    private CheckBox chkEffects;
    
    public DynamicForm()
    {
    InitializeComponent();
        
        chkEffects = new CheckBox
        {
            Text = "Enable Fluent Effects",
   Checked = true,
          Location = new Point(20, 20)
        };
        chkEffects.CheckedChanged += OnEffectsToggle;
        this.Controls.Add(chkEffects);
        
        Fluent.ApplyMica(this);
    }
    
    private void OnEffectsToggle(object sender, EventArgs e)
    {
        if (chkEffects.Checked)
    {
   Fluent.ApplyMica(this);
        }
        else
{
            Fluent.RemoveEffects(this);
   }
    }
    
    protected override void OnSystemColorsChanged(EventArgs e)
    {
        base.OnSystemColorsChanged(e);
        if (chkEffects.Checked)
  {
        this.UpdateTheme();
        }
    }
}
```

---

### Example 9: Adapting to Windows Theme

Customize your UI based on Windows theme.

```csharp
using Evora.FluentForms;

public class AdaptiveForm : Form
{
    private Label titleLabel;
    
    public AdaptiveForm()
    {
        InitializeComponent();
        
        titleLabel = new Label
        {
     Text = "Adaptive Theme Example",
            AutoSize = true,
   Location = new Point(20, 20),
     Font = new Font("Segoe UI", 16, FontStyle.Bold)
        };
   this.Controls.Add(titleLabel);
     
        ApplyThemeCustomization();
    Fluent.ApplyMica(this);
    }
    
    private void ApplyThemeCustomization()
    {
   if (Fluent.IsDarkMode())
        {
 // Dark mode customization
      this.ForeColor = Color.White;
    titleLabel.ForeColor = Color.White;
            // Add more dark theme styling
   }
        else
 {
     // Light mode customization
 this.ForeColor = Color.Black;
     titleLabel.ForeColor = Color.Black;
            // Add more light theme styling
        }
    }
    
    protected override void OnSystemColorsChanged(EventArgs e)
    {
      base.OnSystemColorsChanged(e);
        ApplyThemeCustomization();
        this.UpdateTheme();
    }
}
```

---

## 🔧 Advanced Usage

### Low-Level API Access

For advanced scenarios, you can use the underlying APIs directly:

```csharp
using Evora.FluentForms;

public class AdvancedForm : Form
{
    public AdvancedForm()
    {
        InitializeComponent();
     
     // Direct access to low-level methods
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

### Available Backdrop Types

All available backdrop styles and when to use them:

```csharp
// Option 1: Auto - Let Windows decide (generally chooses Mica-like effect)
LibImport.DwmSystemBackdropTypeFlgs.DWMSBT_AUTO

// Option 2: None - Disable all backdrop effects
LibImport.DwmSystemBackdropTypeFlgs.DWMSBT_NONE

// Option 3: Mica - Main window backdrop (recommended for most apps)
LibImport.DwmSystemBackdropTypeFlgs.DWMSBT_MAINWINDOW

// Option 4: Acrylic - Transient window backdrop (for dialogs, popups)
LibImport.DwmSystemBackdropTypeFlgs.DWMSBT_TRANSIENTWINDOW

// Option 5: Tabbed - Tabbed window backdrop (for tab interfaces)
LibImport.DwmSystemBackdropTypeFlgs.DWMSBT_TABBEDWINDOW
```

**Usage with extension methods:**
```csharp
// Apply Mica (MainWindow style)
this.ApplyMicaEffect(LibImport.DwmSystemBackdropTypeFlgs.DWMSBT_MAINWINDOW);

// Apply Acrylic (TransientWindow style)
this.ApplyMicaEffect(LibImport.DwmSystemBackdropTypeFlgs.DWMSBT_TRANSIENTWINDOW);

// Apply Tabbed style
this.ApplyMicaEffect(LibImport.DwmSystemBackdropTypeFlgs.DWMSBT_TABBEDWINDOW);

// Or use simplified methods
this.ApplyAuto();  // Defaults to DWMSBT_MAINWINDOW (Mica)
this.ApplyAuto(LibImport.DwmSystemBackdropTypeFlgs.DWMSBT_TRANSIENTWINDOW);  // Acrylic
```

### Comparison of Backdrop Styles

| Backdrop Type | Constant | Visual Effect | Transparency | Best Use Case |
|---------------|----------|---------------|--------------|---------------|
| **Mica** | `DWMSBT_MAINWINDOW` | Subtle wallpaper tint | Low (opaque) | Main windows, primary UI |
| **Acrylic** | `DWMSBT_TRANSIENTWINDOW` | Blurred background | High (translucent) | Dialogs, context menus, overlays |
| **Tabbed** | `DWMSBT_TABBEDWINDOW` | Optimized for tabs | Low (opaque) | Multi-tab applications, browsers |
| **Auto** | `DWMSBT_AUTO` | Windows decides | Varies | Let system choose appropriate style |
| **None** | `DWMSBT_NONE` | No effect | None | Disable backdrop materials |

**Visual Differences:**
- **Mica**: Adapts to desktop wallpaper, creates sense of depth
- **Acrylic**: Shows blurred content behind window, more "glass-like"
- **Tabbed**: Similar to Mica but optimized for tabbed interfaces

---

### Registry Access

```csharp
// Theme detection
bool appUsesLight = LibRegistry.GetAppUseLightTheme();
bool systemUsesLight = LibRegistry.GetSysUseLightTheme();

// Colors
Color accent = LibRegistry.GetAccentColor();
Color colorization = LibRegistry.GetColorizationColor();
Color afterglow = LibRegistry.GetColorizationAfterglow();

// Color history
Color[] recentColors = LibRegistry.GetHistoryColors();
```

### Symbol Utilities (Bonus)

Generate icon bitmaps from font symbols:

```csharp
using Evora.FluentForms;

// Create bitmap from Segoe MDL2 Assets symbol
Font iconFont = new Font("Segoe MDL2 Assets", 24);
Bitmap icon = LibSymbol.GetSymbolBitmap(0xE710, iconFont, Brushes.White);

// Or from string
Bitmap iconFromString = LibSymbol.GetSymbolBitmap("🌙", new Font("Segoe UI Emoji", 24), Brushes.White);
```

---

## 🐛 Troubleshooting

### Effects Not Showing

**Symptom:** Backdrop effect doesn't appear.

**Causes & Solutions:**

1. **Not on Windows 11**
   - Effects require Windows 11 (Build 22000+)
   - Check: `Settings > System > About > Windows specifications`

2. **Applied Before Handle Created**
   ```csharp
   // ❌ Wrong
   public MyForm()
   {
       Fluent.ApplyMica(this);  // Handle not created yet!
    InitializeComponent();
   }
   
   // ✅ Correct
   public MyForm()
   {
       InitializeComponent();   // Create handle first
       Fluent.ApplyMica(this);
   }
   ```

3. **Transparency Disabled in Windows**
   - Go to `Settings > Personalization > Colors`
   - Enable "Transparency effects"

---

### Theme Not Updating

**Symptom:** App doesn't switch themes when Windows theme changes.

**Solution:** Override `OnSystemColorsChanged`:

```csharp
protected override void OnSystemColorsChanged(EventArgs e)
{
    base.OnSystemColorsChanged(e);  // ⚠️ Don't forget this!
    this.UpdateTheme();
}
```

---

### Text/Controls Not Visible

**Symptom:** Controls disappear in dark mode.

**Solution:** Set appropriate `ForeColor`:

```csharp
if (Fluent.IsDarkMode())
{
    this.ForeColor = Color.White;
    // Style controls for dark theme
}
else
{
  this.ForeColor = Color.Black;
    // Style controls for light theme
}
```

---

### Performance Issues

**Symptom:** Lag or performance degradation.

**Solutions:**

1. **Use Mica instead of Acrylic** (Mica is more performant)
2. **Remove effects on low-end systems:**
   ```csharp
   try
   {
       Fluent.ApplyMica(this);
   }
   catch
   {
       // Gracefully degrade to no effects
   }
   ```

---

## ❓ FAQ

### Does this work on Windows 10?

**Short answer:** The library runs on Windows 10, but effects only work on Windows 11.

**Details:** Mica and Acrylic backdrop materials are Windows 11 features. On Windows 10, the API calls will be ignored, and your app will function normally without the visual effects. Theme detection and color utilities work on both Windows 10 and 11.

---

### Do I need external dependencies?

**No!** Evora.FluentForms has zero dependencies. It uses only Win32 APIs built into Windows via P/Invoke.

---

### Can I use this in WPF or other UI frameworks?

Currently, Evora.FluentForms is designed for **Windows Forms only**. For WPF, you can use:
- Native WPF backdrop support (Windows 11)
- Community libraries like `Wpf.Ui`

---

### Will this affect performance?

**Minimal impact.** Backdrop effects are GPU-accelerated by Windows DWM:
- **Mica**: Excellent performance (recommended for main windows)
- **Acrylic**: Good performance (slight blur overhead)
- **Tabbed**: Excellent performance

---

### Can I customize blur amount or opacity?

No. Backdrop materials are standardized by Windows and cannot be customized. This ensures consistency across all Windows 11 apps. However, you can:
- Choose different backdrop types (Mica, Acrylic, Tabbed)
- Layer your own controls with semi-transparent backgrounds

---

### Is automatic theme detection reliable?

**Yes!** Theme detection reads directly from Windows Registry:
```
HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes\Personalize\AppsUseLightTheme
```

It's the same method Windows uses internally.

---

### Can I use this commercially?

**Yes!** Evora.FluentForms is MIT licensed. You can use it in:
- Personal projects
- Open-source projects
- Commercial applications
- Proprietary software

No attribution required (but appreciated! ⭐)

---

### How do I contribute?

See the [Contributing](#-contributing) section below. We welcome:
- Bug reports
- Feature requests
- Documentation improvements
- Code contributions

---

## 📋 Requirements

### Minimum Requirements

| Requirement | Version |
|------------|---------|
| **Operating System** | Windows 11 (Build 22000+) |
| **.NET Version** | .NET 8.0 or higher |
| **Framework** | Windows Forms |
| **Visual Studio** | 2022 or later (recommended) |

### Feature Compatibility

| Feature | Windows 11 | Windows 10 | Older |
|---------|------------|------------|-------|
| Mica Effect | ✅ Full | ❌ No | ❌ No |
| Acrylic Effect | ✅ Full | ❌ No | ❌ No |
| Tabbed Effect | ✅ Full | ❌ No | ❌ No |
| Theme Detection | ✅ Yes | ✅ Yes | ⚠️ Partial |
| Accent Colors | ✅ Yes | ✅ Yes | ✅ Yes |

> **Note:** On Windows 10 and older, backdrop effects will be gracefully ignored. Your application will still work, just without the visual materials.

---

## 🤝 Contributing

We welcome contributions from the community! Here's how you can help:

### Ways to Contribute

- 🐛 **Report Bugs** - [Open an issue](https://github.com/evorajhonj/Evora.FluentForms/issues)
- 💡 **Suggest Features** - Share your ideas
- 📖 **Improve Docs** - Help make documentation clearer
- 🔧 **Submit PRs** - Fix bugs or add features
- ⭐ **Star the Repo** - Show your support!

### Development Setup

```bash
# Clone the repository
git clone https://github.com/evorajhonj/Evora.FluentForms.git

# Navigate to directory
cd Evora.FluentForms

# Restore dependencies
dotnet restore

# Build
dotnet build

# Pack (create NuGet package)
dotnet pack
```

### Contribution Guidelines

1. **Fork the repository**
2. **Create a feature branch** (`git checkout -b feature/amazing-feature`)
3. **Commit your changes** (`git commit -m 'Add amazing feature'`)
4. **Push to branch** (`git push origin feature/amazing-feature`)
5. **Open a Pull Request**

---

## 📄 License

**MIT License**

Copyright (c) 2025 Evora

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

---

## 🙏 Acknowledgments

Built with ❤️ for the Windows Forms community.

Special thanks to:
- Microsoft for the Windows 11 Fluent Design System
- The .NET and WinForms teams
- All contributors and users

---

## 📞 Support & Resources

- 📧 **Issues**: [GitHub Issues](https://github.com/evorajhonj/Evora.FluentForms/issues)
- 💬 **Discussions**: [GitHub Discussions](https://github.com/evorajhonj/Evora.FluentForms/discussions)
- 📦 **NuGet**: [Evora.FluentForms](https://www.nuget.org/packages/Evora.FluentForms/)
- 📚 **Source Code**: [GitHub Repository](https://github.com/evorajhonj/Evora.FluentForms)

---

## ⭐ Show Your Support

If you find Evora.FluentForms useful, please:

- ⭐ **Star the repository** on GitHub
- 📢 **Share with others** who might benefit
- 🐦 **Tweet about it** with `#EvoraFluentForms`
- 💬 **Provide feedback** to help us improve

[⭐ Star on GitHub](https://github.com/evorajhonj/Evora.FluentForms)

---

**Made with ❤️ for modern Windows Forms development**
