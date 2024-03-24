#include "UnityCG.cginc"
#include "AutoLight.cginc"
#include "Lighting.cginc"

struct appdata
{
    float4 vertex : POSITION;
    float3 Norm : NORMAL;
    float2 uv : TEXCOORD0;
};

struct v2f
{
    float2 uv : TEXCOORD0;
    float3 N : TEXCOORD1;
               
    float4 vertex : SV_POSITION;
};

float4 _MainTex;
float4 _MainTex_ST, _Ambient;


v2f vert (appdata v)
{
    v2f o;
    o.vertex = UnityObjectToClipPos(v.vertex);
    o.uv = TRANSFORM_TEX(v.uv, _MainTex);

    o.N = v.Norm;
    return o;
}

fixed4 frag (v2f i) : SV_Target
{
    // sample the texture

    float4 lambert = saturate(dot(normalize(i.N), normalize(_WorldSpaceLightPos0)))*_LightColor0 + _Ambient;
    
    float4 col = _MainTex;
    // apply fog
          //  return float4(i.N,1);
   // return float4((col*lambert).xyz,1);
  
    return float4((col*lambert).xyz,1);
}