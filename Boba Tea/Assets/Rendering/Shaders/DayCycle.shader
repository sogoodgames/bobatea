Shader "Custom/DayNightCycle"
{
    SubShader
    {
        Cull Off
        ZWrite Off
        ZTest Always

        Pass
        {
            HLSLPROGRAM

                #include "DayCycle.hlsl"

                #pragma vertex DayCycleVertex
                #pragma fragment DayCycleFrag

            ENDHLSL
        }
    }
}