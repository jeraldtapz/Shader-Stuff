using System;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace Koro
{
    [Serializable]
    [PostProcess(typeof(ColorblindRenderer), PostProcessEvent.AfterStack, "Custom/Colorblind")]
    public sealed class Colorblind : PostProcessEffectSettings
    {
        public Vector3Parameter RedValues = new Vector3Parameter();
        public Vector3Parameter GreenValues = new Vector3Parameter();
        public Vector3Parameter BlueValues = new Vector3Parameter();
    }

    public sealed class ColorblindRenderer : PostProcessEffectRenderer<Colorblind>
    {
        private static readonly int RedValues = Shader.PropertyToID("_RedValues");
        private static readonly int GreenValues = Shader.PropertyToID("_GreenValues");
        private static readonly int BlueValues = Shader.PropertyToID("_BlueValues");

        public override void Render(PostProcessRenderContext context)
        {
            PropertySheet sheet = context.propertySheets.Get(Shader.Find("Unlit/ColorBlindEffect"));
            sheet.properties.SetVector(RedValues, settings.RedValues);
            sheet.properties.SetVector(GreenValues, settings.GreenValues);
            sheet.properties.SetVector(BlueValues, settings.BlueValues);

            context.command.BlitFullscreenTriangle(context.source, context.destination, sheet, 0);
        }
    }
}