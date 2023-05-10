Shader "KJH/sdAlphaCutoff" 
{
	Properties 
	{
		_MainTex ("Base (RGB) Self-Illumination (A)", 2D) = "white" {}
       	_Color ("Emmisive Color", Color) = (0.5, 0.5, 0.5, 1.0)
		_Cutoff ("Alpha cutoff", Range (0,1)) = 0.1
	}

	SubShader 
	{
        Lighting Off
        Cull Back
        SeparateSpecular Off
		Blend Off
        AlphaTest Greater [_Cutoff]
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
