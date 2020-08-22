using PlayVideoInIOS.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PlayVideoInIOS
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (Device.RuntimePlatform == Device.iOS)
            {
                Xamarin.Forms.DependencyService.Get<IPlayVideoFromLocalStorage>().PlayVideoFromLocalStorage("set here local file path");
            }
        }
    }
}
