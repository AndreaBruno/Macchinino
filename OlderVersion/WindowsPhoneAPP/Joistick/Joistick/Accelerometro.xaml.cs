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
using Microsoft.Devices.Sensors;
using System.IO.IsolatedStorage;
using System.IO;


namespace Joistick
{
    public partial class Accelerometro : PhoneApplicationPage
    {
        Accelerometer accelerometer;
        WebBrowser Wb;
        bool Connesso;
        String UrlBase;
        IsolatedStorageFile myFile;

        public Accelerometro()
        {
            InitializeComponent();
    
            accelerometer = new Accelerometer();
            accelerometer.TimeBetweenUpdates = TimeSpan.FromMilliseconds(100);
            accelerometer.Start();

            myFile = IsolatedStorageFile.GetUserStoreForApplication();

            if (!myFile.FileExists("Impo.txt"))
            {
                IsolatedStorageFileStream dataFile = myFile.CreateFile("Impo.txt");
                dataFile.Close();
            }

            Wb = new WebBrowser();
            Connesso = false;
            Carica();

            System.Windows.Threading.DispatcherTimer dt = new System.Windows.Threading.DispatcherTimer();
            dt.Interval = new TimeSpan(0, 0, 0, 0, 250); // 500 Milliseconds
            dt.Tick += new EventHandler(dt_Tick);
            dt.Start();
        }

        void Carica()
        {
            StreamReader Sr = new StreamReader(new IsolatedStorageFileStream("Impo.txt", FileMode.Open, myFile));
            string testo = Sr.ReadToEnd();
            Sr.Close();

            string[] Dati = testo.Split('-');

            try
            {
                string [] appo = Dati[0].Split('.');
                string ndea = appo[3];

                UrlBase = "http://"+ Dati[0] + "/";

            }
            catch
            {
                MessageBox.Show("Indirizzo ip non valido");
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }


        }

        void dt_Tick(object sender, EventArgs e)
        {
            Brush premuto = new SolidColorBrush(Colors.Red);
            Brush nonpremuto = new SolidColorBrush(Colors.Green);

            rectAvanti.Fill = rectDestra.Fill = rectDietro.Fill = rectSinistra.Fill = nonpremuto;
            float ValAcc = accelerometer.CurrentValue.Acceleration.Z;
            float ValDir = accelerometer.CurrentValue.Acceleration.Y;

            if (Connesso)
            {
                string Acc = "5";
                string Dir = "5";

                if (ValAcc < -0.7F && ValAcc > -1F)
                {
                    rectAvanti.Fill = premuto;
                    Acc = "7";
                }
                else if (ValAcc > 0.3F && ValAcc < 1F)
                {
                    rectDietro.Fill = premuto;
                    Acc = "4";
                }

                if (ValDir < -0.3F && ValDir > -1F)
                {
                    rectDestra.Fill = premuto;
                    Dir = "7";
                }
                else if (ValDir > 0.3F && ValDir < 1F)
                {
                    rectSinistra.Fill = premuto;
                    Dir = "3";
                }

                Wb.Navigate(new Uri(@UrlBase + Acc + Dir));
            }
             
        }

        private void btnConnetti_Click(object sender, RoutedEventArgs e)
        {
            Connesso = true;
            Wb.Navigate(new Uri(@""+UrlBase+"CC"));
            rectConn.Fill = new SolidColorBrush(Colors.Green);
        }
    }
}