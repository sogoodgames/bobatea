#ifndef DAY_CYCLE
#define DAY_CYCLE

#include "Packages/com.unity.postprocessing/PostProcessing/Shaders/StdLib.hlsl"
#include "Packages/com.unity.postprocessing/PostProcessing/Shaders/Sampling.hlsl"
#include "Packages/com.unity.postprocessing/PostProcessing/Shaders/Colors.hlsl"

// Camera texture 
TEXTURE2D_SAMPLER2D(_MainTex, sampler_MainTex);
// Material properties
float _DayTime;
float _MaxTime;
float _MinTime;

half4 _Key0;
half4 _Key1;
half4 _Key2;
half4 _Key3;
half4 _Key4;
half4 _Key5;
half4 _Key6;
half4 _Key7;

float _Time0;
float _Time1;
float _Time2;
float _Time3;
float _Time4;
float _Time5;
float _Time6;
float _Time7;

float _Time0s;
float _Time1s;
float _Time2s;
float _Time3s;
float _Time4s;
float _Time5s;
float _Time6s;
float _Time7s;

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
half3 BlendInRange (float t, float min, float max, half3 a, half3 b) {
    float blend = (t - min) / (max - min);
    blend = clamp(blend, 0.0, 1.0);
    return between(min, max, t) * lerp(a, b, blend);
}

float BlendInRangeA (float t, float min, float max, float a, float b) {
    float blend = (t - min) / (max - min);
    blend = clamp(blend, 0.0, 1.0);
    return between(min, max, t) * lerp(a, b, blend);
}

half3 EvaluateGradientColor (float t) {
    half3 color = float3(0, 0, 0);

    color += BlendInRange(t, _Time0, _Time1, _Key0.rgb, _Key1.rgb);
    color += BlendInRange(t, _Time1, _Time2, _Key1.rgb, _Key2.rgb);
    color += BlendInRange(t, _Time2, _Time3, _Key2.rgb, _Key3.rgb);
    color += BlendInRange(t, _Time3, _Time4, _Key3.rgb, _Key4.rgb);
    color += BlendInRange(t, _Time4, _Time5, _Key4.rgb, _Key5.rgb);
    color += BlendInRange(t, _Time5, _Time6, _Key5.rgb, _Key6.rgb);
    color += BlendInRange(t, _Time6, _Time7, _Key6.rgb, _Key7.rgb);

    return color;
}

float EvaluateGradientAlpha (float t) {
    float a = 0;

    a += BlendInRangeA(t, _Time0s, _Time1s, _Key0.a, _Key1.a);
    a += BlendInRangeA(t, _Time1s, _Time2s, _Key1.a, _Key2.a);
    a += BlendInRangeA(t, _Time2s, _Time3s, _Key2.a, _Key3.a);
    a += BlendInRangeA(t, _Time3s, _Time4s, _Key3.a, _Key4.a);
    a += BlendInRangeA(t, _Time4s, _Time5s, _Key4.a, _Key5.a);
    a += BlendInRangeA(t, _Time5s, _Time6s, _Key5.a, _Key6.a);
    a += BlendInRangeA(t, _Time6s, _Time7s, _Key6.a, _Key7.a);

    return a;
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

half4 DayCycleFrag(BasicVertexOutput i) : SV_Target
{
    // regular color 
    half3 color = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.screenPos).rgb;
    color = NeutralTonemap(color);

    // get linear value for time
    float time = (_DayTime - _MinTime) / (_MaxTime - _MinTime);

    // get gradient values
    half3 tint = EvaluateGradientColor(time);
    float saturation = EvaluateGradientAlpha(time);

    // apply tint and saturation
    color *= tint;
    color = Saturation(color, saturation); 

    return half4(color, 1.0);
}

#endif //DAY_CYCLE