using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AlienEngine.Graphics
{
    [StructLayout(LayoutKind.Explicit)]
    internal struct MeshEntry
    {
        [FieldOffset(0)]
        public int NumIndices;
        
        [FieldOffset(4)]
        public int BaseVertex;

        [FieldOffset(8)]
        public int BaseIndex;

        [FieldOffset(12)]
        public int MaterialIndex;

        [FieldOffset(16)]
        public string Name;
    };
}
