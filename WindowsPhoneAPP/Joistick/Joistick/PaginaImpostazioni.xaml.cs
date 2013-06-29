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
using System.IO.IsolatedStorage;

namespace Joistick
{
    public partial class PaginaImpostazioni : PhoneApplicationPage
    {
        IsolatedStorageFile myFile;

        public PaginaImpostazioni()
        {
            InitializeComponent();

            myFile = IsolatedStorageFile.GetUserStoreForApplication();

            if (!myFile.FileExists("Impo.txt"))
            {
                IsolatedStorageFileStream dataFile = myFile.CreateFile("Impo.txt");
                dataFile.Close();
            }
            Carica();
        }


        private void BottoneSalva_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter sw = new StreamWriter(new IsolatedStorageFileStream("Impo.txt", FileMode.Create, myFile));

            try
            {
                string[] Controllo = TextIp.Text.Split('.');
                Controllo[3] = "dfsf";


                string appo = TextIp.Text.Trim() + "-";

                if (RadioAcc.IsChecked==true)
                    appo += "Accelerometro";
                else
                    appo += "Joistick";

                sw.WriteLine(appo);
                sw.Close();

                MessageBox.Show("Salvataggio eseguito");

                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
            catch
            {
                MessageBox.Show("Indirizzi errati");    
            }
        }

        void Carica()
        {
            StreamReader Sr = new StreamReader(new IsolatedStorageFileStream("Impo.txt", FileMode.Open, myFile));
            string testo = Sr.ReadToEnd();
            Sr.Close();

            string[] dati = testo.Split('-');
            TextIp.Text = dati[0];

            if (string.Compare(dati[1].Trim(), "Accelerometro") == 0)
                RadioAcc.IsChecked = true;
            else
                RadioJoi.IsChecked = true;
            
        }
    }
}