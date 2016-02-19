using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RacunarskaGrafika.Vezbe.AssimpNetSample
{
    class Structs
    {

        public struct Vector3
        {
            public float x;
            public float y;
            public float z;

            public Vector3(float xx, float yy, float zz)
            {
                this.x = xx;
                this.y = yy;
                this.z = zz;
            }
        }

    }
}
