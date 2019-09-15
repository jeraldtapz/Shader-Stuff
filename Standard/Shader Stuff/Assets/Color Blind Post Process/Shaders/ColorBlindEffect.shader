Shader "Unlit/ColorBlindEffect"
{
	Properties
	{
		_RedValues("Red Channel Mix", Vector) = (1,0,0,1)
		_GreenValues("Green Channel Mix", Vector) = (0,1,0,1)
		_BlueValues("Blue Channel Mix", Vector) = (0,0,1,1)
	}

		HLSLINCLUDE

#include "Packages/com.unity.postprocessing/PostProcessing/Shaders/StdLib.hlsl"

		TEXTURE2D_SAMPLER2D(_MainTex, sampler_MainTex);

	float4 _RedValues;
	float4 _GreenValues;
	float4 _BlueValues;

	float4 Frag(VaryingsDefault i) : SV_Target
	{
		float4 color = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.texcoord);
		float3 temp = float3(color.x, color.y, color.z);
		temp.r = (color.r * _RedValues.r) + (color.g * _RedValues.g) + (color.b * _RedValues.b);
		temp.g = (color.r * _GreenValues.r) + (color.g * _GreenValues.g) + (color.b * _GreenValues.b);
		temp.b = (color.r * _BlueValues.r) + (color.g * _BlueValues.g) + (color.b * _BlueValues.b);

		return float4(temp, 1);
	}

		ENDHLSL

		SubShader
	{
		Cull Off ZWrite Off ZTest Always
			Tags{ "RenderType" = "Opaque" }

			Pass
		{
			HLSLPROGRAM

			#pragma vertex VertDefault
			#pragma fragment Frag

			ENDHLSL
		}
	}
}