// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Environment/Lightmap Diffuse Map"
{
    Properties
    {
        _Ambient ( "Ambient", Color ) = (0,0,0,1)
        _Color ( "Color", Color ) = (1,1,1,1)
        _MainTex ( "Diffuse Map (RGB)", 2D ) = "white" {}
    }
    
    SubShader
    {
        Tags { "RenderType"="Opaque" "Queue"="Geometry" "ShaderType"="WBGOpaque" "ShadowSupport"="false" "IgnoreProjector"="true" }
        Pass
        {
            Lighting Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            
            #include "UnityCG.cginc"
            
            half4 _Ambient;
            half4 _Color;
            
            struct v2f
            {
                half4 pos : SV_POSITION;
                half2 uv0 : TEXCOORD0;
                half2 uv1 : TEXCOORD1;
            };
            
            struct appdata
            {
                half4 vertex : POSITION;
                half4 texcoord0 : TEXCOORD0;
                half4 texcoord1 : TEXCOORD1;
            };
                        
            sampler2D _MainTex;
            half4 _MainTex_ST;
            
            v2f vert( appdata v )
            {
                v2f o;
                o.pos = UnityObjectToClipPos( v.vertex );
                o.uv0 = TRANSFORM_TEX( v.texcoord0, _MainTex );
                o.uv1 = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
                return o;
            }
            
            fixed4 frag( v2f v ) : COLOR
            {
                half4 c = _Ambient;
                c += tex2D( _MainTex, v.uv0 ) * _Color;
                c.rgb *= DecodeLightmap( UNITY_SAMPLE_TEX2D( unity_Lightmap, v.uv1 ) );
                return c;
            }
            
            
            ENDCG
        }
        
    }
}