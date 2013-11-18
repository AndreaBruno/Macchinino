using System;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Text;
using System.Drawing;
using System.Net.Sockets;

namespace Joistick3
{
    public partial class Form1 : Form
    {
        ConnessioneUdp conn;
        bool PremutoAcc;
        bool PremutoDir;
        bool Avanti;
        bool Dietro;
        bool Destra;
        bool Sinistra;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn = new ConnessioneUdp();
            label1.Text = conn.Connect("192.168.2.1", "A5D5", 50000);

            Avanti = Destra = Dietro = Sinistra = false;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            //label1.Text = conn.Send("Timer avviato");
            timer1.Start();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            string Tasto = e.KeyData.ToString();


            if (Tasto.CompareTo("W") == 0 || Tasto.CompareTo("S") == 0)
            {
                PremutoAcc = true;

                if (Tasto.CompareTo("W") == 0)
                {
                    Avanti = true;
                    Dietro = false;
                }
                else if (Tasto.CompareTo("S") == 0)
                {
                    Avanti = false;
                    Dietro = true;
                }
            }
            if (Tasto.CompareTo("A") == 0 || Tasto.CompareTo("D") == 0)
            {
                PremutoDir = true;

                if (Tasto.CompareTo("A") == 0)
                {
                    Destra = false;
                    Sinistra = true;
                }
                else if (Tasto.CompareTo("D") == 0)
                {
                    Destra = true;
                    Sinistra = false;
                }
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            string Tasto = e.KeyData.ToString();

            if (Tasto.CompareTo("W") == 0 || Tasto.CompareTo("S") == 0)
            {
                PremutoAcc = false;
                Avanti = Dietro = false;
            }
            if (Tasto.CompareTo("A") == 0 || Tasto.CompareTo("D") == 0)
            {
                PremutoDir = false;
                Destra = Sinistra = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //D5A5
            string Richiesta = "D";

            if (PremutoDir)
            {
                if (Destra) Richiesta += "3";
                else Richiesta += "7";
            }
            else Richiesta += "5";

            Richiesta += "A";

            if (PremutoAcc)
            {
                if (Avanti) Richiesta += "8";
                else Richiesta += "3";
            }
            else Richiesta += "5";

           // Colora();

            label1.Text= conn.Send(Richiesta);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Send("A5D5");
        }



        void Colora()
        {
            if (Avanti == false && Dietro == false)
            {
                BoxAvanti.BackColor = Color.Red;
                BoxDietro.BackColor = Color.Red;
            }
            else
            {
                if (Avanti)
                {
                    BoxAvanti.BackColor = Color.Green;
                    BoxDietro.BackColor = Color.Red;
                }
                else
                {
                    BoxAvanti.BackColor = Color.Red;
                    BoxDietro.BackColor = Color.Green;
                }
            }

            if (Destra == false && Sinistra == false)
            {
                BoxDestra.BackColor = Color.Red;
                BoxSinistra.BackColor = Color.Red;
            }
            else
            {
                if (Destra)
                {
                    BoxDestra.BackColor = Color.Green;
                    BoxSinistra.BackColor = Color.Red;
                }
                else
                {
                    BoxDestra.BackColor = Color.Red;
                    BoxSinistra.BackColor = Color.Green;
                }
            }
        }

    }

    //public class Connessione
    //{
    //    TcpClient client;
    //    byte[] data;
    //    NetworkStream stream;


    //    public String Connect(String server, String message, Int32 port)
    //    {
    //        try
    //        {
    //            TcpClient client = new TcpClient(server, port);
    //            Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

    //            // Get a client stream for reading and writing.
    //            //  Stream stream = client.GetStream();
    //            NetworkStream stream;
    //            stream = client.GetStream(); 
    //            stream.Write(data, 0, data.Length);
    //            stream.BeginRead(

    //            //data = new Byte[256];

    //            //// String to store the response ASCII representation.
    //            //String responseData = String.Empty;

    //            //// Read the first batch of the TcpServer response bytes.
    //            //Int32 bytes = stream.Read(data, 0, data.Length);
    //            //responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);

    //            return "Connessione riuscita";
    //        }
    //        catch (ArgumentNullException e)
    //        {
    //            return "Null exception";
    //        }
    //        catch (SocketException e)
    //        {
    //            return "Problemi di socket";
    //        }
    //    }

    //    public void disconnect()
    //    {
    //        stream.Close();
    //        client.Close();
    //    }

    //    public String Send(String message)
    //    {
    //        try
    //        {
    //            Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);

    //            // Get a client stream for reading and writing.
    //            //  Stream stream = client.GetStream();
    //            stream = client.GetStream();
    //            stream.Write(data, 0, data.Length);
    //            //data = new Byte[256];

    //            //// String to store the response ASCII representation.
    //            //String responseData = String.Empty;

    //            // Read the first batch of the TcpServer response bytes.
    //           // Int32 bytes = stream.Read(data, 0, data.Length);
    //           // responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);

    //            return "Invio riuscito";
    //        }
    //        catch
    //        {
    //            return "Invio non riuscito";
    //        }
    //    }
    //}

    public class ConnessioneUdp
    {
        UdpClient client;
        Byte[] data;

        public String Connect(String server, String message, Int32 port)
        {
            try
            {
                client = new UdpClient(server, port);
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
                client.Send(data, data.Length);
                return "Connessione riuscita";
            }
            catch (ArgumentNullException e)
            {
                return "Null exception";
            }
            catch (SocketException e)
            {
                return "Problemi di socket";
            }
        }

        public void disconnect()
        {
            client.Close();
        }

        public String Send(String message)
        {
            try
            {
                data = System.Text.Encoding.ASCII.GetBytes(message);
                client.Send(data, data.Length);
                return "Invio riuscito";
            }
            catch
            {
                return "Invio non riuscito";
            }
        }
    }
}
