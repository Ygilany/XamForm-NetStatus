using System;

using Xamarin.Forms;

namespace NetStatus
{
    public class NoNetworkPage : ContentPage
    {
        public NoNetworkPage()
        {
            BackgroundColor = Color.FromRgb(0xf0, 0xf0, 0xf0);
            Content = new Label()
            {
                Text = "No Network Connection is Available",
                TextColor = Color.FromRgb(0x40, 0x40, 0x40),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };
        }
    }
}

