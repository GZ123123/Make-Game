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
using System.Reflection;
using System.IO;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Play_Page : ContentPage
	{
        #region public
        public static bool fall = false;
        #endregion

        #region private
        private string p = "";
        private long score = 0;
        private float updown = 0;
        private int tus = -1;
        private double count = 1;
        private bool is_long_press = false;
        // Paints
        private Random random = new Random();


        SKPaint rpaint;


        // draw trees not tree
        private Tree tree;

        // draw rects not rect
        //private Rect Crect;
        //private Rect Nrect;
        private Stand Crect;
        private Stand Nrect;

        // draw moveObjects 
        //private List<MoveObject> moveObjects = new List<MoveObject>();

        // Container
        //private ObjectContainer<Rect> rects = new ObjectContainer<Rect>();
        private StandContainer stands = new StandContainer();
        private TreeContainer trees = new TreeContainer();

        List<IMovableObject> movables = new List<IMovableObject>();

        // draw character
        private Character character;
        #endregion
        public Play_Page ()
		{
			InitializeComponent ();

            NavigationPage.SetHasNavigationBar(this, false);

            setUp();
            fall = false;

            stands.add(Crect);
            stands.add(Nrect);
           
            // end test
            trees.add(new Tree(tree));
            // Frame 
            Device.StartTimer(TimeSpan.FromSeconds(1f/60), () =>
            {
                ((SKCanvasView)canvasView).InvalidateSurface();
                return true;
            });

        }

        #region Set_UP

        void background_draw(object sender, SKPaintSurfaceEventArgs e)
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
        void setUp()
        {
            tree = new Tree(96, App.SCREEN_HEIGHT / 3 * 2, 0);
            character = new Character(100 - tree.Width , App.SCREEN_HEIGHT / 3 * 2);
            Crect = new Stand(0, App.SCREEN_HEIGHT / 3 * 2);
            Nrect = new Stand(Crect.Current_pos.X + Crect.Width + 50 + random.Next(10, 400), App.SCREEN_HEIGHT / 3 * 2,50+ random.Next(10, 100));

            SKPaint paint = new SKPaint()
            {
                Color = SKColors.Black,
                IsStroke = true,
                Style = SKPaintStyle.Stroke,
            };

            rpaint = new SKPaint()
            {
                Color = SKColors.Gray
            };

            SKPaint characterPain = new SKPaint()
            {
                Color = SKColors.Violet,
            };

            tree.paint = paint;
            Crect.paint = rpaint;
            Nrect.paint = rpaint;
            character.paint = characterPain;
        }
        #endregion

        #region Method
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
                trees.rotation();
            is_long_press = false;
        }
        #endregion

        #region Update
        private async void SKCanvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            // set up environment
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();
            // logic 
            if (is_long_press) trees.updateHeight(4);
            if (fall && tus < 3)
            {
                if (tus == -1)
                {
                    trees.Last.moveTo(new SKPoint(trees.Last.Start_from.X, trees.Last.Start_from.Y + -trees.Last.Width / 2));
                    //if (stands.Last.Current_pos.X > 100 - tree.Width)
                    //    character.moveTo(new SKPoint(character.Current_pos.X - 5, character.Current_pos.Y));
                    //else
                    tus = 0;
                }
                if (updown < trees.Last.Width && tus == 0)
                {
                    character.moveTo(new SKPoint(character.Current_pos.X,character.Current_pos.Y-1));
                    character.is_stand = false;
                    updown++;
                    if (updown >= trees.Last.Width)
                        tus = 1;
                } 
                else if (character.Current_pos.X < trees.Last.Start_from.X+ trees.Last.Height)
                {
                    character.moveTo(new SKPoint(character.Current_pos.X+5,character.Current_pos.Y));
                    if (character.Current_pos.X >= trees.Last.Start_from.X + trees.Last.Height)
                        tus = 2;
                }
                if(updown > 0 && tus == 2)
                {
                    character.moveTo(new SKPoint(character.Current_pos.X, character.Current_pos.Y + 1));
                    updown--;
                    if (updown <= 0)
                    {
                        if (character.Current_pos.X+character.Width < stands.Last.Current_pos.X || character.Current_pos.X - character.Width/2 > stands.Last.Current_pos.X + stands.Last.Width)
                        {
                            //string text = File.ReadAllText(App.fileName);
                            if (await DisplayAlert("Game Over", "High Score: 56", "New game", "Home"))
                            {
                                Application.Current.MainPage.Navigation.InsertPageBefore(new Play_Page(), Navigation.NavigationStack[Navigation.NavigationStack.Count - 1]);
                                await Navigation.PopAsync();
                                return;
                            }
                            else
                            {
                                this.Navigation.RemovePage(this.Navigation.NavigationStack.Last());
                                return;
                            }
                            score = 0;
                        }
                        else {
                            score++;
                            character.is_stand = true;
                            tus = 3;
                        }
                    }
                        
                }
                
            }
            if (fall && tus >= 3) {
                if (tus == 3)
                {
                    if (stands.Last.Current_pos.X + stands.Last.Width - trees.Last.Width > 98)
                    {
                        stands.secondLast.moveTo(new SKPoint(stands.secondLast.Current_pos.X - 10, stands.secondLast.Current_pos.Y));
                        stands.Last.moveTo(new SKPoint(stands.Last.Current_pos.X - 10, stands.Last.Current_pos.Y));
                        character.moveTo(new SKPoint(character.Current_pos.X - 10, character.Current_pos.Y));
                        trees.Last.moveTo(new SKPoint(trees.Last.Start_from.X - 10, trees.Last.Start_from.Y));
                        if (trees.Count > 1)
                            trees.secondLast.moveTo(new SKPoint(trees.secondLast.Start_from.X - 10, trees.secondLast.Start_from.Y));
                    }
                    else tus = 4;
                }
                else if (tus == 4)
                {
                    if (character.Current_pos.X > 100 - trees.Last.Width - character.Width)
                        character.moveTo(new SKPoint(character.Current_pos.X - Math.Min(5.0f, character.Current_pos.X - (100 - trees.Last.Width - character.Width)), character.Current_pos.Y));
                    else if (character.Current_pos.X < 100 - trees.Last.Width - character.Width)
                        character.moveTo(new SKPoint(character.Current_pos.X + Math.Min(5.0f, 100 - trees.Last.Width - character.Width - character.Current_pos.X), character.Current_pos.Y));
                    else
                    {
                        if (trees.Count > 1)
                            trees.remove(0);
                        NextMove();
                        fall = false;
                        tus = -1;
                    }
                    
                }
                
            }

            // draw Object;
            stands.draw(canvas);

            trees.draw(canvas);
            
            character.draw(canvas);
            canvas.DrawText(score.ToString(), App.SCREEN_WIDTH / 2, 100, new SKPaint()
            {
                Color = SKColors.Black,
                IsStroke = true,
                Style = SKPaintStyle.Stroke,
                TextSize = 50
            });
            
        }

        private void NextMove()
        {
            trees.add(new Tree(tree));
            stands.add(new Stand(stands.Last.Current_pos.X + stands.Last.Width + 50 + random.Next(10, 500), App.SCREEN_HEIGHT / 3 * 2, 50 + random.Next(10, 100), paint:rpaint));
        }
        #endregion
    }
}