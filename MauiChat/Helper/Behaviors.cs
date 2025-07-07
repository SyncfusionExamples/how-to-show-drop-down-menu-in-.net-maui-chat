using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using Syncfusion.Maui.Chat;
using Syncfusion.Maui.Core;
using Syncfusion.Maui.Popup;

namespace MauiChat
{
    public class ContentPageBehavior : Behavior<ContentPage>
    {
        #region Fileds

        private SfPopup? popup;
        private SfChipGroup? chipGroup;

        #endregion

        #region Protected Methods
        protected override void OnAttachedTo(ContentPage bindable)
        {
            this.popup = bindable.Resources["sfPopup"] as SfPopup;
            this.chipGroup = bindable.Resources["chipGroup"] as SfChipGroup;
            if (this.chipGroup != null)
            {
                this.chipGroup.ChipClicked += ChipGroup_ChipClicked;
            }

            base.OnAttachedTo(bindable);
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            if (this.chipGroup != null)
            {
                this.chipGroup.ChipClicked -= ChipGroup_ChipClicked;
                this.chipGroup = null;
            }
            this.popup = null;
            base.OnDetachingFrom(bindable);
        }

        #endregion

        #region Callbacks

        private void ChipGroup_ChipClicked(object? sender, EventArgs e)
        {
            if (this.popup != null && this.popup.IsOpen)
            {
                this.popup.IsOpen = false;
            }
        }

        #endregion
    }
}
