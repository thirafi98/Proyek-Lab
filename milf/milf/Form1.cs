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

using System.IO;


using SharpGL;
using SharpGL.SceneGraph;
using SharpGL.SceneGraph.Cameras;
using SharpGL.SceneGraph.Collections;
using SharpGL.SceneGraph.Primitives;
using SharpGL.Serialization;
using SharpGL.SceneGraph.Core;
using SharpGL.Enumerations;
using SharpGL.SceneGraph.Assets;
using System.Runtime.InteropServices;
using System.Configuration;
using System.Drawing.Drawing2D;
using System.Net.NetworkInformation;



namespace milf
{
    public partial class Form1 : Form
    {
        private SerialPort comPort = new SerialPort();
        CommunicationManager comm = new CommunicationManager();
        CommunicationManager commAT = new CommunicationManager();
        static double xTimeStamp = 0;
        List<Polygon> polygons = new List<Polygon>();
        Texture texture = new Texture();

        string header, Accx, Accy, Accz, Gyrox, Gyroy, Gyroz;//basic header, acc and gyro
        double roll, pitch, yaw, h = 000.0;
        static LineItem Kax, Kay, Kaz;//dun no
        int airAll, head;
        static RollingPointPairList Lax, Lay, Laz;//probably for latitude
        float rotate, lol = 0;


        string[] data;

        public delegate void myDelegate();

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void importPolygonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //  Show a file open dialog.
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = SerializationEngine.Instance.Filter;
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                Scene scene = SerializationEngine.Instance.LoadScene(openDialog.FileName);
                if (scene != null)
                {
                    foreach (var polygon in scene.SceneContainer.Traverse<Polygon>())
                    {
                        //  Get the bounds of the polygon.
                        BoundingVolume boundingVolume = polygon.BoundingVolume;
                        float[] extent = new float[3];
                        polygon.BoundingVolume.GetBoundDimensions(out extent[0], out extent[1], out extent[2]);

                        //  Get the max extent.
                        float maxExtent = extent.Max();

                        //  Scale so that we are at most 10 units in size.
                        float scaleFactor = maxExtent > 10 ? 10.0f / maxExtent : 1;
                        polygon.Transformation.ScaleX = scaleFactor;
                        polygon.Transformation.ScaleY = scaleFactor;
                        polygon.Transformation.ScaleZ = scaleFactor;
                        polygon.Freeze(openGLControl1.OpenGL);
                        polygons.Add(polygon);
                    }
                }
            }
        }

        private void importTextureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //OpenFileDialog openFileDialog1 = new OpenFileDialog();

            //  Show a file open dialog.
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //  Destroy the existing texture.
                texture.Destroy(openGLControl1.OpenGL);

                //  Create a new texture.
                texture.Create(openGLControl1.OpenGL, openFileDialog1.FileName);

                //  Redraw.
                openGLControl1.Invalidate();
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SharpGL.OpenGL gl = this.openGLControl1.OpenGL;
            polygons.Clear();
            texture.Destroy(gl);
        }

        private void freezeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var poly in polygons)
                poly.Freeze(openGLControl1.OpenGL);
        }

        private void unFreezeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var poly in polygons)
                poly.Unfreeze(openGLControl1.OpenGL);
        }

        private void wireframeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wireframeToolStripMenuItem.Checked = true;
            solidToolStripMenuItem.Checked = false;
            lighterToolStripMenuItem.Checked = false;
            openGLControl1.OpenGL.PolygonMode(FaceMode.FrontAndBack, PolygonMode.Lines);
            openGLControl1.OpenGL.Disable(OpenGL.GL_LIGHTING);
        }

        private void solidToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wireframeToolStripMenuItem.Checked = false;
            solidToolStripMenuItem.Checked = true;
            lighterToolStripMenuItem.Checked = false;
            openGLControl1.OpenGL.PolygonMode(FaceMode.FrontAndBack, PolygonMode.Filled);
            openGLControl1.OpenGL.Disable(OpenGL.GL_LIGHTING);
        }

        private void lighterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wireframeToolStripMenuItem.Checked = false;
            solidToolStripMenuItem.Checked = false;
            lighterToolStripMenuItem.Checked = true;
            openGLControl1.OpenGL.PolygonMode(FaceMode.FrontAndBack, PolygonMode.Filled);
            openGLControl1.OpenGL.Enable(OpenGL.GL_LIGHTING);
            openGLControl1.OpenGL.Enable(OpenGL.GL_LIGHT0);
            openGLControl1.OpenGL.Enable(OpenGL.GL_COLOR_MATERIAL);
        }

        private void openGLControl1_OpenGLDraw_1(object sender, PaintEventArgs e)
        {
            //  The texture identifier.
            /*Texture texture = new Texture(); */

            //  Get the OpenGL object, for quick access.
            SharpGL.OpenGL gl = this.openGLControl1.OpenGL;

            //  Clear and load the identity.
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.LoadIdentity();

            //  Bind the texture.
            texture.Bind(gl);

            //  View from a bit away the y axis and a few units above the ground.
            gl.LookAt(-10, -15, 0, 0, 0, 0, 0, 1, 0);


            //  Rotate the objects every cycle.
            // gl.Rotate(rotate, 0.0f, 0.0f, 1.0f);
            //gl.Rotate(float.Parse(data_r), float.Parse(data_p), float.Parse(data_h));

            //  Move the objects down a bit so that they fit in the screen better.
            gl.Translate(0, 0, 0);

            //  Draw every polygon in the collection.
            foreach (Polygon polygon in polygons)
            {
                polygon.PushObjectSpace(gl);
                polygon.Render(gl, SharpGL.SceneGraph.Core.RenderMode.Render);
                polygon.PopObjectSpace(gl);
            }
            //  Rotate a bit more each cycle.
            rotate += 1.0f;
        }

        

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }




        private void UpdateData()
        {
            richTextBox1.Invoke(new EventHandler(delegate
            {
                //airSpeedIndicatorInstrumentControl1.SetAirSpeedIndicatorParameters();
                altimeterInstrumentControl1.SetAlimeterParameters((int)(h));
                attitudeIndicatorInstrumentControl1.SetAttitudeIndicatorParameters(pitch, roll);
                headingIndicatorInstrumentControl1.SetHeadingIndicatorParameters(head);
                //instrumentControl1
                //turnCoordinatorInstrumentControl1.SetTurnCoordinatorParameters();
                //verticalSpeedIndicatorInstrumentControl1.SetVerticalSpeedIndicatorParameters()


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
            foreach (Polygon polygon in polygons)
            {

                polygon.Transformation.RotateX = head;
                polygon.Transformation.RotateY = airAll;
                polygon.Transformation.RotateZ = lol;

            }
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

                    head = int.Parse(data[0]);
                    pitch = double.Parse(data[11]);
                    airAll = int.Parse(data[10]);
                    roll = double.Parse(data[12]);
                    h = int.Parse(data[1]);
                    yaw = double.Parse(data[4]);
                    lol = float.Parse(data[2]);

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
            SharpGL.OpenGL gl = this.openGLControl1.OpenGL;
            gl.Enable(OpenGL.GL_TEXTURE_2D);

        }


    }
}
