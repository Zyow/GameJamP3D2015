Shader "Cartoon/Cartoon_Outline" {
	Properties {
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Shininess ("Shininess", Range (0.03, 1)) = 0.078125 
		_SpecMap ("SpecMap", 2D) = "white" {}
		_Ramp ("Ramp (RGB)", 2D) = "white" {}
		_OutlineColor ("Outline Color", Color) = (0,0,0,1)
        _Outline ("Outline width", Range (0, 0.1)) = .005
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		Pass
        {
            // Pass drawing outline
            Cull Front
       
            Blend SrcAlpha OneMinusSrcAlpha
           
            CGPROGRAM
            #include "UnityCG.cginc"
            #pragma vertex vert
            #pragma fragment frag
           
            uniform float _Outline;
            uniform float4 _OutlineColor;
            uniform float4 _MainTex_ST;
            uniform sampler2D _MainTex;
 
            struct v2f
            {
                float4 pos : POSITION;
                float4 color : COLOR;
            };
           
            v2f vert(appdata_base v)
            {
                v2f o;
                o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
                float3 norm   = mul ((float3x3)UNITY_MATRIX_IT_MV, v.normal);
                float2 offset = TransformViewToProjection(norm.xy);
                o.pos.xy += offset  * _Outline;
                o.color = _OutlineColor;
                return o;
            }
           
            half4 frag(v2f i) :COLOR
            {
                return i.color;
            }
                   
            ENDCG
        }
        
        CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Ramp fullforwardshadows vertex:vert

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 4.0

		sampler2D _MainTex;
		sampler2D _Ramp;
		sampler2D _SpecMap;
		half _Shininess;

		struct Input {
			float2 uv_MainTex;
			float3 viewDir;
			float4 lightDir;
			float2 uv_SpecMap;
			half3 tangent_input;
            half3 binormal_input;                        
        };
 		
 		float4 LightingRamp (SurfaceOutput s,float3 lightDir, float3 viewDir, half atten)
		{
			float _Dot = ((dot(s.Normal,lightDir))+1)*0.5;
			float4 _ramplight = tex2D(_Ramp, float2(_Dot,_Dot)) ;
			
			float _speclight = tex2D(_SpecMap, float2(_Dot,_Dot)) * _Shininess;
			
			float4 c;
			c.rgb = s.Albedo * _LightColor0.rgb * (_ramplight * _speclight * atten *2);
			return c;
		}
 		
 		void vert(inout appdata_full i, out Input o)
			{      
			    UNITY_INITIALIZE_OUTPUT(Input, o);
			 
			    half4 p_normal = mul(float4(i.normal,0.0f),_World2Object);
			    half4 p_tangent =  normalize(mul(_Object2World,i.tangent));

			    half3 binormal_input = cross(p_normal.xyz,p_tangent.xyz) * i.tangent.w;
			               
			    o.tangent_input = p_tangent ;
			    o.binormal_input = binormal_input ;
			}

		void surf (Input IN, inout SurfaceOutput o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
//			fixed4 specTex = tex2D(_SpecMap, IN.uv_SpecMap);

			o.Albedo = c.rgb;
// 			o.Gloss = specTex.r;
// 			o.Specular = _Shininess * specTex.g;

			// Metallic and smoothness come from slider variables
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
