Shader "Unlit/Blinn"
{
    Properties
    {
        _MainTex ("Texture", color) = (1,0,0,1)
        _Ambient("ACol",color) = (1,0,1,1)
        _LCol("LCol",color) = (1,0,1,1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
          //   Tags { "LightMode" = "ForwardBase" }
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
           
            #include "Light.cginc"

            
            ENDCG
        }
//        Pass
//        {
//             Tags { "LightMode" = "ForwardAdd" }
//            CGPROGRAM
//            #pragma vertex vert
//            #pragma fragment frag
//            // make fog work
//            #include "AutoLight.cginc"
//            #include "Light.cginc"
//
//            
//            ENDCG
//        }
        
    }
    FallBack "Diffuse"
}
