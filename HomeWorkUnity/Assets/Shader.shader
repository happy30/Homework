Shader "Custom/Shader" 
{
	Properties 
	{
		_Color ("Base Color", Color) = (0,0,0,0)
		_Smoothness("Smoothness", 2D) = "black" {}
		_Metallic("Metallic", 2D) = "black" {}
		_Normal("Normal", 2D) = "bump" {}
		_Emission("Emmission", 2D) = "black" {}
		_EmissionColor ("Emission Color", Color) = (0,0,0,0)
	}

	SubShader 
	{
		Tags{ "RenderType" = "Opaque" }
		CGPROGRAM

		#pragma surface surf Standard fullforwardshadows addshadow
		#pragma target 3.0
		#pragma multi_compile_instancing


		struct Input
		{
			float2 uv_Smoothness;
		};

		half4 _Color;
		sampler2D _Smoothness;
		sampler2D _Metallic;
		sampler2D _Normal;
		sampler2D _Emission;
		half4 _EmissionColor;

		//FallBack "Diffuse"

		void surf(Input IN, inout SurfaceOutputStandard o) 
		{
			//fixed4 c = tex2D(_Smoothness, IN.uv_Smoothness);

			o.Albedo = _Color;
			o.Metallic = tex2D(_Metallic, IN.uv_Smoothness);
			o.Smoothness = tex2D(_Smoothness, IN.uv_Smoothness);
			o.Normal = UnpackNormal(tex2D(_Normal, IN.uv_Smoothness));
			o.Emission = tex2D(_Emission, IN.uv_Smoothness) * _EmissionColor;
		}
		ENDCG
		
	}

	
}
