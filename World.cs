namespace RacunarskaGrafika.Vezbe.AssimpNetSample
{
    using System;
    using Tao.OpenGl;
    using Assimp;
    using System.IO;
    using System.Reflection;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Windows.Forms;
    using System.Diagnostics;

    /// <summary>
    ///  Klasa enkapsulira OpenGL kod i omogucava njegovo iscrtavanje i azuriranje.
    /// </summary>
    public class World : IDisposable
    {
        #region Atributi

        /// <summary>
        ///	 Scena koja se prikazuje.
        /// </summary>
        private AssimpScene m_model;
        
        /// <summary>
        ///	Instanca kamere
        /// </summary>
        private MyCamera m_camera = null;

        /// <summary>
        /// Uniformno skaliranje
        /// </summary>
        private float scaleXYZ = 0.015f;

        /// <summary>
        /// Pozicija aviona po Y osi
        /// </summary>
        private float posY = 800.0f;

        /// <summary>
        /// Pozicija aviona po Z osi
        /// </summary>
        private float posZ = 400.0f;

        /// <summary>
        /// Ugao rotacije aviona oko X ose
        /// </summary>
        private float rotX = 0.0f;

        /// <summary>
        /// Ugao rotacije aviona oko Y ose
        /// </summary>
        private float rotY = 0.0f;

        /// <summary>
        /// Ugao rotacije aviona oko Z ose
        /// </summary>
        private float rotZ = 0.0f;

        /// <summary>
        ///	Ugao rotacije sveta oko X ose.
        /// </summary>
        private float m_xRotation = 0.0f;

        /// <summary>
        ///	Ugao rotacije sveta oko Y ose.
        /// </summary>
        private float m_yRotation = 0.0f;

        /// <summary>
        ///	Udaljenost scene od kamere.
        /// </summary>
        private float m_sceneDistance = 2000.0f;

        /// <summary>
        ///	Crvena boja sijalica
        /// </summary>
        private float red = 0.0f;

        /// <summary>
        ///	Zelena boja sijalica
        /// </summary>
        private float green = 0.0f;

        /// <summary>
        ///	Plava boja sijalica
        /// </summary>
        private float blue = 1.0f;

        /// <summary>
        ///	Sirina OpenGL kontrole u pikselima.
        /// </summary>
        private int m_width;

        /// <summary>
        ///	Visina OpenGL kontrole u pikselima.
        /// </summary>
        private int m_height;
        
        /// <summary>
        /// Instanca Bitmap font-a 
        /// </summary>
        private BitmapFont m_font;

        /// <summary>
        /// Tekst za ispis
        /// </summary>
        private String[] m_message = { "Predmet: Racunarska grafika",
                                       "Sk.god: 2015/16.", 
                                       "Ime: Bogdan",
                                       "Prezime: Todorovic",
                                       "Sifra zad: 6.1"};

        /// <summary>
        /// Slike tekstura
        /// </summary>
        private string[] textureFiles = null;

        /// <summary>
        /// Teksture
        /// </summary>
        private int[] textures = null;

        /// <summary>
        /// Brojac sekundi
        /// </summary>
        private int couter = 0;

        #endregion Atributi

        #region Properties

        /// <summary>
        ///	Scena koja se prikazuje.
        /// </summary>
        public AssimpScene Scene
        {
            get { return m_model; }
            set { m_model = value; }
        }

        /// <summary>
        /// Uniformno skaliranje
        /// </summary>
        public float ScaleXYZ
        {
            get { return scaleXYZ; }
            set { scaleXYZ = value; }
        }

        /// <summary>
        /// Pozicija aviona po Y osi
        /// </summary>
        public float PositionY
        {
            get { return posY; }
            set { posY = value; }
        }

        /// <summary>
        /// Pozicija aviona po Z osi
        /// </summary>
        public float PositionZ
        {
            get { return posZ; }
            set { posZ = value; }
        }

        /// <summary>
        /// Ugao rotacije aviona oko X ose
        /// </summary>
        public float RotateX
        {
            get { return rotX; }
            set { rotX = value; }
        }

        /// <summary>
        /// Ugao rotacije aviona oko Y ose
        /// </summary>
        public float RotateY
        {
            get { return rotY; }
            set { rotY = value; }
        }

        /// <summary>
        /// Ugao rotacije aviona oko Z ose
        /// </summary>
        public float RotateZ
        {
            get { return rotZ; }
            set { rotZ = value; }
        }

        /// <summary>
        ///	Ugao rotacije sveta oko X ose.
        /// </summary>
        public float RotationX
        {
            get { return m_xRotation; }
            set { m_xRotation = value; }
        }

        /// <summary>
        ///	Ugao rotacije sveta oko Y ose.
        /// </summary>
        public float RotationY
        {
            get { return m_yRotation; }
            set { m_yRotation = value; }
        }

        /// <summary>
        ///	Udaljenost od centra scene
        /// </summary>
        public float SceneDistance
        {
            get { return m_sceneDistance; }
            set { m_sceneDistance = value; }
        }


        /// <summary>
        ///	Crvena boja sijalica
        /// </summary>
        public float Red
        {
            get { return red; }
            set { red = value; }
        }

        /// <summary>
        ///	Zelena boja sijalica
        /// </summary>
        public float Green
        {
            get { return green; }
            set { green = value; }
        }

        /// <summary>
        ///	Plava boja sijalica
        /// </summary>
        public float Blue
        {
            get { return blue; }
            set { blue = value; }
        }


        /// <summary>
        ///	Sirina OpenGL kontrole u pikselima.
        /// </summary>
        public int Width
        {
            get { return m_width; }
            set { m_width = value; }
        }

        /// <summary>
        ///	Visina OpenGL kontrole u pikselima.
        /// </summary>
        public int Height
        {
            get { return m_height; }
            set { m_height = value; }
        }

        #endregion Properties

        #region Konstruktori

        /// <summary>
        ///  Konstruktor klase World.
        /// </summary>
        public World(String scenePath, String sceneFileName, int width, int height)
        {
            this.m_model = new AssimpScene(scenePath, sceneFileName);
            this.m_width = width;
            this.m_height = height;

            try
            {
                m_camera = new MyCamera();
            }
            catch (Exception)
            {
                MessageBox.Show("Neuspesno kreirana instanca klase Camera", "GRESKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                m_font = new BitmapFont("Times New Roman", 10, true, false, false, false);
            }
            catch (Exception)
            {
                MessageBox.Show("Neuspesno kreirana instanca OpenGL fonta", "GRESKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Initialize();  // Korisnicka inicijalizacija OpenGL parametara
            this.Resize();      // Podesavanje projekcije i viewport-a
        }

        /// <summary>
        /// Destruktor klase World.
        /// </summary>
        ~World()
        {
            this.Dispose(false);
        }

        #endregion Konstruktori

        #region Metode

        /// <summary>
        ///  Iscrtavanje OpenGL kontrole.
        /// </summary>

        /// <summary>
        ///  Iscrtavanje podloge
        /// </summary>
        private void DrawBase() 
        {
            new Base(new Structs.Vector3(-1000.0f, -1000.0f, 0.0f), textures[0]);
        }
        
        /// <summary>
        ///  Iscrtavanje piste
        /// </summary>
        private void DrawAirStrip() 
        {
            new AirStrip(new Structs.Vector3(800.0f, 2000.0f, 20.0f), textures[1]);
        }

        /// <summary>
        ///  Iscrtavanje sijalica
        /// </summary>
        private void DrawBulbs() 
        {
            new Bulbs(new Structs.Vector3(-450.0f, -900.0f, 10.0f), red, green, blue);
        }

        /// <summary>
        ///  Iscrtavanje modela aviona
        /// </summary>
        private void DrawAirplane() 
        {
            Gl.glPushMatrix();
            Gl.glTranslatef(0.0f, posY, posZ);
            Gl.glRotatef(90.0f, 1.0f, 0.0f, 0.0f);
            

            Gl.glRotatef(rotX, 1.0f, 0.0f, 0.0f);
            Gl.glRotatef(rotY, 0.0f, 1.0f, 0.0f);
            Gl.glRotatef(rotZ, 0.0f, 0.0f, 1.0f);

            Gl.glScalef(scaleXYZ, scaleXYZ, scaleXYZ);
            m_model.Draw();
            Gl.glPopMatrix();
        }

        /// <summary>
        ///  Iscrtavanje teksta
        /// </summary>
        private void DrawText()
        {
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Glu.gluOrtho2D(-m_width / 2.0, m_width / 2.0, -m_height / 2.0, m_height / 2.0);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
            Gl.glColor3f(1.0f, 1.0f, 0.0f);

            for (int i = 0; i < m_message.Length; i++)
            {
                Gl.glRasterPos2d(m_width / 2 - m_font.CalculateTextWidth(m_message[0]), -m_height / 2 + m_message.Length * m_font.CalculateTextHeight(m_message[0]) - i * m_font.CalculateTextHeight(m_message[i]));
                m_font.DrawText(m_message[i]);
            }
        }
        
        public void Draw()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            
            Gl.glPushMatrix();
            Gl.glTranslatef(0.0f, 0.0f, -m_sceneDistance);
            Gl.glRotatef(m_xRotation, 1.0f, 0.0f, 0.0f);
            Gl.glRotatef(m_yRotation, 0.0f, 1.0f, 0.0f);

            m_camera.Look();
            
            Gl.glPushMatrix();
            DrawBase();
            DrawAirStrip();
            DrawBulbs();
            DrawAirplane();
            DrawText();
            Gl.glPopMatrix();
            Gl.glPopMatrix();
            Resize();
            Gl.glFlush();
            
        }
        /// <summary>
        ///  Azuriranje podataka za novi frejm animacije sijalica
        /// </summary>
        public void UpdateBulbAnimation()
        {
            ++couter;
            if (couter % 3 == 0)
            {
                Red = 0.0f;
                Green = 0.0f;
                Blue = 1.0f;
            }
            else if (couter % 3 == 1)
            {
                Red = 1.0f;
                Green = 0.0f;
                Blue = 1.0f;
            }
            else if (couter % 3 == 2)
            {
                Red = 1.0f;
                Green = 0.0f;
                Blue = 0.0f;
            }

        }

        /// <summary>
        ///  Azuriranje podataka za novi frejm animacije aviona
        /// </summary>
        public void UpdateAirplaneAnimation()
        {
           
            if (this.PositionY >= -800.0f)
            {
                if (this.PositionZ >= 80.0f)
                {
                    this.PositionY -= 25.0f;
                    this.PositionZ -= 8.0f;
                }
                else
                {
                    this.PositionY -= 22.0f;
                }
            }
        }

        /// <summary>
        ///  Definisanje tackastog izvora svetlosti, bele boje, pozicioniranog iznad centra scene
        /// </summary>
        private void InitializePointLightSource()
        {
            //float[] ambientLight = { 1.0f, 1.0f, 1.0f, 1.0f };
            float[] diffuseLight = { 1.0f, 1.0f, 1.0f, 1.0f };
            float[] lightPosition = { 0.0f, -2000.0f, 0.0f, 1.0f };

            //Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_AMBIENT, ambientLight);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_DIFFUSE, diffuseLight);
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, lightPosition);

            Gl.glEnable(Gl.GL_LIGHT0);
        }

        /// <summary>
        ///  Definisanje reflektorskog izvora svetlosti, zute boje, pozicioniranog iznad aviona
        /// </summary>
        private void InitializeReflectorLightSource(float posY, float posZ)
        {
            
            //float[] ambientLight = { 1.0f, 1.0f, 0.0f, 1.0f };
            float[] diffuseLight = { 1.0f, 1.0f, 0.0f, 1.0f };
            float[] lightPosition = { -posY, -posZ-100.0f, 0.0f, 1.0f };
            float[] lightDirection = { 0.0f, 0.0f, -1.0f };

            //Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_AMBIENT, ambientLight);
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_DIFFUSE, diffuseLight);

            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_SPOT_DIRECTION, lightDirection); 
            Gl.glLightf(Gl.GL_LIGHT1, Gl.GL_SPOT_CUTOFF, 30.0f);

            Gl.glEnable(Gl.GL_LIGHT1);
        }

        /// <summary>
        /// Generisanje tekstura
        /// </summary>
        private void GenerateTextures()
        {
            textureFiles = new string[] { "..//..//Textures//grass.jpg",
                                          "..//..//Textures//asp.jpg" };

            textures = new int[textureFiles.Length];
            Gl.glGenTextures(textureFiles.Length, textures);
        }

        /// <summary>
        /// Definisanje tekstura
        /// </summary>
        private void InitializeTextures()
        {
            // Prelazak u rezim rada sa 2D teksturama
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            
            // Podesavanje nacina stapanja teksture sa materijalom na GL_ADD
            Gl.glTexEnvi(Gl.GL_TEXTURE_ENV, Gl.GL_TEXTURE_ENV_MODE, Gl.GL_ADD);

            // Ucitavanje slika i kreiranje tekstura
            GenerateTextures();
            for (int i = 0; i < textureFiles.Length; ++i)
            {
                // Pridruzivanje teksture odgovarajucem identifikatoru
                Gl.glBindTexture(Gl.GL_TEXTURE_2D, textures[i]);
                
                // Ucitavanje slike i podesavanje parametara teksture
                Bitmap image = new Bitmap(textureFiles[i]);
                
                // Rotacija slike zbog koordinantog sistema OpenGL-a
                image.RotateFlip(RotateFlipType.RotateNoneFlipY);
                Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);

                // RGBA format (dozvoljena providnost slike tj. alfa kanal)
                BitmapData imageData = image.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadOnly,
                                                      System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                Glu.gluBuild2DMipmaps(Gl.GL_TEXTURE_2D, (int)Gl.GL_RGBA8, image.Width, image.Height, Gl.GL_BGRA, Gl.GL_UNSIGNED_BYTE, imageData.Scan0);

                // Podesavanje wrapping-a na GL_REPEAT po obema osama
                Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_S, Gl.GL_REPEAT);
                Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_T, Gl.GL_REPEAT);

                // Podesavanje filtera za teksture na GL_NEAREST
                Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_NEAREST);
                Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_NEAREST);

                image.UnlockBits(imageData);
                image.Dispose();
            }
            
        }

        /// <summary>
        ///  Korisnicka inicijalizacija i podesavanje OpenGL parametara.
        /// </summary>
        private void Initialize()
        {
            // Podesavanje boje pozadine
            Gl.glClearColor(1.0f, 1.0f, 1.0f, 1.0f);

            // Testiranje dubine
            Gl.glEnable(Gl.GL_DEPTH_TEST);

            // Sakrivanje nevidljivih povrsina
            Gl.glEnable(Gl.GL_CULL_FACE);

            // Ukljucivanje color tracking mehanizma
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);

            // Podesavanje ambijentalne i difuzne komponente materijala
            Gl.glColorMaterial(Gl.GL_FRONT, Gl.GL_AMBIENT_AND_DIFFUSE);

            // Pozicioniranje kamere
            m_camera.Position(200.0f, 200.0f, 600.0f,
                                0.0f, 0.0f, 600.0f,
                                0.0f, 0.0f, 1.0f);

            // Ukljucivanje automatske normalizacije nad normalama
            Gl.glEnable(Gl.GL_NORMALIZE);

            // Ukljucivanje proracuna osvetljenja
            Gl.glEnable(Gl.GL_LIGHTING);

            // Inicijalizacija tackastog izvora svetlosti
            InitializePointLightSource();
            
            // Inicijalizacija reflektorskog izvora svetlosti
            InitializeReflectorLightSource(posY, posZ);
            
            // Inicijalizacija tekstura
            InitializeTextures();
        }

        /// <summary>
        /// Podesava viewport i projekciju za OpenGL kontrolu.
        /// </summary>
        public void Resize()
        {
            // Podesavanje viewport-a preko celog prozora
            Gl.glViewport(0, 0, m_width, m_height); 
            
            Gl.glMatrixMode(Gl.GL_PROJECTION);      
            Gl.glLoadIdentity();			        
            
            // Definisanje projekcije u perspektivi(fov=45, near=1, far po potrebi)
            Glu.gluPerspective(45.0, (double)m_width / (double)m_height, 1.0, 10000.0);

            Gl.glMatrixMode(Gl.GL_MODELVIEW);   
            Gl.glLoadIdentity();                
        }

        /// <summary>
        ///  Implementacija IDisposable interfejsa.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Oslodi managed resurse
            }

            // Oslobodi unmanaged resurse
            m_model.Dispose();
            m_font.Dispose();
            Gl.glDeleteTextures(textureFiles.Length, textures);
        }

        #endregion Metode

        #region IDisposable metode

        /// <summary>
        ///  Dispose metoda.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable metode
    }
}
