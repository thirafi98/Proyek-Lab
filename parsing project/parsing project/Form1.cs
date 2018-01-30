using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
//using System.IO.Ports.SerialPort;
using System.IO;
using System.Text.RegularExpressions;
using PCComm;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;

using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.MapProviders;
using GMap.NET.Projections;



namespace parsing_project
{
    public partial class Form1 : Form
    {

        public delegate void myDelegate();

        private SerialPort comPort = new SerialPort();

       // SerialPort port();

        CommunicationManager comm = new CommunicationManager();
        CommunicationManager commAT = new CommunicationManager();
        static double xTimeStamp = 0;

        public Form1()
        {
            InitializeComponent();
            timer1.Tick += new EventHandler(timer1_Tick);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comm.isOpen() == true) // Kalau Kebuka Serial Portnya, ditutup dulu 
            {
                //button1.Text = "Connect";
                System.Threading.Thread.Sleep(100);
                comm.ClosePort();
            }
            else
            {
                /*serialPort1.PortName = comboBox1.Text; // PIlih Port Koneksi
                serialPort1.BaudRate = int.Parse(comboBox2.Text); // Pilih Baudrate
                serialPort1.Parity = Parity.None; // Parity 1, Databits 8, Stopbits 1
                serialPort1.DataBits = 8;
                serialPort1.StopBits = StopBits.One;
                serialPort1.Handshake = Handshake.None;
                serialPort1.Open();*/

                if (comboBox1.Text == "") { return; }
                comm.Parity = "None";
                comm.StopBits = "One";
                comm.DataBits = "8";
                comm.BaudRate = comboBox2.Text;
                comm.DisplayWindow = richTextBox1;
               // comm.DisplayWindowforGambar = richTextBox2;
                //comm.DisplayGambar = pictureBox1;
                comm.PortName = comboBox1.Text;
                comm.OpenPort();

                
                //button1.Text = "Disconnect";

                //timer2.Start();
                button1.Enabled = false;
                button2.Enabled = true;
               // textBox4.Text = comboBox1.Text + " conneected";
            }
            /*catch
            {
                MessageBox.Show("Failed to Connect "+ comboBox1.Text);
            }*/
        }

        public void DiscardOutBuffer()
        {

        }

        public void DiscardInBuffer()
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //timerr.Start();
            comm.WriteData("1");
            timer1.Interval = 100;
            timer1.Enabled = true;
            timer1.Start();
            DiscardInBuffer();
            comm.gambar = 0;
            timer1.Tick += new EventHandler(FastTimer);
          
        }


       /* private async void ClearBuffer()
        {
            try
            {
                DataReader reader = soc.GetReaderStream();
                reader.InputStreamOptions = InputStreamOptions.Partial;
                uint count = reader.UnconsumedBufferLength;

                //if (count > 0)
                {
                    // TODO Buffer overflow exception
                    await reader.LoadAsync(count);
                    reader.ReadBuffer(count);
                }
            }
        } 
        */

        private void comboBox1_DropDown(object sender, EventArgs e)
        {

            string[] port = SerialPort.GetPortNames();


            comboBox1.Items.Clear();

            foreach (String sambung in port)
            {
                comboBox1.Items.Add(sambung);
            }
        }

        int yaws, air, head;
        string lala, header, a, b,c,d,e,f,g,h,i, j, k,l,m, line;

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        double roll, pitch, yaw, suhu, alti, tekan, bearing = 000.0;
        float x, y, z, r, p ;
        string[] data,klo;// = new string[15];

        private void FastTimer(Object myObject, EventArgs myEventArgs)
        {
            string[] tempArray = comm.DisplayWindow.Lines;
          string line = tempArray[tempArray.Length - 2];
            if (line == "") return;
            
            /*
            try
            {
                line = line.Trim();
            }
            catch (IOException ex)
            {
                //process any errors
            }
            */

           // data = Regex.Split(line, "a");
            data = Regex.Split(line, " ");
         //   data = Regex.Split(line, "a");
            header = data[0];
            if (comm.gambar == 0)
            {

                if (header == "005" && data.Length == 13 )
                {
                    a = data[1];
                    b = data[2];
                    c = data[3];
                    d = data[4];
                    e = data[5];
                    f = data[6];
                    g = data[7];
                    
                    label1.Text = Convert.ToString(line.Length);
                    //sesuaikan data parsing ke payload
                    //jangan lupa sesuaikan dengan paramater yang sudah di set di atas dan dibawah
                    air = int.Parse(data[5]);
                    pitch = double.Parse(data[7]);
                    roll = double.Parse(data[6]);
                    head = int.Parse(data[0]);
                }
                
            }


        }

        public void updateData()
        {
            //deklarasi instrumen dan sesuaikan bebs

            //airSpeedIndicatorInstrumentControl1.SetAirSpeedIndicatorParameters();
            altimeterInstrumentControl1.SetAlimeterParameters(air);
            attitudeIndicatorInstrumentControl1.SetAttitudeIndicatorParameters(pitch,roll);
            headingIndicatorInstrumentControl1.SetHeadingIndicatorParameters(head);
            //instrumentControl1
            //turnCoordinatorInstrumentControl1.SetTurnCoordinatorParameters();
            //verticalSpeedIndicatorInstrumentControl1.SetVerticalSpeedIndicatorParameters()

            GMapOverlay markersOverlay = new GMapOverlay("markers");
            GMarkerGoogle marker = new GMarkerGoogle(new PointLatLng(Convert.ToDouble(l), Convert.ToDouble(m)), GMarkerGoogleType.green);
            markersOverlay.Markers.Clear();
            MainMap.Overlays.Add(markersOverlay);
            markersOverlay.Markers.Add(marker);
            MainMap.Invalidate(false);


            richTextBox1.Invoke(new EventHandler(delegate
            {
                textBox1.Text = a;
                textBox2.Text = b;
                textBox3.Text = c;
                textBox4.Text = d;
                textBox5.Text = e;
                textBox6.Text = f;
                textBox7.Text = g;
                textBox8.Text = h;
                textBox9.Text = i;

            }));
            //richTextBox1.AppendText(line);
            richTextBox1.ScrollToCaret();
            xTimeStamp = xTimeStamp + 1;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            updateData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MainMap.MapProvider = BingSatelliteMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = AccessMode.ServerOnly;
            MainMap.Position = new PointLatLng(-6.9768651, 107.63018883);

            Double lat = -6.9768651;
            Double lng = 107.63018883;

            //GmarkerGoogle
            GMapOverlay markersOverlay = new GMapOverlay("markers");
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {

        }


    }
}
