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
using System.Text.RegularExpressions;

namespace tes
{
    public partial class Form1 : Form
    {

        string kata;
        string[] words;

        //int xTimeStamp = 1;
        string header, ax, ay, az, gx, gy, gz, suhu, lembab, altid, latid, longit; //inisiasi string dari dummies

        private void serialPort1_DataReceived_1(object sender, SerialDataReceivedEventArgs e)
        {
            kata = serialPort1.ReadLine();
            words = Regex.Split(kata, " ");
            //take the information from dummies to richTextBox
            if (words[0] == "005" && words.Length == 13)
                richTextBox1.BeginInvoke(new myDelegate(updateTextBox));

        }

        public delegate void myDelegate();

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            kata = serialPort1.ReadLine();
            words = Regex.Split(kata, " ");

            if (words[0] == "005" && words.Length == 13)
                richTextBox1.BeginInvoke(new myDelegate(updateTextBox));
        }

        public void updateTextBox()
        {
            //taking each string and put them to arrays
            richTextBox1.Text = kata;
            header = words[0];
            ax = words[1];
            ay = words[2];
            az = words[3];
            gx = words[4];
            gy = words[5];
            gz = words[6];
            suhu = words[7];
            lembab = words[8];
            altid = words[9];
            latid = words[10];
            longit = words[11];
            richTextBox1.Text = words[0];
            richTextBox1.AppendText(kata);
            //richTextBox2.Text = words[1];
            //fetch data from arrayas before
            textBox6.Text = ax;
            textBox2.Text = ay;
            textBox3.Text = az;
            textBox7.Text = gx;
            textBox5.Text = gy;
            textBox4.Text = gz;
            textBox10.Text = suhu;
            textBox9.Text = lembab;
            textBox8.Text = altid;
            textBox13.Text = latid;
            textBox12.Text = longit;
            textBox11.Text = ("mantap");
            
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            //fetching port name from seriapPort1
            string[] port = SerialPort.GetPortNames();
            comboBox1.Items.Clear();
            foreach (String sambung in port)
            {
                comboBox1.Items.Add(sambung);
            }
        }

        private void btnConn_Click(object sender, EventArgs e)
        {
            //6 holy lines to conn
            serialPort1.PortName = comboBox1.Text;
            serialPort1.BaudRate = int.Parse(comboBox2.Text);
            serialPort1.StopBits = StopBits.One;
            serialPort1.Parity = Parity.None;
            serialPort1.DataBits = 8;
            serialPort1.Open();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            serialPort1.Write("1");
        }

        private void btnDiscc_Click(object sender, EventArgs e)
        {
            serialPort1.Dispose();
            serialPort1.Close();

            btnConn.Enabled = true;
            btnDiscc.Enabled = true;
        }
    }
}
