using Xamarin.Forms;
using System;
using Plugin.Connectivity;
using System.ComponentModel;

namespace MedeiApp
{
    public partial class MedeiAppPage : ContentPage
    {

        public MedeiAppPage()
        {
            InitializeComponent();
            CrossConnectivity.Current.ConnectivityChanged += (sender, args) => 
            {
                if (args.IsConnected)
                {
                    LabelStatusText.Text = "Is connected!";
                }
                else if (!args.IsConnected)
                {
                    LabelStatusText.Text = "Is not connected";
                }
                else
                {
                    LabelStatusText.Text = "Something's wrong";
                }
            };
        }

        async void OpenAboutPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AboutPage());
        }

        async void OpenStudiesPage(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new StudiesPage());
        }
    }
}
