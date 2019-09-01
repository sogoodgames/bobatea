using System;

using UnityEditor;
using UnityEditor.Rendering.PostProcessing;

using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace BobaTea {

    [PostProcessEditor(typeof(DayCycleSettings))]
    public class DayCycleSettingsEditor : PostProcessEffectEditor<DayCycleSettings>
    {
        SerializedParameterOverride m_time;
        SerializedParameterOverride m_minTime;
        SerializedParameterOverride m_maxTime;

        SerializedParameterOverride m_key0;
        SerializedParameterOverride m_key1;
        SerializedParameterOverride m_key2;
        SerializedParameterOverride m_key3;
        SerializedParameterOverride m_key4;
        SerializedParameterOverride m_key5;
        SerializedParameterOverride m_key6;
        SerializedParameterOverride m_key7;

        SerializedParameterOverride m_time0;
        SerializedParameterOverride m_time1;
        SerializedParameterOverride m_time2;
        SerializedParameterOverride m_time3;
        SerializedParameterOverride m_time4;
        SerializedParameterOverride m_time5;
        SerializedParameterOverride m_time6;
        SerializedParameterOverride m_time7;

        SerializedParameterOverride m_time0s;
        SerializedParameterOverride m_time1s;
        SerializedParameterOverride m_time2s;
        SerializedParameterOverride m_time3s;
        SerializedParameterOverride m_time4s;
        SerializedParameterOverride m_time5s;
        SerializedParameterOverride m_time6s;
        SerializedParameterOverride m_time7s;

        Gradient gradient;

        public override void OnEnable () 
        {
            m_time = FindParameterOverride(x => x.time);
            m_minTime = FindParameterOverride(x => x.minTime);
            m_maxTime = FindParameterOverride(x => x.maxTime);

            m_key0 = FindParameterOverride(x => x.key0);
            m_key1 = FindParameterOverride(x => x.key1);
            m_key2 = FindParameterOverride(x => x.key2);
            m_key3 = FindParameterOverride(x => x.key3);
            m_key4 = FindParameterOverride(x => x.key4);
            m_key5 = FindParameterOverride(x => x.key5);
            m_key6 = FindParameterOverride(x => x.key6);
            m_key7 = FindParameterOverride(x => x.key7);

            m_time0 = FindParameterOverride(x => x.time0);
            m_time1 = FindParameterOverride(x => x.time1);
            m_time2 = FindParameterOverride(x => x.time2);
            m_time3 = FindParameterOverride(x => x.time3);
            m_time4 = FindParameterOverride(x => x.time4);
            m_time5 = FindParameterOverride(x => x.time5);
            m_time6 = FindParameterOverride(x => x.time6);
            m_time7 = FindParameterOverride(x => x.time7);

            m_time0s = FindParameterOverride(x => x.time0s);
            m_time1s = FindParameterOverride(x => x.time1s);
            m_time2s = FindParameterOverride(x => x.time2s);
            m_time3s = FindParameterOverride(x => x.time3s);
            m_time4s = FindParameterOverride(x => x.time4s);
            m_time5s = FindParameterOverride(x => x.time5s);
            m_time6s = FindParameterOverride(x => x.time6s);
            m_time7s = FindParameterOverride(x => x.time7s);

            gradient = new Gradient();

            GradientColorKey[] colorKeys = new GradientColorKey[] {
                new GradientColorKey(m_key0.value.colorValue, m_time0.value.floatValue),
                new GradientColorKey(m_key1.value.colorValue, m_time1.value.floatValue),
                new GradientColorKey(m_key2.value.colorValue, m_time2.value.floatValue),
                new GradientColorKey(m_key3.value.colorValue, m_time3.value.floatValue),
                new GradientColorKey(m_key4.value.colorValue, m_time4.value.floatValue),
                new GradientColorKey(m_key5.value.colorValue, m_time5.value.floatValue),
                new GradientColorKey(m_key6.value.colorValue, m_time6.value.floatValue),
                new GradientColorKey(m_key7.value.colorValue, m_time7.value.floatValue)
            };

            GradientAlphaKey[] alphaKeys = new GradientAlphaKey [] {
                new GradientAlphaKey(m_key0.value.colorValue.a, m_time0s.value.floatValue),
                new GradientAlphaKey(m_key1.value.colorValue.a, m_time1s.value.floatValue),
                new GradientAlphaKey(m_key2.value.colorValue.a, m_time2s.value.floatValue),
                new GradientAlphaKey(m_key3.value.colorValue.a, m_time3s.value.floatValue),
                new GradientAlphaKey(m_key4.value.colorValue.a, m_time4s.value.floatValue),
                new GradientAlphaKey(m_key5.value.colorValue.a, m_time5s.value.floatValue),
                new GradientAlphaKey(m_key6.value.colorValue.a, m_time6s.value.floatValue),
                new GradientAlphaKey(m_key7.value.colorValue.a, m_time7s.value.floatValue)
            };

            gradient.SetKeys(colorKeys, alphaKeys);
        }

        public override void OnInspectorGUI () {
            PropertyField(m_time);
            PropertyField(m_minTime);
            PropertyField(m_maxTime);

            EditorGUILayout.Space();
            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Color and Saturation Gradient", EditorStyles.boldLabel);
            EditorGUILayout.LabelField("Color key = tint color (multiplied)");
            EditorGUILayout.LabelField("Alpha key = saturation");
            EditorGUILayout.LabelField("Max of 8 color keys and 8 alpha keys.");

            gradient = EditorGUILayout.GradientField("Gradient", gradient);
            SetGradientValues();
        }

        private void SetGradientValues () {
            GradientColorKey[] colorKeys = new GradientColorKey[8];
            for (int i = 0; i < 8; i++) {
                if(i < gradient.colorKeys.Length) {
                    colorKeys[i] = gradient.colorKeys[i];
                } else {
                    colorKeys[i] = new GradientColorKey(Color.black, -1);
                }
            }

            GradientAlphaKey[] alphaKeys = new GradientAlphaKey[8];
            for(int i = 0; i < 8; i++) {
                if(i < gradient.alphaKeys.Length) {
                    alphaKeys[i] = gradient.alphaKeys[i];
                } else {
                    alphaKeys[i] = new GradientAlphaKey(0, -1);
                }
            }

            m_key0.overrideState.boolValue = true;
            m_key1.overrideState.boolValue = true;
            m_key2.overrideState.boolValue = true;
            m_key3.overrideState.boolValue = true;
            m_key4.overrideState.boolValue = true;
            m_key5.overrideState.boolValue = true;
            m_key6.overrideState.boolValue = true;
            m_key7.overrideState.boolValue = true;

            m_time0.overrideState.boolValue = true;
            m_time1.overrideState.boolValue = true;
            m_time2.overrideState.boolValue = true;
            m_time3.overrideState.boolValue = true;
            m_time4.overrideState.boolValue = true;
            m_time5.overrideState.boolValue = true;
            m_time6.overrideState.boolValue = true;
            m_time7.overrideState.boolValue = true;

            m_time0s.overrideState.boolValue = true;
            m_time1s.overrideState.boolValue = true;
            m_time2s.overrideState.boolValue = true;
            m_time3s.overrideState.boolValue = true;
            m_time4s.overrideState.boolValue = true;
            m_time5s.overrideState.boolValue = true;
            m_time6s.overrideState.boolValue = true;
            m_time7s.overrideState.boolValue = true;

            m_key0.value.colorValue = new Color(
            colorKeys[0].color.r,
            colorKeys[0].color.g,
            colorKeys[0].color.b,
            alphaKeys[0].alpha
            );

            m_key1.value.colorValue = new Color(
            colorKeys[1].color.r,
            colorKeys[1].color.g,
            colorKeys[1].color.b,
            alphaKeys[1].alpha
            );

            m_key2.value.colorValue = new Color(
            colorKeys[2].color.r,
            colorKeys[2].color.g,
            colorKeys[2].color.b,
            alphaKeys[2].alpha
            );

            m_key3.value.colorValue = new Color(
            colorKeys[3].color.r,
            colorKeys[3].color.g,
            colorKeys[3].color.b,
            alphaKeys[3].alpha
            );

            m_key4.value.colorValue = new Color(
            colorKeys[4].color.r,
            colorKeys[4].color.g,
            colorKeys[4].color.b,
            alphaKeys[4].alpha
            );

            m_key5.value.colorValue = new Color(
            colorKeys[5].color.r,
            colorKeys[5].color.g,
            colorKeys[5].color.b,
            alphaKeys[5].alpha
            );

            m_key6.value.colorValue = new Color(
            colorKeys[6].color.r,
            colorKeys[6].color.g,
            colorKeys[6].color.b,
            alphaKeys[6].alpha
            );

            m_key7.value.colorValue = new Color(
            colorKeys[7].color.r,
            colorKeys[7].color.g,
            colorKeys[7].color.b,
            alphaKeys[7].alpha
            );

            m_time0.value.floatValue = colorKeys[0].time;
            m_time1.value.floatValue = colorKeys[1].time;
            m_time2.value.floatValue = colorKeys[2].time;
            m_time3.value.floatValue = colorKeys[3].time;
            m_time4.value.floatValue = colorKeys[4].time;
            m_time5.value.floatValue = colorKeys[5].time;
            m_time6.value.floatValue = colorKeys[6].time;
            m_time7.value.floatValue = colorKeys[7].time;

            m_time0s.value.floatValue = alphaKeys[0].time;
            m_time1s.value.floatValue = alphaKeys[1].time;
            m_time2s.value.floatValue = alphaKeys[2].time;
            m_time3s.value.floatValue = alphaKeys[3].time;
            m_time4s.value.floatValue = alphaKeys[4].time;
            m_time5s.value.floatValue = alphaKeys[5].time;
            m_time6s.value.floatValue = alphaKeys[6].time;
            m_time7s.value.floatValue = alphaKeys[7].time;
        }
    }

}