using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(DayCycleRenderer), PostProcessEvent.AfterStack, "Custom/DayNightCycle")]
public sealed class DayCycleSettings : PostProcessEffectSettings
{
    [Range(0f, 1f), Tooltip("Normalized time of day.")]
    public FloatParameter time = new FloatParameter {value = 0.0f};
}

public class DayCycleRenderer : PostProcessEffectRenderer<DayCycleSettings>
{
    public override void Render(PostProcessRenderContext context) {
        var sheet = context.propertySheets.Get(Shader.Find("Custom/DayNightCycle"));

        sheet.properties.SetFloat("_DayTime", settings.time);

        context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
    }
}
