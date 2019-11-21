Shader "Unlit/TextTilt"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Mag("Magnitude", float) = 0
        _Speed("Speed", float) = 100
    }
    SubShader
    {
        Tags 
        { 
            "RenderType"="Transparent"
            "Queue" = "Transparent"
         }
        LOD 100
        ZWrite Off
        Blend One OneMinusSrcAlpha
        Cull Off

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
           

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _Mag,_Speed;
            
            float rnd(float x){
                return sin(x*1.23)+sin(x*.241)+sin(x*3.123)+sin(x*.57576) +cos(x*1.324);
            }

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                
                float2 offset = float2(rnd(_Time*_Speed), rnd(_Time*_Speed+13*_Speed));
                o.vertex += float4(offset * _Mag,0,0);
                
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                col.rgb *= col.a;
                return col;
            }
            ENDCG
        }
    }
}
