Shader "KJH/sdAlphaBlend" 
{
	Properties 
	{
		_MainTex ("Base (RGB) Self-Illumination (A)", 2D) = "white" {}
       	_Color ("Emmisive Color", Color) = (0.5, 0.5, 0.5, 1.0)
	}

	SubShader 
	{
		Tags { "Queue"="Transparent"}
        Lighting Off
        Cull Back
        SeparateSpecular Off
		Blend SrcAlpha OneMinusSrcAlpha
		Pass
		{
			SetTexture [_MainTex]
			{
				ConstantColor [_Color]
				Combine Constant * Texture 
			}
		}
	} 
}
