using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SkiaSharp;
using SkiaSharp.Views.Forms;


namespace App1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Play_Page : ContentPage
	{
		public Play_Page()
		{
			InitializeComponent();
		}
        private bool showFill = true;

        public void OnCanvasViewPaintSurface(object sender,SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            SKPaint paint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = Color.Red.ToSKColor(),
                StrokeWidth = 50
            };
            canvas.DrawCircle(info.Width / 2, info.Height / 2, 100, paint);

            if (showFill)
            {
                paint.Style = SKPaintStyle.Fill;
                paint.Color = SKColors.Blue;
                canvas.DrawCircle(info.Width / 2, info.Height / 2, 100, paint);
            }
        }
        public void OnCanvasViewTapped(object sender, EventArgs args)
        {
            showFill ^= true;
            (sender as SKCanvasView).InvalidateSurface();
        }

    }
}