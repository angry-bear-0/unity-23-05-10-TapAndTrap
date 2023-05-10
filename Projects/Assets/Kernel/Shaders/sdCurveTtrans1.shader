Shader "hgn/transparent"
{
	Properties
	{
		[NoScaleOffset]_Color ("Main Color", Color) = (1,1,1,1)
		[NoScaleOffset]_MainTex ("Texture", 2D) = "white" {}
		[NoScaleOffset]_Cutoff ("Outline Width", Range(0, 0.9)) = 0.5
	}
	SubShader
	{
	 Tags { "LIGHTMODE"="ForwardBase""RenderType"="Opaque" }
	LOD 150
		Cull Off
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			struct appdata
			{
		        float4 vertex : POSITION;
				float3 normal : NORMAL;
	            float4 uv0 : TEXCOORD0;
			};

			struct v2f
			{
				/*float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;*/

				float4  pos : SV_POSITION;
				float4 norm: NORMAL;
				float2  uv0 : TEXCOORD0;
				float3 uv1 : TEXCOORD1;
				float3 uv2 : TEXCOORD2;
				float3 uv3 : TEXCOORD3;
			};

			float _Offset;
			sampler2D _MainTex;
			float4 _MainTex_ST;
			
			v2f vert (appdata v)
			{
				v2f o;
				float OffsetZ;
				float Delta;

				o.pos = mul (unity_ObjectToWorld, v.vertex);
				OffsetZ = o.pos.z - _Offset;
				if(OffsetZ > - 5)
				{
					Delta = OffsetZ * OffsetZ / 381.97;//381.972
					o.pos.x -= Delta;
					o.pos.y -= Delta;
				}
				o.pos = mul (UNITY_MATRIX_VP, o.pos);


				float3 worldNormal_1;
				float3 tmpvar_2;
				float3x3 tmpvar_4;
				tmpvar_4[0] = unity_WorldToObject[0].xyz;
				tmpvar_4[1] = unity_WorldToObject[1].xyz;
				tmpvar_4[2] = unity_WorldToObject[2].xyz;
				float3 tmpvar_5;
				tmpvar_5 = normalize(mul(tmpvar_4,v.normal));
				float3 normal_6;
				normal_6 = tmpvar_5;
				float4 tmpvar_7;
				tmpvar_7.w = 1.0;
				tmpvar_7.xyz = normal_6;
				float3 res_8;
				float3 x_9;
				x_9.x = dot (unity_SHAr, tmpvar_7);
				x_9.y = dot (unity_SHAg, tmpvar_7);
				x_9.z = dot (unity_SHAb, tmpvar_7);
				float3 x1_10;
				float4 tmpvar_11;
				tmpvar_11 = (normal_6.xyzz * normal_6.yzzx);
				x1_10.x = dot (unity_SHBr, tmpvar_11);
				x1_10.y = dot (unity_SHBg, tmpvar_11);
				x1_10.z = dot (unity_SHBb, tmpvar_11);
				res_8 = (x_9 + (x1_10 + (unity_SHC.xyz * 
				  ((normal_6.x * normal_6.x) - (normal_6.y * normal_6.y))
				)));
				float3 tmpvar_12;
				tmpvar_12 = max (((1.055 * 
				  pow (max (res_8, float3(0.0, 0.0, 0.0)), float3(0.4166667, 0.4166667, 0.4166667))
				) - 0.055), float3(0.0, 0.0, 0.0));
				res_8 = tmpvar_12;
				o.uv0 = ((v.uv0.xy * _MainTex_ST.xy) + _MainTex_ST.zw);
				o.uv1 = tmpvar_5;
				o.uv2 = (mul(unity_ObjectToWorld , v.vertex)).xyz;
				o.uv3 = max (float3(0.0, 0.0, 0.0), tmpvar_12);
				return o;
			}
			
			float _Cutoff;
			float4 _Color;
			float4 _LightColor0;
			fixed4 frag (v2f i) : SV_Target
			{
				float3 tmpvar_1;
				float3 tmpvar_2;
				float4 c_3;
				float3 tmpvar_4;
				float3 lightDir_5;
				float3 tmpvar_6;
				tmpvar_6 = _WorldSpaceLightPos0.xyz;
				lightDir_5 = tmpvar_6;
				tmpvar_4 = i.uv1;
				float4 tmpvar_7;
				tmpvar_7 = tex2D (_MainTex, i.uv0);
				tmpvar_1 = _LightColor0.xyz;
				tmpvar_2 = lightDir_5;
				float4 c_8;
				float4 c_9;
				float diff_10;
				float tmpvar_11;
				tmpvar_11 = max (0.0, dot (tmpvar_4, tmpvar_2));
				diff_10 = tmpvar_11;
				c_9.xyz = ((tmpvar_7.xyz * tmpvar_1) * diff_10);
				c_9.w = tmpvar_7.w;
				c_8.w = c_9.w;
				c_8.xyz = (c_9.xyz + (tmpvar_7.xyz * i.uv3));
				c_3.xyz = c_8.xyz;
				c_3.w = c_8.w;//1.0;
				float x_4;
				x_4 = (c_3.w - _Cutoff);
				if ((x_4 < 0.0)) {
				  discard;
				};
				return c_3;
			}
			ENDCG
		}
	}
}
