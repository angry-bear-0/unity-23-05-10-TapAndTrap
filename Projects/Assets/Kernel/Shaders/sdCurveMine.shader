// Upgrade NOTE: replaced 'glstate_matrix_mvp' with 'UNITY_MATRIX_MVP'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "hgn/CurveMine" 
{
	Properties 
	{
	    [NoScaleOffset]_MainTex ("Texture", 2D) = "white" { }
	}
	SubShader 
	{
	    Pass 
	    {
			Tags { "LIGHTMODE"="ForwardBase"}
			CGPROGRAM
			// Upgrade NOTE: excluded shader from OpenGL ES 2.0 because it uses non-square matrices
			//		#pragma exclude_renderers gles
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"
			struct v2f
			{
				float2 uv0 : TEXCOORD0;
				//float2 uv1 : TEXCOORD1;
				fixed4 color : COLOR0;
				float4 vertex : SV_POSITION;
			};
			struct appdata {
				float4 vertex : POSITION;
				float4 normal : NORMAL;
				fixed4 color : COLOR0;
				float4 uv0 : TEXCOORD0;
			};
		
			sampler2D _MainTex;
			float _Offset;
			float4 _MainTex_ST;
			float _LightColor0;
			v2f vert (appdata v)
			{
				v2f o;
				float OffsetZ;
				float Delta;

				o.vertex = mul (unity_ObjectToWorld, v.vertex);
				OffsetZ = o.vertex.z - _Offset;
				
				if(OffsetZ > - 5)
				{
					Delta = OffsetZ * OffsetZ / 381.97;//381.972
					o.vertex.x -= Delta;
					o.vertex.y -= Delta;
				}
				
				o.vertex = mul (UNITY_MATRIX_VP, o.vertex);

				o.uv0 = ((v.uv0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
				half3 worldNormal = UnityObjectToWorldNormal(v.normal);
				half nl = max(0, dot(worldNormal, _WorldSpaceLightPos0.xyz));
				o.color = nl * _LightColor0;

				// the only difference from previous shader:
				// in addition to the diffuse lighting from the main light,
				// add illumination from ambient or light probes
				// ShadeSH9 function from UnityCG.cginc evaluates it,
				// using world space normal
				o.color.rgb += ShadeSH9(half4(worldNormal,0.3));
				return o;
			}


			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv0);
				col *= i.color;
				return col;
			}
		

			ENDCG

	    }
	}
	FallBack "Diffuse"
}