using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


// TODO: Hotkey to hide the crosshair
// TODO: Cursor styles!

namespace EDCrossHair
{
    public partial class Form1 : Form
    {
        KeyboardHook hook = new KeyboardHook();
        private bool activate;
        BackgroundWorker locationUpdate;
        int finalLocX;
        int finalLocY;
        int x;
        int y;

        public Form1()
        {
            InitializeComponent();
            locationUpdate = new BackgroundWorker();
            activate = true;


            hook.KeyPressed +=
                new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);
            // register the control + shift + F12 combination as hot key.
            hook.RegisterHotKey((ModifierKeys)2 | (ModifierKeys)4, Keys.F1);
            locationUpdate.DoWork += new DoWorkEventHandler(_DoWork);
           

            Thread thread = new Thread(new ThreadStart(RunPaint));
            thread.Start();

            bufferedPanel.BorderStyle = BorderStyle.None;

        }

        void _DoWorkCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }

        void _DoWork(object sender, DoWorkEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    this.DesktopLocation = new Point(finalLocX, finalLocY);
                    this.Width = x * 2;
                    this.Height = y * 2;
                }));
            }
            else
            {
                this.DesktopLocation = new Point(finalLocX, finalLocY);
            }

        }

        void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            // show the keys pressed in a label.
            if (activate)
            {
                Console.WriteLine("Crosshair disabled! Press CTRL+SHIFT+F1 again to enable it.");
                activate = false;
            }
            else
            {
                Console.WriteLine("Crosshair enabled! Press CTRL+SHIFT+F1 again to disable it.");
                activate = true;
            }
        }

        private void RunPaint()
        {
            Console.WriteLine("Welcome to EliteDangerousCrosshair v1.0.1 by RobCubed!");
            Console.WriteLine("http://www.github.com/RobCubed");
            Console.WriteLine("* * * Now works on multi-screens/any screen! * * *");
            Console.WriteLine("Remember, Elite Dangerous *must* be in windowed mode for this to function.");
            Console.WriteLine("CTRL+SHIFT+F1 will enable/disable the crosshairs.");
            Console.WriteLine("--------------------------------------------");
            string gameName = "EliteDangerous32";
            IntPtr ptr = ProcessHandler.WaitForProcessByName(gameName);
            EDCrossHair.ProcessHandler.RECT clientRect = ProcessHandler.GetRect(ptr);
            
            
            bool coordinatesFound;
            int newPointX;
            int newPointY;


            while (true)
            {
                if (activate)
                {
                    ptr = ProcessHandler.WaitForProcessByName(gameName);
                    clientRect = ProcessHandler.GetRect(ptr);

                    if (ProcessHandler.IsForeground(ptr))
                    {
                        bufferedPanel.programFocus = true;
                    }
                    else
                    {
                        bufferedPanel.programFocus = false;
                    }

                    Point point;
                    x = clientRect.Width / 2;
                    y = clientRect.Height / 2;
                    coordinatesFound = false;


                    point = new Point();

                    coordinatesFound = ProcessHandler.ClientToScreen(ptr, ref point);

                    finalLocX = point.X;
                    finalLocY = point.Y;

                    if (!locationUpdate.IsBusy)
                    {
                        locationUpdate.RunWorkerAsync();
                    }


                    newPointX = point.X + x;
                    newPointY = point.Y + y;



                    if (coordinatesFound == true && (newPointX != bufferedPanel.xDraw || newPointY != bufferedPanel.yDraw))
                    {
                        bufferedPanel.xDraw = newPointX;
                        bufferedPanel.yDraw = newPointY;
                        bufferedPanel.xScreen = clientRect.Width;
                        bufferedPanel.yScreen = clientRect.Height;
                    }
                }
                else
                {
                    bufferedPanel.programFocus = false;
                }
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x80000 | 0x20;
                return cp;
            }
        }



    }
}
