// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "KJH/sdOutline" 
{
    Properties
    {
        // Color property for material inspector, default to white
		[NoScaleOffset] _MainTex ("Texture", 2D) = "white" {}
        _Color ("Main Color", Color) = (0.949,0.0431,1,1)
		_OutLine ("Outline Width", Range(0, 0.5)) = 0.03
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
			
			float _OutLine;
			
            float4 vert (float4 vertex : POSITION, float4 normal : NORMAL) : SV_POSITION
            {
				float outLine = _OutLine * (sin(_Time.w * 2)/2 + 1);
				float4 outPos = UnityObjectToClipPos(vertex);
				float3 norm = mul(UNITY_MATRIX_IT_MV, normal);//(float3x3) 
				float2 offset = TransformViewToProjection(norm.xy);
				outPos.xy += offset * outPos.z * outLine;
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

			v2f vert(appdata_base v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.texcoord;
				half3 worldNormal = UnityObjectToWorldNormal(v.normal);
				half nl = max(0, dot(worldNormal, _WorldSpaceLightPos0.xyz));
				o.diff = nl * _LightColor0;

				// the only difference from previous shader:
				// in addition to the diffuse lighting from the main light,
				// add illumination from ambient or light probes
				// ShadeSH9 function from UnityCG.cginc evaluates it,
				// using world space normal
				o.diff.rgb += ShadeSH9(half4(worldNormal, 1));
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
