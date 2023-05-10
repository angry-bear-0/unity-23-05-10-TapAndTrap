Shader "hgn/sdOutline" 
{
    Properties
    {
        // Color property for material inspector, default to white
		[NoScaleOffset] _MainTex ("Texture", 2D) = "white" {}
        _Color ("Main Color", Color) = (1,1,1,1)
		_OutLine ("Outline Width", Range(0, 0.1)) = 0.01
    }
    SubShader
    {	
         Pass
        {
			Cull Front
			//ZWrite Off
			//ZTest Always
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
			#include "UnityCG.cginc"
            // vertex shader
            // this time instead of using "appdata" struct, just spell inputs manually,
            // and instead of returning v2f struct, also just return a single output
            // float4 clip position
			
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

			float _OutLine;
			float _Offset;
			
            float4 vert (float4 vertex : POSITION, float4 normal : NORMAL) : SV_POSITION
            {
				float4 outPos;
				float OffsetZ;
				float Delta;

				outPos = mul (unity_ObjectToWorld, vertex);
				OffsetZ = outPos.z - _Offset;
				if(OffsetZ > - 5)
				{
					Delta = OffsetZ * OffsetZ / 381.97;//381.972
					outPos.x -= Delta;
					outPos.y -= Delta;
				}
				outPos = mul (UNITY_MATRIX_VP, outPos);

				float outLine = _OutLine * (sin(_Time.w * 2) * 0.75);
				float3 norm = mul(UNITY_MATRIX_IT_MV, normal);//(float3x3) 
				float2 offset = TransformViewToProjection(norm);
				outPos.xy +=   offset * outLine;//outPos.z *
                return outPos;
            }
            
            // color from the material
            fixed4 _Color;

            // pixel shader, no inputs needed
            fixed4 frag () : SV_Target
            {
                return _Color; // just return it
            }
            ENDCG
        }

        Pass
        {
            Tags {"LightMode"="ForwardBase"}
			ZTest LEqual
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            #include "UnityLightingCommon.cginc"

            struct v2f
            {
                float2 uv : TEXCOORD0;
                fixed4 diff : COLOR0;
                float4 vertex : SV_POSITION;
            };
			float _Offset;
			v2f vert(appdata_base v)
			{
				v2f o;
				float OffsetZ;
				float Delta;

				o.vertex = mul (unity_ObjectToWorld, v.vertex);
				OffsetZ = o.vertex.z - _Offset;
				
				/*Delta = OffsetZ * OffsetZ /381.97 ;//381.972500
				o.vertex.x -= Delta;
				o.vertex.y -= Delta;*/
				
				o.vertex = mul (UNITY_MATRIX_VP, o.vertex);
				//o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.texcoord;
				half3 worldNormal = UnityObjectToWorldNormal(v.normal);
				half nl = max(0, dot(worldNormal, _WorldSpaceLightPos0.xyz));
				o.diff = nl * _LightColor0;

				// the only difference from previous shader:
				// in addition to the diffuse lighting from the main light,
				// add illumination from ambient or light probes
				// ShadeSH9 function from UnityCG.cginc evaluates it,
				// using world space normal
				o.diff.rgb += ShadeSH9(half4(worldNormal, 0.3));
				return o;
			}
            
            sampler2D _MainTex;

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                col *= i.diff;
                return col;
            }
            ENDCG
        }
		UsePass "Legacy Shaders/VertexLit/SHADOWCASTER"
		//UsePass "Mobile/Diffuse"
		//UsePass "VertexLit"
    }
	//FallBack "Diffuse"
}
