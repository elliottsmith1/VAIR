﻿Shader "ToonWater/WaterSurface" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
	}
	SubShader {
		  Tags { "RenderType"="Opaque"
	  "Queue" = "Geometry+50"
	  }

		LOD 200
		 	Blend OneMinusDstAlpha DstAlpha // This makes water invisible without using transparency
		CGPROGRAM
		#pragma surface surf SimpleSpecular fullforwardshadows vertex:vert  nofog nometa interpolateview
		#pragma target 3.0

		struct Input {
			float2 uv_MainTex;
			float4 wpos;
		};

		fixed4 _Color;
		float4 _ShadowColor;

		UNITY_INSTANCING_CBUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_CBUFFER_END

		struct MySurfaceOutput {
		fixed3 Albedo;  // diffuse color
		fixed3 Normal;  // tangent space normal, if written
		fixed3 Emission;
		fixed Alpha;    
		};

	half4 LightingSimpleSpecular (MySurfaceOutput s, half3 lightDir, half3 viewDir, half atten) {
		half4 c;
		float hardAtten = max( min(1, atten*16), _ShadowColor.a) ;
        c.rgb = s.Albedo * _LightColor0.rgb * hardAtten+
		_ShadowColor.rgb*(1-hardAtten);
        return c;
	}

	void vert (inout appdata_full v, out Input b) {
		float4 posWorld = mul( unity_ObjectToWorld, v.vertex );
		b.uv_MainTex = 0;
		b.wpos = posWorld;
	}

	void surf (Input IN, inout MySurfaceOutput o) {
		o.Albedo = _Color.rgb;
	}


		ENDCG
	}
	FallBack "Diffuse"
}
