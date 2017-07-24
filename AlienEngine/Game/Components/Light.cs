using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlienEngine
{
    public class Light : Component
    {
        public enum LightType
        {
            Spot,
            Directional,
            Sun
        }

        public LightType Type;
    }
}
