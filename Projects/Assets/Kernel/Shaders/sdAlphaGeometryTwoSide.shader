Shader "KJH/sdAlphaGeometryTwoSide" 
{
	Properties 
	{
		_MainTex ("Texture", 2D) = "white" {}
       	_Emission ("Emmisive Color", Color) = (0.5, 0.5, 0.5, 1.0)
       	_Cutoff ("Alpha cutoff", Range (0,1)) = 0.1
	}

	SubShader 
	{
		Tags { "Queue" = "Transparent" }
        Lighting Off
        Cull Off
        Blend SrcAlpha OneMinusSrcAlpha
        AlphaTest Greater [_Cutoff]
        SeparateSpecular Off

		CGPROGRAM
		#pragma surface surf Lambert
		struct Input 
		{
			float4 color : COLOR;
			float2 uv_MainTex;
		};

		sampler2D _MainTex;
		float4 _Emission;
		
		void surf (Input IN, inout SurfaceOutput o) 
		{
			float4 c = tex2D(_MainTex, IN.uv_MainTex);
		 	o.Albedo = c.rgb * (0.5f * IN.color.rgb + 0.5f * _Emission.rgb);
		 	o.Alpha	= c.a * _Emission.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
