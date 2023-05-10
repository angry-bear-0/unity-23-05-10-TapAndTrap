Shader "KJH/sdAlphaGeometry" 
{
	Properties 
	{
		_MainTex ("Texture", 2D) = "white" {}
       	_Emission ("Emmisive Color", Color) = (0.5, 0.5, 0.5, 1.0)
	}

	SubShader 
	{
		Tags { "Queue" = "Transparent" }
        Lighting Off
        Cull Back
        Blend SrcAlpha OneMinusSrcAlpha
        
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
		 	o.Albedo = 2 * c.rgb * (0.8f * IN.color.rgb + 0.2f * _Emission.rgb);
		 	o.Alpha	= c.a * _Emission.a;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
