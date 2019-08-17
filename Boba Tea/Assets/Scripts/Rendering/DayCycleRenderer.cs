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

    [Tooltip("Multiplied tint (1).")]
    public ColorParameter tint = new ColorParameter {value = Color.white};

    [Range(0f, 2f), Tooltip("Saturation. (1)")]
    public FloatParameter saturation = new FloatParameter {value = 1.0f};

    [Tooltip("Multiplied tint. (2)")]
    public ColorParameter tint2 = new ColorParameter {value = Color.white};

    [Range(0f, 2f), Tooltip("Saturation. (2)")]
    public FloatParameter saturation2 = new FloatParameter {value = 1.0f};
}

public class DayCycleRenderer : PostProcessEffectRenderer<DayCycleSettings>
{
    public override void Render(PostProcessRenderContext context) {
        var sheet = context.propertySheets.Get(Shader.Find("Custom/DayNightCycle"));

        sheet.properties.SetFloat("_DayTime", settings.time);
        sheet.properties.SetFloat("_MaxTime", settings.maxTime);
        sheet.properties.SetFloat("_MinTime", settings.minTime);

        sheet.properties.SetFloat("_Saturation", settings.saturation);
        sheet.properties.SetColor("_Tint", settings.tint);
        sheet.properties.SetFloat("_Saturation2", settings.saturation2);
        sheet.properties.SetColor("_Tint2", settings.tint2);

        context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
    }
}