using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views;
using SkiaSharp.Views.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            // BackgroundImage = "image/background.jpg";
            
            InitializeComponent();



            NavigationPage.SetHasNavigationBar(this, false);
        }
        async void Start_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Alert", "Start", "Ok"); 
            await Navigation.PushAsync(new Play_Page());
        }

        async void Exit_Clicked(object sender, EventArgs e)
        {
            var res = await DisplayAlert("Alert", "Exit", "Yes","No");
            if(res == true) { 
                var closer = DependencyService.Get<ICloseApplication>();
                closer?.closeApplication();
            }
        }

        async void Setting_Clicked(object sender, EventArgs e)
        {
            //await DisplayAlert("Alert", "Setting", "Ok");
            await Navigation.PushAsync(new Setting());
        }
    }
}
