using AlienEngine.Core.Rendering;
using AlienEngine.Imaging;
using ZeroFormatter;

namespace AlienEngine.Core.Assets.Material
{
    [ZeroFormattable]
    public class MaterialData
    {
        public virtual ShaderData ShaderData { get; set; }
        public virtual MaterialBlendMode BlendMode { get; set; }
        public virtual float BumpScaling { get; set; }
        public virtual Color4 ColorAmbient { get; set; }
        public virtual Color4 ColorDiffuse { get; set; }
        public virtual Color4 ColorEmissive { get; set; }
        public virtual Color4 ColorReflective { get; set; }
        public virtual Color4 ColorSpecular { get; set; }
        public virtual Color4 ColorTransparent { get; set; }
        public virtual bool HasBlendMode { get; set; }
        public virtual bool HasBumpScaling { get; set; }
        public virtual bool HasColorAmbient { get; set; }
        public virtual bool HasColorDiffuse { get; set; }
        public virtual bool HasColorEmissive { get; set; }
        public virtual bool HasColorReflective { get; set; }
        public virtual bool HasColorSpecular { get; set; }
        public virtual bool HasColorTransparent { get; set; }
        public virtual bool HasName { get; set; }
        public virtual bool HasOpacity { get; set; }
        public virtual bool HasReflectivity { get; set; }
        public virtual bool HasShadingMode { get; set; }
        public virtual bool HasShininess { get; set; }
        public virtual bool HasShininessStrength { get; set; }
        public virtual bool HasTextureAmbient { get; set; }
        public virtual bool HasTextureDiffuse { get; set; }
        public virtual bool HasTextureDisplacement { get; set; }
        public virtual bool HasTextureEmissive { get; set; }
        public virtual bool HasTextureHeight { get; set; }
        public virtual bool HasTextureLightMap { get; set; }
        public virtual bool HasTextureNormal { get; set; }
        public virtual bool HasTextureOpacity { get; set; }
        public virtual bool HasTextureReflection { get; set; }
        public virtual bool HasTextureSpecular { get; set; }
        public virtual bool HasTwoSided { get; set; }
        public virtual bool HasWireFrame { get; set; }
        public virtual bool IsTwoSided { get; set; }
        public virtual bool IsWireFrameEnabled { get; set; }
        public virtual string Name { get; set; }
        public virtual float Opacity { get; set; }
        public virtual int PropertyCount { get; set; }
        public virtual float Reflectivity { get; set; }
        public virtual MaterialShadingMode ShadingMode { get; set; }
        public virtual float Shininess { get; set; }
        public virtual float ShininessStrength { get; set; }
        public virtual string TextureAmbient { get; set; }
        public virtual string TextureDiffuse { get; set; }
        public virtual string TextureDisplacement { get; set; }
        public virtual string TextureEmissive { get; set; }
        public virtual string TextureHeight { get; set; }
        public virtual string TextureLightMap { get; set; }
        public virtual string TextureNormal { get; set; }
        public virtual string TextureOpacity { get; set; }
        public virtual string TextureReflection { get; set; }
        public virtual string TextureSpecular { get; set; }

        public MaterialData()
        { }
    }
}
