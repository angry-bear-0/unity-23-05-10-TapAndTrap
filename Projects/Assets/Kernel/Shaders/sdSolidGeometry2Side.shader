Shader "KJH/sdSolidGeometry2Side" 
{
	Properties 
	{
		_MainTex ("Texture", 2D) = "white" {}
       	_Emission ("Emmisive Color", Color) = (0.5, 0.5, 0.5, 1.0)
	}

	SubShader 
	{
		Tags { "Queue" = "Geometry" }
        Lighting On
        Cull Off
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
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
