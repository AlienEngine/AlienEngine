using System;

namespace AlienEngine.ASL
{
    public abstract partial class RenderShader : ASLShader
    {
        [BuiltIn]
        protected int textureSize(sampler1D sampler, int lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected int textureSize(isampler1D sampler, int lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected int textureSize(usampler1D sampler, int lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec2 textureSize(sampler2D sampler, int lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec2 textureSize(isampler2D sampler, int lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec2 textureSize(usampler2D sampler, int lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec3 textureSize(sampler3D sampler, int lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec3 textureSize(isampler3D sampler, int lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec3 textureSize(usampler3D sampler, int lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec2 textureSize(samplerCube sampler, int lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec2 textureSize(isamplerCube sampler, int lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec2 textureSize(usamplerCube sampler, int lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected int textureSize(sampler1DShadow sampler, int lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec2 textureSize(sampler2DShadow sampler, int lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec2 textureSize(samplerCubeShadow sampler, int lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec2 textureSize(sampler2DRect sampler) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec2 textureSize(isampler2DRect sampler) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec2 textureSize(usampler2DRect sampler) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec2 textureSize(sampler2DRectShadow sampler) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec2 textureSize(sampler1DArray sampler, int lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec2 textureSize(isampler1DArray sampler, int lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec2 textureSize(usampler1DArray sampler, int lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec3 textureSize(sampler2DArray sampler, int lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec3 textureSize(isampler2DArray sampler, int lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec3 textureSize(usampler2DArray sampler, int lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec2 textureSize(sampler1DArrayShadow sampler, int lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec3 textureSize(sampler2DArrayShadow sampler, int lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected int textureSize(samplerBuffer sampler) { throw new NotImplementedException(); }
        [BuiltIn]
        protected int textureSize(isamplerBuffer sampler) { throw new NotImplementedException(); }
        [BuiltIn]
        protected int textureSize(usamplerBuffer sampler) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec2 textureSize(sampler2DMS sampler) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec2 textureSize(isampler2DMS sampler) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec2 textureSize(usampler2DMS sampler) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec2 textureSize(sampler2DMSArray sampler) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec2 textureSize(isampler2DMSArray sampler) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec2 textureSize(usampler2DMSArray sampler) { throw new NotImplementedException(); }

        [BuiltIn]
        protected vec4 texture(sampler1D sampler, float p, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 texture(isampler1D sampler, float p, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 texture(usampler1D sampler, float p, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 texture(sampler2D sampler, vec2 p, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 texture(isampler2D sampler, vec2 p, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 texture(usampler2D sampler, vec2 p, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 texture2D(sampler2D sampler, vec2 p, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 texture2D(isampler2D sampler, vec2 p, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 texture2D(usampler2D sampler, vec2 p, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 texture(sampler3D sampler, vec3 p, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 texture(isampler3D sampler, vec3 p, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 texture(usampler3D sampler, vec3 p, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 texture(samplerCube sampler, vec3 p, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected float texture(sampler1DShadow sampler, vec3 p, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected float texture(sampler2DShadow sampler, vec3 p, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected float texture(samplerCubeShadow sampler, vec4 p, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 texture(sampler1DArray sampler, float p, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 texture(isampler1DArray sampler, float p, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 texture(usampler1DArray sampler, float p, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 texture(sampler2DArray sampler, vec2 p, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 texture(isampler2DArray sampler, vec2 p, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 texture(usampler2DArray sampler, vec2 p, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected float texture(sampler1DArrayShadow sampler, float p, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected float texture(sampler2DArrayShadow sampler, float p, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 texture(sampler2DRect sampler, vec2 p) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 texture(isampler2DRect sampler, vec2 p) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 texture(usampler2DRect sampler, vec2 p) { throw new NotImplementedException(); }
        [BuiltIn]
        protected float texture(sampler2DRectShadow sampler, vec2 p) { throw new NotImplementedException(); }
        
        [BuiltIn]
        protected vec4 textureProj(sampler1D sampler, vec2 p, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureProj(isampler1D sampler, vec2 p, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureProj(usampler1D sampler, vec2 p, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureProj(sampler1D sampler, vec4 p, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureProj(isampler1D sampler, vec4 p, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureProj(usampler1D sampler, vec4 p, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureProj(sampler2D sampler, vec3 p, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureProj(isampler2D sampler, vec3 p, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureProj(usampler2D sampler, vec3 p, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureProj(sampler2D sampler, vec4 p, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureProj(isampler2D sampler, vec4 p, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureProj(usampler2D sampler, vec4 p, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureProj(sampler3D sampler, vec4 p, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureProj(isampler3D sampler, vec4 p, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureProj(usampler3D sampler, vec4 p, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected float textureProj(sampler1DShadow sampler, float p, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected float textureProj(sampler2DShadow sampler, vec2 p, float bias = 0) { throw new NotImplementedException(); }

        [BuiltIn]
        protected float textureProj(sampler2DShadow sampler, vec4 p, float bias = 0) { throw new NotImplementedException(); }

        [BuiltIn]
        protected vec4 textureProj(sampler2DRect sampler, vec3 p) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureProj(isampler2DRect sampler, vec3 p) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureProj(usampler2DRect sampler, vec3 p) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureProj(sampler2DRect sampler, vec4 p) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureProj(isampler2DRect sampler, vec4 p) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureProj(usampler2DRect sampler, vec4 p) { throw new NotImplementedException(); }
        [BuiltIn]
        protected float textureProj(sampler2DRectShadow sampler, vec2 p) { throw new NotImplementedException(); }

        [BuiltIn]
        protected vec4 textureLod(sampler1D sampler, float p, float lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureLod(isampler1D sampler, float p, float lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureLod(usampler1D sampler, float p, float lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureLod(sampler2D sampler, vec2 p, float lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureLod(isampler2D sampler, vec2 p, float lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureLod(usampler2D sampler, vec2 p, float lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureLod(sampler3D sampler, vec3 p, float lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureLod(isampler3D sampler, vec3 p, float lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureLod(usampler3D sampler, vec3 p, float lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureLod(samplerCube sampler, vec3 p, float lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureLod(isamplerCube sampler, vec3 p, float lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureLod(usamplerCube sampler, vec3 p, float lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected float textureLod(sampler1DShadow sampler, vec3 p, float lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected float textureLod(sampler2DShadow sampler, vec3 p, float lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureLod(sampler1DArray sampler, vec2 p, float lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureLod(isampler1DArray sampler, vec2 p, float lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureLod(usampler1DArray sampler, vec2 p, float lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureLod(sampler2DArray sampler, vec3 p, float lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureLod(isampler2DArray sampler, vec3 p, float lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureLod(usampler2DArray sampler, vec3 p, float lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected float textureLod(sampler1DArrayShadow sampler, vec3 p, float lod) { throw new NotImplementedException(); }

        [BuiltIn]
        protected vec4 textureOffset(sampler1D sampler, float p, int offset, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureOffset(isampler1D sampler, float p, int offset, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureOffset(usampler1D sampler, float p, int offset, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureOffset(sampler2D sampler, vec2 p, ivec2 offset, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 texttextureOffsetureLod(isampler2D sampler, vec2 p, ivec2 offset, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureOffset(usampler2D sampler, vec2 p, ivec2 offset, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureOffset(sampler3D sampler, vec3 p, ivec3 offset, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureOffset(isampler3D sampler, vec3 p, ivec3 offset, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureOffset(usampler3D sampler, vec3 p, ivec3 offset, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureOffset(sampler2DRect sampler, vec3 p, ivec2 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureOffset(isampler2DRect sampler, vec3 p, ivec2 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureOffset(usampler2DRect sampler, vec3 p, ivec2 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureOffset(sampler2DRectShadow sampler, vec3 p, ivec2 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected float textureOffset(sampler1DShadow sampler, vec3 p, int offset, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected float textureOffset(sampler2DShadow sampler, vec3 p, ivec2 offset, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureOffset(sampler1DArray sampler, vec2 p, int offset, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureOffset(sampler2DArray sampler, vec3 p, ivec2 offset, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureOffset(isampler1DArray sampler, vec2 p, int offset, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureOffset(isampler2DArray sampler, vec3 p, ivec2 offset, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureOffset(usampler1DArray sampler, vec2 p, int offset, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureOffset(usampler2DArray sampler, vec3 p, ivec2 offset, float bias = 0) { throw new NotImplementedException(); }
        
        [BuiltIn]
        protected vec4 texelFetch(sampler1D sampler, int p, int lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 texelFetch(isampler1D sampler, int p, int lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 texelFetch(usampler1D sampler, int p, int lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 texelFetch(sampler2D sampler, ivec2 p, int lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 texelFetch(isampler2D sampler, ivec2 p, int lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 texelFetch(usampler2D sampler, ivec2 p, int lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 texelFetch(sampler3D sampler, ivec3 p, int lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 texelFetch(isampler3D sampler, ivec3 p, int lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 texelFetch(usampler3D sampler, ivec3 p, int lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 texelFetch(sampler2DRect sampler, ivec2 p, int lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 texelFetch(isampler2DRect sampler, ivec2 p, int lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 texelFetch(usampler2DRect sampler, ivec2 p, int lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 texelFetch(sampler1DArray sampler, ivec2 p, int lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 texelFetch(isampler1DArray sampler, ivec2 p, int lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 texelFetch(usampler1DArray sampler, ivec2 p, int lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 texelFetch(sampler2DArray sampler, ivec3 p, int lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 texelFetch(isampler2DArray sampler, ivec3 p, int lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 texelFetch(usampler2DArray sampler, ivec3 p, int lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 texelFetch(samplerBuffer sampler, int p, int lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 texelFetch(isamplerBuffer sampler, int p, int lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 texelFetch(usamplerBuffer sampler, int p, int lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 texelFetch(sampler2DMS sampler, ivec2 p, int lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 texelFetch(isampler2DMS sampler, ivec2 p, int lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 texelFetch(usampler2DMS sampler, ivec2 p, int lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 texelFetch(sampler2DMSArray sampler, ivec3 p, int lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 texelFetch(isampler2DMSArray sampler, ivec3 p, int lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 texelFetch(usampler2DMSArray sampler, ivec3 p, int lod) { throw new NotImplementedException(); }

        [BuiltIn]
        protected vec4 texelFetchOffset(sampler1D sampler, int p, int lod, int offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 texelFetchOffset(isampler1D sampler, int p, int lod, int offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 texelFetchOffset(usampler1D sampler, int p, int lod, int offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 texelFetchOffset(sampler2D sampler, ivec2 p, int lod, ivec2 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 texelFetchOffset(isampler2D sampler, ivec2 p, int lod, ivec2 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 texelFetchOffset(usampler2D sampler, ivec2 p, int lod, ivec2 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 texelFetchOffset(sampler3D sampler, ivec3 p, int lod, ivec3 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 texelFetchOffset(isampler3D sampler, ivec3 p, int lod, ivec3 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 texelFetchOffset(usampler3D sampler, ivec3 p, int lod, ivec3 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 texelFetchOffset(sampler2DRect sampler, ivec2 p, int lod, ivec2 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 texelFetchOffset(isampler2DRect sampler, ivec2 p, int lod, ivec2 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 texelFetchOffset(usampler2DRect sampler, ivec2 p, int lod, ivec2 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 texelFetchOffset(sampler1DArray sampler, ivec2 p, int lod, int offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 texelFetchOffset(isampler1DArray sampler, ivec2 p, int lod, int offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 texelFetchOffset(usampler1DArray sampler, ivec2 p, int lod, int offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 texelFetchOffset(sampler2DArray sampler, ivec3 p, int lod, ivec2 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 texelFetchOffset(isampler2DArray sampler, ivec3 p, int lod, ivec2 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 texelFetchOffset(usampler2DArray sampler, ivec3 p, int lod, ivec2 offset) { throw new NotImplementedException(); }

        [BuiltIn]
        protected vec4 textureProjOffset(sampler1D sampler, vec2 p, int offset, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureProjOffset(isampler1D sampler, vec2 p, int offset, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureProjOffset(usampler1D sampler, vec2 p, int offset, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureProjOffset(sampler1D sampler, vec4 p, int offset, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureProjOffset(isampler1D sampler, vec4 p, int offset, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureProjOffset(usampler1D sampler, vec4 p, int offset, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureProjOffset(sampler2D sampler, vec3 p, ivec2 offset, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureProjOffset(isampler2D sampler, vec3 p, ivec2 offset, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureProjOffset(usampler2D sampler, vec3 p, ivec2 offset, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureProjOffset(sampler2D sampler, vec4 p, ivec2 offset, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureProjOffset(isampler2D sampler, vec4 p, ivec2 offset, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureProjOffset(usampler2D sampler, vec4 p, ivec2 offset, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureProjOffset(sampler3D sampler, vec4 p, ivec3 offset, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureProjOffset(isampler3D sampler, vec4 p, ivec3 offset, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureProjOffset(usampler3D sampler, vec4 p, ivec3 offset, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureProjOffset(sampler2DRect sampler, vec3 p, ivec2 offset, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureProjOffset(isampler2DRect sampler, vec3 p, ivec2 offset, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureProjOffset(usampler2DRect sampler, vec3 p, ivec2 offset, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureProjOffset(sampler2DRect sampler, vec4 p, ivec2 offset, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureProjOffset(isampler2DRect sampler, vec4 p, ivec2 offset, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureProjOffset(usampler2DRect sampler, vec4 p, ivec2 offset, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected float textureProjOffset(sampler2DRectShadow sampler, vec4 p, ivec2 offset, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected float textureProjOffset(sampler1DShadow sampler, vec4 p, int offset, float bias = 0) { throw new NotImplementedException(); }
        [BuiltIn]
        protected float textureProjOffset(sampler2DShadow sampler, vec4 p, ivec2 offset, float bias = 0) { throw new NotImplementedException(); }
        
        [BuiltIn]
        protected vec4 textureLodOffset(sampler1D sampler, float p, int lod, int offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureLodOffset(isampler1D sampler, float p, int lod, int offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureLodOffset(usampler1D sampler, float p, int lod, int offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureLodOffset(sampler2D sampler, vec2 p, int lod, ivec2 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureLodOffset(isampler2D sampler, vec2 p, int lod, ivec2 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureLodOffset(usampler2D sampler, vec2 p, int lod, ivec2 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureLodOffset(sampler3D sampler, vec3 p, int lod, ivec3 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureLodOffset(isampler3D sampler, vec3 p, int lod, ivec3 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureLodOffset(usampler3D sampler, vec3 p, int lod, ivec3 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureLodOffset(sampler1DShadow sampler, int p, int lod, int offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureLodOffset(sampler2DShadow sampler, int p, int lod, ivec2 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureLodOffset(sampler1DArray sampler, vec2 p, int lod, int offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureLodOffset(isampler1DArray sampler, vec2 p, int lod, int offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureLodOffset(usampler1DArray sampler, vec2 p, int lod, int offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureLodOffset(sampler2DArray sampler, vec3 p, int lod, ivec2 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureLodOffset(isampler2DArray sampler, vec3 p, int lod, ivec2 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureLodOffset(usampler2DArray sampler, vec3 p, int lod, ivec2 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected float textureLodOffset(sampler1DArrayShadow sampler, vec3 p, int lod, int offset) { throw new NotImplementedException(); }
        
        [BuiltIn]
        protected vec4 textureProjLod(sampler1D sampler, vec2 p, float lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureProjLod(isampler1D sampler, vec2 p, float lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureProjLod(usampler1D sampler, vec2 p, float lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureProjLod(sampler1D sampler, vec4 p, float lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureProjLod(isampler1D sampler, vec4 p, float lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureProjLod(usampler1D sampler, vec4 p, float lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureProjLod(sampler2D sampler, vec3 p, float lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureProjLod(isampler2D sampler, vec3 p, float lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureProjLod(usampler2D sampler, vec3 p, float lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureProjLod(sampler2D sampler, vec4 p, float lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureProjLod(isampler2D sampler, vec4 p,float lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureProjLod(usampler2D sampler, vec4 p, float lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureProjLod(sampler3D sampler, vec4 p, float lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureProjLod(isampler3D sampler, vec4 p, float lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureProjLod(usampler3D sampler, vec4 p, float lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected float textureProjLod(sampler1DShadow sampler, vec4 p, float lod) { throw new NotImplementedException(); }
        [BuiltIn]
        protected float textureProjLod(sampler2DShadow sampler, vec4 p, float lod) { throw new NotImplementedException(); }

        [BuiltIn]
        protected vec4 textureProjLodOffset(sampler1D sampler, vec2 p, float lod, int offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureProjLodOffset(isampler1D sampler, vec2 p, float lod, int offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureProjLodOffset(usampler1D sampler, vec2 p, float lod, int offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureProjLodOffset(sampler1D sampler, vec4 p, float lod, int offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureProjLodOffset(isampler1D sampler, vec4 p, float lod, int offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureProjLodOffset(usampler1D sampler, vec4 p, float lod, int offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureProjLodOffset(sampler2D sampler, vec3 p, float lod, ivec2 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureProjLodOffset(isampler2D sampler, vec3 p, float lod, ivec2 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureProjLodOffset(usampler2D sampler, vec3 p, float lod, ivec2 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureProjLodOffset(sampler2D sampler, vec4 p, float lod, ivec2 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureProjLodOffset(isampler2D sampler, vec4 p,float lod, ivec2 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureProjLodOffset(usampler2D sampler, vec4 p, float lod, ivec2 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureProjLodOffset(sampler3D sampler, vec4 p, float lod, ivec3 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureProjLodOffset(isampler3D sampler, vec4 p, float lod, ivec3 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureProjLodOffset(usampler3D sampler, vec4 p, float lod, ivec3 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected float textureProjLodOffset(sampler1DShadow sampler, vec4 p, float lod, int offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected float textureProjLodOffset(sampler2DShadow sampler, vec4 p, float lod, ivec2 offset) { throw new NotImplementedException(); }
        
        [BuiltIn]
        protected vec4 textureGrad(sampler1D sampler, float p, float dPdx, float dPdy) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureGrad(isampler1D sampler, float p, float dPdx, float dPdy) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureGrad(usampler1D sampler, float p, float dPdx, float dPdy) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureGrad(sampler2D sampler, vec2 p, vec2 dPdx, vec2 dPdy) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureGrad(isampler2D sampler, vec2 p, vec2 dPdx, vec2 dPdy) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureGrad(usampler2D sampler, vec2 p, vec2 dPdx, vec2 dPdy) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureGrad(sampler3D sampler, vec3 p, vec3 dPdx, vec3 dPdy) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureGrad(isampler3D sampler, vec3 p, vec3 dPdx, vec3 dPdy) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureGrad(usampler3D sampler, vec3 p, vec3 dPdx, vec3 dPdy) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureGrad(samplerCube sampler, vec3 p, vec3 dPdx, vec3 dPdy) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureGrad(isamplerCube sampler, vec3 p, vec3 dPdx, vec3 dPdy) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureGrad(usamplerCube sampler, vec3 p, vec3 dPdx, vec3 dPdy) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureGrad(sampler2DRect sampler, vec2 p, vec2 dPdx, vec2 dPdy) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureGrad(isampler2DRect sampler, vec2 p, vec2 dPdx, vec2 dPdy) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureGrad(usampler2DRect sampler, vec2 p, vec2 dPdx, vec2 dPdy) { throw new NotImplementedException(); }
        [BuiltIn]
        protected float textureGrad(sampler2DRectShadow sampler, vec3 p, vec2 dPdx, vec2 dPdy) { throw new NotImplementedException(); }
        [BuiltIn]
        protected float textureGrad(sampler1DShadow sampler, vec3 p, float dPdx, float dPdy) { throw new NotImplementedException(); }
        [BuiltIn]
        protected float textureGrad(sampler2DShadow sampler, vec3 p, vec2 dPdx, vec2 dPdy) { throw new NotImplementedException(); }
        [BuiltIn]
        protected float textureGrad(samplerCubeShadow sampler, vec4 p, vec3 dPdx, vec3 dPdy) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureGrad(sampler1DArray sampler, vec2 p, float dPdx, float dPdy) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureGrad(isampler1DArray sampler, vec2 p, float dPdx, float dPdy) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureGrad(usampler1DArray sampler, vec2 p, float dPdx, float dPdy) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureGrad(sampler2DArray sampler, vec3 p, vec2 dPdx, vec2 dPdy) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureGrad(isampler2DArray sampler, vec3 p, vec2 dPdx, vec2 dPdy) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureGrad(usampler2DArray sampler, vec3 p, vec2 dPdx, vec2 dPdy) { throw new NotImplementedException(); }
        [BuiltIn]
        protected float textureGrad(sampler1DArrayShadow sampler, vec3 p, float dPdx, float dPdy) { throw new NotImplementedException(); }
        [BuiltIn]
        protected float textureGrad(sampler2DArrayShadow sampler, vec4 p, vec2 dPdx, vec2 dPdy) { throw new NotImplementedException(); }

        [BuiltIn]
        protected vec4 textureGradOffset(sampler1D sampler, float p, float dPdx, float dPdy, int offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureGradOffset(isampler1D sampler, float p, float dPdx, float dPdy, int offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureGradOffset(usampler1D sampler, float p, float dPdx, float dPdy, int offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureGradOffset(sampler2D sampler, vec2 p, vec2 dPdx, vec2 dPdy, ivec2 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureGradOffset(isampler2D sampler, vec2 p, vec2 dPdx, vec2 dPdy, ivec2 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureGradOffset(usampler2D sampler, vec2 p, vec2 dPdx, vec2 dPdy, ivec2 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureGradOffset(sampler3D sampler, vec3 p, vec3 dPdx, vec3 dPdy, ivec3 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureGradOffset(isampler3D sampler, vec3 p, vec3 dPdx, vec3 dPdy, ivec3 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureGradOffset(usampler3D sampler, vec3 p, vec3 dPdx, vec3 dPdy, ivec3 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureGradOffset(sampler2DRect sampler, vec2 p, vec2 dPdx, vec2 dPdy, ivec2 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureGradOffset(isampler2DRect sampler, vec2 p, vec2 dPdx, vec2 dPdy, ivec2 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureGradOffset(usampler2DRect sampler, vec2 p, vec2 dPdx, vec2 dPdy, ivec2 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected float textureGradOffset(sampler2DRectShadow sampler, vec3 p, vec2 dPdx, vec2 dPdy, ivec2 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected float textureGradOffset(sampler1DShadow sampler, vec3 p, float dPdx, float dPdy, int offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected float textureGradOffset(sampler2DShadow sampler, vec3 p, vec2 dPdx, vec2 dPdy, ivec2 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected float textureGradOffset(samplerCubeShadow sampler, vec4 p, vec3 dPdx, vec3 dPdy, ivec3 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureGradOffset(sampler1DArray sampler, vec2 p, float dPdx, float dPdy, int offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureGradOffset(isampler1DArray sampler, vec2 p, float dPdx, float dPdy, int offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureGradOffset(usampler1DArray sampler, vec2 p, float dPdx, float dPdy, int offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureGradOffset(sampler2DArray sampler, vec3 p, vec2 dPdx, vec2 dPdy, ivec2 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureGradOffset(isampler2DArray sampler, vec3 p, vec2 dPdx, vec2 dPdy, ivec2 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureGradOffset(usampler2DArray sampler, vec3 p, vec2 dPdx, vec2 dPdy, ivec2 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected float textureGradOffset(sampler1DArrayShadow sampler, vec3 p, float dPdx, float dPdy, int offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected float textureGradOffset(sampler2DArrayShadow sampler, vec4 p, vec2 dPdx, vec2 dPdy, ivec2 offset) { throw new NotImplementedException(); }

        [BuiltIn]
        protected vec4 textureProGrad(sampler1D sampler, vec2 p, float dPdx, float dPdy) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureProGrad(isampler1D sampler, vec2 p, float dPdx, float dPdy) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureProGrad(usampler1D sampler, vec2 p, float dPdx, float dPdy) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureProGrad(sampler1D sampler, vec4 p, float dPdx, float dPdy) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureProGrad(isampler1D sampler, vec4 p, float dPdx, float dPdy) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureProGrad(usampler1D sampler, vec4 p, float dPdx, float dPdy) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureProGrad(sampler2D sampler, vec3 p, vec2 dPdx, vec2 dPdy) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureProGrad(isampler2D sampler, vec3 p, vec2 dPdx, vec2 dPdy) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureProGrad(usampler2D sampler, vec3 p, vec2 dPdx, vec2 dPdy) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureProGrad(sampler2D sampler, vec4 p, vec2 dPdx, vec2 dPdy) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureProGrad(isampler2D sampler, vec4 p, vec2 dPdx, vec2 dPdy) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureProGrad(usampler2D sampler, vec4 p, vec2 dPdx, vec2 dPdy) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureProGrad(sampler3D sampler, vec4 p, vec3 dPdx, vec3 dPdy) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureProGrad(isampler3D sampler, vec4 p, vec3 dPdx, vec3 dPdy) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureProGrad(usampler3D sampler, vec4 p, vec3 dPdx, vec3 dPdy) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureProGrad(sampler2DRect sampler, vec3 p, vec2 dPdx, vec2 dPdy) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureProGrad(isampler2DRect sampler, vec3 p, vec2 dPdx, vec2 dPdy) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureProGrad(usampler2DRect sampler, vec3 p, vec2 dPdx, vec2 dPdy) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureProGrad(sampler2DRect sampler, vec4 p, vec2 dPdx, vec2 dPdy) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureProGrad(isampler2DRect sampler, vec4 p, vec2 dPdx, vec2 dPdy) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureProGrad(usampler2DRect sampler, vec4 p, vec2 dPdx, vec2 dPdy) { throw new NotImplementedException(); }
        [BuiltIn]
        protected float textureProGrad(sampler2DRectShadow sampler, vec4 p, vec2 dPdx, vec2 dPdy) { throw new NotImplementedException(); }
        [BuiltIn]
        protected float textureProGrad(sampler1DShadow sampler, vec4 p, float dPdx, float dPdy) { throw new NotImplementedException(); }
        [BuiltIn]
        protected float textureProGrad(sampler2DShadow sampler, vec4 p, vec2 dPdx, vec2 dPdy) { throw new NotImplementedException(); }

        [BuiltIn]
        protected vec4 textureProjGradOffset(sampler1D sampler, vec2 p, float dPdx, float dPdy, int offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureProjGradOffset(isampler1D sampler, vec2 p, float dPdx, float dPdy, int offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureProjGradOffset(usampler1D sampler, vec2 p, float dPdx, float dPdy, int offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureProjGradOffset(sampler1D sampler, vec4 p, float dPdx, float dPdy, int offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureProjGradOffset(isampler1D sampler, vec4 p, float dPdx, float dPdy, int offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureProjGradOffset(usampler1D sampler, vec4 p, float dPdx, float dPdy, int offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureProjGradOffset(sampler2D sampler, vec3 p, vec2 dPdx, vec2 dPdy, ivec2 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureProjGradOffset(isampler2D sampler, vec3 p, vec2 dPdx, vec2 dPdy, ivec2 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureProjGradOffset(usampler2D sampler, vec3 p, vec2 dPdx, vec2 dPdy, ivec2 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureProjGradOffset(sampler2D sampler, vec4 p, vec2 dPdx, vec2 dPdy, ivec2 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureProjGradOffset(isampler2D sampler, vec4 p, vec2 dPdx, vec2 dPdy, ivec2 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureProjGradOffset(usampler2D sampler, vec4 p, vec2 dPdx, vec2 dPdy, ivec2 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureProjGradOffset(sampler3D sampler, vec4 p, vec3 dPdx, vec3 dPdy, ivec3 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureProjGradOffset(isampler3D sampler, vec4 p, vec3 dPdx, vec3 dPdy, ivec3 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureProjGradOffset(usampler3D sampler, vec4 p, vec3 dPdx, vec3 dPdy, ivec3 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureProjGradOffset(sampler2DRect sampler, vec3 p, vec2 dPdx, vec2 dPdy, ivec2 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureProjGradOffset(isampler2DRect sampler, vec3 p, vec2 dPdx, vec2 dPdy, ivec2 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureProjGradOffset(usampler2DRect sampler, vec3 p, vec2 dPdx, vec2 dPdy, ivec2 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 textureProjGradOffset(sampler2DRect sampler, vec4 p, vec2 dPdx, vec2 dPdy, ivec2 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 textureProjGradOffset(isampler2DRect sampler, vec4 p, vec2 dPdx, vec2 dPdy, ivec2 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 textureProjGradOffset(usampler2DRect sampler, vec4 p, vec2 dPdx, vec2 dPdy, ivec2 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected float textureProjGradOffset(sampler2DRectShadow sampler, vec4 p, vec2 dPdx, vec2 dPdy, ivec2 offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected float textureProjGradOffset(sampler1DShadow sampler, vec4 p, float dPdx, float dPdy, int offset) { throw new NotImplementedException(); }
        [BuiltIn]
        protected float textureProjGradOffset(sampler2DShadow sampler, vec4 p, vec2 dPdx, vec2 dPdy, ivec2 offset) { throw new NotImplementedException(); }

        [BuiltIn]
        protected float noise1(float p) { throw new NotImplementedException(); }
        [BuiltIn]
        protected float noise1(vec2 p) { throw new NotImplementedException(); }
        [BuiltIn]
        protected float noise1(vec3 p) { throw new NotImplementedException(); }
        [BuiltIn]
        protected float noise1(vec4 p) { throw new NotImplementedException(); }

        [BuiltIn]
        protected vec2 noise2(float p) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec2 noise2(vec2 p) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec2 noise2(vec3 p) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec2 noise2(vec4 p) { throw new NotImplementedException(); }

        [BuiltIn]
        protected vec3 noise3(float p) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 noise3(vec2 p) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 noise3(vec3 p) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 noise3(vec4 p) { throw new NotImplementedException(); }

        [BuiltIn]
        protected vec4 noise4(float p) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 noise4(vec2 p) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 noise4(vec3 p) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 noise4(vec4 p) { throw new NotImplementedException(); }
    }
}
