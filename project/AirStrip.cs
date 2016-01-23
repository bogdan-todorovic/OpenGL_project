using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tao.OpenGl;

namespace RacunarskaGrafika.Vezbe.AssimpNetSample
{
    class AirStrip
    {
        float height = 0.0f;
        float width = 0.0f;
        float depth = 0.0f;

        public AirStrip(Structs.Vector3 xyz, int texId)
        {
            this.width = xyz.x;
            this.height = xyz.y;
            this.depth = xyz.z;

            Gl.glPushMatrix();
            {
                Gl.glTranslatef(0.0f, 0.0f, 20.0f);
                Gl.glBindTexture(Gl.GL_TEXTURE_2D, texId);
                this.Draw();
            }
            Gl.glPopMatrix();

        }

        public void Draw()
        {
            Gl.glBegin(Gl.GL_QUADS);

            // Zadnja
            Gl.glNormal3fv(Lighting.FindFaceNormal(-width / 2, -height / 2, -depth / 2, -width / 2, height / 2, -depth / 2, width / 2, height / 2, -depth / 2));
            Gl.glTexCoord2f(0.0f, 0.0f);
            Gl.glVertex3f(-width / 2, -height / 2, -depth / 2);
            Gl.glTexCoord2f(0.0f, 1.0f);
            Gl.glVertex3f(-width / 2, height / 2, -depth / 2);
            Gl.glTexCoord2f(1.0f, 1.0f);
            Gl.glVertex3f(width / 2, height / 2, -depth / 2);
            Gl.glTexCoord2f(1.0f, 0.0f);
            Gl.glVertex3f(width / 2, -height / 2, -depth / 2);
            
            // Desna
            Gl.glNormal3fv(Lighting.FindFaceNormal(width / 2, -height / 2, depth / 2, width / 2, height / 2, depth / 2, width / 2, height / 2, -depth / 2));
            Gl.glTexCoord2f(0.0f, 0.0f);
            Gl.glVertex3f(width / 2, -height / 2, -depth / 2);
            Gl.glTexCoord2f(0.0f, 1.0f);
            Gl.glVertex3f(width / 2, height / 2, -depth / 2);
            Gl.glTexCoord2f(1.0f, 1.0f);
            Gl.glVertex3f(width / 2, height / 2, depth / 2);
            Gl.glTexCoord2f(1.0f, 0.0f);
            Gl.glVertex3f(width / 2, -height / 2, depth / 2);

            // Prednja
            Gl.glNormal3fv(Lighting.FindFaceNormal(-width / 2, -height / 2, depth / 2, -width / 2, height / 2, depth / 2, width / 2, height / 2, depth / 2));
            Gl.glTexCoord2f(0.0f, 0.0f);
            Gl.glVertex3f(width / 2, -height / 2, depth / 2);
            Gl.glTexCoord2f(0.0f, 1.0f);
            Gl.glVertex3f(width / 2, height / 2, depth / 2);
            Gl.glTexCoord2f(1.0f, 1.0f);
            Gl.glVertex3f(-width / 2, height / 2, depth / 2);
            Gl.glTexCoord2f(1.0f, 0.0f);
            Gl.glVertex3f(-width / 2, -height / 2, depth / 2);

            // Leva
            Gl.glNormal3fv(Lighting.FindFaceNormal(-width / 2, -height / 2, -depth / 2, -width / 2, height / 2, -depth / 2, -width / 2, height / 2, depth / 2));
            Gl.glTexCoord2f(0.0f, 0.0f);
            Gl.glVertex3f(-width / 2, -height / 2, depth / 2);
            Gl.glTexCoord2f(0.0f, 1.0f);
            Gl.glVertex3f(-width / 2, height / 2, depth / 2);
            Gl.glTexCoord2f(1.0f, 1.0f);
            Gl.glVertex3f(-width / 2, height / 2, -depth / 2);
            Gl.glTexCoord2f(1.0f, 0.0f);
            Gl.glVertex3f(-width / 2, -height / 2, -depth / 2);

            // Donja
            Gl.glNormal3fv(Lighting.FindFaceNormal(-width / 2, -height / 2, -depth / 2, width / 2, -height / 2, -depth / 2, width / 2, -height / 2, depth / 2));
            Gl.glTexCoord2f(0.0f, 0.0f);
            Gl.glVertex3f(-width / 2, -height / 2, -depth / 2);
            Gl.glTexCoord2f(0.0f, 1.0f);
            Gl.glVertex3f(width / 2, -height / 2, -depth / 2);
            Gl.glTexCoord2f(1.0f, 1.0f);
            Gl.glVertex3f(width / 2, -height / 2, depth / 2);
            Gl.glTexCoord2f(1.0f, 0.0f);
            Gl.glVertex3f(-width / 2, -height / 2, depth / 2);

            // Gornja
            Gl.glNormal3fv(Lighting.FindFaceNormal(width / 2, height / 2, -depth / 2, width / 2, height / 2, depth / 2, -width / 2, height / 2, depth / 2));
            Gl.glTexCoord2f(0.0f, 0.0f);
            Gl.glVertex3f(-width / 2, height / 2, -depth / 2);
            Gl.glTexCoord2f(0.0f, 1.0f);
            Gl.glVertex3f(-width / 2, height / 2, depth / 2);
            Gl.glTexCoord2f(1.0f, 1.0f);
            Gl.glVertex3f(width / 2, height / 2, depth / 2);
            Gl.glTexCoord2f(1.0f, 0.0f);
            Gl.glVertex3f(width / 2, height / 2, -depth / 2);
            
            Gl.glEnd();
        }
        
    }
}
