using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SkiaSharp.Views.Forms;
using SkiaSharp;
using App1.Object;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Play_Page : ContentPage
	{
        private string p = "asdasdas";
        private double count = 1;
        private bool is_long_press = false;
        

        private Tree tree;
        private Rect Crect;
        private Rect Nrect;
        private Character character;

        public Play_Page ()
		{
			InitializeComponent ();
            Random random = new Random();
            Crect = new Rect(50, App.SCREEN_HEIGHT / 3 * 2);
            Nrect = new Rect(Crect.Current_pos.X+Crect.Width + 50 + random.Next(10,500), App.SCREEN_HEIGHT / 3 * 2);
            tree = new Tree(100, App.SCREEN_HEIGHT / 3 * 2, 0);
            character = new Character(100-20-tree.Width/2, App.SCREEN_HEIGHT / 3 * 2-20);

            SKPaint paint = new SKPaint()
            {
                Color = SKColors.Black,
                IsStroke = true,
                Style = SKPaintStyle.Stroke,
            };

            SKPaint rpaint = new SKPaint()
            {
                Color = SKColors.Red
            };

            SKPaint characterPain = new SKPaint()
            {
                Color = SKColors.Violet,
            };

            //tree.rotation();
            tree.paint = paint;
            Crect.paint = rpaint;
            Nrect.paint = rpaint;
            character.paint = characterPain;

            Device.StartTimer(TimeSpan.FromSeconds(1f/60), () =>
              {
                  ((SKCanvasView)canvasView).InvalidateSurface();
                  return true;
              });
        }

        void Red_LongPressing(object sender, MR.Gestures.LongPressEventArgs e)
        {
            count++;
            p = count+"LongPressing";
            is_long_press = true;
            //((SKCanvasView)canvasView).InvalidateSurface();
        }

        void Red_LongPressed(object sender, MR.Gestures.LongPressEventArgs e)
        {
            p = "LongPressed";
            if(is_long_press)
                tree.rotation();
            is_long_press = false;


            if (tree.Degrees >= 80 && tree.Is_rotate == true)
                Crect.moveTo(new SKPoint(50,50));
            
        }

        private void SKCanvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();
            if (is_long_press == true)
            {
                tree.updateHight(1);
            }
            
            Crect.draw(canvas);
            Nrect.draw(canvas);
            tree.draw(canvas);
            character.draw(canvas);

            using (var paint = new SKPaint())
            {
                paint.TextSize = 64.0f;
                paint.IsAntialias = true;
                paint.Color = new SKColor(0x42, 0x81, 0xA4);
                paint.IsStroke = false;

                if (is_long_press)
            {
                count += 0.01;
                count = tree.Height;
                canvas.DrawText(Convert.ToString(count), info.Width/(2.3f), info.Height / 10, paint);
            }
                else
                {
                    count = 1;
                }
        }


    }

        //private void BoxView_Swiped(object sender, MR.Gestures.DownUpEventArgs e)
        //{
        //    DisplayAlert("Up", "Up", "Ok");
        //}
    }
}