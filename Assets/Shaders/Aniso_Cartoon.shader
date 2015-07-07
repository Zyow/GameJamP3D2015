Shader "Cartoon/Cartoon_Aniso" {
	Properties {
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Ramp ("Ramp (RGB)", 2D) = "white" {}
		_AniX ("Anisotropic X", Range(0.0,2.0)) = 1.0
		_AniY ("Anisotropic Y", Range(0.0,0.1)) = 0.025
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Ramp fullforwardshadows vertex:vert

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 4.0

		sampler2D _MainTex;
		sampler2D _Ramp;
		float _AniX;
		float _AniY;

		struct Input {
			float2 uv_MainTex;
			float3 viewDir;
			float4 lightDir;
			half3 tangent_input;
            half3 binormal_input;                        
        };
 		
 		float4 LightingRamp (SurfaceOutput s,float3 lightDir, float3 viewDir, half atten)
		{
			float _Dot = ((dot(s.Normal,lightDir))+1)*0.5;
			float4 _ramplight = tex2D(_Ramp, float2(_Dot,_Dot)) ;
			
			float4 c;
			c.rgb = s.Albedo * _LightColor0.rgb * (_ramplight * atten *2);
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
			
			
			float3 h = h = normalize(IN.lightDir.xyz+ IN.viewDir);  
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
			
			fixed tDotHX = dot(IN.tangent_input, h) / _AniX;
			fixed bDotHY = dot(IN.binormal_input, h) / _AniY;
			fixed3 specularReflection =  exp( -(tDotHX * tDotHX + bDotHY * bDotHY) );

			o.Albedo = c.rgb + specularReflection/0.01;
			// Metallic and smoothness come from slider variables
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
