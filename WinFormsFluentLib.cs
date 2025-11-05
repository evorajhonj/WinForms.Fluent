#nullable enable
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace WinForms.Fluent
{
    public static class FluentApply
    {
        [Description("Light Color")]
        public static Color LightColor = Color.FromArgb(233, 233, 234);
        [Description("Dark Color")]
        public static Color DarkColor = Color.FromArgb(22, 22, 21);

        // Apply backdrop effect in Win32 apps
        public static void Apply_Backdrop_Effect(IntPtr HWnd, FluentImport.DwmSystemBackdropTypeFlgs BackdropFlag = FluentImport.DwmSystemBackdropTypeFlgs.DWMSBT_MAINWINDOW)
        {
            int key = (int)BackdropFlag;
            FluentImport.DwmSetWindowAttribute(HWnd, FluentImport.DwmSetWindowAttributeFlags.DWM_SYSTEMBACKDROP_TYPE, ref key, Marshal.SizeOf(typeof(int)));
        }
        // Apply light/dark theme in Win32 apps
        public static void Apply_Light_Theme(IntPtr HWnd, bool Dark = false)
        {
            int key = Dark ? 1 : 0;
            FluentImport.DwmSetWindowAttribute(HWnd, FluentImport.DwmSetWindowAttributeFlags.DWM_USE_IMMERSIVE_DARK_MODE, ref key, Marshal.SizeOf(typeof(int)));
        }
        // Apply transparent client area in Win32 apps
        public static void Apply_Transparent_Form(IntPtr HWnd, bool Dark = false)
        {
            if (Control.FromHandle(HWnd) is not Form form) return;
            form.ForeColor = Dark ? LightColor : DarkColor;
            form.TransparencyKey = form.BackColor = Dark ? DarkColor : LightColor;
        }
        // Cancel backdrop effect in Win32 apps
        public static void Cancel_Backdrop_Effect(IntPtr HWnd)
        {
            int Key = 0;
            FluentImport.DwmSetWindowAttribute(HWnd, FluentImport.DwmSetWindowAttributeFlags.DWM_SYSTEMBACKDROP_TYPE, ref Key, Marshal.SizeOf(typeof(int)));
        }
        // Cancel transparent client area in Win32 apps
        public static void Cancel_Transparent_Form(IntPtr HWnd)
        {
            if (Control.FromHandle(HWnd) is Form form)
            {
                form.TransparencyKey = Color.Empty;
            }
        }
        // Get description of the specified method
        public static string? About_Method_Description(string MethodName)
        {
            return typeof(FluentApply).GetMethod(MethodName)?.GetCustomAttribute<DescriptionAttribute>()?.Description;
        }
        // Get description of the specified enum
        public static string? About_Enum_Description(Enum EnumFlag)
        {
            Type type = EnumFlag.GetType();
            return type.GetField(Enum.GetName(type, EnumFlag)!)?.GetCustomAttribute<DescriptionAttribute>()?.Description;
        }
    }

    public static class FluentImport
    {
        #region Dll Import

        [DllImport("dwmapi.dll"), Description("https://learn.microsoft.com/zh-cn/windows/win32/api/dwmapi/nf-dwmapi-dwmsetwindowattribute")]
        internal static extern IntPtr DwmSetWindowAttribute(IntPtr hwnd, DwmSetWindowAttributeFlags dwAttribute, ref int pvAttribute, int cbAttribute);

        #endregion

        #region Dll Enum

        [Description("https://learn.microsoft.com/en-us/windows/win32/api/dwmapi/ne-dwmapi-dwmwindowattribute")]
        public enum DwmSetWindowAttributeFlags
        {
            DWM_NCRENDERING_ENABLED,
            DWM_NCRENDERING_POLICY,
            DWM_TRANSITIONS_FORCEDISABLED,
            DWM_ALLOW_NCPAINT,
            DWM_CAPTION_BUTTON_BOUNDS,
            DWM_NONCLIENT_RTL_LAYOUT,
            DWM_FORCE_ICONIC_REPRESENTATION,
            DWM_FLIP3D_POLICY,
            DWM_EXTENDED_FRAME_BOUNDS,
            DWM_HAS_ICONIC_BITMAP,
            DWM_DISALLOW_PEEK,
            DWM_EXCLUDED_FROM_PEEK,
            DWM_CLOAK,
            DWM_CLOAKED,
            DWM_FREEZE_REPRESENTATION,
            DWM_PASSIVE_UPDATE_MODE,
            DWM_USE_HOSTBACKDROPBRUSH,
            DWM_USE_IMMERSIVE_DARK_MODE = 20,
            DWM_WINDOW_CORNER_PREFERENCE = 33,
            DWM_BORDER_COLOR,
            DWM_CAPTION_COLOR,
            DWM_TEXT_COLOR,
            DWM_VISIBLE_FRAME_BORDER_THICKNESS,
            DWM_SYSTEMBACKDROP_TYPE,
            DWM_LAST,
            DWM_MICA_EFFECT = 1029
        };
        [Description("https://learn.microsoft.com/en-us/windows/win32/api/dwmapi/ne-dwmapi-dwm_systembackdrop_type")]
        public enum DwmSystemBackdropTypeFlgs
        {
            [Description("Default. Let DWM automatically decide the system-drawn backdrop material for this window.")]
            DWMSBT_AUTO,
            [Description("Do not draw any system backdrop.")]
            DWMSBT_NONE,
            [Description("Draw backdrop material effect corresponding to a long-lived window.")]
            DWMSBT_MAINWINDOW,
            [Description("Draw backdrop material effect corresponding to a transient window.")]
            DWMSBT_TRANSIENTWINDOW,
            [Description("Draw backdrop material effect corresponding to a window with a tabbed title bar.")]
            DWMSBT_TABBEDWINDOW
        };

        #endregion

        #region MSDN

        public static bool CalcIsColorLight(Color clr)
        {
            return (((5 * clr.G) + (2 * clr.R) + clr.B) > (8 * 128));
        }

        public static Color CalcTransparentColor(Color Clr)
        {
            return (Clr.R != Clr.B) ? Clr : Color.FromArgb(Clr.ToArgb() | 0x1);
        }

        #endregion


    }

    public static class FluentRegistry
    {
        [Description(@$"{Personalize}")]
        public const string Personalize = @"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize";

        [Description(@$"{Personalize}\{AppsUseLightTheme}")]
        public const string AppsUseLightTheme = "AppsUseLightTheme";

        [Description(@$"{Personalize}\{SystemUsesLightTheme}")]
        public const string SystemUsesLightTheme = "SystemUsesLightTheme";

        [Description(@$"{Colors}")]
        public const string Colors = @"Software\Microsoft\Windows\CurrentVersion\Themes\History\Colors";

        [Description($@"{DWM}")]
        public const string DWM = @"Software\Microsoft\Windows\DWM";

        [Description($@"{DWM}\{AccentColor}")]
        public const string AccentColor = "AccentColor";

        [Description($@"{DWM}\{ColorizationColor}")]
        public const string ColorizationColor = "ColorizationColor";

        [Description($@"{DWM}\{ColorizationAfterglow}")]
        public const string ColorizationAfterglow = "ColorizationAfterglow";


        [Description("Is the app color template light?")]
        public static bool GetAppUseLightTheme()
        {
            return GetValueToBoolean(Personalize, AppsUseLightTheme);
        }

        [Description("Is the system color template light?")]
        public static bool GetSysUseLightTheme()
        {
            return GetValueToBoolean(Personalize, SystemUsesLightTheme);
        }

        [Description("Get recent color group")]
        public static Color[]? GetHistoryColors()
        {
            RegistryKey? SubKey = Registry.CurrentUser.OpenSubKey(Colors);
            if (SubKey == null) return null;
            string[]? Names = SubKey?.GetValueNames();
            if (Names == null) return null;

            List<Color> ColorList = new();
            ColorList.AddRange(Names.Select(ValueName => GetValueToColor(Colors, ValueName)));
            return ColorList.ToArray();
        }

        [Description("Get accent color")]
        public static Color GetAccentColor()
        {
            return GetValueToColor(DWM, AccentColor);
        }
        [Description("Get main color")]
        public static Color GetColorizationColor()
        {
            return GetValueToColor(DWM, ColorizationColor);
        }
        [Description("Get similar color")]
        public static Color GetColorizationAfterglow()
        {
            return GetValueToColor(DWM, ColorizationAfterglow);
        }
        [Description("Get bool")]
        private static bool GetValueToBoolean(string subkey, string subvalue)
        {
            using RegistryKey? key = Registry.CurrentUser.OpenSubKey(subkey);
            object? value = key?.GetValue(subvalue);
            return value != null && Convert.ToInt32(value) != default;
        }
        [Description("Get Color")]
        private static Color GetValueToColor(string subkey, string subvalue)
        {
            using RegistryKey? key = Registry.CurrentUser.OpenSubKey(subkey);
            object? value = key?.GetValue(subvalue);
            return value != null ? Color.FromArgb(Convert.ToInt32(value)) : Color.Empty;
        }

    }
    public static class FluentSymbol
    {
        [Description("Get Bitmap corresponding to Symbol from font")]
        public static Bitmap GetSymbolBitmap(string symbol, Font font, Brush brush, bool rectangle = true)
        {
            using var control = new Control();

            var size = control.CreateGraphics().MeasureString(symbol, font).ToSize();
            var border = size.Width > size.Height ? size.Width : size.Height;
            var bitmap = new Bitmap(border, border);

            using (var graphics = Graphics.FromImage(bitmap))
            {
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                graphics.DrawString(symbol, font, brush, rectangle ? (border - size.Width) / 2 : 0, rectangle ? (border - size.Height) / 2 : 0);
            }
            return bitmap;
        }
        [Description("Get Bitmap corresponding to SymbolCode from Font")]
        public static Bitmap GetSymbolBitmap(int symbol, Font font, Brush brush, bool rectangle = false)
        {
            return GetSymbolBitmap(GetSymbolString(symbol), font, brush, rectangle);
        }
        [Description("Convert SymbolCode to String")]
        public static String GetSymbolString(int symbol)
        {
            return Convert.ToString(Convert.ToChar(symbol));
        }
    }
}