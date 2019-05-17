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
        public static bool play = true;

        private string p = "asdasdas";
        private double count = 1;
        private bool is_long_press = false;
        private int tus = 0;
        private int updown = 0;

        private Rect [] rects = new Rect[1000];
        private Tree tree;
        private Tree Otree;
        private Rect Crect;
        private Rect Nrect;
        private Rect Frect;
        private Character character;

        public Play_Page ()
		{
			InitializeComponent ();
            Random random = new Random();
            Crect = new Rect(50, App.SCREEN_HEIGHT / 3 * 2);
            Nrect = new Rect(Crect.Current_pos.X + Crect.Width + 50 + random.Next(10, 400), App.SCREEN_HEIGHT / 3 * 2);
            Frect = new Rect(Nrect.Current_pos.X + Nrect.Width + 50 + random.Next(10, 400), App.SCREEN_HEIGHT/3*2+60);
            tree = new Tree(100, App.SCREEN_HEIGHT / 3 * 2, 0);
            Otree = new Tree(100, App.SCREEN_HEIGHT / 3 * 2, 0);
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
            Otree.paint = paint;
            Crect.paint = rpaint;
            Nrect.paint = rpaint;
            Frect.paint = rpaint;
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


            //if (tree.Degrees >= 80 && tree.Is_rotate == true)
            //    Crect.moveTo(new SKPoint(50,50));
            
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
                if (updown < tree.Width && tus == 0)
                {
                    character.moveTo(new SKPoint(character.Current_pos.X, character.Current_pos.Y - 1));
                    updown++;
                }
                else if (updown >= tree.Width && tus == 0)
                {
                    tus = 1;
                }
                if (tus == 1 && character.Current_pos.X < tree.Start_from.X + tree.Height)
                {
                    character.moveTo(new SKPoint(character.Current_pos.X + 1, character.Current_pos.Y));
                }   
                else if (tus == 1 && character.Current_pos.X >= tree.Start_from.X + tree.Height)
                {
                    tus = 2;
                }

                if (tus == 2 && updown > 0)
                {
                    character.moveTo(new SKPoint(character.Current_pos.X, character.Current_pos.Y + 1));
                    updown--;
                }
                else if (tus == 2 && updown <= 0)
                {
                    tus = -1;
                    play = false;
                }

                if (tus == -1)
                {
                    float move = 0;
                    if (Nrect.Current_pos.X > 50)
                        move = Math.Min(1, Nrect.Current_pos.X - 50);
                    if (Nrect.Current_pos.X > 50)
                    {
                        Crect.moveTo(new SKPoint(Crect.Current_pos.X - move, Crect.Current_pos.Y));
                        Nrect.moveTo(new SKPoint(Nrect.Current_pos.X - move, Nrect.Current_pos.Y));
                        Frect.moveTo(new SKPoint(Frect.Current_pos.X - move, Frect.Current_pos.Y));
                        tree.moveTo(new SKPoint(tree.Start_from.X - move, tree.Start_from.Y));
                        character.moveTo(new SKPoint(character.Current_pos.X - move, character.Current_pos.Y));
                    }
                    else
                    {
                        Otree = new Tree(tree);
                        tree = new Tree(100, App.SCREEN_HEIGHT / 3 * 2, 0);
                        tree.paint = new SKPaint()
                        {
                            Color = SKColors.Black,
                            IsStroke = true,
                            Style = SKPaintStyle.Stroke,
                        };
                        fall = false;
                        if (Frect.Current_pos.Y > App.SCREEN_HEIGHT / 3 * 2)
                        {
                            //Frect.moveTo(new SKPoint(Frect.Current_pos.X, Frect.Current_pos.Y-Math.Min(Crect.Current_pos.Y - App.SCREEN_HEIGHT / 3 * 2, 1)));
                            Frect.moveTo(new SKPoint(Frect.Current_pos.X, App.SCREEN_HEIGHT / 3 * 2));
                        }
                    }
                        
                }

                //Crect.moveTo(new SKPoint(300, 50));
                //Nrect.moveTo(new SKPoint(50, 50));
                //tree.moveTo(new SKPoint(50, 50));
            }
            Crect.draw(canvas);
            Nrect.draw(canvas);
            Frect.draw(canvas);
            tree.draw(canvas);
            Otree.draw(canvas);
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