Shader "Custom/Color/SliderBar"
{
	Properties
	{
		//_MainTex ("Sprite Texture", 2D) = "white" {}
		_Color ("Tint", Color) = (1,1,1,1)
		_Fill("Fill Amount", Range(0.0, 1.0)) = 1.0
	}

	SubShader
	{
		Tags
		{ 
			"Queue"="Transparent" 
			"IgnoreProjector"="True" 
			"RenderType"="Transparent" 
			"PreviewType"="Plane"
			"CanUseSpriteAtlas"="True"
		}

		Cull Back
		Lighting Off
		ZWrite Off
		Blend One OneMinusSrcAlpha

		Pass {
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma target 2.0
			#include "UnityCG.cginc"
			
			struct appdata_t {
				float4 vertex   : POSITION;
				float2 texcoord : TEXCOORD0;
			};

			struct v2f {
				float4 vertex   : SV_POSITION;
				fixed4 color    : COLOR;
				float2 texcoord  : TEXCOORD0;
			};
			
			fixed4 _Color;
			float _Fill;
			//sampler2D _MainTex;

			v2f vert(appdata_t IN) {
				v2f OUT;
				OUT.vertex = UnityObjectToClipPos(IN.vertex);
				OUT.texcoord = IN.texcoord;
				OUT.color = _Color;
				return OUT;
			}

			fixed4 frag(v2f IN) : SV_Target {
				fixed4 c;
				if (IN.texcoord.x > _Fill) {
					c = 0;
				} else {
					//c = tex2D(_MainTex, IN.texcoord) * IN.color;
					c = IN.color;
				} 
				return c;
			}
			ENDCG
		}
	}
}
