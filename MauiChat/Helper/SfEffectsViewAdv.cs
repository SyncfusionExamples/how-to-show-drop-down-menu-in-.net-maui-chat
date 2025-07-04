using Microsoft.Maui.Controls.Platform;
using Microsoft.Maui.Platform;
using Syncfusion.Maui.Popup;
using Syncfusion.Maui.Core;

#if MACCATALYST
using UIKit;
using Foundation;
#elif WINDOWS
using Microsoft.UI.Input;
#endif

namespace MauiChat
{
    public class CustomEffectsView : SfEffectsView
    {
        #region Constructor

        public CustomEffectsView()
        {
            this.LongPressEffects = SfEffects.None;
            this.TouchDownEffects = SfEffects.None;
            this.TouchUpEffects = SfEffects.None;
#if ANDROID || IOS || MACCATALYST
            this.LongPressed += SfEffectsViewAdv_LongPressed;
#endif
        }

        #endregion

        #region Properties
        public SfPopup? Popup { get; set; }
        #endregion

        #region Protected Methods
        protected override void OnHandlerChanged()
        {
            base.OnHandlerChanged();
#if WINDOWS
            if (this.Handler != null && this.Handler.PlatformView is MauiPanel platformView)
            {
                platformView.RightTapped += PlatformView_RightTapped;
            }
#endif
        }
        #endregion

        #region Callbacks

#if WINDOWS
        private void PlatformView_RightTapped(object sender, Microsoft.UI.Xaml.Input.RightTappedRoutedEventArgs e)
        {
            if (this.Popup != null)
            {
                this.Popup.RelativeView = this;
                this.Popup.RelativePosition = Syncfusion.Maui.Popup.PopupRelativePosition.AlignTopRight;
                this.Popup.IsOpen = true;
            }
        }
#endif
        private void SfEffectsViewAdv_LongPressed(object? sender, EventArgs e)
        {
            if (sender is CustomEffectsView view && view.Popup is SfPopup popup)
            {
                popup.RelativeView = view;
                popup.RelativePosition = Syncfusion.Maui.Popup.PopupRelativePosition.AlignTopRight;
                popup.IsOpen = true;
            }
        }
        #endregion
    }
}