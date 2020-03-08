#ifndef INCL_DAY_CYCLE
#define INCL_DAY_CYCLE

#include "Packages/com.unity.postprocessing/PostProcessing/Shaders/StdLib.hlsl"
#include "Packages/com.unity.postprocessing/PostProcessing/Shaders/Sampling.hlsl"
#include "Packages/com.unity.postprocessing/PostProcessing/Shaders/Colors.hlsl"
#include "Gradient.hlsl"

// Camera texture 
TEXTURE2D_SAMPLER2D(_MainTex, sampler_MainTex);
// Material properties
float _DayTime;
float _MaxTime;
float _MinTime;

// ----------------------------------------------------------------------------
// Input Structs
// ----------------------------------------------------------------------------
struct BasicVertexInput {
    float4 vertex : POSITION;
};

struct BasicVertexOutput {
    float4 pos : SV_POSITION;
    float2 screenPos : TEXCOORD0;
};

// ----------------------------------------------------------------------------
// Vertex and Frag Functions
// ----------------------------------------------------------------------------
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

// ----------------------------------------------------------------------------
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

#endif //INCL_DAY_CYCLE