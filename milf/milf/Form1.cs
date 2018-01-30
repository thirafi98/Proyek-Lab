using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using ZedGraph;
using System.IO.Ports;
using PCComm;
using System.Text.RegularExpressions;


namespace milf
{
    public partial class Form1 : Form
    {
        private SerialPort comPort = new SerialPort();
        CommunicationManager comm = new CommunicationManager();
        CommunicationManager commAT = new CommunicationManager();
        static double xTimeStamp = 0;

        string header, Accx, Accy, Accz, Gyrox, Gyroy, Gyroz;//basic header, acc and gyro
        double roll, pitch, yaw = 000.0;
        static LineItem Kax, Kay, Kaz;//dun no
        static RollingPointPairList Lax, Lay, Laz;//probably for latitude


        string[] data;

        public delegate void myDelegate();

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void UpdateData()
        {
            richTextBox1.Invoke(new EventHandler(delegate
            {
                textBox6.Text = header;
                textBox2.Text = Accx;
                textBox3.Text = Accy;
                textBox5.Text = Accz;
                textBox4.Text = Gyrox;
                textBox1.Text = Gyroy;
                textBox7.Text = Gyroz;

            }));
            richTextBox1.ScrollToCaret();
            xTimeStamp = xTimeStamp + 1;

            //artifical_horizon1.SetArtificalHorizon(roll, pitch);
            //turnCoordinatorInstrumentControl1.SetTurnCoordinatorParameters(r, r);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GraphPane myPane = zedGraphControl1.GraphPane;
            //for config the zedGraph showed the output it self
            Lax = new RollingPointPairList(300);
            Kax = myPane.AddCurve("acc_roll", Lax, Color.Pink, SymbolType.None);
            Lay = new RollingPointPairList(300);
            Kay = myPane.AddCurve("acc_roll", Lay, Color.Blue, SymbolType.None);
            Laz = new RollingPointPairList(300);
            Kaz = myPane.AddCurve("acc_roll", Laz, Color.Purple, SymbolType.None);
            myPane.XAxis.Scale.Min = 0;
            myPane.XAxis.Scale.Max = 30;
            myPane.XAxis.Scale.MinorStep = 1;
            myPane.XAxis.Scale.MajorStep = 5;
            zedGraphControl1.AxisChange();
        }

        private void FastTimer(object sender, EventArgs myEventArgs)
        {
            string[] tempArray = comm.DisplayWindow.Lines;
            string line = tempArray[tempArray.Length - 2];
            if (line == "") return;

            data = Regex.Split(line, " ");
            header = data[0];
            if (comm.gambar == 0)
            {
                if (header == "005" && data.Length == 13)
                {
                    header = data[0];
                    Accx = data[1];
                    Accy = data[2];
                    Accz = data[3];
                    Gyrox = data[4];
                    Gyroy = data[5];
                    Gyroz = data[6];
                    //how many length they can accept
                    label1.Text = Convert.ToString(line.Length);
                    //u know it from the line bruv
                    Lax.Add(xTimeStamp, Convert.ToDouble(data[1]));
                    Lay.Add(xTimeStamp, Convert.ToDouble(data[2]));
                    Laz.Add(xTimeStamp, Convert.ToDouble(data[3]));

                    xTimeStamp = xTimeStamp + 1;
                    //scaling the zedgraph to axis change
                    Scale xScale = zedGraphControl1.GraphPane.XAxis.Scale;
                    if (xTimeStamp > xScale.Max - xScale.MajorStep)
                    {
                        xScale.Max = xTimeStamp + xScale.MajorStep;
                        xScale.Min = xScale.Max - 30.0;

                    }
                    zedGraphControl1.AxisChange();
                    zedGraphControl1.Invalidate();

                }
            }
        }

        private void btnSend2_Click(object sender, EventArgs e)
        {
            comm.WriteData("2");
            timer1.Interval = 100;
            timer1.Enabled = true;
            timer1.Start();
            //DiscardInBuffer();
            comm.gambar = 0;
            timer1.Tick += new EventHandler(FastTimer);
        }

        private void btnSend1_Click(object sender, EventArgs e)
        {
            comm.WriteData("1");
            timer1.Interval = 100;
            timer1.Enabled = true;
            timer1.Start();
            //DiscardInBuffer();
            comm.gambar = 0;
            timer1.Tick += new EventHandler(FastTimer);
        }

        private void btnDiscc_Click(object sender, EventArgs e)
        {
            timer1.Dispose();
            richTextBox1.Enabled = false;

            btnConn.Enabled = true;
            btnDiscc.Enabled = true;
        }

        private void btnConn_Click(object sender, EventArgs e)
        {
            if (comm.isOpen() == true)
            {
                System.Threading.Thread.Sleep(100);
                comm.ClosePort();
            }
            else
            {
                if (comboBox1.Text == "") { return; }
                comm.Parity = "None";
                comm.StopBits = "One";
                comm.DataBits = "8";
                comm.BaudRate = comboBox2.Text;
                comm.DisplayWindow = richTextBox1;
                comm.PortName = comboBox1.Text;
                comm.OpenPort();
            }
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            string[] port = SerialPort.GetPortNames();
            comboBox1.Items.Clear();
            foreach (String sambung in port)
            {
                comboBox1.Items.Add(sambung);
            }
        }

        private void comboBox2_DropDown(object sender, EventArgs e)
        {

        }

        public Form1()
        {
            InitializeComponent();
            timer1.Tick += new EventHandler(timer1_Tick);
            //timer1.Tick += new EventHandler(timer1_Tick);

        }


    }
}
