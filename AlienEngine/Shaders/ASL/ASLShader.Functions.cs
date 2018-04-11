using System;

namespace AlienEngine.Shaders.ASL
{
    public abstract partial class ASLShader
    {
        [BuiltIn]
        protected float radians(float degrees) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec2 radians(vec2 degrees) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 radians(vec3 degrees) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 radians(vec4 degrees) { throw new NotImplementedException(); }

        [BuiltIn]
        protected float degrees(float radians) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec2 degrees(vec2 radians) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 degrees(vec3 radians) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 degrees(vec4 radians) { throw new NotImplementedException(); }

        [BuiltIn]
        protected float sin(float angle) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec2 sin(vec2 angle) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 sin(vec3 angle) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 sin(vec4 angle) { throw new NotImplementedException(); }

        [BuiltIn]
        protected float cos(float angle) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec2 cos(vec2 angle) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 cos(vec3 angle) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 cos(vec4 angle) { throw new NotImplementedException(); }

        [BuiltIn]
        protected float tan(float angle) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec2 tan(vec2 angle) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 tan(vec3 angle) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 tan(vec4 angle) { throw new NotImplementedException(); }

        [BuiltIn]
        protected float asin(float angle) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec2 asin(vec2 angle) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 asin(vec3 angle) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 asin(vec4 angle) { throw new NotImplementedException(); }

        [BuiltIn]
        protected float acos(float angle) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec2 acos(vec2 angle) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 acos(vec3 angle) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 acos(vec4 angle) { throw new NotImplementedException(); }

