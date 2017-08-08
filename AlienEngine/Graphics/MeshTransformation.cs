using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace AlienEngine.Core.Graphics
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct MeshTransformation
    {
        public Vector3f Position;
        public Vector3f Scale;
        public Vector3f Rotation;

        public MeshTransformation(Assimp.Matrix4x4 transform)
        {
            Assimp.Vector3D t, s;
            Assimp.Quaternion r;
            transform.Decompose(out s, out r, out t);

            Position = new Vector3f(t.X, t.Y, t.Z);
            Scale = new Vector3f(s.X, s.Y, s.Z);
            Rotation = new Quaternion(r.W, r.X, r.Y, r.Z).ToEulerAngles();
        }
    }
}
