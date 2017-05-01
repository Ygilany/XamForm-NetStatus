using System;
using System.Linq;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using Xamarin.Forms;

namespace NetStatus
{
    public class NetworkViewPage : ContentPage
    {
        Label ConnectionDetails;

        public NetworkViewPage()
        {
            BackgroundColor = Color.FromRgb(62, 100, 160);
            ConnectionDetails = new Label()
            {
                Text = "Yes Network",
                FontSize = 42,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.FromRgb(255, 206, 165),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            Content = ConnectionDetails;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ConnectionDetails.Text = CrossConnectivity.Current.ConnectionTypes.First().ToString();

            if (CrossConnectivity.Current != null)
                CrossConnectivity.Current.ConnectivityChanged += UpdateNetworkInfo;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            if (CrossConnectivity.Current != null)
                CrossConnectivity.Current.ConnectivityChanged -= UpdateNetworkInfo;
        }

        private void UpdateNetworkInfo(object sender, ConnectivityChangedEventArgs e)
        {
            if (CrossConnectivity.Current != null && CrossConnectivity.Current.ConnectionTypes != null)
            {
                var connectionType = CrossConnectivity.Current.ConnectionTypes.FirstOrDefault();
                ConnectionDetails.Text = connectionType.ToString();
            }
        }
    }
}