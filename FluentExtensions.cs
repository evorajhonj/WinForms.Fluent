using System.ComponentModel;
using static Evora.FluentForms.LibImport.DwmSystemBackdropTypeFlgs;

namespace Evora.FluentForms
{
    /// <summary>
    /// Extension methods for easy application of Fluent Design effects to WinForms
    /// </summary>
    public static class FluentExtensions
    {
        /// <summary>
   /// Apply Mica or Acrylic backdrop effect to a form
        /// </summary>
        /// <param name="form">The form to apply the effect to</param>
        /// <param name="backdropType">The type of backdrop effect (default: MainWindow/Mica)</param>
        [Description("Apply Mica or Acrylic backdrop effect to a form")]
     public static void ApplyMicaEffect(this Form form, LibImport.DwmSystemBackdropTypeFlgs backdropType = DWMSBT_MAINWINDOW)
        {
    LibApply.Apply_Backdrop_Effect(form.Handle, backdropType);
        }

        /// <summary>
     /// Apply dark or light theme to a form
        /// </summary>
        /// <param name="form">The form to apply the theme to</param>
    /// <param name="useDarkMode">True for dark mode, false for light mode</param>
        [Description("Apply dark or light theme to a form")]
        public static void ApplyTheme(this Form form, bool useDarkMode = false)
        {
            LibApply.Apply_Light_Theme(form.Handle, useDarkMode);
        }

        /// <summary>
        /// Apply transparent background to a form (required for Mica effect)
        /// </summary>
  /// <param name="form">The form to apply transparency to</param>
        /// <param name="useDarkMode">True for dark mode, false for light mode</param>
        [Description("Apply transparent background to a form")]
        public static void ApplyTransparency(this Form form, bool useDarkMode = false)
        {
  LibApply.Apply_Transparent_Form(form.Handle, useDarkMode);
        }

     /// <summary>
        /// Apply all Fluent Design effects to a form with automatic theme detection
  /// </summary>
        /// <param name="form">The form to apply effects to</param>
        /// <param name="backdropType">The type of backdrop effect (default: MainWindow/Mica)</param>
  [Description("Apply all Fluent Design effects with automatic theme detection")]
   public static void ApplyAuto(this Form form, LibImport.DwmSystemBackdropTypeFlgs backdropType = DWMSBT_MAINWINDOW)
 {
       bool isDarkMode = !LibRegistry.GetAppUseLightTheme();
   form.ApplyMicaEffect(backdropType);
            form.ApplyTheme(isDarkMode);
            form.ApplyTransparency(isDarkMode);
        }

     /// <summary>
        /// Remove Mica/Acrylic backdrop effect from a form
      /// </summary>
        /// <param name="form">The form to remove the effect from</param>
        [Description("Remove backdrop effect from a form")]
        public static void RemoveMicaEffect(this Form form)
        {
       LibApply.Cancel_Backdrop_Effect(form.Handle);
        }

        /// <summary>
      /// Remove transparency from a form
        /// </summary>
  /// <param name="form">The form to remove transparency from</param>
        [Description("Remove transparency from a form")]
    public static void RemoveTransparency(this Form form)
 {
        LibApply.Cancel_Transparent_Form(form.Handle);
        }

        /// <summary>
        /// Remove all Fluent Design effects from a form
        /// </summary>
        /// <param name="form">The form to remove effects from</param>
      [Description("Remove all Fluent Design effects from a form")]
        public static void RemoveAuto(this Form form)
      {
            form.RemoveMicaEffect();
            form.RemoveTransparency();
        }

        /// <summary>
        /// Update theme when system colors change
   /// </summary>
        /// <param name="form">The form to update</param>
    [Description("Update theme based on current system settings")]
        public static void UpdateTheme(this Form form)
        {
            bool isDarkMode = !LibRegistry.GetAppUseLightTheme();
            form.ApplyTheme(isDarkMode);
          form.ApplyTransparency(isDarkMode);
     }
    }
}
