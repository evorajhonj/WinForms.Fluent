#nullable enable
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using static WinForms.Fluent.FluentImport.DwmSystemBackdropTypeFlgs;

namespace WinForms.Fluent
{
    // ============ THEME CONSTANTS ============
    public static class Theme
    {
        public const bool Dark = true;
        public const bool Light = false;
    }

    // ============ TIER 1: SIMPLE PRESET EXTENSIONS ============
    public static class FluentExtensions
    {
        // Apply Mica effect - Auto-detects system theme
        public static void Mica(this Form form)
        {
            bool isDark = FluentRegistry.GetAppUseLightTheme();
            FluentApply.Apply_Backdrop_Effect(form.Handle, DWMSBT_MAINWINDOW);
            FluentApply.Apply_Light_Theme(form.Handle, isDark);
        }

        // Apply Mica effect with explicit theme - Use Theme.Dark or Theme.Light
        public static void Mica(this Form form, bool dark)
        {
            FluentApply.Apply_Backdrop_Effect(form.Handle, DWMSBT_MAINWINDOW);
            FluentApply.Apply_Light_Theme(form.Handle, dark);
        }

        // Apply Acrylic effect - Auto-detects system theme
        public static void Acrylic(this Form form)
        {
            bool isDark = FluentRegistry.GetAppUseLightTheme();
            FluentApply.Apply_Backdrop_Effect(form.Handle, DWMSBT_TRANSIENTWINDOW);
            FluentApply.Apply_Light_Theme(form.Handle, isDark);
            FluentApply.Apply_Transparent_Form(form.Handle, isDark);
        }

        // Apply Acrylic effect with explicit theme - Use Theme.Dark or Theme.Light
        public static void Acrylic(this Form form, bool dark)
        {
            FluentApply.Apply_Backdrop_Effect(form.Handle, DWMSBT_TRANSIENTWINDOW);
            FluentApply.Apply_Light_Theme(form.Handle, dark);
            FluentApply.Apply_Transparent_Form(form.Handle, dark);
        }

        // Apply Tabbed effect - Auto-detects system theme
        public static void Tabbed(this Form form)
        {
            bool isDark = FluentRegistry.GetAppUseLightTheme();
            FluentApply.Apply_Backdrop_Effect(form.Handle, DWMSBT_TABBEDWINDOW);
            FluentApply.Apply_Light_Theme(form.Handle, isDark);
        }

        // Apply Tabbed effect with explicit theme - Use Theme.Dark or Theme.Light
        public static void Tabbed(this Form form, bool dark)
        {
            FluentApply.Apply_Backdrop_Effect(form.Handle, DWMSBT_TABBEDWINDOW);
            FluentApply.Apply_Light_Theme(form.Handle, dark);
        }

        // Auto-detect system theme and apply Mica
        public static void Auto(this Form form)
        {
            bool isDark = FluentRegistry.GetAppUseLightTheme();
            form.Mica(isDark);
        }

        // Remove all effects
        public static void Reset(this Form form)
        {
            FluentApply.Cancel_Backdrop_Effect(form.Handle);
            FluentApply.Cancel_Transparent_Form(form.Handle);
        }

        // Entry point for configuration (Tier 2 & 3)
        public static FluentConfig Configure(this Form form) => new(form);
    }

    // ============ TIER 2: FLUENT CONFIG ============
    public class FluentConfig
    {
        private readonly Form _form;
        private FluentImport.DwmSystemBackdropTypeFlgs _backdropEffect = DWMSBT_MAINWINDOW;
        private bool _isDark = true;
        private bool _transparencyEnabled = false;
        private bool _backdropEnabled = true;

        public FluentConfig(Form form)
        {
            _form = form;
        }

        // ========== BACKDROP METHODS ==========

        // Set Auto backdrop
        public FluentConfig AutoBackdrop()
        {
            _backdropEffect = DWMSBT_AUTO;
            return this;
        }

        // Set None backdrop (disabled)
        public FluentConfig None()
        {
            _backdropEffect = DWMSBT_NONE;
            _backdropEnabled = false;
            return this;
        }

        // Set Mica backdrop
        public FluentConfig Mica()
        {
            _backdropEffect = DWMSBT_MAINWINDOW;
            _backdropEnabled = true;
            return this;
        }

        // Set Acrylic backdrop
        public FluentConfig Acrylic()
        {
            _backdropEffect = DWMSBT_TRANSIENTWINDOW;
            _backdropEnabled = true;
            return this;
        }

        // Set Tabbed backdrop
        public FluentConfig Tabbed()
        {
            _backdropEffect = DWMSBT_TABBEDWINDOW;
            _backdropEnabled = true;
            return this;
        }

        // ========== THEME METHODS ==========

        // Auto-detect system theme
        public FluentConfig Auto()
        {
            _isDark = FluentRegistry.GetAppUseLightTheme();
            return this;
        }

        // Set dark theme
        public FluentConfig Dark()
        {
            _isDark = true;
            return this;
        }

        // Set light theme
        public FluentConfig Light()
        {
            _isDark = false;
            return this;
        }

        // ========== TRANSPARENCY METHODS ==========

        // Enable transparency
        public FluentConfig Transparency()
        {
            _transparencyEnabled = true;
            ApplyInternal();
            return this;
        }

        // Disable transparency
        public FluentConfig NoTransparency()
        {
            _transparencyEnabled = false;
            ApplyInternal();
            return this;
        }

        // ========== APPLY METHODS ==========

        // Explicit apply method
        public void Apply()
        {
            ApplyInternal();
        }

        // Internal apply implementation
        private void ApplyInternal()
        {
            if (_backdropEnabled)
            {
                FluentApply.Apply_Backdrop_Effect(_form.Handle, _backdropEffect);
            }
            else
            {
                FluentApply.Cancel_Backdrop_Effect(_form.Handle);
            }

            FluentApply.Apply_Light_Theme(_form.Handle, _isDark);

            if (_transparencyEnabled)
            {
                FluentApply.Apply_Transparent_Form(_form.Handle, _isDark);
            }
            else
            {
                FluentApply.Cancel_Transparent_Form(_form.Handle);
            }
        }
    }
}