        [BuiltIn]
        protected float atan(float y, float x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec2 atan(vec2 y, vec2 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 atan(vec3 y, vec3 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 atan(vec4 y, vec4 x) { throw new NotImplementedException(); }

        [BuiltIn]
        protected float atan(float yOverX) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec2 atan(vec2 yOverX) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 atan(vec3 yOverX) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 atan(vec4 yOverX) { throw new NotImplementedException(); }

        [BuiltIn]
        protected float sinh(float x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec2 sinh(vec2 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 sinh(vec3 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 sinh(vec4 x) { throw new NotImplementedException(); }

        [BuiltIn]
        protected float cosh(float x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec2 cosh(vec2 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 cosh(vec3 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 cosh(vec4 x) { throw new NotImplementedException(); }

        [BuiltIn]
        protected float tanh(float x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec2 tanh(vec2 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 tanh(vec3 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 tanh(vec4 x) { throw new NotImplementedException(); }

        [BuiltIn]
        protected float asinh(float x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec2 asinh(vec2 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 asinh(vec3 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 asinh(vec4 x) { throw new NotImplementedException(); }

        [BuiltIn]
        protected float acosh(float x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec2 acosh(vec2 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 acosh(vec3 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 acosh(vec4 x) { throw new NotImplementedException(); }

        [BuiltIn]
        protected float atanh(float x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec2 atanh(vec2 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 atanh(vec3 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 atanh(vec4 x) { throw new NotImplementedException(); }

        // Exponential Functions

        [BuiltIn]
        protected float pow(float x, float y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec2 pow(vec2 x, vec2 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 pow(vec3 x, vec3 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 pow(vec4 x, vec4 y) { throw new NotImplementedException(); }

        [BuiltIn]
        protected float exp(float x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec2 exp(vec2 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 exp(vec3 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 exp(vec4 x) { throw new NotImplementedException(); }

        [BuiltIn]
        protected float log(float x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec2 log(vec2 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 log(vec3 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 log(vec4 x) { throw new NotImplementedException(); }

        [BuiltIn]
        protected float exp2(float x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec2 exp2(vec2 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 exp2(vec3 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 exp2(vec4 x) { throw new NotImplementedException(); }

        [BuiltIn]
        protected float log2(float x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec2 log2(vec2 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 log2(vec3 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 log2(vec4 x) { throw new NotImplementedException(); }

        [BuiltIn]
        protected float sqrt(float x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec2 sqrt(vec2 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 sqrt(vec3 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 sqrt(vec4 x) { throw new NotImplementedException(); }

        [BuiltIn]
        protected float inversesqrt(float x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec2 inversesqrt(vec2 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 inversesqrt(vec3 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 inversesqrt(vec4 x) { throw new NotImplementedException(); }

        // Common Functions

        [BuiltIn]
        protected float abs(float x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec2 abs(vec2 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 abs(vec3 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 abs(vec4 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected int abs(int x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec2 abs(ivec2 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec3 abs(ivec3 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 abs(ivec4 x) { throw new NotImplementedException(); }

        [BuiltIn]
        protected float sign(float x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec2 sign(vec2 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 sign(vec3 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 sign(vec4 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected int sign(int x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec2 sign(ivec2 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec3 sign(ivec3 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 sign(ivec4 x) { throw new NotImplementedException(); }

        [BuiltIn]
        protected float floor(float x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec2 floor(vec2 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 floor(vec3 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 floor(vec4 x) { throw new NotImplementedException(); }

        [BuiltIn]
        protected float trunc(float x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec2 trunc(vec2 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 trunc(vec3 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 trunc(vec4 x) { throw new NotImplementedException(); }

        [BuiltIn]
        protected float round(float x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec2 round(vec2 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 round(vec3 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 round(vec4 x) { throw new NotImplementedException(); }

        [BuiltIn]
        protected float roundEven(float x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec2 roundEven(vec2 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 roundEven(vec3 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 roundEven(vec4 x) { throw new NotImplementedException(); }

        [BuiltIn]
        protected float ceil(float x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec2 ceil(vec2 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 ceil(vec3 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 ceil(vec4 x) { throw new NotImplementedException(); }

        [BuiltIn]
        protected float fract(float x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec2 fract(vec2 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 fract(vec3 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 fract(vec4 x) { throw new NotImplementedException(); }

        [BuiltIn]
        protected float mod(float x, float y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec2 mod(vec2 x, vec2 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 mod(vec3 x, vec3 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 mod(vec4 x, vec4 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec2 mod(vec2 x, float y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 mod(vec3 x, float y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 mod(vec4 x, float y) { throw new NotImplementedException(); }

        [BuiltIn]
        protected float modf(float x, out float y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec2 modf(vec2 x, out vec2 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 modf(vec3 x, out vec3 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 modf(vec4 x, out vec4 y) { throw new NotImplementedException(); }

        [BuiltIn]
        protected float min(float x, float y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec2 min(vec2 x, vec2 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 min(vec3 x, vec3 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 min(vec4 x, vec4 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec2 min(vec2 x, float y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 min(vec3 x, float y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 min(vec4 x, float y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected int min(int x, int y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec2 min(ivec2 x, ivec2 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec3 min(ivec3 x, ivec3 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 min(ivec4 x, ivec4 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec2 min(ivec2 x, int y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec3 min(ivec3 x, int y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 min(ivec4 x, int y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uint min(uint x, uint y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec2 min(uvec2 x, uvec2 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec3 min(uvec3 x, uvec3 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 min(uvec4 x, uvec4 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec2 min(uvec2 x, uint y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec3 min(uvec3 x, uint y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 min(uvec4 x, uint y) { throw new NotImplementedException(); }

        [BuiltIn]
        protected float max(float x, float y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec2 max(vec2 x, vec2 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 max(vec3 x, vec3 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 max(vec4 x, vec4 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec2 max(vec2 x, float y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 max(vec3 x, float y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 max(vec4 x, float y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected int max(int x, int y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec2 max(ivec2 x, ivec2 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec3 max(ivec3 x, ivec3 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 max(ivec4 x, ivec4 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec2 max(ivec2 x, int y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec3 max(ivec3 x, int y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 max(ivec4 x, int y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uint max(uint x, uint y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec2 max(uvec2 x, uvec2 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec3 max(uvec3 x, uvec3 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 max(uvec4 x, uvec4 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec2 max(uvec2 x, uint y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec3 max(uvec3 x, uint y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 max(uvec4 x, uint y) { throw new NotImplementedException(); }

        [BuiltIn]
        protected float clamp(float x, float minVal, float maxVal) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec2 clamp(vec2 x, vec2 minVal, vec2 maxVal) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 clamp(vec3 x, vec3 minVal, vec3 maxVal) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 clamp(vec4 x, vec4 minVal, vec4 maxVal) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec2 clamp(vec2 x, float minVal, float maxVal) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 clamp(vec3 x, float minVal, float maxVal) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 clamp(vec4 x, float minVal, float maxVal) { throw new NotImplementedException(); }
        [BuiltIn]
        protected int clamp(int x, int minVal, int maxVal) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec2 clamp(ivec2 x, ivec2 minVal, ivec2 maxVal) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec3 clamp(ivec3 x, ivec3 minVal, ivec3 maxVal) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 clamp(ivec4 x, ivec4 minVal, ivec4 maxVal) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec2 clamp(ivec2 x, int minVal, int maxVal) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec3 clamp(ivec3 x, int minVal, int maxVal) { throw new NotImplementedException(); }
        [BuiltIn]
        protected ivec4 clamp(ivec4 x, int minVal, int maxVal) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uint clamp(uint x, uint y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec2 clamp(uvec2 x, uvec2 minVal, uvec2 maxVal) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec3 clamp(uvec3 x, uvec3 minVal, uvec3 maxVal) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 clamp(uvec4 x, uvec4 minVal, uvec4 maxVal) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec2 clamp(uvec2 x, uint minVal, uint maxVal) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec3 clamp(uvec3 x, uint minVal, uint maxVal) { throw new NotImplementedException(); }
        [BuiltIn]
        protected uvec4 clamp(uvec4 x, uint minVal, uint maxVal) { throw new NotImplementedException(); }

        [BuiltIn]
        protected float mix(float x, float y, float a) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec2 mix(vec2 x, vec2 y, vec2 a) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 mix(vec3 x, vec3 y, vec3 a) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 mix(vec4 x, vec4 y, vec4 a) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec2 mix(vec2 x, vec2 y, float a) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 mix(vec3 x, vec2 y, float a) { throw new NotImplementedException(); }
        protected vec3 mix(vec3 x, vec3 y, float a) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 mix(vec4 x, vec2 y, float a) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec2 mix(float x, float y, bool a) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec2 mix(vec2 x, vec2 y, bvec2 a) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 mix(vec3 x, vec3 y, bvec3 a) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 mix(vec4 x, vec4 y, bvec4 a) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 mix(vec4 x, vec4 y, float a) { throw new NotImplementedException(); }

        [BuiltIn]
        protected float step(float edge, float x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec2 step(vec2 edge, vec2 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 step(vec3 edge, vec3 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 step(vec4 edge, vec4 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec2 step(float edge, vec2 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 step(float edge, vec3 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 step(float edge, vec4 x) { throw new NotImplementedException(); }

        [BuiltIn]
        protected float smoothstep(float edge0, float edge1, float x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec2 smoothstep(vec2 edge0, vec2 edge1, vec2 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 smoothstep(vec3 edge0, vec2 edge1, vec3 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 smoothstep(vec4 edge0, vec2 edge1, vec4 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec2 smoothstep(float edge0, float edge1, vec2 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 smoothstep(float edge0, float edge1, vec3 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 smoothstep(float edge0, float edge1, vec4 x) { throw new NotImplementedException(); }

        [BuiltIn]
        protected bool isnan(float x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec2 isnan(vec2 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec3 isnan(vec3 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec4 isnan(vec4 x) { throw new NotImplementedException(); }

        [BuiltIn]
        protected bool isinf(float x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec2 isinf(vec2 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec3 isinf(vec3 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec4 isinf(vec4 x) { throw new NotImplementedException(); }

        // Geometric Functions

        [BuiltIn]
        protected float length(float x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected float length(vec2 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected float length(vec3 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected float length(vec4 x) { throw new NotImplementedException(); }

        [BuiltIn]
        protected float dot(float x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected float dot(vec2 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected float dot(vec3 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected float dot(vec4 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected float dot(vec2 x, vec2 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected float dot(vec3 x, vec3 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected float dot(vec4 x, vec4 y) { throw new NotImplementedException(); }

        [BuiltIn]
        protected vec3 cross(vec3 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 cross(vec3 x, vec3 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 cross(vec2 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 cross(vec2 x, vec2 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 cross(vec4 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 cross(vec4 x, vec4 y) { throw new NotImplementedException(); }

        [BuiltIn]
        protected float normalize(float x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec2 normalize(vec2 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 normalize(vec3 x) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 normalize(vec4 x) { throw new NotImplementedException(); }

        [BuiltIn]
        protected vec4 ftransform() { throw new NotImplementedException(); }

        [BuiltIn]
        protected float faceforward(float N, float I, float Nref) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec2 faceforward(vec2 N, vec2 I, vec2 Nref) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 faceforward(vec3 N, vec3 I, vec3 Nref) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 faceforward(vec4 N, vec4 I, vec4 Nref) { throw new NotImplementedException(); }

        [BuiltIn]
        protected float reflect(float I, float N) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec2 reflect(vec2 I, vec2 N) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 reflect(vec3 I, vec3 N) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 reflect(vec4 I, vec4 N) { throw new NotImplementedException(); }

        [BuiltIn]
        protected float refract(float I, float N, float eta) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec2 refract(vec2 I, vec2 N, float eta) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec3 refract(vec3 I, vec3 N, float eta) { throw new NotImplementedException(); }
        [BuiltIn]
        protected vec4 refract(vec4 I, vec4 N, float eta) { throw new NotImplementedException(); }

        // Matrix Functions

        [BuiltIn]
        protected mat2 matrixCompMult(mat2 x, mat2 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected mat3 matrixCompMult(mat3 x, mat3 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected mat4 matrixCompMult(mat4 x, mat4 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected mat2x3 matrixCompMult(mat2x3 x, mat2x3 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected mat2x4 matrixCompMult(mat2x4 x, mat2x4 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected mat3x2 matrixCompMult(mat3x2 x, mat3x2 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected mat3x4 matrixCompMult(mat3x4 x, mat3x4 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected mat4x2 matrixCompMult(mat4x2 x, mat4x2 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected mat4x3 matrixCompMult(mat4x3 x, mat4x3 y) { throw new NotImplementedException(); }

        [BuiltIn]
        protected mat2 outerProduct(vec2 c, vec2 r) { throw new NotImplementedException(); }
        [BuiltIn]
        protected mat3 outerProduct(vec3 c, vec3 r) { throw new NotImplementedException(); }
        [BuiltIn]
        protected mat4 outerProduct(vec4 c, vec4 r) { throw new NotImplementedException(); }
        [BuiltIn]
        protected mat2x3 outerProduct(vec3 c, vec2 r) { throw new NotImplementedException(); }
        [BuiltIn]
        protected mat2x4 outerProduct(vec4 c, vec2 r) { throw new NotImplementedException(); }
        [BuiltIn]
        protected mat3x2 outerProduct(vec2 c, vec3 r) { throw new NotImplementedException(); }
        [BuiltIn]
        protected mat3x4 outerProduct(vec4 c, vec3 r) { throw new NotImplementedException(); }
        [BuiltIn]
        protected mat4x2 outerProduct(vec2 c, vec4 r) { throw new NotImplementedException(); }
        [BuiltIn]
        protected mat4x3 outerProduct(vec3 c, vec4 r) { throw new NotImplementedException(); }

        [BuiltIn]
        protected mat2 transpose(mat2 m) { throw new NotImplementedException(); }
        [BuiltIn]
        protected mat3 transpose(mat3 m) { throw new NotImplementedException(); }
        [BuiltIn]
        protected mat4 transpose(mat4 m) { throw new NotImplementedException(); }
        [BuiltIn]
        protected mat2x3 transpose(mat3x2 m) { throw new NotImplementedException(); }
        [BuiltIn]
        protected mat2x4 transpose(mat4x2 m) { throw new NotImplementedException(); }
        [BuiltIn]
        protected mat3x2 transpose(mat2x3 m) { throw new NotImplementedException(); }
        [BuiltIn]
        protected mat3x4 transpose(mat4x3 m) { throw new NotImplementedException(); }
        [BuiltIn]
        protected mat4x2 transpose(mat2x4 m) { throw new NotImplementedException(); }
        [BuiltIn]
        protected mat4x3 transpose(mat3x4 m) { throw new NotImplementedException(); }

        [BuiltIn]
        protected mat2 determinant(mat2 m) { throw new NotImplementedException(); }
        [BuiltIn]
        protected mat3 determinant(mat3 m) { throw new NotImplementedException(); }
        [BuiltIn]
        protected mat4 determinant(mat4 m) { throw new NotImplementedException(); }

        [BuiltIn]
        protected mat2 inverse(mat2 m) { throw new NotImplementedException(); }
        [BuiltIn]
        protected mat3 inverse(mat3 m) { throw new NotImplementedException(); }
        [BuiltIn]
        protected mat4 inverse(mat4 m) { throw new NotImplementedException(); }

        // Vector Relational Functions

        [BuiltIn]
        protected bvec2 lessThan(vec2 x, vec2 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec3 lessThan(vec3 x, vec3 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec4 lessThan(vec4 x, vec4 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec2 lessThan(ivec2 x, ivec2 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec3 lessThan(ivec3 x, ivec3 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec4 lessThan(ivec4 x, ivec4 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec2 lessThan(uvec2 x, uvec2 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec3 lessThan(uvec3 x, uvec3 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec4 lessThan(uvec4 x, uvec4 y) { throw new NotImplementedException(); }

        [BuiltIn]
        protected bvec2 lessThanEqual(vec2 x, vec2 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec3 lessThanEqual(vec3 x, vec3 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec4 lessThanEqual(vec4 x, vec4 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec2 lessThanEqual(ivec2 x, ivec2 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec3 lessThanEqual(ivec3 x, ivec3 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec4 lessThanEqual(ivec4 x, ivec4 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec2 lessThanEqual(uvec2 x, uvec2 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec3 lessThanEqual(uvec3 x, uvec3 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec4 lessThanEqual(uvec4 x, uvec4 y) { throw new NotImplementedException(); }

        [BuiltIn]
        protected bvec2 greaterThan(vec2 x, vec2 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec3 greaterThan(vec3 x, vec3 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec4 greaterThan(vec4 x, vec4 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec2 greaterThan(ivec2 x, ivec2 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec3 greaterThan(ivec3 x, ivec3 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec4 greaterThan(ivec4 x, ivec4 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec2 greaterThan(uvec2 x, uvec2 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec3 greaterThan(uvec3 x, uvec3 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec4 greaterThan(uvec4 x, uvec4 y) { throw new NotImplementedException(); }

        [BuiltIn]
        protected bvec2 greaterThanEqual(vec2 x, vec2 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec3 greaterThanEqual(vec3 x, vec3 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec4 greaterThanEqual(vec4 x, vec4 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec2 greaterThanEqual(ivec2 x, ivec2 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec3 greaterThanEqual(ivec3 x, ivec3 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec4 greaterThanEqual(ivec4 x, ivec4 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec2 greaterThanEqual(uvec2 x, uvec2 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec3 greaterThanEqual(uvec3 x, uvec3 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec4 greaterThanEqual(uvec4 x, uvec4 y) { throw new NotImplementedException(); }

        [BuiltIn]
        protected bvec2 equal(vec2 x, vec2 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec3 equal(vec3 x, vec3 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec4 equal(vec4 x, vec4 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec2 equal(ivec2 x, ivec2 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec3 equal(ivec3 x, ivec3 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec4 equal(ivec4 x, ivec4 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec2 equal(uvec2 x, uvec2 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec3 equal(uvec3 x, uvec3 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec4 equal(uvec4 x, uvec4 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec2 equal(bvec2 x, bvec2 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec3 equal(bvec3 x, bvec3 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec4 equal(bvec4 x, bvec4 y) { throw new NotImplementedException(); }

        [BuiltIn]
        protected bvec2 notEqual(vec2 x, vec2 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec3 notEqual(vec3 x, vec3 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec4 notEqual(vec4 x, vec4 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec2 notEqual(ivec2 x, ivec2 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec3 notEqual(ivec3 x, ivec3 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec4 notEqual(ivec4 x, ivec4 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec2 notEqual(uvec2 x, uvec2 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec3 notEqual(uvec3 x, uvec3 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec4 notEqual(uvec4 x, uvec4 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec2 notEqual(bvec2 x, bvec2 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec3 notEqual(bvec3 x, bvec3 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec4 notEqual(bvec4 x, bvec4 y) { throw new NotImplementedException(); }

        [BuiltIn]
        protected bvec2 all(bvec2 x, bvec2 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec3 all(bvec3 x, bvec3 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec4 all(bvec4 x, bvec4 y) { throw new NotImplementedException(); }

        [BuiltIn]
        protected bvec2 any(bvec2 x, bvec2 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec3 any(bvec3 x, bvec3 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec4 any(bvec4 x, bvec4 y) { throw new NotImplementedException(); }

        [BuiltIn]
        protected bvec2 not(bvec2 x, bvec2 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec3 not(bvec3 x, bvec3 y) { throw new NotImplementedException(); }
        [BuiltIn]
        protected bvec4 not(bvec4 x, bvec4 y) { throw new NotImplementedException(); }
    }
}
