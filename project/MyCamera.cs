using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RacunarskaGrafika.Vezbe.AssimpNetSample
{
    using System;
    using Tao.OpenGl;

    class MyCamera : Structs
    {
        #region Atributi

        /// <summary>
        ///  Pozicija kamere.
        /// </summary>
        private Vector3 m_eye;

        /// <summary>
        ///  Pogled kamere.
        /// </summary>
        private Vector3 m_view;

        /// <summary>
        ///  Up vektor kamere.
        /// </summary>
        private Vector3 m_up;

        #endregion Atributi

        #region Properties

        /// <summary>
        ///  Pozicija kamere.
        /// </summary>
        public Vector3 Eye
        {
            get { return m_eye; }
            set { m_eye = value; }
        }

        /// <summary>
        ///  Pogled kamere.
        /// </summary>
        public Vector3 View
        {
            get { return m_view; }
            set { m_view = value; }
        }

        /// <summary>
        ///  Up vektor kamere.
        /// </summary>
        public Vector3 Up
        {
            get { return m_up; }
            set { m_up = value; }
        }

        #endregion Properties

        #region Konstruktori

        public MyCamera(){ }

        #endregion Konstruktori

        #region Metode
        public void Position(float eyeX, float eyeY, float eyeZ,
                             float viewX, float viewY, float viewZ,
                             float upX, float upY, float upZ)
        {
            m_eye.x = eyeX;
            m_eye.y = eyeY;
            m_eye.z = eyeZ;
            m_view.x = viewX;
            m_view.y = viewY;
            m_view.z = viewZ;
            m_up.x = upX;
            m_up.y = upY;
            m_up.z = upZ;
        }

        public void Look()
        {
            Glu.gluLookAt(m_eye.x, m_eye.y, m_eye.z,
                          m_view.x, m_view.y, m_view.z,
                          m_up.x, m_up.y, m_up.z);
        }

        #endregion Metode
    }
}
