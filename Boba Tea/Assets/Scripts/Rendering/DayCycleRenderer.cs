using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(DayCycleRenderer), PostProcessEvent.AfterStack, "Custom/DayNightCycle")]
public sealed class DayCycleSettings : PostProcessEffectSettings
{
    [Range(0f, 24f), Tooltip("Normalized time of day.")]
    public FloatParameter time = new FloatParameter {value = 12.0f};
    public FloatParameter minTime = new FloatParameter {value = 0.0f};
    public FloatParameter maxTime = new FloatParameter {value = 24.0f};

    public ColorParameter key0 = new ColorParameter {value = Color.white};
    public ColorParameter key1 = new ColorParameter {value = Color.white};
    public ColorParameter key2 = new ColorParameter {value = Color.white};
    public ColorParameter key3 = new ColorParameter {value = Color.white};
    public ColorParameter key4 = new ColorParameter {value = Color.white};
    public ColorParameter key5 = new ColorParameter {value = Color.white};
    public ColorParameter key6 = new ColorParameter {value = Color.white};
    public ColorParameter key7 = new ColorParameter {value = Color.white};

    public FloatParameter time0 = new FloatParameter {value = 0.0f};
    public FloatParameter time1 = new FloatParameter {value = 0.0f};
    public FloatParameter time2 = new FloatParameter {value = 0.0f};
    public FloatParameter time3 = new FloatParameter {value = 0.0f};
    public FloatParameter time4 = new FloatParameter {value = 0.0f};
    public FloatParameter time5 = new FloatParameter {value = 0.0f};
    public FloatParameter time6 = new FloatParameter {value = 0.0f};
    public FloatParameter time7 = new FloatParameter {value = 0.0f};

    public FloatParameter time0s = new FloatParameter {value = 0.0f};
    public FloatParameter time1s = new FloatParameter {value = 0.0f};
    public FloatParameter time2s = new FloatParameter {value = 0.0f};
    public FloatParameter time3s = new FloatParameter {value = 0.0f};
    public FloatParameter time4s = new FloatParameter {value = 0.0f};
    public FloatParameter time5s = new FloatParameter {value = 0.0f};
    public FloatParameter time6s = new FloatParameter {value = 0.0f};
    public FloatParameter time7s = new FloatParameter {value = 0.0f};
}

public class DayCycleRenderer : PostProcessEffectRenderer<DayCycleSettings>
{
    public override void Render(PostProcessRenderContext context) {
        var sheet = context.propertySheets.Get(Shader.Find("Custom/DayNightCycle"));

        sheet.properties.SetFloat("_DayTime", settings.time);
        sheet.properties.SetFloat("_MaxTime", settings.maxTime);
        sheet.properties.SetFloat("_MinTime", settings.minTime);

        sheet.properties.SetFloat("_Time0", settings.time0);
        sheet.properties.SetFloat("_Time1", settings.time1);
        sheet.properties.SetFloat("_Time2", settings.time2);
        sheet.properties.SetFloat("_Time3", settings.time3);
        sheet.properties.SetFloat("_Time4", settings.time4);
        sheet.properties.SetFloat("_Time5", settings.time5);
        sheet.properties.SetFloat("_Time6", settings.time6);
        sheet.properties.SetFloat("_Time7", settings.time7);

        sheet.properties.SetFloat("_Time0s", settings.time0s);
        sheet.properties.SetFloat("_Time1s", settings.time1s);
        Debug.Log("time1s:" + settings.time1s.value);
        sheet.properties.SetFloat("_Time2s", settings.time2s);
        sheet.properties.SetFloat("_Time3s", settings.time3s);
        sheet.properties.SetFloat("_Time4s", settings.time4s);
        sheet.properties.SetFloat("_Time5s", settings.time5s);
        sheet.properties.SetFloat("_Time6s", settings.time6s);
        sheet.properties.SetFloat("_Time7s", settings.time7s);

        sheet.properties.SetColor("_Key0", settings.key0);
        sheet.properties.SetColor("_Key1", settings.key1);
        sheet.properties.SetColor("_Key2", settings.key2);
        sheet.properties.SetColor("_Key3", settings.key3);
        sheet.properties.SetColor("_Key4", settings.key4);
        sheet.properties.SetColor("_Key5", settings.key5);
        sheet.properties.SetColor("_Key6", settings.key6);
        sheet.properties.SetColor("_Key7", settings.key7);
        
        context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
    }
}