using System;
using FormsPlugin.Iconize;
using FormsPlugin.Iconize.Droid;
using Plugin.Iconize.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using ButtonRenderer = Xamarin.Forms.Platform.Android.AppCompat.ButtonRenderer;
using Single = System.Single;

[assembly: ExportRenderer(typeof(IconButton), typeof(IconButtonRenderer))]
namespace FormsPlugin.Iconize.Droid
{
    /// <summary>
    /// Defines the <see cref="IconButtonRenderer" /> renderer.
    /// </summary>
    /// <seealso cref="Xamarin.Forms.Platform.Android.AppCompat.ButtonRenderer" />
    public class IconButtonRenderer : ButtonRenderer
    {
        /// <summary>
        /// Disposes the specified disposing.
        /// </summary>
        /// <param name="disposing">if set to <c>true</c> [disposing].</param>
        protected override void Dispose(Boolean disposing)
        {
            base.Dispose(disposing);

            Control.TextChanged -= OnTextChanged;
        }

        /// <summary>
        /// Raises the <see cref="E:ElementChanged" /> event.
        /// </summary>
        /// <param name="e">The <see cref="ElementChangedEventArgs{Button}" /> instance containing the event data.</param>
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (Control == null || Element == null)
                return;

            Control.SetAllCaps(false);
            Control.TextChanged += OnTextChanged;
        }

        /// <summary>
        /// Called when [text changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="Android.Text.TextChangedEventArgs"/> instance containing the event data.</param>
        private void OnTextChanged(Object sender, Android.Text.TextChangedEventArgs e)
        {
            UpdateText();
        }

        /// <summary>
        /// Updates the text.
        /// </summary>
        private void UpdateText()
        {
            Control.TextChanged -= OnTextChanged;
            if (String.IsNullOrEmpty(Element.Text) == false)
            {
                Control.TextFormatted = Control.Compute(Context, new Java.Lang.String(Element.Text), (Single)Element.FontSize);
            }
            Control.TextChanged += OnTextChanged;
        }
    }
}