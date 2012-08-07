using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.DirectX.DirectDraw;
using TestDirectX2.Core;

namespace TestDirectX2
{
    public partial class Form1 : Form
    {
       // DxInitGraphics _graphics = null;
        //DxInitImage _background = null;

        //DxInitSprite _sprite = null;
       // DxAnimation _animation = null;
        //float deltaTime = 0;
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;

            //_graphics = new DxInitGraphics(this);
          //  _background = new DxInitImage("Assets\\wallpaper_1.jpg", _graphics.GraphicsDevice);

           // _sprite = new DxInitSprite("Assets\\walk.png", _graphics.GraphicsDevice, 104, 150);
           // _animation = new DxAnimation(_sprite, 30, true);
            this.Show();

            GameLogic game = new GameLogic(this);
            game.Initialize();
            game.GameLoop();
          //  timer1.Start();
           
           
           // System.Threading.Thread.Sleep(5000);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
          //  deltaTime += timer1.Interval;
          //  _graphics.Clear(Color.CornflowerBlue);

//#if DEBUG
//            _graphics.SecondarySurface.ColorFill(Color.Aquamarine);
//#else
//            _graphics.SecondarySurface.ColorFill(Color.Orange);
//#endif
           // _background.DrawFast(0, 0, _graphics.SecondarySurface,DrawFastFlags.Wait);

           // _sprite.DrawFast(20, 20,2, _graphics.SecondarySurface, DrawFastFlags.Wait);
          //  _animation.Draw(20, 20, _graphics.SecondarySurface);

         //   _animation.Update(deltaTime);
          //  _graphics.Render();
        }

       
    }
}
