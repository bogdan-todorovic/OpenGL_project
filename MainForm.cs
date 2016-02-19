using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Assimp;
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace RacunarskaGrafika.Vezbe.AssimpNetSample
{
    public partial class MainForm : Form
    {
        #region Atributi

        /// <summary>
        ///	 Instanca OpenGL "sveta" - klase koja je zaduzena za iscrtavanje koriscenjem OpenGL-a.
        /// </summary>
        World m_world = null;

        /// <summary>
        /// Instanca stoperice
        /// </summary>
        private Stopwatch stopWatch = new Stopwatch();

        /// <summary>
        /// Indikator kontorle tastera 
        /// </summary>
        private bool enabledKeys = true;

        #endregion Atributi

        #region Konstruktori

        public MainForm()
        {
            // Inicijalizacija komponenti
            InitializeComponent();

            // Inicijalizacija OpenGL konteksta
            openglControl.InitializeContexts();

            // Kreiranje OpenGL sveta
            try
            {
                m_world = new World(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "3D Models\\Canadair"), "Canadair.obj", openglControl.Width, openglControl.Height);
            }
            catch (Exception e)
            {
                MessageBox.Show("Neuspesno kreirana instanca OpenGL sveta. Poruka greške: " + e.Message, "GRESKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

        }

        #endregion Konstruktori

        #region Rukovaoci dogadjajima OpenGL kontrole

        /// <summary>
        /// Rukovalac dogadja izmene dimenzija OpenGL kontrole
        /// </summary>
        private void OpenGlControlResize(object sender, EventArgs e)
        {
            m_world.Height = openglControl.Height;
            m_world.Width = openglControl.Width;

            m_world.Resize();
        }

        /// <summary>
        /// Rukovalac dogadjaja iscrtavanja OpenGL kontrole
        /// </summary>
        private void OpenGlControlPaint(object sender, PaintEventArgs e)
        {
            // Iscrtaj svet
            m_world.Draw();
        }

        /// <summary>
        /// Rukovalac dogadjaja: obrada tastera nad formom
        /// </summary>
        private void OpenGlControlKeyDown(object sender, KeyEventArgs e)
        {
            if (enabledKeys)
            {
                switch (e.KeyCode)
                {
                    case Keys.F4: this.Close(); break;
                    case Keys.W: m_world.RotationX += 5.0f; break;
                    case Keys.S: m_world.RotationX -= 5.0f; break;
                    case Keys.A: m_world.RotationY += 5.0f; break;
                    case Keys.D: m_world.RotationY -= 5.0f; break;
                    case Keys.Add: m_world.SceneDistance -= 100.0f; break;
                    case Keys.Subtract: m_world.SceneDistance += 100.0f; break;
                    case Keys.C: PrepareAndStartAnimation(); break;
                }
            }
            if (m_world.RotationX < -10.0f) m_world.RotationX = -10.0f;
            else if (m_world.RotationX > 90.0f) m_world.RotationX = 90.0f;

            openglControl.Refresh();
        }

       
        #endregion Rukovaoci dogadjajima OpenGL kontrole

        //Skaliranje aviona
        private void Scale_ValueChanged(object sender, EventArgs e)
        {
            m_world.ScaleXYZ = (float)this.ScaleXYZ.Value * 0.01f;
            openglControl.Refresh();
        }

        //Visina aviona
        private void Height_ValueChanged(object sender, EventArgs e)
        {
            m_world.PositionZ = (float)this.HeightZ.Value;
            openglControl.Refresh();
        }

        //Rotacija oko X ose
        private void RotationX_ValueChanged(object sender, EventArgs e)
        {
            m_world.RotateX = (float)this.RotationX.Value;
            openglControl.Refresh();
        }

        //Rotacija oko Y ose
        private void RotationY_ValueChanged(object sender, EventArgs e)
        {
            m_world.RotateY = (float)this.RotationY.Value;
            openglControl.Refresh();
        }

        //Rotacija oko Z ose
        private void RotationZ_ValueChanged(object sender, EventArgs e)
        {
            m_world.RotateZ = (float)this.RotationZ.Value;
            openglControl.Refresh();
        }
        
        // Tajmer za animaciju sijalica
        private void timer1_Tick(object sender, EventArgs e)
        {
            m_world.UpdateBulbAnimation();
            openglControl.Refresh();
        }

        // Priprema i pokretanje animacije
        private void PrepareAndStartAnimation()
        {
            enabledKeys = false;
            ScaleXYZ.Enabled = false;
            HeightZ.Enabled = false;
            RotationZ.Enabled = false;
            RotationY.Enabled = false;
            RotationX.Enabled = false;
            m_world.RotateX = 0.0f;
            m_world.RotateY = 0.0f;
            m_world.RotateZ = 0.0f;
            m_world.PositionZ = 400.0f;
            m_world.ScaleXYZ = 0.015f;
            stopWatch.Start();
            timer2.Enabled = true;
        }

        // Tajmer za animaciju aviona
        private void timer2_Tick(object sender, EventArgs e)
        {
            if ((stopWatch.ElapsedMilliseconds / 1000) <= 7)
            {
                m_world.UpdateAirplaneAnimation();
            }
            else
            {
                m_world.PositionY = 800.0f;
                m_world.PositionZ = 400.0f;
                enabledKeys = true;
                ScaleXYZ.Enabled = true;
                HeightZ.Enabled = true;
                RotationZ.Enabled = true;
                RotationY.Enabled = true;
                RotationX.Enabled = true;
                stopWatch.Stop();
                stopWatch.Reset();
                timer2.Enabled = false;
            }
            openglControl.Refresh();
            
        }


        
      
    }
}
