using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tao.OpenGl;

namespace RacunarskaGrafika.Vezbe.AssimpNetSample
{
    class Base
    {
        private float x;
        private float y;
        private float z;

        public Base(Structs.Vector3 xyz, int texId)
        {
            this.x = xyz.x;
            this.y = xyz.y;
            this.z = xyz.z;

            Gl.glPushMatrix();
            {
                Gl.glMatrixMode(Gl.GL_TEXTURE);
                Gl.glLoadIdentity();
                Gl.glScalef(10.0f, 10.0f, 0.0f);
                Gl.glMatrixMode(Gl.GL_MODELVIEW);
                Gl.glTexEnvi(Gl.GL_TEXTURE_ENV, Gl.GL_TEXTURE_ENV_MODE, Gl.GL_DECAL);
                Gl.glBindTexture(Gl.GL_TEXTURE_2D, texId);
                Gl.glColor3f(0.4f, 0.4f, 0.4f);
                this.Draw();
                Gl.glMatrixMode(Gl.GL_TEXTURE);
                Gl.glLoadIdentity();
                Gl.glMatrixMode(Gl.GL_MODELVIEW);
                Gl.glTexEnvi(Gl.GL_TEXTURE_ENV, Gl.GL_TEXTURE_ENV_MODE, Gl.GL_ADD);
            }
            Gl.glPopMatrix();
        }

        public void Draw()
        {
            Gl.glBegin(Gl.GL_QUADS);
            {
                Gl.glNormal3fv(Lighting.FindFaceNormal(x, y, z, -x, y, z, -x, -y, z));
                Gl.glTexCoord2f(0.0f, 0.0f);
                Gl.glVertex3f(x, y, z);
                Gl.glTexCoord2f(0.0f, 1.0f);
                Gl.glVertex3f(-x, y, z);
                Gl.glTexCoord2f(1.0f, 1.0f);
                Gl.glVertex3f(-x, -y, z);
                Gl.glTexCoord2f(1.0f, 0.0f);
                Gl.glVertex3f(x, -y, z);
            }
            Gl.glEnd();
        }

    }
}
