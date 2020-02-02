// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "M_BasicEmissive"
{
	Properties
	{
		_Cutoff( "Mask Clip Value", Float ) = 0.5
		_Albedo("Albedo", 2D) = "white" {}
		_Mask("Mask", 2D) = "white" {}
		_Alpha1("Alpha", 2D) = "white" {}
		_Color("Color", Color) = (0.6415094,0.390392,0.1180135,0)
		_EmissiveIntensity("Emissive Intensity", Float) = 1
		_ColorIntensity("ColorIntensity", Float) = 0
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Geometry+0" "IsEmissive" = "true"  }
		Cull Back
		CGPROGRAM
		#pragma target 3.0
		#pragma surface surf Standard keepalpha addshadow fullforwardshadows exclude_path:deferred 
		struct Input
		{
			float2 uv_texcoord;
		};

		uniform float4 _Color;
		uniform float _ColorIntensity;
		uniform sampler2D _Albedo;
		uniform float4 _Albedo_ST;
		uniform sampler2D _Mask;
		uniform float4 _Mask_ST;
		uniform float _EmissiveIntensity;
		uniform sampler2D _Alpha1;
		uniform float4 _Alpha1_ST;
		uniform float _Cutoff = 0.5;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_Albedo = i.uv_texcoord * _Albedo_ST.xy + _Albedo_ST.zw;
			o.Albedo = ( _Color * ( _ColorIntensity + tex2D( _Albedo, uv_Albedo ) ) ).rgb;
			float2 uv_Mask = i.uv_texcoord * _Mask_ST.xy + _Mask_ST.zw;
			o.Emission = ( tex2D( _Mask, uv_Mask ) * _EmissiveIntensity ).rgb;
			o.Alpha = 1;
			float2 uv_Alpha1 = i.uv_texcoord * _Alpha1_ST.xy + _Alpha1_ST.zw;
			clip( tex2D( _Alpha1, uv_Alpha1 ).r - _Cutoff );
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=17700
6.4;45.6;1524;751;969.2615;127.7266;1.334766;True;True
Node;AmplifyShaderEditor.SamplerNode;1;-573.5,33;Inherit;True;Property;_Albedo;Albedo;1;0;Create;True;0;0;False;0;-1;055d5626238f7924fa73d52d28a1590c;055d5626238f7924fa73d52d28a1590c;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.RangedFloatNode;19;-449.2401,-247.8197;Inherit;False;Property;_ColorIntensity;ColorIntensity;6;0;Create;True;0;0;False;0;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.ColorNode;15;-524.9053,-140.6836;Inherit;False;Property;_Color;Color;4;0;Create;True;0;0;False;0;0.6415094,0.390392,0.1180135,0;0.6415094,0.390392,0.1180135,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleAddOpNode;18;-212.2007,-243.8022;Inherit;False;2;2;0;FLOAT;0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.RangedFloatNode;8;-513.1672,450.6006;Inherit;False;Property;_EmissiveIntensity;Emissive Intensity;5;0;Create;True;0;0;False;0;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;6;-576.4366,232.5271;Inherit;True;Property;_Mask;Mask;2;0;Create;True;0;0;False;0;-1;53ce896ab62be9647a20055047ec67c5;53ce896ab62be9647a20055047ec67c5;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;7;-170.9323,240.4009;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;14;-3.647856,-129.3074;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.SamplerNode;20;-568.8062,553.004;Inherit;True;Property;_Alpha1;Alpha;3;0;Create;True;0;0;False;0;-1;5ff84948f8ea2af478697183392967a8;53ce896ab62be9647a20055047ec67c5;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;529.6685,57.75285;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;M_BasicEmissive;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Custom;0.5;True;True;0;True;Transparent;;Geometry;ForwardOnly;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;0;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;18;0;19;0
WireConnection;18;1;1;0
WireConnection;7;0;6;0
WireConnection;7;1;8;0
WireConnection;14;0;15;0
WireConnection;14;1;18;0
WireConnection;0;0;14;0
WireConnection;0;2;7;0
WireConnection;0;10;20;0
ASEEND*/
//CHKSM=B5FF172EEFC4B770C23F1F0CD3E264786C1928B4