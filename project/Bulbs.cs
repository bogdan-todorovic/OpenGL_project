using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tao.OpenGl;

namespace RacunarskaGrafika.Vezbe.AssimpNetSample
{
    class Bulbs
    {

        private Glu.GLUquadric bulb = Glu.gluNewQuadric();
        private float x;
        private float y;
        private float z;

        public Bulbs(Structs.Vector3 xyz, float r, float g, float b)
        {
            this.x = xyz.x;
            this.y = xyz.y;
            this.z = xyz.z;
            
            Glu.gluQuadricNormals(bulb, Glu.GLU_SMOOTH);
            Gl.glColor3f(r, g, b);
            this.Draw();
            
        }

        public void Draw()
        {
            Gl.glPushMatrix();
            {
             Gl.glTranslatef(x, y, z);
                for (int i = 0; i < 19; ++i)
                {
                    Glu.gluSphere(bulb, 20.0f, 128, 128);
                    Gl.glTranslatef(0.0f, 100.0f, 0.0f);
                }
            }
            Gl.glPopMatrix();
            Gl.glPushMatrix();
            {
                Gl.glTranslatef(-x, y, z);
                for (int i = 0; i < 19; ++i)
                {
                    Glu.gluSphere(bulb, 20.0f, 128, 128);
                    Gl.glTranslatef(0.0f, 100.0f, 0.0f);
                }
            }
            Gl.glPopMatrix();
        }
    }
}
