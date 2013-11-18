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
using System.IO;
using System.Text;
using System.Threading;
using System.IO.IsolatedStorage;

namespace Joistick
{
    public partial class MainPage : PhoneApplicationPage
    {

        IsolatedStorageFile myFile;

        public MainPage()
        {
            InitializeComponent();

            myFile = IsolatedStorageFile.GetUserStoreForApplication();

            if (!myFile.FileExists("Impo.txt"))
            {
                IsolatedStorageFileStream dataFile = myFile.CreateFile("Impo.txt");
                dataFile.Close();
            }
        }

        // Gestore dell'evento semplice Click del pulsante per andare alla seconda pagina
        private void BottoneGioco_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new Uri("/GamePage.xaml", UriKind.Relative));
            if(Carica())
                NavigationService.Navigate(new Uri("/Canvas.xaml", UriKind.Relative));
            else
                NavigationService.Navigate(new Uri("/Accelerometro.xaml", UriKind.Relative));
        }

        private void BottoneImpostazioni_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PaginaImpostazioni.xaml", UriKind.Relative));
        }

        private void BottoneConnetti_Click(object sender, RoutedEventArgs e)
        {

        }

        bool Carica()
        {
            StreamReader Sr = new StreamReader(new IsolatedStorageFileStream("Impo.txt", FileMode.Open, myFile));
            string testo = Sr.ReadToEnd();
            Sr.Close();

            string[] dati = testo.Split('-');

            if (string.Compare(dati[1].Trim(), "Joistick") == 0)
                return true;
            else
                return false;


        }
    }
}