// Upgrade NOTE: replaced 'glstate_matrix_mvp' with 'UNITY_MATRIX_MVP'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "hgn/Curve" 
{
	Properties 
	{
	    [NoScaleOffset]_Color ("Main Color", Color) = (1,1,1,0.5)
	    [NoScaleOffset]_MainTex ("Texture", 2D) = "white" { }
	}
	SubShader 
	{
		LOD 150
		Tags { "RenderType"="Opaque" }
	    Pass 
	    {
			Name "FORWARD"
			Tags { "LIGHTMODE"="ForwardBase" "SHADOWSUPPORT"="true" "RenderType"="Opaque" }
		CGPROGRAM
// Upgrade NOTE: excluded shader from OpenGL ES 2.0 because it uses non-square matrices
//		#pragma exclude_renderers gles
		#pragma vertex vert
		#pragma fragment frag

		#include "UnityCG.cginc"

		
		struct v2f 
		{
		    float4  pos : SV_POSITION;
		    float4 norm: NORMAL;
		    float2  uv0 : TEXCOORD0;
			float3 uv1 : TEXCOORD1;
			float3 uv2 : TEXCOORD2;
			float3 uv3 : TEXCOORD3;
			float3 uv4 : TEXCOORD4;
		};
		
		struct appdata {
            float4 vertex : POSITION;
			float3 normal : NORMAL;
            float4 uv0 : TEXCOORD0;
			
        };
		
		float4 _Color;
		sampler2D _MainTex;
		float _Offset;
		float4 _MainTex_ST;


/*		uniform 	float4 unity_4LightPosX0;
		uniform 	float4 unity_4LightPosY0;
		uniform 	float4 unity_4LightPosZ0;
		uniform 	float4 unity_4LightAtten0;
		uniform 	float4 unity_LightColor[8];
		uniform 	float4 unity_SHAr;
		uniform 	float4 unity_SHAg;
		uniform 	float4 unity_SHAb;
		uniform 	float4 unity_SHBr;
		uniform 	float4 unity_SHBg;
		uniform 	float4 unity_SHBb;
		uniform 	float4 unity_SHC;*/
		uniform 	float4 hlslcc_mtx4x4unity_WorldToShadow[16];
		uniform 	float4 hlslcc_mtx4x4glstate_matrix_mvp[4];
		uniform 	float4 hlslcc_mtx4x4unity_ObjectToWorld[4];
		uniform 	float4 hlslcc_mtx4x4unity_WorldToObject[4];
		/*in highp vec4 in_POSITION0;
		in highp vec3 in_NORMAL0;
		in highp vec4 in_TEXCOORD0;*/
		/*out highp vec2 vs_TEXCOORD0;
		out mediump vec3 vs_TEXCOORD1;
		out highp vec3 vs_TEXCOORD2;
		out mediump vec3 vs_TEXCOORD3;
		out highp vec4 vs_TEXCOORD4;*/
		float4 u_xlat0;
		float4 u_xlat1;
		float4 u_xlat2;
		float4 u_xlat16_2;
		float4 u_xlat3;
		float4 u_xlat4;
		float3 u_xlat16_5;
		float3 u_xlat16_6;
		float u_xlat21;


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


			/*u_xlat0 = in_POSITION0.yyyy * hlslcc_mtx4x4glstate_matrix_mvp[1];
			u_xlat0 = hlslcc_mtx4x4glstate_matrix_mvp[0] * in_POSITION0.xxxx + u_xlat0;
			u_xlat0 = hlslcc_mtx4x4glstate_matrix_mvp[2] * in_POSITION0.zzzz + u_xlat0;
			gl_Position = u_xlat0 + hlslcc_mtx4x4glstate_matrix_mvp[3];*/
			o.uv0.xy = v.uv0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
			u_xlat0.x = dot(v.normal.xyz, hlslcc_mtx4x4unity_WorldToObject[0].xyz);
			u_xlat0.y = dot(v.normal.xyz, hlslcc_mtx4x4unity_WorldToObject[1].xyz);
			u_xlat0.z = dot(v.normal.xyz, hlslcc_mtx4x4unity_WorldToObject[2].xyz);
			u_xlat21 = dot(u_xlat0.xyz, u_xlat0.xyz);
			u_xlat21 = sqrt(u_xlat21);//inverse
			u_xlat0.xyz = float3(u_xlat21,u_xlat21,u_xlat21) * u_xlat0.xyz;
			o.uv1.xyz = u_xlat0.xyz;
			u_xlat1.xyz = v.vertex.yyy * hlslcc_mtx4x4unity_ObjectToWorld[1].xyz;
			u_xlat1.xyz = hlslcc_mtx4x4unity_ObjectToWorld[0].xyz * v.vertex.xxx + u_xlat1.xyz;
			u_xlat1.xyz = hlslcc_mtx4x4unity_ObjectToWorld[2].xyz * v.vertex.zzz + u_xlat1.xyz;
			u_xlat1.xyz = hlslcc_mtx4x4unity_ObjectToWorld[3].xyz * v.vertex.www + u_xlat1.xyz;
			o.uv2.xyz = u_xlat1.xyz;
			u_xlat2 = (-u_xlat1.xxxx) + unity_4LightPosX0;
			u_xlat3 = (-u_xlat1.yyyy) + unity_4LightPosY0;
			u_xlat1 = (-u_xlat1.zzzz) + unity_4LightPosZ0;
			u_xlat4 = u_xlat0.yyyy * u_xlat3;
			u_xlat3 = u_xlat3 * u_xlat3;
			u_xlat3 = u_xlat2 * u_xlat2 + u_xlat3;
			u_xlat2 = u_xlat2 * u_xlat0.xxxx + u_xlat4;
			u_xlat2 = u_xlat1 * u_xlat0.zzzz + u_xlat2;
			u_xlat1 = u_xlat1 * u_xlat1 + u_xlat3;
			u_xlat1 = max(u_xlat1, float4(9.99999997e-007, 9.99999997e-007, 9.99999997e-007, 9.99999997e-007));
			u_xlat3 = sqrt(u_xlat1);
			u_xlat1 = u_xlat1 * unity_4LightAtten0 + float4(1.0, 1.0, 1.0, 1.0);
			u_xlat1 = float4(1.0, 1.0, 1.0, 1.0) / u_xlat1;
			u_xlat2 = u_xlat2 * u_xlat3;
			u_xlat2 = max(u_xlat2, float4(0.0, 0.0, 0.0, 0.0));
			u_xlat1 = u_xlat1 * u_xlat2;
			u_xlat2.xyz = u_xlat1.yyy * unity_LightColor[1].xyz;
			u_xlat2.xyz = unity_LightColor[0].xyz * u_xlat1.xxx + u_xlat2.xyz;
			u_xlat1.xyz = unity_LightColor[2].xyz * u_xlat1.zzz + u_xlat2.xyz;
			u_xlat1.xyz = unity_LightColor[3].xyz * u_xlat1.www + u_xlat1.xyz;
			u_xlat16_5.x = u_xlat0.y * u_xlat0.y;
			u_xlat16_5.x = u_xlat0.x * u_xlat0.x + (-u_xlat16_5.x);
			u_xlat16_2 = u_xlat0.yzzx * u_xlat0.xyzz;
			u_xlat16_6.x = dot(unity_SHBr, u_xlat16_2);
			u_xlat16_6.y = dot(unity_SHBg, u_xlat16_2);
			u_xlat16_6.z = dot(unity_SHBb, u_xlat16_2);
			u_xlat16_5.xyz = unity_SHC.xyz * u_xlat16_5.xxx + u_xlat16_6.xyz;
			u_xlat0.w = 1.0;
			u_xlat16_6.x = dot(unity_SHAr, u_xlat0);
			u_xlat16_6.y = dot(unity_SHAg, u_xlat0);
			u_xlat16_6.z = dot(unity_SHAb, u_xlat0);
			u_xlat16_5.xyz = u_xlat16_5.xyz + u_xlat16_6.xyz;
			u_xlat16_5.xyz = max(u_xlat16_5.xyz, float3(0.0, 0.0, 0.0));
			u_xlat0.xyz = log2(u_xlat16_5.xyz);
			u_xlat0.xyz = u_xlat0.xyz * float3(0.416666657, 0.416666657, 0.416666657);
			u_xlat0.xyz = exp2(u_xlat0.xyz);
			u_xlat0.xyz = u_xlat0.xyz * float3(1.05499995, 1.05499995, 1.05499995) + float3(-0.0549999997, -0.0549999997, -0.0549999997);
			u_xlat0.xyz = max(u_xlat0.xyz, float3(0.0, 0.0, 0.0));
			o.uv3.xyz = u_xlat0.xyz + u_xlat1.xyz;
			u_xlat0 = v.vertex.yyyy * hlslcc_mtx4x4unity_ObjectToWorld[1];
			u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[0] * v.vertex.xxxx + u_xlat0;
			u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[2] * v.vertex.zzzz + u_xlat0;
			u_xlat0 = hlslcc_mtx4x4unity_ObjectToWorld[3] * v.vertex.wwww + u_xlat0;
			u_xlat1 = u_xlat0.yyyy * hlslcc_mtx4x4unity_WorldToShadow[1];
			u_xlat1 = hlslcc_mtx4x4unity_WorldToShadow[0] * u_xlat0.xxxx + u_xlat1;
			u_xlat1 = hlslcc_mtx4x4unity_WorldToShadow[2] * u_xlat0.zzzz + u_xlat1;
			o.uv4 = hlslcc_mtx4x4unity_WorldToShadow[3] * u_xlat0.wwww + u_xlat1;
			return o;
		}


		float4 _LightColor0;


		//precision highp int;
		sampler2D hlslcc_zcmp_ShadowMapTexture;//Shadow
		sampler2D _ShadowMapTexture;
		/*in highp vec2 vs_TEXCOORD0;
		in mediump vec3 vs_TEXCOORD1;
		in mediump vec3 vs_TEXCOORD3;
		in highp vec4 vs_TEXCOORD4;*/
		//layout(location = 0) out lowp vec4 SV_Target0;
		float4 u_xlat10_0;
		float4 u_xlat16_1;
//		float4 u_xlat16_2;
		float u_xlat16_10;
		float4 frag (v2f i) : COLOR
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
			c_3.w = 1.0;
			return c_3;


	/*		float3 txVec3 = float3(i.uv4.xy,i.uv4.z);
			u_xlat10_0.x = tex(hlslcc_zcmp_ShadowMapTexture, txVec3, 0.0);
//			u_xlat10_0.x = hlslcc_zcmp_ShadowMapTexture * txVec3 * 0.0;
			u_xlat16_1.x = (-_LightShadowData.x) + 1.0;
			u_xlat16_1.x = u_xlat10_0.x * u_xlat16_1.x + _LightShadowData.x;
			u_xlat16_1.xyz = u_xlat16_1.xxx * _LightColor0.xyz;
			u_xlat10_0.xyz = text3D(_MainTex, i.uv0.xy).xyz;
			u_xlat16_1.xyz = u_xlat16_1.xyz * u_xlat10_0.xyz;
			u_xlat16_2.xyz = u_xlat10_0.xyz * i.uv3.xyz;
			u_xlat16_10 = dot(i.uv1.xyz, _WorldSpaceLightPos0.xyz);
			u_xlat16_10 = max(u_xlat16_10, 0.0);
			u_xlat16_1.xyz = u_xlat16_1.xyz * vec3(u_xlat16_10) + u_xlat16_2.xyz;
			SV_Target0.xyz = u_xlat16_1.xyz;
			SV_Target0.w = 1.0;
			return;*/
		}
		

		ENDCG

	    }
	}
//	Fallback "VertexLit"
//	Fallback "Mobile/VertexLit"
	FallBack "Diffuse"
}