﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace XFTestApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ImageFullScreen : ContentPage
	{
        double currentScale = 1;
        double startScale = 1;
        double xOffset = 0;
        double yOffset = 0;
        public ImageFullScreen (string imageLink)
		{
            InitializeComponent();
            var lm = new LinkModel
            {
                Link = imageLink
            };
            BindingContext = lm;
        }
        private async void BackButton_Click(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        //void OnPanUpdated(object sender, PanUpdatedEventArgs e)
        //{
        //    switch (e.StatusType)
        //    {
        //        case GestureStatus.Running:
        //            // Translate and ensure we don't pan beyond the wrapped user interface element bounds. 
        //            Content.TranslationX =
        //             Math.Max(Math.Min(0, x + e.TotalX), -Math.Abs(Content.Width - Application.Current.MainPage.Width));
        //            Content.TranslationY =
        //             Math.Max(Math.Min(0, y + e.TotalY), -Math.Abs(Content.Height - Application.Current.MainPage.Height));
        //            break;

        //        case GestureStatus.Completed:
        //            // Store the translation applied during the pan 
        //            x = Content.TranslationX;
        //            y = Content.TranslationY;
        //            break;
        //    }
        //}

        public void OnPinchUpdated(object sender, PinchGestureUpdatedEventArgs e)
        {
            if (e.Status == GestureStatus.Started)
            {
                // Store the current scale factor applied to the wrapped user interface element,
                // and zero the components for the center point of the translate transform.
                startScale = Content.Scale;
                Content.AnchorX = 0;
                Content.AnchorY = 0;
            }
            if (e.Status == GestureStatus.Running)
            {
                // Calculate the scale factor to be applied.
                currentScale += (e.Scale - 1) * startScale;
                currentScale = Math.Max(0.1, currentScale);

                // The ScaleOrigin is in relative coordinates to the wrapped user interface element,
                // so get the X pixel coordinate.
                double renderedX = Content.X + xOffset;
                double deltaX = renderedX / Width;
                double deltaWidth = Width / (Content.Width * startScale);
                double originX = (e.ScaleOrigin.X - deltaX) * deltaWidth;

                // The ScaleOrigin is in relative coordinates to the wrapped user interface element,
                // so get the Y pixel coordinate.
                double renderedY = Content.Y + yOffset;
                double deltaY = renderedY / Height;
                double deltaHeight = Height / (Content.Height * startScale);
                double originY = (e.ScaleOrigin.Y - deltaY) * deltaHeight;

                // Calculate the transformed element pixel coordinates.
                double targetX = xOffset - (originX * Content.Width) * (currentScale - startScale);
                double targetY = yOffset - (originY * Content.Height) * (currentScale - startScale);

                // Apply translation based on the change in origin.
                Content.TranslationX = targetX.Clamp(-Content.Width * (currentScale - 1), 0);
                Content.TranslationY = targetY.Clamp(-Content.Height * (currentScale - 1), 0);

                // Apply scale factor
                Content.Scale = currentScale;
            }
            if (e.Status == GestureStatus.Completed)
            {
                // Store the translation delta of the wrapped user interface element.
                xOffset = Content.TranslationX;
                yOffset = Content.TranslationY;
            }
        }
    }
}