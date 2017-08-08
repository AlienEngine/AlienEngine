using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace AlienEngine.Core.Graphics
{
    [StructLayout(LayoutKind.Explicit)]
    public struct MeshEntry
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
