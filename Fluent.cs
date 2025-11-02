using System.ComponentModel;
using static Evora.FluentForms.LibImport.DwmSystemBackdropTypeFlgs;

namespace Evora.FluentForms
{
    /// <summary>
    /// Simplified helper class for applying Fluent Design effects to WinForms
    /// </summary>
    public static class Fluent
    {
        /// <summary>
     /// Apply Mica effect with automatic theme detection to a form
        /// </summary>
        /// <param name="form">The form to apply Mica effect to</param>
        [Description("Apply Mica effect with automatic theme detection")]
     public static void ApplyMica(Form form)
     {
      form.ApplyAuto(DWMSBT_MAINWINDOW);
        }

        /// <summary>
        /// Apply Acrylic effect with automatic theme detection to a form
   /// </summary>
  /// <param name="form">The form to apply Acrylic effect to</param>
        [Description("Apply Acrylic effect with automatic theme detection")]
        public static void ApplyAcrylic(Form form)
        {
            form.ApplyAuto(DWMSBT_TRANSIENTWINDOW);
      }

        /// <summary>
 /// Apply Tabbed Window effect with automatic theme detection to a form
        /// </summary>
  /// <param name="form">The form to apply effect to</param>
 [Description("Apply Tabbed Window effect with automatic theme detection")]
      public static void ApplyTabbedWindow(Form form)
        {
 form.ApplyAuto(DWMSBT_TABBEDWINDOW);
        }

        /// <summary>
        /// Check if the current Windows theme is dark mode
        /// </summary>
 /// <returns>True if dark mode is active</returns>
        [Description("Check if dark mode is active")]
 public static bool IsDarkMode()
 {
    return !LibRegistry.GetAppUseLightTheme();
        }

      /// <summary>
      /// Check if the current Windows theme is light mode
        /// </summary>
        /// <returns>True if light mode is active</returns>
        [Description("Check if light mode is active")]
     public static bool IsLightMode()
        {
     return LibRegistry.GetAppUseLightTheme();
        }

        /// <summary>
        /// Get the Windows accent color
      /// </summary>
        /// <returns>The accent color</returns>
        [Description("Get Windows accent color")]
  public static Color GetAccentColor()
{
   return LibRegistry.GetAccentColor();
   }

   /// <summary>
        /// Get the Windows colorization color
/// </summary>
        /// <returns>The colorization color</returns>
        [Description("Get Windows colorization color")]
public static Color GetColorizationColor()
      {
        return LibRegistry.GetColorizationColor();
        }

    /// <summary>
     /// Remove all Fluent Design effects from a form
        /// </summary>
        /// <param name="form">The form to remove effects from</param>
        [Description("Remove all Fluent Design effects")]
        public static void RemoveEffects(Form form)
        {
     form.RemoveAuto();
        }
    }
}
