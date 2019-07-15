#ifndef DAY_CYCLE
#define DAY_CYCLE

#include "Packages/com.unity.postprocessing/PostProcessing/Shaders/StdLib.hlsl"
#include "Packages/com.unity.postprocessing/PostProcessing/Shaders/Sampling.hlsl"
#include "Packages/com.unity.postprocessing/PostProcessing/Shaders/Colors.hlsl"

// Camera texture 
TEXTURE2D_SAMPLER2D(_MainTex, sampler_MainTex);
// Material properties
float _DayTime;
float _Saturation;
float3 _Tint;

struct BasicVertexInput {
    float4 vertex : POSITION;
};

struct BasicVertexOutput {
    float4 pos : SV_POSITION;
    float2 screenPos : TEXCOORD0;
};

// Returns 1 if min <= t <= max, 0 otherwise
float between (float min, float max, float t) {
    return step(min, t) * step(t, max);
}

// Blends colors a and b based on t's position between min and max
// Returns black if t is not inside min & max
float3 BlendInRange (float t, float min, float max, float3 a, float3 b) {
    float blend = (t - min) / (max - min);
    blend = clamp(blend, 0.0, 1.0);
    return between(min, max, t) * lerp(a, b, blend);
}

// Based off of the smoothstep() function
// But instead of using a Hermite curve,
// use e^x with some parameters
float Blend(float min, float max, float x, float k, float p) {
    x = (x - min) / (max-min);
    x = clamp(x, 0.0, 1.0);
    x = exp(-pow(k * (1 - x), p));
    return x;
}

BasicVertexOutput DayCycleVertex(BasicVertexInput i) {
    BasicVertexOutput o;
    o.pos = float4(i.vertex.xy, 0.0, 1.0);
    
    // get clip space coordinates for sampling camera tex
    o.screenPos = TransformTriangleVertexToUV(i.vertex.xy);
#if UNITY_UV_STARTS_AT_TOP
    o.screenPos = o.screenPos * float2(1.0, -1.0) + float2(0.0, 1.0);
#endif

    return o;
}

float4 DayCycleFrag(BasicVertexOutput i) : SV_Target
{
    // regular color 
    float3 color = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.screenPos).rgb;
    color = NeutralTonemap(color);

    // get blended value for tint and saturation
    float3 tint = _Tint.rgb;
    float saturation = _Saturation;

    // apply tint and saturation
    color *= tint;
    color = Saturation(color, saturation); 

    return float4(color, 1.0);
}

#endif //DAY_CYCLE