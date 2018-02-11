namespace milf
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.btnDiscc = new System.Windows.Forms.Button();
            this.btnSend1 = new System.Windows.Forms.Button();
            this.btnConn = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSend2 = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.label1 = new System.Windows.Forms.Label();
            this.airSpeedIndicatorInstrumentControl1 = new milf.AirSpeedIndicatorInstrumentControl();
            this.altimeterInstrumentControl1 = new milf.AltimeterInstrumentControl();
            this.attitudeIndicatorInstrumentControl1 = new milf.AttitudeIndicatorInstrumentControl();
            this.instrumentControl1 = new milf.InstrumentControl();
            this.headingIndicatorInstrumentControl1 = new milf.HeadingIndicatorInstrumentControl();
            this.turnCoordinatorInstrumentControl1 = new milf.TurnCoordinatorInstrumentControl();
            this.verticalSpeedIndicatorInstrumentControl1 = new milf.VerticalSpeedIndicatorInstrumentControl();
            this.btnClose = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importPolygonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importTextureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.freezeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unFreezeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wireframeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.solidToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lighterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.openGLControl1 = new SharpGL.OpenGLControl();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(4, 314);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(391, 88);
            this.richTextBox1.TabIndex = 35;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(23, 164);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(74, 20);
            this.textBox3.TabIndex = 34;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(23, 138);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(74, 20);
            this.textBox2.TabIndex = 33;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(23, 112);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(74, 20);
            this.textBox6.TabIndex = 32;
            // 
            // btnDiscc
            // 
            this.btnDiscc.Location = new System.Drawing.Point(105, 70);
            this.btnDiscc.Name = "btnDiscc";
            this.btnDiscc.Size = new System.Drawing.Size(75, 23);
            this.btnDiscc.TabIndex = 31;
            this.btnDiscc.Text = "Disconnect";
            this.btnDiscc.UseVisualStyleBackColor = true;
            this.btnDiscc.Click += new System.EventHandler(this.btnDiscc_Click);
            // 
            // btnSend1
            // 
            this.btnSend1.Location = new System.Drawing.Point(199, 43);
            this.btnSend1.Name = "btnSend1";
            this.btnSend1.Size = new System.Drawing.Size(75, 23);
            this.btnSend1.TabIndex = 30;
            this.btnSend1.Text = "Send 1";
            this.btnSend1.UseVisualStyleBackColor = true;
            this.btnSend1.Click += new System.EventHandler(this.btnSend1_Click);
            // 
            // btnConn
            // 
            this.btnConn.Location = new System.Drawing.Point(13, 70);
            this.btnConn.Name = "btnConn";
            this.btnConn.Size = new System.Drawing.Size(75, 23);
            this.btnConn.TabIndex = 29;
            this.btnConn.Text = "Connect";
            this.btnConn.UseVisualStyleBackColor = true;
            this.btnConn.Click += new System.EventHandler(this.btnConn_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "300",
            "500",
            "9600",
            "57600",
            "115200"});
            this.comboBox2.Location = new System.Drawing.Point(105, 43);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(75, 21);
            this.comboBox2.TabIndex = 28;
            this.comboBox2.DropDown += new System.EventHandler(this.comboBox2_DropDown);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(13, 43);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(75, 21);
            this.comboBox1.TabIndex = 27;
            this.comboBox1.DropDown += new System.EventHandler(this.comboBox1_DropDown);
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(23, 242);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(74, 20);
            this.textBox1.TabIndex = 38;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(23, 216);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(74, 20);
            this.textBox4.TabIndex = 37;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(23, 190);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(74, 20);
            this.textBox5.TabIndex = 36;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(23, 268);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(74, 20);
            this.textBox7.TabIndex = 39;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(112, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 41;
            this.label3.Text = "Baud Rate";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(20, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "Serial Port";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSend2
            // 
            this.btnSend2.Location = new System.Drawing.Point(289, 43);
            this.btnSend2.Name = "btnSend2";
            this.btnSend2.Size = new System.Drawing.Size(75, 23);
            this.btnSend2.TabIndex = 42;
            this.btnSend2.Text = "Send 2";
            this.btnSend2.UseVisualStyleBackColor = true;
            this.btnSend2.Click += new System.EventHandler(this.btnSend2_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(115, 99);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(280, 209);
            this.zedGraphControl1.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(300, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // airSpeedIndicatorInstrumentControl1
            // 
            this.airSpeedIndicatorInstrumentControl1.Location = new System.Drawing.Point(441, 46);
            this.airSpeedIndicatorInstrumentControl1.Name = "airSpeedIndicatorInstrumentControl1";
            this.airSpeedIndicatorInstrumentControl1.Size = new System.Drawing.Size(75, 76);
            this.airSpeedIndicatorInstrumentControl1.TabIndex = 45;
            this.airSpeedIndicatorInstrumentControl1.Text = "airSpeedIndicatorInstrumentControl1";
            // 
            // altimeterInstrumentControl1
            // 
            this.altimeterInstrumentControl1.Location = new System.Drawing.Point(559, 46);
            this.altimeterInstrumentControl1.Name = "altimeterInstrumentControl1";
            this.altimeterInstrumentControl1.Size = new System.Drawing.Size(75, 76);
            this.altimeterInstrumentControl1.TabIndex = 46;
            this.altimeterInstrumentControl1.Text = "altimeterInstrumentControl1";
            // 
            // attitudeIndicatorInstrumentControl1
            // 
            this.attitudeIndicatorInstrumentControl1.Location = new System.Drawing.Point(441, 129);
            this.attitudeIndicatorInstrumentControl1.Name = "attitudeIndicatorInstrumentControl1";
            this.attitudeIndicatorInstrumentControl1.Size = new System.Drawing.Size(75, 76);
            this.attitudeIndicatorInstrumentControl1.TabIndex = 47;
            this.attitudeIndicatorInstrumentControl1.Text = "attitudeIndicatorInstrumentControl1";
            // 
            // instrumentControl1
            // 
            this.instrumentControl1.Location = new System.Drawing.Point(559, 164);
            this.instrumentControl1.Name = "instrumentControl1";
            this.instrumentControl1.Size = new System.Drawing.Size(75, 76);
            this.instrumentControl1.TabIndex = 48;
            this.instrumentControl1.Text = "instrumentControl1";
            // 
            // headingIndicatorInstrumentControl1
            // 
            this.headingIndicatorInstrumentControl1.Location = new System.Drawing.Point(441, 215);
            this.headingIndicatorInstrumentControl1.Name = "headingIndicatorInstrumentControl1";
            this.headingIndicatorInstrumentControl1.Size = new System.Drawing.Size(75, 76);
            this.headingIndicatorInstrumentControl1.TabIndex = 49;
            this.headingIndicatorInstrumentControl1.Text = "headingIndicatorInstrumentControl1";
            // 
            // turnCoordinatorInstrumentControl1
            // 
            this.turnCoordinatorInstrumentControl1.Location = new System.Drawing.Point(559, 298);
            this.turnCoordinatorInstrumentControl1.Name = "turnCoordinatorInstrumentControl1";
            this.turnCoordinatorInstrumentControl1.Size = new System.Drawing.Size(75, 76);
            this.turnCoordinatorInstrumentControl1.TabIndex = 50;
            this.turnCoordinatorInstrumentControl1.Text = "turnCoordinatorInstrumentControl1";
            // 
            // verticalSpeedIndicatorInstrumentControl1
            // 
            this.verticalSpeedIndicatorInstrumentControl1.Location = new System.Drawing.Point(441, 298);
            this.verticalSpeedIndicatorInstrumentControl1.Name = "verticalSpeedIndicatorInstrumentControl1";
            this.verticalSpeedIndicatorInstrumentControl1.Size = new System.Drawing.Size(75, 76);
            this.verticalSpeedIndicatorInstrumentControl1.TabIndex = 51;
            this.verticalSpeedIndicatorInstrumentControl1.Text = "verticalSpeedIndicatorInstrumentControl1";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(199, 70);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 52;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.renderToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(948, 24);
            this.menuStrip1.TabIndex = 53;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importPolygonToolStripMenuItem,
            this.importTextureToolStripMenuItem,
            this.clearToolStripMenuItem,
            this.freezeToolStripMenuItem,
            this.unFreezeToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // importPolygonToolStripMenuItem
            // 
            this.importPolygonToolStripMenuItem.Name = "importPolygonToolStripMenuItem";
            this.importPolygonToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.importPolygonToolStripMenuItem.Text = "Import Polygon";
            this.importPolygonToolStripMenuItem.Click += new System.EventHandler(this.importPolygonToolStripMenuItem_Click);
            // 
            // importTextureToolStripMenuItem
            // 
            this.importTextureToolStripMenuItem.Name = "importTextureToolStripMenuItem";
            this.importTextureToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.importTextureToolStripMenuItem.Text = "Import Texture";
            this.importTextureToolStripMenuItem.Click += new System.EventHandler(this.importTextureToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // freezeToolStripMenuItem
            // 
            this.freezeToolStripMenuItem.Name = "freezeToolStripMenuItem";
            this.freezeToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.freezeToolStripMenuItem.Text = "Freeze";
            this.freezeToolStripMenuItem.Click += new System.EventHandler(this.freezeToolStripMenuItem_Click);
            // 
            // unFreezeToolStripMenuItem
            // 
            this.unFreezeToolStripMenuItem.Name = "unFreezeToolStripMenuItem";
            this.unFreezeToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.unFreezeToolStripMenuItem.Text = "Un-Freeze";
            this.unFreezeToolStripMenuItem.Click += new System.EventHandler(this.unFreezeToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // renderToolStripMenuItem
            // 
            this.renderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wireframeToolStripMenuItem,
            this.solidToolStripMenuItem,
            this.lighterToolStripMenuItem});
            this.renderToolStripMenuItem.Name = "renderToolStripMenuItem";
            this.renderToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.renderToolStripMenuItem.Text = "Render";
            // 
            // wireframeToolStripMenuItem
            // 
            this.wireframeToolStripMenuItem.Name = "wireframeToolStripMenuItem";
            this.wireframeToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.wireframeToolStripMenuItem.Text = "Wireframe";
            this.wireframeToolStripMenuItem.Click += new System.EventHandler(this.wireframeToolStripMenuItem_Click);
            // 
            // solidToolStripMenuItem
            // 
            this.solidToolStripMenuItem.Name = "solidToolStripMenuItem";
            this.solidToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.solidToolStripMenuItem.Text = "Solid";
            this.solidToolStripMenuItem.Click += new System.EventHandler(this.solidToolStripMenuItem_Click);
            // 
            // lighterToolStripMenuItem
            // 
            this.lighterToolStripMenuItem.Name = "lighterToolStripMenuItem";
            this.lighterToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.lighterToolStripMenuItem.Text = "Lighter";
            this.lighterToolStripMenuItem.Click += new System.EventHandler(this.lighterToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.openGLControl1);
            this.panel1.Location = new System.Drawing.Point(653, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(283, 373);
            this.panel1.TabIndex = 54;
            // 
            // openGLControl1
            // 
            this.openGLControl1.BackColor = System.Drawing.SystemColors.Control;
            this.openGLControl1.BitDepth = 24;
            this.openGLControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openGLControl1.DrawFPS = true;
            this.openGLControl1.FrameRate = 28;
            this.openGLControl1.Location = new System.Drawing.Point(0, 0);
            this.openGLControl1.Name = "openGLControl1";
            this.openGLControl1.RenderContextType = SharpGL.RenderContextType.NativeWindow;
            this.openGLControl1.Size = new System.Drawing.Size(283, 373);
            this.openGLControl1.TabIndex = 3;
            this.openGLControl1.OpenGLDraw += new System.Windows.Forms.PaintEventHandler(this.openGLControl1_OpenGLDraw_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 421);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.verticalSpeedIndicatorInstrumentControl1);
            this.Controls.Add(this.turnCoordinatorInstrumentControl1);
            this.Controls.Add(this.headingIndicatorInstrumentControl1);
            this.Controls.Add(this.instrumentControl1);
            this.Controls.Add(this.attitudeIndicatorInstrumentControl1);
            this.Controls.Add(this.altimeterInstrumentControl1);
            this.Controls.Add(this.airSpeedIndicatorInstrumentControl1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.btnSend2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.btnDiscc);
            this.Controls.Add(this.btnSend1);
            this.Controls.Add(this.btnConn);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Button btnDiscc;
        private System.Windows.Forms.Button btnSend1;
        private System.Windows.Forms.Button btnConn;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSend2;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Timer timer1;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.Label label1;
        private AirSpeedIndicatorInstrumentControl airSpeedIndicatorInstrumentControl1;
        private AltimeterInstrumentControl altimeterInstrumentControl1;
        private AttitudeIndicatorInstrumentControl attitudeIndicatorInstrumentControl1;
        private InstrumentControl instrumentControl1;
        private HeadingIndicatorInstrumentControl headingIndicatorInstrumentControl1;
        private TurnCoordinatorInstrumentControl turnCoordinatorInstrumentControl1;
        private VerticalSpeedIndicatorInstrumentControl verticalSpeedIndicatorInstrumentControl1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importPolygonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importTextureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem freezeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unFreezeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wireframeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem solidToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lighterToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private SharpGL.OpenGLControl openGLControl1;
    }
}

