using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views;
using SkiaSharp.Views.Forms;
using System.Reflection;
using System.IO;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {            
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);
        }
        async void Start_Clicked(object sender, EventArgs e)
        {
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
            await Navigation.PushAsync(new Setting());
        }

        void SKCanvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            SKRect rect = SKRect.Create(0, 0, info.Width, info.Height);

            // load bitmap
            Assembly assembly = GetType().GetTypeInfo().Assembly;
            using (Stream stream = assembly.GetManifestResourceStream("App1.Media.background02.png"))
            {
                SKBitmap CharactorBitsMap = SKBitmap.Decode(stream);
                canvas.DrawBitmap(CharactorBitsMap, rect);

            }
        }
    }
}
