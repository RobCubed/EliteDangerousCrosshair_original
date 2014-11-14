using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDCrossHair
{
    class BufferedPanel : Panel
    {
        private Graphics g;
        private static Rectangle rEllipse;
        private static Pen outline;
        //public static int xDraw = 0;
        public int _yDraw = 0;
        public int yDraw
        {
            get { return _yDraw; }
            set
            {
                if (_yDraw != value)
                {
                    _yDraw = value;
                    this.Invalidate();
                }
            }
        }

        private int _xDraw = 0;
        public int xDraw
        {
            get { return _xDraw; }
            set
            {
                if (_xDraw != value)
                {
                    this.Invalidate();
                }
                _xDraw = value;
            }
        }

        private bool _programFocus;
        public bool programFocus
        {
            get { return _programFocus;  }
            set
            {
                _programFocus = value;
                this.Invalidate();
            }
        }

        public BufferedPanel()
        {
            outline = new Pen(Color.Red);
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (programFocus == true)
            {
                g = e.Graphics;
                rEllipse = new Rectangle();
                rEllipse.Width = 50;
                rEllipse.Height = 50;
                rEllipse.X = xDraw - (rEllipse.Width / 2);
                rEllipse.Y = yDraw - (rEllipse.Height / 2);

                g.DrawEllipse(outline, rEllipse);

                base.OnPaint(e);
            }
        }
    }
}
