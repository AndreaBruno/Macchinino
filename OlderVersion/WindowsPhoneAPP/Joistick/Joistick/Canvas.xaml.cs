using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Windows.Media.Imaging;

namespace Joistick
{
    public partial class Canvas : PhoneApplicationPage
    {

        const string BASE_URL = @"http://192.168.2.20/";
        const string CONN = @"CC";
        double AltezzaSchermo, LarghezzaSchermo;
        private int Dir, Acc;
        WebBrowser wb;
        public bool isConnected { get; set; }
        public bool isTouching { get; set; }
        Point x;

        public Canvas()
        {
            InitializeComponent();
            wb = new WebBrowser();
            isConnected = false;
            AltezzaSchermo = canvas1.ActualHeight;
            LarghezzaSchermo = canvas1.ActualWidth;
            txtComandi.FontSize = 30;
            txtComandi.Text = "Doppio tap";
        }

        void dt_Tick(object sender, EventArgs e)
        {
            Dir = 5;
            Acc = 5;

            if (isConnected)
            {
                if (isTouching)
                {

                    //Mi metto in un sistema di riferimento cartesiano (il centro dello schermo è 0;0)
                    if (x.Y < -10 || x.Y > 10)
                    {
                        Acc = (int)Math.Round(x.Y / 315 * 4);
                    }
                    if (x.X > 10 || x.X < -10)
                    {
                        Dir = (int)Math.Round(x.X / 210 * 4);
                    }

                    Dir += 5;
                    Acc += 5;
                    Dir = Dir == 10 ? 5 : Dir;
                    Acc = Acc == 10 ? 5 : Acc;
                }

            }
            txtComandi.Text ="Connesso ---> "+ Acc.ToString() + " " + Dir.ToString();

            Move(Dir, Acc);
        }

        public void Move(int vel, int dir)
        {
            wb.Navigate(new Uri(BASE_URL + vel + dir));

        }

        private void canvas1_MouseMove_1(object sender, MouseEventArgs e)
        {
            x = e.GetPosition((UIElement)e.OriginalSource);
            x.X = (x.X - 220);
            x.Y = -(x.Y - 315);
            isTouching = true;
        }

        private void canvas1_DoubleTap_1(object sender, GestureEventArgs e)
        {
            //isConnected = true;
            //System.Windows.Threading.DispatcherTimer dt = new System.Windows.Threading.DispatcherTimer();
            //dt.Interval = new TimeSpan(0, 0, 0, 0, 250); // 500 Milliseconds
            //dt.Tick += new EventHandler(dt_Tick);
            //dt.Start();
            if (!isConnected)
            {
                wb.Navigate(new Uri(BASE_URL + CONN));
                //logger.Text = BASE_URL + CONN;
                System.Windows.Threading.DispatcherTimer dt = new System.Windows.Threading.DispatcherTimer();
                dt.Interval = new TimeSpan(0, 0, 0, 0, 250); // 500 Milliseconds
                dt.Tick += new EventHandler(dt_Tick);
                dt.Start();
                isConnected = true;
                
                ImageBrush myBrush = new ImageBrush();
                myBrush.ImageSource =
                    new BitmapImage(new Uri(@"Images/frecce.jpg", UriKind.Relative));
                canvas1.Background = myBrush;
            }
        }

        private void canvas1_MouseLeave_1(object sender, MouseEventArgs e)
        {
            isTouching = false;
        }


    }
}