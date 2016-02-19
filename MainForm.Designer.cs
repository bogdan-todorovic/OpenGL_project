namespace RacunarskaGrafika.Vezbe.AssimpNetSample
{
    partial class MainForm
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
            this.m_world.Dispose();
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
            this.openglControl = new Tao.Platform.Windows.SimpleOpenGlControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.RotationZ = new System.Windows.Forms.NumericUpDown();
            this.RotationY = new System.Windows.Forms.NumericUpDown();
            this.RotationX = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.HeightZ = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.ScaleXYZ = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RotationZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotationY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotationX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScaleXYZ)).BeginInit();
            this.SuspendLayout();
            // 
            // openglControl
            // 
            this.openglControl.AccumBits = ((byte)(0));
            this.openglControl.AutoCheckErrors = false;
            this.openglControl.AutoFinish = false;
            this.openglControl.AutoMakeCurrent = true;
            this.openglControl.AutoSwapBuffers = true;
            this.openglControl.BackColor = System.Drawing.Color.Black;
            this.openglControl.ColorBits = ((byte)(32));
            this.openglControl.DepthBits = ((byte)(16));
            this.openglControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openglControl.Location = new System.Drawing.Point(0, 0);
            this.openglControl.Name = "openglControl";
            this.openglControl.Size = new System.Drawing.Size(584, 562);
            this.openglControl.StencilBits = ((byte)(0));
            this.openglControl.TabIndex = 1;
            this.openglControl.Paint += new System.Windows.Forms.PaintEventHandler(this.OpenGlControlPaint);
            this.openglControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OpenGlControlKeyDown);
            this.openglControl.Resize += new System.EventHandler(this.OpenGlControlResize);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.RotationZ);
            this.panel1.Controls.Add(this.RotationY);
            this.panel1.Controls.Add(this.RotationX);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.HeightZ);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.ScaleXYZ);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(584, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 562);
            this.panel1.TabIndex = 2;
            this.panel1.Text = "Options";
            // 
            // RotationZ
            // 
            this.RotationZ.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.RotationZ.Location = new System.Drawing.Point(112, 119);
            this.RotationZ.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.RotationZ.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.RotationZ.Name = "RotationZ";
            this.RotationZ.Size = new System.Drawing.Size(46, 20);
            this.RotationZ.TabIndex = 9;
            this.RotationZ.ValueChanged += new System.EventHandler(this.RotationZ_ValueChanged);
            // 
            // RotationY
            // 
            this.RotationY.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.RotationY.Location = new System.Drawing.Point(112, 90);
            this.RotationY.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.RotationY.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.RotationY.Name = "RotationY";
            this.RotationY.Size = new System.Drawing.Size(47, 20);
            this.RotationY.TabIndex = 8;
            this.RotationY.ValueChanged += new System.EventHandler(this.RotationY_ValueChanged);
            // 
            // RotationX
            // 
            this.RotationX.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.RotationX.Location = new System.Drawing.Point(113, 63);
            this.RotationX.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.RotationX.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.RotationX.Name = "RotationX";
            this.RotationX.Size = new System.Drawing.Size(46, 20);
            this.RotationX.TabIndex = 7;
            this.RotationX.ValueChanged += new System.EventHandler(this.RotationX_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Rotacija oko Z ose:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Rotacija oko Y ose:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Rotacija oko X ose:";
            // 
            // HeightZ
            // 
            this.HeightZ.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.HeightZ.Location = new System.Drawing.Point(86, 34);
            this.HeightZ.Maximum = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.HeightZ.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.HeightZ.Name = "HeightZ";
            this.HeightZ.Size = new System.Drawing.Size(46, 20);
            this.HeightZ.TabIndex = 3;
            this.HeightZ.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.HeightZ.ValueChanged += new System.EventHandler(this.Height_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Visina aviona:";
            // 
            // ScaleXYZ
            // 
            this.ScaleXYZ.Location = new System.Drawing.Point(103, 3);
            this.ScaleXYZ.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.ScaleXYZ.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ScaleXYZ.Name = "ScaleXYZ";
            this.ScaleXYZ.Size = new System.Drawing.Size(41, 20);
            this.ScaleXYZ.TabIndex = 1;
            this.ScaleXYZ.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.ScaleXYZ.ValueChanged += new System.EventHandler(this.Scale_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Skaliranje aviona:";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.openglControl);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sletanje aviona";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RotationZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotationY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RotationX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScaleXYZ)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Tao.Platform.Windows.SimpleOpenGlControl openglControl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown ScaleXYZ;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown HeightZ;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown RotationZ;
        private System.Windows.Forms.NumericUpDown RotationY;
        private System.Windows.Forms.NumericUpDown RotationX;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
    }
}

