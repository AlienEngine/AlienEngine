using System;

namespace AlienEngine.ASL
{
    public abstract partial class ASLShader
    {
        [BuiltIn]
        protected struct bvec2
        {
            public bvec2(bool all) { throw new NotImplementedException(); }
            public bvec2(bool x, bool y) { throw new NotImplementedException(); }

            public bool x { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bool y { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public bool r { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bool g { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public bool s { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bool t { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public bool this[int item] { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public static bvec2 operator +(bvec2 left, bvec2 right) { throw new NotImplementedException(); }
            public static bvec2 operator -(bvec2 left, bvec2 right) { throw new NotImplementedException(); }
            public static bvec2 operator *(bvec2 left, bvec2 right) { throw new NotImplementedException(); }
            public static bvec2 operator /(bvec2 left, bvec2 right) { throw new NotImplementedException(); }

            public bvec2 xx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec2 xy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec2 yx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec2 yy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 xxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 xxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 xyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 xyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 yxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 yxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 yyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 yyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xxxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xxxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xxyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xxyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xyxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xyxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xyyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xyyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yxxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yxxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yxyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yxyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yyxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yyxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yyyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yyyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
        }

        [BuiltIn]
        protected struct ivec2
        {
            public ivec2(int all) { throw new NotImplementedException(); }
            public ivec2(int x, int y) { throw new NotImplementedException(); }

            public int x { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public int y { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public int r { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public int g { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public int s { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public int t { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public int this[int item] { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public static ivec2 operator +(ivec2 left, ivec2 right) { throw new NotImplementedException(); }
            public static ivec2 operator -(ivec2 left, ivec2 right) { throw new NotImplementedException(); }
            public static ivec2 operator *(ivec2 left, ivec2 right) { throw new NotImplementedException(); }
            public static ivec2 operator /(ivec2 left, ivec2 right) { throw new NotImplementedException(); }

            public static implicit operator vec2(ivec2 v) { throw new NotImplementedException(); }

            public ivec2 rr { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec2 rg { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec2 gr { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec2 gg { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec2 ss { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec2 st { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec2 ts { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec2 tt { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec2 xx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec2 xy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec2 yx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec2 yy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 xxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 xxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 xyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 xyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 yxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 yxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 yyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 yyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xxxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xxxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xxyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xxyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xyxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xyxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xyyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xyyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yxxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yxxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yxyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yxyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yyxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yyxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yyyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yyyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
        }

        [BuiltIn]
        protected struct uvec2
        {
            public uvec2(uint all) { throw new NotImplementedException(); }
            public uvec2(uint x, uint y) { throw new NotImplementedException(); }

            public uint x { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uint y { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public uint r { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uint g { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public uint s { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uint t { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public uint this[int item] { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public static uvec2 operator +(uvec2 left, uvec2 right) { throw new NotImplementedException(); }
            public static uvec2 operator -(uvec2 left, uvec2 right) { throw new NotImplementedException(); }
            public static uvec2 operator *(uvec2 left, uvec2 right) { throw new NotImplementedException(); }
            public static uvec2 operator /(uvec2 left, uvec2 right) { throw new NotImplementedException(); }

            public static implicit operator vec2(uvec2 v) { throw new NotImplementedException(); }

            public uvec2 rr { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec2 rg { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec2 gr { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec2 gg { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec2 ss { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec2 st { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec2 ts { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec2 tt { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec2 xx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec2 xy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec2 yx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec2 yy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 xxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 xxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 xyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 xyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 yxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 yxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 yyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 yyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xxxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xxxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xxyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xxyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xyxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xyxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xyyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xyyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yxxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yxxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yxyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yxyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yyxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yyxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yyyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yyyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
        }

        [BuiltIn]
        protected struct vec2
        {
            public vec2(float all) { throw new NotImplementedException(); }
            public vec2(float x, float y) { throw new NotImplementedException(); }

            public float x { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public float y { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public float r { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public float g { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public float s { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public float t { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public float this[int item] { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public static vec2 operator +(vec2 left, vec2 right) { throw new NotImplementedException(); }
            public static vec2 operator -(vec2 vec) { throw new NotImplementedException(); }
            public static vec2 operator -(vec2 left, vec2 right) { throw new NotImplementedException(); }
            public static vec2 operator *(vec2 left, vec2 right) { throw new NotImplementedException(); }
            public static vec2 operator *(vec2 left, float right) { throw new NotImplementedException(); }
            public static vec2 operator *(float left, vec2 right) { throw new NotImplementedException(); }
            public static vec2 operator /(vec2 left, vec2 right) { throw new NotImplementedException(); }
            public static vec2 operator /(vec2 left, float right) { throw new NotImplementedException(); }

            public vec2 rr { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec2 rg { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec2 gr { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec2 gg { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec2 ss { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec2 st { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec2 ts { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec2 tt { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec2 xx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec2 xy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec2 yx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec2 yy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 xxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 xxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 xyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 xyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 yxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 yxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 yyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 yyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xxxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xxxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xxyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xxyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xyxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xyxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xyyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xyyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yxxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yxxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yxyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yxyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yyxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yyxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yyyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yyyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
        }

        [BuiltIn]
        protected struct dvec2
        {
            public dvec2(double all) { throw new NotImplementedException(); }
            public dvec2(double x, double y) { throw new NotImplementedException(); }

            public double x { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public double y { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public double r { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public double b { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public double s { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public double t { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public double this[int item] { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public static dvec2 operator +(dvec2 left, dvec2 right) { throw new NotImplementedException(); }
            public static dvec2 operator -(dvec2 left, dvec2 right) { throw new NotImplementedException(); }
            public static dvec2 operator *(dvec2 left, dvec2 right) { throw new NotImplementedException(); }
            public static dvec2 operator /(dvec2 left, dvec2 right) { throw new NotImplementedException(); }

            public dvec2 xx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec2 xy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec2 yx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec2 yy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 xxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 xxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 xyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 xyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 yxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 yxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 yyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 yyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xxxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xxxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xxyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xxyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xyxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xyxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xyyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xyyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yxxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yxxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yxyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yxyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yyxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yyxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yyyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yyyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
        }

        [BuiltIn]
        protected struct bvec3
        {
            public bvec3(bool all) { throw new NotImplementedException(); }
            public bvec3(bvec2 xy, bool z) { throw new NotImplementedException(); }
            public bvec3(bool x, bvec2 yz) { throw new NotImplementedException(); }
            public bvec3(bool x, bool y, bool z) { throw new NotImplementedException(); }

            public bool x { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bool y { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bool z { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public bool r { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bool g { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bool b { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public bool s { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bool t { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bool p { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public bool this[int item] { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public static bvec3 operator +(bvec3 left, bvec3 right) { throw new NotImplementedException(); }
            public static bvec3 operator -(bvec3 left, bvec3 right) { throw new NotImplementedException(); }
            public static bvec3 operator *(bvec3 left, bvec3 right) { throw new NotImplementedException(); }
            public static bvec3 operator /(bvec3 left, bvec3 right) { throw new NotImplementedException(); }

            public bvec2 xx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec2 xy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec2 xz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec2 yx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec2 yy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec2 yz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec2 zx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec2 zy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec2 zz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 xxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 xxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 xxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 xyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 xyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 xyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 xzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 xzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 xzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 yxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 yxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 yxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 yyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 yyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 yyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 yzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 yzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 yzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 zxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 zxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 zxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 zyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 zyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 zyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 zzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 zzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 zzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xxxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xxxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xxxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xxyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xxyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xxyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xxzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xxzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xxzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xyxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xyxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xyxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xyyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xyyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xyyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xyzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xyzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xyzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xzxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xzxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xzxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xzyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xzyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xzyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xzzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xzzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xzzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yxxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yxxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yxxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yxyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yxyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yxyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yxzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yxzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yxzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yyxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yyxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yyxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yyyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yyyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yyyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yyzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yyzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yyzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yzxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yzxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yzxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yzyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yzyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yzyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yzzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yzzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yzzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zxxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zxxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zxxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zxyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zxyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zxyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zxzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zxzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zxzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zyxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zyxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zyxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zyyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zyyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zyyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zyzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zyzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zyzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zzxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zzxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zzxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zzyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zzyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zzyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zzzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zzzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zzzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
        }

        [BuiltIn]
        protected struct ivec3
        {
            public ivec3(int all) { throw new NotImplementedException(); }
            public ivec3(ivec2 xy, int z) { throw new NotImplementedException(); }
            public ivec3(int x, ivec2 yz) { throw new NotImplementedException(); }
            public ivec3(int x, int y, int z) { throw new NotImplementedException(); }

            public int x { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public int y { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public int z { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public int r { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public int g { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public int b { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public int a { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public int s { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public int t { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public int p { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public int this[int item] { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public static ivec3 operator +(ivec3 left, ivec3 right) { throw new NotImplementedException(); }
            public static ivec3 operator -(ivec3 left, ivec3 right) { throw new NotImplementedException(); }
            public static ivec3 operator *(ivec3 left, ivec3 right) { throw new NotImplementedException(); }
            public static ivec3 operator /(ivec3 left, ivec3 right) { throw new NotImplementedException(); }

            public static implicit operator vec3(ivec3 v) { throw new NotImplementedException(); }

            public ivec2 xx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec2 xy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec2 xz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec2 yx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec2 yy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec2 yz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec2 zx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec2 zy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec2 zz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 xxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 xxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 xxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 xyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 xyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 xyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 xzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 xzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 xzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 yxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 yxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 yxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 yyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 yyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 yyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 yzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 yzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 yzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 zxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 zxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 zxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 zyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 zyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 zyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 zzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 zzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 zzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xxxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xxxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xxxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xxyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xxyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xxyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xxzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xxzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xxzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xyxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xyxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xyxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xyyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xyyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xyyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xyzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xyzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xyzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xzxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xzxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xzxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xzyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xzyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xzyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xzzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xzzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xzzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yxxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yxxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yxxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yxyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yxyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yxyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yxzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yxzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yxzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yyxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yyxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yyxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yyyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yyyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yyyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yyzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yyzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yyzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yzxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yzxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yzxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yzyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yzyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yzyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yzzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yzzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yzzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zxxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zxxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zxxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zxyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zxyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zxyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zxzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zxzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zxzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zyxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zyxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zyxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zyyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zyyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zyyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zyzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zyzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zyzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zzxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zzxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zzxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zzyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zzyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zzyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zzzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zzzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zzzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
        }

        [BuiltIn]
        protected struct uvec3
        {
            public uvec3(uint all) { throw new NotImplementedException(); }
            public uvec3(uvec2 xy, uint z) { throw new NotImplementedException(); }
            public uvec3(uint x, uvec2 yz) { throw new NotImplementedException(); }
            public uvec3(uint x, uint y, uint z) { throw new NotImplementedException(); }

            public uint x { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uint y { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uint z { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public uint r { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uint g { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uint b { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public uint s { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uint t { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uint p { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public uint this[int item] { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public static uvec3 operator +(uvec3 left, uvec3 right) { throw new NotImplementedException(); }
            public static uvec3 operator -(uvec3 left, uvec3 right) { throw new NotImplementedException(); }
            public static uvec3 operator *(uvec3 left, uvec3 right) { throw new NotImplementedException(); }
            public static uvec3 operator /(uvec3 left, uvec3 right) { throw new NotImplementedException(); }

            public static implicit operator vec3(uvec3 v) { throw new NotImplementedException(); }

            public uvec2 xx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec2 xy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec2 xz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec2 yx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec2 yy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec2 yz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec2 zx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec2 zy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec2 zz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 xxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 xxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 xxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 xyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 xyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 xyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 xzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 xzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 xzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 yxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 yxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 yxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 yyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 yyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 yyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 yzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 yzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 yzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 zxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 zxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 zxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 zyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 zyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 zyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 zzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 zzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 zzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xxxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xxxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xxxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xxyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xxyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xxyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xxzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xxzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xxzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xyxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xyxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xyxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xyyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xyyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xyyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xyzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xyzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xyzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xzxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xzxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xzxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xzyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xzyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xzyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xzzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xzzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xzzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yxxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yxxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yxxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yxyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yxyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yxyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yxzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yxzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yxzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yyxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yyxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yyxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yyyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yyyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yyyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yyzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yyzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yyzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yzxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yzxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yzxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yzyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yzyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yzyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yzzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yzzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yzzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zxxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zxxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zxxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zxyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zxyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zxyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zxzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zxzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zxzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zyxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zyxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zyxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zyyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zyyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zyyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zyzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zyzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zyzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zzxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zzxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zzxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zzyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zzyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zzyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zzzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zzzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zzzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
        }

        [BuiltIn]
        protected struct vec3
        {
            public vec3(float all) { throw new NotImplementedException(); }
            public vec3(vec2 xy, float z) { throw new NotImplementedException(); }
            public vec3(float x, vec2 yz) { throw new NotImplementedException(); }
            public vec3(float x, float y, float z) { throw new NotImplementedException(); }

            public float x { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public float y { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public float z { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public float r { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public float g { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public float b { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public float s { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public float t { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public float p { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public float this[int item] { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public static vec3 operator +(vec3 left, vec3 right) { throw new NotImplementedException(); }
            public static vec3 operator -(vec3 left, vec3 right) { throw new NotImplementedException(); }
            public static vec3 operator -(vec3 vec) { throw new NotImplementedException(); }
            public static vec3 operator *(vec3 left, vec3 right) { throw new NotImplementedException(); }
            public static vec3 operator *(vec3 left, float right) { throw new NotImplementedException(); }
            public static vec3 operator *(float left, vec3 right) { throw new NotImplementedException(); }
            public static vec3 operator /(vec3 left, vec3 right) { throw new NotImplementedException(); }
            public static vec3 operator /(vec3 left, float right) { throw new NotImplementedException(); }

            public vec2 xx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec2 xy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec2 xz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec2 yx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec2 yy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec2 yz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec2 zx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec2 zy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec2 zz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public vec3 xxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 xxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 xxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 xyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 xyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 xyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 xzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 xzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 xzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 yxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 yxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 yxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 yyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 yyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 yyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 yzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 yzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 yzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 zxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 zxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 zxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 zyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 zyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 zyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 zzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 zzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 zzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public vec4 xxxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xxxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xxxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xxyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xxyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xxyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xxzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xxzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xxzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xyxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xyxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xyxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xyyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xyyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xyyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xyzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xyzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xyzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xzxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xzxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xzxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xzyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xzyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xzyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xzzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xzzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xzzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yxxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yxxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yxxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yxyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yxyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yxyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yxzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yxzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yxzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yyxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yyxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yyxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yyyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yyyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yyyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yyzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yyzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yyzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yzxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yzxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yzxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yzyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yzyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yzyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yzzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yzzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yzzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zxxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zxxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zxxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zxyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zxyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zxyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zxzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zxzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zxzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zyxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zyxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zyxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zyyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zyyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zyyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zyzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zyzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zyzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zzxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zzxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zzxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zzyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zzyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zzyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zzzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zzzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zzzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
        }

        [BuiltIn]
        protected struct dvec3
        {
            public dvec3(double all) { throw new NotImplementedException(); }
            public dvec3(dvec2 xy, double z) { throw new NotImplementedException(); }
            public dvec3(double x, dvec2 yz) { throw new NotImplementedException(); }
            public dvec3(double x, double y, double z) { throw new NotImplementedException(); }

            public double x { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public double y { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public double z { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public double r { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public double g { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public double b { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public double s { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public double t { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public double p { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public double this[int item] { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public static dvec3 operator +(dvec3 left, dvec3 right) { throw new NotImplementedException(); }
            public static dvec3 operator -(dvec3 left, dvec3 right) { throw new NotImplementedException(); }
            public static dvec3 operator *(dvec3 left, dvec3 right) { throw new NotImplementedException(); }
            public static dvec3 operator /(dvec3 left, dvec3 right) { throw new NotImplementedException(); }

            public dvec2 xx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec2 xy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec2 xz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec2 yx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec2 yy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec2 yz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec2 zx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec2 zy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec2 zz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 xxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 xxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 xxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 xyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 xyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 xyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 xzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 xzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 xzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 yxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 yxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 yxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 yyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 yyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 yyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 yzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 yzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 yzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 zxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 zxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 zxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 zyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 zyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 zyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 zzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 zzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 zzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xxxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xxxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xxxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xxyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xxyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xxyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xxzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xxzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xxzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xyxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xyxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xyxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xyyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xyyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xyyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xyzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xyzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xyzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xzxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xzxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xzxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xzyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xzyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xzyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xzzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xzzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xzzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yxxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yxxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yxxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yxyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yxyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yxyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yxzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yxzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yxzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yyxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yyxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yyxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yyyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yyyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yyyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yyzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yyzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yyzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yzxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yzxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yzxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yzyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yzyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yzyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yzzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yzzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yzzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zxxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zxxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zxxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zxyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zxyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zxyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zxzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zxzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zxzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zyxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zyxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zyxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zyyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zyyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zyyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zyzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zyzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zyzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zzxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zzxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zzxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zzyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zzyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zzyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zzzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zzzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zzzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
        }

        [BuiltIn]
        protected struct bvec4
        {
            public bvec4(bool all) { throw new NotImplementedException(); }
            public bvec4(bvec3 xyz, bool w) { throw new NotImplementedException(); }
            public bvec4(bool x, bvec3 yzw) { throw new NotImplementedException(); }
            public bvec4(bvec2 xy, bvec2 zw) { throw new NotImplementedException(); }
            public bvec4(bvec2 xy, bool z, bool w) { throw new NotImplementedException(); }
            public bvec4(bool x, bvec2 zw, bool y) { throw new NotImplementedException(); }
            public bvec4(bool x, bool y, bvec2 zw) { throw new NotImplementedException(); }
            public bvec4(bool x, bool y, bool z, bool w) { throw new NotImplementedException(); }

            public bool x { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bool y { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bool z { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bool w { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public bool r { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bool g { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bool b { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bool a { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public bool s { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bool t { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bool p { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bool q { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public bool this[int item] { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public static bvec4 operator +(bvec4 left, bvec4 right) { throw new NotImplementedException(); }
            public static bvec4 operator -(bvec4 left, bvec4 right) { throw new NotImplementedException(); }
            public static bvec4 operator *(bvec4 left, bvec4 right) { throw new NotImplementedException(); }
            public static bvec4 operator /(bvec4 left, bvec4 right) { throw new NotImplementedException(); }

            public bvec2 xx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec2 xy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec2 xz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec2 xw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec2 yx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec2 yy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec2 yz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec2 yw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec2 zx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec2 zy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec2 zz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec2 zw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec2 wx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec2 wy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec2 wz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec2 ww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 xxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 xxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 xxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 xxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 xyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 xyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 xyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 xyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 xzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 xzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 xzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 xzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 xwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 xwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 xwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 xww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 yxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 yxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 yxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 yxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 yyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 yyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 yyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 yyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 yzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 yzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 yzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 yzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 ywx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 ywy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 ywz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 yww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 zxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 zxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 zxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 zxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 zyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 zyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 zyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 zyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 zzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 zzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 zzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 zzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 zwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 zwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 zwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 zww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 wxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 wxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 wxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 wxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 wyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 wyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 wyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 wyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 wzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 wzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 wzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 wzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 wwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 wwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 wwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec3 www { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xxxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xxxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xxxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xxxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xxyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xxyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xxyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xxyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xxzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xxzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xxzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xxzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xxwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xxwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xxwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xxww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xyxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xyxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xyxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xyxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xyyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xyyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xyyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xyyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xyzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xyzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xyzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xyzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xywx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xywy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xywz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xyww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xzxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xzxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xzxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xzxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xzyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xzyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xzyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xzyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xzzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xzzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xzzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xzzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xzwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xzwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xzwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xzww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xwxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xwxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xwxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xwxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xwyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xwyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xwyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xwyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xwzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xwzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xwzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xwzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xwwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xwwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xwwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 xwww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yxxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yxxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yxxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yxxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yxyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yxyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yxyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yxyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yxzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yxzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yxzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yxzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yxwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yxwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yxwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yxww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yyxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yyxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yyxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yyxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yyyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yyyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yyyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yyyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yyzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yyzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yyzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yyzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yywx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yywy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yywz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yyww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yzxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yzxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yzxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yzxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yzyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yzyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yzyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yzyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yzzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yzzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yzzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yzzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yzwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yzwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yzwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 yzww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 ywxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 ywxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 ywxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 ywxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 ywyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 ywyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 ywyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 ywyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 ywzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 ywzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 ywzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 ywzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 ywwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 ywwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 ywwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 ywww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zxxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zxxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zxxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zxxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zxyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zxyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zxyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zxyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zxzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zxzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zxzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zxzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zxwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zxwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zxwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zxww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zyxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zyxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zyxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zyxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zyyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zyyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zyyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zyyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zyzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zyzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zyzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zyzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zywx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zywy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zywz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zyww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zzxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zzxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zzxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zzxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zzyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zzyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zzyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zzyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zzzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zzzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zzzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zzzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zzwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zzwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zzwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zzww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zwxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zwxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zwxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zwxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zwyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zwyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zwyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zwyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zwzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zwzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zwzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zwzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zwwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zwwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zwwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 zwww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wxxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wxxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wxxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wxxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wxyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wxyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wxyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wxyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wxzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wxzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wxzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wxzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wxwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wxwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wxwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wxww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wyxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wyxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wyxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wyxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wyyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wyyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wyyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wyyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wyzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wyzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wyzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wyzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wywx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wywy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wywz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wyww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wzxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wzxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wzxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wzxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wzyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wzyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wzyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wzyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wzzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wzzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wzzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wzzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wzwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wzwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wzwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wzww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wwxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wwxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wwxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wwxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wwyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wwyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wwyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wwyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wwzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wwzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wwzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wwzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wwwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wwwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wwwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public bvec4 wwww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
        }

        [BuiltIn]
        protected struct ivec4
        {
            public ivec4(int all) { throw new NotImplementedException(); }
            public ivec4(ivec3 xyz, int w) { throw new NotImplementedException(); }
            public ivec4(int x, ivec3 yzw) { throw new NotImplementedException(); }
            public ivec4(ivec2 xy, ivec2 zw) { throw new NotImplementedException(); }
            public ivec4(ivec2 xy, int z, int w) { throw new NotImplementedException(); }
            public ivec4(int x, ivec2 zw, int y) { throw new NotImplementedException(); }
            public ivec4(int x, int y, ivec2 zw) { throw new NotImplementedException(); }
            public ivec4(int x, int y, int z, int w) { throw new NotImplementedException(); }

            public int x { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public int y { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public int z { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public int w { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public int r { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public int g { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public int b { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public int a { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public int s { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public int t { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public int p { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public int q { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public int this[int item] { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public static ivec4 operator +(ivec4 left, ivec4 right) { throw new NotImplementedException(); }
            public static ivec4 operator -(ivec4 left, ivec4 right) { throw new NotImplementedException(); }
            public static ivec4 operator *(ivec4 left, ivec4 right) { throw new NotImplementedException(); }
            public static ivec4 operator /(ivec4 left, ivec4 right) { throw new NotImplementedException(); }

            public static implicit operator vec4(ivec4 v) { throw new NotImplementedException(); }

            public ivec2 xx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec2 xy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec2 xz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec2 xw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec2 yx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec2 yy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec2 yz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec2 yw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec2 zx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec2 zy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec2 zz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec2 zw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec2 wx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec2 wy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec2 wz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec2 ww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 xxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 xxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 xxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 xxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 xyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 xyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 xyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 xyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 xzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 xzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 xzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 xzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 xwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 xwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 xwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 xww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 yxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 yxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 yxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 yxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 yyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 yyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 yyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 yyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 yzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 yzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 yzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 yzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 ywx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 ywy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 ywz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 yww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 zxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 zxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 zxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 zxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 zyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 zyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 zyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 zyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 zzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 zzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 zzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 zzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 zwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 zwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 zwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 zww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 wxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 wxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 wxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 wxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 wyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 wyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 wyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 wyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 wzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 wzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 wzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 wzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 wwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 wwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 wwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec3 www { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xxxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xxxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xxxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xxxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xxyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xxyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xxyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xxyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xxzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xxzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xxzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xxzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xxwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xxwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xxwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xxww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xyxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xyxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xyxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xyxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xyyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xyyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xyyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xyyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xyzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xyzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xyzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xyzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xywx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xywy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xywz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xyww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xzxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xzxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xzxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xzxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xzyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xzyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xzyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xzyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xzzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xzzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xzzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xzzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xzwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xzwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xzwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xzww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xwxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xwxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xwxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xwxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xwyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xwyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xwyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xwyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xwzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xwzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xwzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xwzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xwwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xwwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xwwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 xwww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yxxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yxxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yxxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yxxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yxyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yxyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yxyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yxyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yxzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yxzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yxzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yxzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yxwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yxwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yxwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yxww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yyxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yyxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yyxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yyxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yyyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yyyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yyyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yyyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yyzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yyzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yyzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yyzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yywx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yywy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yywz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yyww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yzxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yzxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yzxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yzxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yzyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yzyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yzyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yzyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yzzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yzzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yzzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yzzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yzwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yzwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yzwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 yzww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 ywxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 ywxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 ywxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 ywxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 ywyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 ywyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 ywyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 ywyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 ywzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 ywzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 ywzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 ywzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 ywwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 ywwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 ywwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 ywww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zxxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zxxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zxxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zxxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zxyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zxyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zxyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zxyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zxzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zxzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zxzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zxzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zxwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zxwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zxwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zxww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zyxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zyxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zyxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zyxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zyyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zyyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zyyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zyyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zyzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zyzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zyzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zyzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zywx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zywy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zywz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zyww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zzxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zzxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zzxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zzxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zzyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zzyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zzyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zzyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zzzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zzzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zzzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zzzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zzwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zzwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zzwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zzww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zwxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zwxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zwxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zwxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zwyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zwyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zwyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zwyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zwzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zwzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zwzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zwzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zwwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zwwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zwwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 zwww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wxxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wxxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wxxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wxxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wxyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wxyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wxyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wxyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wxzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wxzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wxzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wxzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wxwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wxwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wxwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wxww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wyxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wyxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wyxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wyxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wyyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wyyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wyyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wyyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wyzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wyzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wyzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wyzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wywx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wywy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wywz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wyww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wzxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wzxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wzxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wzxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wzyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wzyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wzyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wzyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wzzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wzzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wzzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wzzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wzwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wzwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wzwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wzww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wwxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wwxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wwxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wwxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wwyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wwyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wwyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wwyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wwzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wwzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wwzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wwzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wwwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wwwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wwwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public ivec4 wwww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
        }

        [BuiltIn]
        protected struct uvec4
        {
            public uvec4(uint all) { throw new NotImplementedException(); }
            public uvec4(uvec3 xyz, uint w) { throw new NotImplementedException(); }
            public uvec4(uint x, uvec3 yzw) { throw new NotImplementedException(); }
            public uvec4(uvec2 xy, uvec2 zw) { throw new NotImplementedException(); }
            public uvec4(uvec2 xy, uint z, uint w) { throw new NotImplementedException(); }
            public uvec4(uint x, uvec2 zw, uint y) { throw new NotImplementedException(); }
            public uvec4(uint x, uint y, uvec2 zw) { throw new NotImplementedException(); }
            public uvec4(uint x, uint y, uint z, uint w) { throw new NotImplementedException(); }

            public uint x { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uint y { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uint z { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uint w { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public uint r { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uint g { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uint b { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uint a { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public uint s { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uint t { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uint p { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uint q { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public uint this[int item] { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public static uvec4 operator +(uvec4 left, uvec4 right) { throw new NotImplementedException(); }
            public static uvec4 operator -(uvec4 left, uvec4 right) { throw new NotImplementedException(); }
            public static uvec4 operator *(uvec4 left, uvec4 right) { throw new NotImplementedException(); }
            public static uvec4 operator /(uvec4 left, uvec4 right) { throw new NotImplementedException(); }

            public static implicit operator vec4(uvec4 v) { throw new NotImplementedException(); }

            public uvec2 xx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec2 xy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec2 xz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec2 xw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec2 yx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec2 yy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec2 yz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec2 yw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec2 zx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec2 zy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec2 zz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec2 zw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec2 wx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec2 wy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec2 wz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec2 ww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 xxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 xxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 xxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 xxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 xyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 xyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 xyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 xyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 xzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 xzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 xzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 xzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 xwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 xwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 xwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 xww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 yxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 yxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 yxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 yxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 yyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 yyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 yyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 yyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 yzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 yzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 yzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 yzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 ywx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 ywy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 ywz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 yww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 zxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 zxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 zxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 zxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 zyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 zyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 zyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 zyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 zzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 zzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 zzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 zzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 zwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 zwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 zwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 zww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 wxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 wxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 wxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 wxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 wyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 wyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 wyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 wyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 wzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 wzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 wzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 wzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 wwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 wwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 wwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec3 www { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xxxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xxxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xxxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xxxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xxyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xxyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xxyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xxyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xxzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xxzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xxzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xxzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xxwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xxwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xxwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xxww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xyxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xyxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xyxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xyxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xyyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xyyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xyyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xyyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xyzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xyzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xyzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xyzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xywx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xywy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xywz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xyww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xzxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xzxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xzxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xzxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xzyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xzyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xzyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xzyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xzzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xzzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xzzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xzzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xzwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xzwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xzwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xzww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xwxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xwxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xwxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xwxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xwyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xwyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xwyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xwyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xwzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xwzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xwzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xwzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xwwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xwwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xwwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 xwww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yxxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yxxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yxxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yxxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yxyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yxyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yxyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yxyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yxzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yxzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yxzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yxzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yxwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yxwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yxwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yxww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yyxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yyxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yyxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yyxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yyyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yyyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yyyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yyyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yyzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yyzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yyzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yyzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yywx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yywy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yywz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yyww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yzxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yzxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yzxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yzxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yzyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yzyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yzyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yzyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yzzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yzzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yzzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yzzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yzwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yzwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yzwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 yzww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 ywxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 ywxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 ywxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 ywxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 ywyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 ywyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 ywyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 ywyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 ywzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 ywzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 ywzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 ywzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 ywwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 ywwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 ywwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 ywww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zxxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zxxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zxxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zxxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zxyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zxyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zxyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zxyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zxzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zxzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zxzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zxzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zxwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zxwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zxwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zxww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zyxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zyxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zyxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zyxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zyyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zyyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zyyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zyyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zyzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zyzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zyzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zyzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zywx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zywy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zywz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zyww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zzxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zzxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zzxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zzxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zzyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zzyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zzyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zzyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zzzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zzzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zzzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zzzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zzwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zzwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zzwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zzww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zwxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zwxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zwxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zwxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zwyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zwyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zwyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zwyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zwzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zwzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zwzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zwzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zwwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zwwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zwwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 zwww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wxxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wxxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wxxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wxxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wxyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wxyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wxyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wxyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wxzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wxzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wxzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wxzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wxwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wxwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wxwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wxww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wyxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wyxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wyxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wyxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wyyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wyyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wyyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wyyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wyzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wyzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wyzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wyzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wywx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wywy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wywz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wyww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wzxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wzxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wzxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wzxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wzyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wzyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wzyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wzyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wzzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wzzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wzzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wzzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wzwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wzwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wzwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wzww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wwxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wwxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wwxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wwxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wwyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wwyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wwyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wwyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wwzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wwzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wwzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wwzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wwwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wwwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wwwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public uvec4 wwww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
        }

        [BuiltIn]
        protected struct vec4
        {
            public vec4(float all) { }
            public vec4(vec3 xyz, float w) { }
            public vec4(float x, vec3 yzw) { }
            public vec4(vec2 xy, vec2 zw) { }
            public vec4(vec2 xy, float z, float w) { }
            public vec4(float x, vec2 zw, float y) { }
            public vec4(float x, float y, vec2 zw) { }
            public vec4(float x, float y, float z, float w) { }

            public float x { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public float y { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public float z { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public float w { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public float r { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public float g { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public float b { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public float a { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public float s { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public float t { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public float p { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public float q { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public float this[int item] { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public static vec4 operator +(vec4 left, vec4 right) { throw new NotImplementedException(); }
            public static vec4 operator -(vec4 left, vec4 right) { throw new NotImplementedException(); }
            public static vec4 operator *(vec4 left, vec4 right) { throw new NotImplementedException(); }
            public static vec4 operator *(vec4 left, float right) { throw new NotImplementedException(); }
            public static vec4 operator *(float left, vec4 right) { throw new NotImplementedException(); }
            public static vec4 operator /(vec4 left, vec4 right) { throw new NotImplementedException(); }
            public static vec4 operator /(vec4 left, float right) { throw new NotImplementedException(); }

            public vec2 xx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec2 xy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec2 xz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec2 xw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec2 yx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec2 yy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec2 yz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec2 yw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec2 zx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec2 zy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec2 zz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec2 zw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec2 wx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec2 wy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec2 wz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec2 ww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public vec3 xxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 xxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 xxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 xxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 xyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 xyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 xyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 xyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 xzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 xzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 xzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 xzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 xwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 xwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 xwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 xww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 yxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 yxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 yxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 yxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 yyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 yyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 yyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 yyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 yzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 yzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 yzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 yzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 ywx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 ywy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 ywz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 yww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 zxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 zxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 zxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 zxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 zyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 zyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 zyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 zyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 zzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 zzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 zzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 zzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 zwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 zwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 zwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 zww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 wxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 wxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 wxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 wxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 wyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 wyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 wyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 wyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 wzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 wzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 wzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 wzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 wwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 wwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 wwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 www { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public vec3 rgb { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 rbg { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 brg { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 bgr { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 gbr { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec3 grb { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public vec4 xxxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xxxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xxxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xxxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xxyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xxyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xxyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xxyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xxzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xxzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xxzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xxzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xxwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xxwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xxwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xxww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xyxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xyxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xyxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xyxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xyyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xyyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xyyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xyyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xyzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xyzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xyzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xyzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xywx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xywy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xywz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xyww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xzxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xzxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xzxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xzxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xzyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xzyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xzyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xzyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xzzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xzzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xzzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xzzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xzwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xzwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xzwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xzww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xwxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xwxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xwxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xwxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xwyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xwyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xwyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xwyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xwzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xwzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xwzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xwzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xwwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xwwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xwwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 xwww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yxxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yxxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yxxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yxxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yxyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yxyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yxyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yxyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yxzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yxzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yxzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yxzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yxwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yxwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yxwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yxww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yyxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yyxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yyxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yyxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yyyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yyyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yyyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yyyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yyzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yyzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yyzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yyzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yywx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yywy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yywz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yyww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yzxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yzxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yzxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yzxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yzyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yzyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yzyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yzyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yzzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yzzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yzzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yzzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yzwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yzwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yzwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 yzww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 ywxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 ywxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 ywxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 ywxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 ywyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 ywyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 ywyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 ywyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 ywzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 ywzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 ywzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 ywzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 ywwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 ywwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 ywwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 ywww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zxxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zxxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zxxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zxxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zxyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zxyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zxyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zxyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zxzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zxzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zxzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zxzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zxwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zxwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zxwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zxww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zyxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zyxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zyxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zyxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zyyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zyyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zyyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zyyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zyzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zyzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zyzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zyzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zywx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zywy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zywz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zyww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zzxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zzxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zzxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zzxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zzyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zzyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zzyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zzyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zzzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zzzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zzzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zzzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zzwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zzwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zzwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zzww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zwxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zwxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zwxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zwxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zwyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zwyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zwyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zwyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zwzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zwzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zwzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zwzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zwwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zwwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zwwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 zwww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wxxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wxxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wxxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wxxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wxyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wxyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wxyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wxyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wxzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wxzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wxzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wxzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wxwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wxwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wxwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wxww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wyxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wyxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wyxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wyxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wyyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wyyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wyyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wyyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wyzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wyzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wyzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wyzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wywx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wywy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wywz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wyww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wzxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wzxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wzxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wzxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wzyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wzyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wzyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wzyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wzzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wzzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wzzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wzzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wzwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wzwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wzwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wzww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wwxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wwxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wwxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wwxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wwyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wwyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wwyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wwyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wwzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wwzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wwzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wwzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wwwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wwwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wwwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 wwww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public vec4 rgba { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 rbga { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 brga { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 bgra { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 gbra { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public vec4 grba { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
        }

        [BuiltIn]
        protected struct dvec4
        {
            public dvec4(double all) { throw new NotImplementedException(); }
            public dvec4(dvec3 xyz, double w) { throw new NotImplementedException(); }
            public dvec4(double x, dvec3 yzw) { throw new NotImplementedException(); }
            public dvec4(dvec2 xy, dvec2 zw) { throw new NotImplementedException(); }
            public dvec4(dvec2 xy, double z, double w) { throw new NotImplementedException(); }
            public dvec4(double x, dvec2 zw, double y) { throw new NotImplementedException(); }
            public dvec4(double x, double y, dvec2 zw) { throw new NotImplementedException(); }
            public dvec4(double x, double y, double z, double w) { throw new NotImplementedException(); }

            public double x { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public double y { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public double z { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public double w { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public double r { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public double g { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public double b { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public double a { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public double s { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public double t { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public double p { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public double q { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public double this[int item] { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }

            public static dvec4 operator +(dvec4 left, dvec4 right) { throw new NotImplementedException(); }
            public static dvec4 operator -(dvec4 left, dvec4 right) { throw new NotImplementedException(); }
            public static dvec4 operator *(dvec4 left, dvec4 right) { throw new NotImplementedException(); }
            public static dvec4 operator /(dvec4 left, dvec4 right) { throw new NotImplementedException(); }

            public dvec2 xx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec2 xy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec2 xz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec2 xw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec2 yx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec2 yy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec2 yz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec2 yw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec2 zx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec2 zy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec2 zz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec2 zw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec2 wx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec2 wy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec2 wz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec2 ww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 xxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 xxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 xxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 xxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 xyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 xyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 xyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 xyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 xzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 xzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 xzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 xzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 xwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 xwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 xwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 xww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 yxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 yxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 yxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 yxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 yyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 yyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 yyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 yyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 yzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 yzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 yzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 yzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 ywx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 ywy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 ywz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 yww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 zxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 zxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 zxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 zxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 zyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 zyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 zyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 zyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 zzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 zzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 zzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 zzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 zwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 zwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 zwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 zww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 wxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 wxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 wxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 wxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 wyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 wyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 wyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 wyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 wzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 wzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 wzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 wzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 wwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 wwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 wwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec3 www { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xxxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xxxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xxxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xxxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xxyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xxyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xxyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xxyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xxzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xxzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xxzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xxzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xxwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xxwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xxwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xxww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xyxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xyxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xyxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xyxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xyyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xyyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xyyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xyyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xyzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xyzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xyzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xyzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xywx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xywy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xywz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xyww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xzxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xzxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xzxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xzxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xzyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xzyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xzyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xzyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xzzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xzzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xzzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xzzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xzwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xzwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xzwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xzww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xwxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xwxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xwxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xwxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xwyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xwyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xwyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xwyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xwzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xwzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xwzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xwzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xwwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xwwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xwwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 xwww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yxxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yxxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yxxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yxxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yxyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yxyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yxyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yxyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yxzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yxzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yxzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yxzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yxwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yxwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yxwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yxww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yyxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yyxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yyxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yyxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yyyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yyyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yyyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yyyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yyzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yyzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yyzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yyzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yywx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yywy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yywz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yyww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yzxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yzxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yzxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yzxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yzyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yzyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yzyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yzyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yzzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yzzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yzzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yzzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yzwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yzwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yzwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 yzww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 ywxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 ywxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 ywxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 ywxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 ywyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 ywyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 ywyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 ywyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 ywzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 ywzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 ywzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 ywzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 ywwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 ywwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 ywwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 ywww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zxxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zxxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zxxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zxxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zxyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zxyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zxyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zxyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zxzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zxzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zxzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zxzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zxwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zxwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zxwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zxww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zyxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zyxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zyxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zyxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zyyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zyyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zyyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zyyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zyzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zyzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zyzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zyzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zywx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zywy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zywz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zyww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zzxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zzxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zzxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zzxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zzyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zzyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zzyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zzyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zzzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zzzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zzzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zzzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zzwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zzwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zzwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zzww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zwxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zwxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zwxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zwxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zwyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zwyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zwyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zwyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zwzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zwzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zwzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zwzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zwwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zwwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zwwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 zwww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wxxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wxxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wxxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wxxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wxyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wxyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wxyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wxyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wxzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wxzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wxzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wxzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wxwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wxwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wxwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wxww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wyxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wyxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wyxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wyxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wyyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wyyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wyyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wyyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wyzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wyzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wyzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wyzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wywx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wywy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wywz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wyww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wzxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wzxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wzxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wzxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wzyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wzyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wzyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wzyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wzzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wzzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wzzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wzzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wzwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wzwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wzwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wzww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wwxx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wwxy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wwxz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wwxw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wwyx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wwyy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wwyz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wwyw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wwzx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wwzy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wwzz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wwzw { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wwwx { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wwwy { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wwwz { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
            public dvec4 wwww { get { throw new NotImplementedException(); } set { throw new NotImplementedException(); } }
        }
    }
}
