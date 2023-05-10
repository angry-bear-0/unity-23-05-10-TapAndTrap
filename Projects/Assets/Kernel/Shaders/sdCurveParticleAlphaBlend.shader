// Upgrade NOTE: replaced 'glstate_matrix_modelview0' with 'UNITY_MATRIX_MV'

Shader "hgn/sdParticleAlphaBlend" 
{
	Properties 
	{
		_TintColor ("Tint Color", Color) = (0.500000,0.500000,0.500000,0.500000)
       	_MainTex ("Particle Texture", 2D) = "white" { }
	}
	SubShader 
	{
		 Tags { "QUEUE"="Transparent" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" "PreviewType"="Plane" }
		 ZWrite Off
		 Cull Off
		 Blend SrcAlpha OneMinusSrcAlpha
		 ColorMask RGB
		Pass
		{
			
			CGPROGRAM
			// Upgrade NOTE: excluded shader from OpenGL ES 2.0 because it uses non-square matrices
			//		#pragma exclude_renderers gles
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"
			struct v2f
			{
				float2 uv0 : TEXCOORD0;
				float2 uv1 : TEXCOORD1;
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
			float4 _TintColor;
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
				float4 tmpvar_1;
				tmpvar_1 = v.vertex;
				float4 o_5;
				float4 tmpvar_2;
				float4 tmpvar_6;
				tmpvar_6 = (o.vertex * 0.5);
				float2 tmpvar_7;
				tmpvar_7.x = tmpvar_6.x;
				tmpvar_7.y = (tmpvar_6.y * _ProjectionParams.x);
				o_5.xy = (tmpvar_7 + tmpvar_6.w);
				o_5.zw = o.vertex.zw;
				tmpvar_2.xyw = o_5.xyw;
				float4 tmpvar_8;
				tmpvar_8.w = 1.0;
				tmpvar_8.xyz = tmpvar_1.xyz;
				tmpvar_2.z = -(mul(UNITY_MATRIX_MV , tmpvar_8).z);
				o.color = (v.color * _TintColor);
				o.uv0 = ((v.uv0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
				o.uv1 = tmpvar_2;
				return o;
			}


			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 u_xlat16_0;
				float4 u_xlat10_1;
				u_xlat16_0 = i.color * float4(2.0, 2.0, 2.0, 2.0);
				u_xlat10_1 = tex2D(_MainTex, i.uv0.xy);
				u_xlat16_0 = u_xlat16_0 * u_xlat10_1;
				return u_xlat16_0;
			}
			ENDCG
		}
		
	} 
}
