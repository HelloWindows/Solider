Shader "Custom/2Side_Alpha_Cutout_Custom_shader" {
Properties {
 _Color ("Main Color", Color) = (1,1,1,1)
 _MainTex ("Base (RGB)Trans(A)", 2D) = "white" {}
}
SubShader { 
 LOD 200
 Tags { "QUEUE"="Transparent" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" }
 Pass {
  Tags { "QUEUE"="Transparent" "IGNOREPROJECTOR"="true" "RenderType"="Transparent" }
  Cull Off
  Blend SrcAlpha OneMinusSrcAlpha
  AlphaTest Greater 0.5
  SetTexture [_MainTex] { ConstantColor [_Color] combine texture lerp(constant) constant }
 }
}
Fallback "Mobile Particles Additive"
}