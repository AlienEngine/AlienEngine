using ZeroFormatter;

namespace AlienEngine.Core.Assets.Material
{
    [ZeroFormattable]
    public class ShaderData
    {
        [Index(0)]
        public virtual string VertexShader { get; set; }

        [Index(1)]
        public virtual string FragmentShader { get; set; }

        [Index(2)]
        public virtual string GeometryShader { get; set; }

        [Index(3)]
        public virtual string TesselationControlShader { get; set; }

        [Index(4)]
        public virtual string TesselationEvaluationShader { get; set; }
        
        public ShaderData()
        { }
    }
}