// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "New Amplify Shader"
{
	Properties
	{
		_Cutoff( "Mask Clip Value", Float ) = 0.5
		_Opacity("Opacity", 2D) = "white" {}
		_Color("Color", Color) = (0,0,0,0)
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
		uniform sampler2D _Opacity;
		uniform float4 _Opacity_ST;
		uniform float _ColorIntensity;
		uniform float _Cutoff = 0.5;

		void surf( Input i , inout SurfaceOutputStandard o )
		{
			float2 uv_Opacity = i.uv_texcoord * _Opacity_ST.xy + _Opacity_ST.zw;
			float4 tex2DNode1 = tex2D( _Opacity, uv_Opacity );
			float4 temp_output_4_0 = ( _Color * ( tex2DNode1 * _ColorIntensity ) );
			o.Albedo = temp_output_4_0.rgb;
			o.Emission = temp_output_4_0.rgb;
			o.Alpha = 1;
			clip( tex2DNode1.a - _Cutoff );
		}

		ENDCG
	}
	Fallback "Diffuse"
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=17700
6.4;0.8;1524;796;1005;242.5;1;True;True
Node;AmplifyShaderEditor.RangedFloatNode;6;-522,-175;Inherit;False;Property;_ColorIntensity;ColorIntensity;3;0;Create;True;0;0;False;0;0;3.7;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.SamplerNode;1;-760,190;Inherit;True;Property;_Opacity;Opacity;1;0;Create;True;0;0;False;0;-1;e670949a1504b7446b331f677516f7d6;e670949a1504b7446b331f677516f7d6;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1;False;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.ColorNode;3;-739,-36;Inherit;False;Property;_Color;Color;2;0;Create;True;0;0;False;0;0,0,0,0;0,0.8018868,0.77679,0;True;0;5;COLOR;0;FLOAT;1;FLOAT;2;FLOAT;3;FLOAT;4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;5;-410,100;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;FLOAT;0;False;1;COLOR;0
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;4;-237,-12;Inherit;False;2;2;0;COLOR;0,0,0,0;False;1;COLOR;0,0,0,0;False;1;COLOR;0
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;0,0;Float;False;True;-1;2;ASEMaterialInspector;0;0;Standard;New Amplify Shader;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;False;Back;0;False;-1;0;False;-1;False;0;False;-1;0;False;-1;False;0;Custom;0.5;True;True;0;True;Transparent;;Geometry;ForwardOnly;14;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;0;0;False;-1;0;False;-1;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;Relative;0;;0;-1;-1;-1;0;False;0;0;False;-1;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;False;-1;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;5;0;1;0
WireConnection;5;1;6;0
WireConnection;4;0;3;0
WireConnection;4;1;5;0
WireConnection;0;0;4;0
WireConnection;0;2;4;0
WireConnection;0;10;1;4
ASEEND*/
//CHKSM=B82B8824389BB8CFE50D60B82B32CCEDF055073A