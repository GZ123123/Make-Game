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
        public static  bool fall = false;
        private string p = "";
        private double count = 1;
        private bool is_long_press = false;

        private List<Tree> trees = new List<Tree>();
        private Tree tree;

        private List<Rect> rects = new List<Rect>();
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

            SKPaint paint = new SKPaint() {
                Color = SKColors.Black,
                IsStroke = true,
                Style = SKPaintStyle.Stroke,
            };

            SKPaint rpaint = new SKPaint() {
                Color = SKColors.Red
            };

            SKPaint characterPain = new SKPaint() {
                Color = SKColors.Violet,
            };

            tree.paint = paint;
            Crect.paint = rpaint;
            Nrect.paint = rpaint;
            character.paint = characterPain;

            var _  = new MoveObject(Nrect);
            _.container = rects;

            rects.Add(new Rect(Crect.Current_pos.X + Crect.Width + 50 + random.Next(10, 500), App.SCREEN_HEIGHT / 3 * 2));

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
        }

        void Red_LongPressed(object sender, MR.Gestures.LongPressEventArgs e)
        {
            p = "LongPressed";
            if(is_long_press)
                tree.rotation();
            is_long_press = false;            
        }

        private void SKCanvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();
            if (is_long_press)
            {
                tree.updateHight(1);
            }
            if (fall)
            {
                fall = false;
            }
            Crect.draw(canvas);
            Nrect.draw(canvas);
            tree.draw(canvas);
            character.draw(canvas);
        }
    }
}