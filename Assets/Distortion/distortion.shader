Shader "Unlit/distortion"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_DistorionToggle("DistorionToggle",Range(0,1)) = 1
		_DistorionPointX("DistionPointX",Range(0,1)) = 0.5
		_DistorionPointY("DistionPointY",Range(0,1)) = 0.5

		_Ratio("Ratio",float) = 1
		xAdd("xAdd",float) = 0.05
		yAdd("yAdd",float) = 0.03
		radiusA("radiusA",float) = 0.03
		radius("radius",float) = 0.03
		upvalue("upvalue",float) = 1
			
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

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

			float _DistorionPointX;
			float _DistorionPointY;
			float _Ratio;
			float radiusA;
			float radius;
			float xAdd;
			float yAdd;
			float upvalue;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

			float2 scaleUV(float2 uv)
			{
				float2 newOriginUV = float2(_DistorionPointX, _DistorionPointY);
				float2 newUV = float2(uv.x, uv.y);
				if (_Ratio < 1)
				{
					newOriginUV = float2(_DistorionPointX*_Ratio, _DistorionPointY);
					newUV = float2(uv.x*_Ratio, uv.y);
				}
				else if (_Ratio > 1) {
					newOriginUV = float2(_DistorionPointX, _DistorionPointY / _Ratio);
					newUV = float2(uv.x, uv.y / _Ratio);
				}

				float ds = distance(newUV, newOriginUV)*4;
				ds = 1-min(ds,10);
				return uv + (newOriginUV -uv) * ds;
			}

			float2 distortionUV(float2 uv)
			{
				float2 newOriginUV = float2(_DistorionPointX, _DistorionPointY);
				float2 newUV = float2(uv.x, uv.y);
				if (_Ratio < 1)
				{
					newOriginUV = float2(_DistorionPointX*_Ratio, _DistorionPointY);
					newUV = float2(uv.x*_Ratio, uv.y);
				}
				else if (_Ratio > 1) {
					newOriginUV = float2(_DistorionPointX, _DistorionPointY / _Ratio);
					newUV = float2(uv.x, uv.y / _Ratio);
				}

				///////////////////////////////////////////////////////


				float ys = newUV.y - newOriginUV.y;
				ys = min(ys, radiusA);
				ys = max(ys, radiusA*-1)/ radiusA; //-1  1
				ys = 1-abs(ys);//1-0
				//ys = pow(ys,10);

				float xs = newUV.x - newOriginUV.x;
				xs = min(xs, radiusA);
				xs = max(xs, radiusA*-1)/ radiusA;   //-1  1
				xs = 1 - abs(xs);//1-0
				//xs = pow(xs, 10);

				newUV = float2(newUV.x + xAdd * ys*xs, newUV.y + yAdd * xs*ys);

				///////////////////////////////////////////////////////



				float absDis = distance(newUV, newOriginUV);

				float2 direction = normalize(newUV - newOriginUV);

				float2 pointToScal = newOriginUV + direction * radius;

				float dir2 = newUV - pointToScal;
				float dis2 = distance(newUV, pointToScal);
				float rat = dis2 / radius;
				rat = 1-min(rat, 1);
				//rat = pow(rat, 2);

				if (absDis > radius)
				{
					rat = rat * 0.1;
				}

				return newUV + rat * (pointToScal - newUV)*upvalue;
			}

			float2 distortionUV_1(float2 uv)
			{
				float2 newOriginUV = float2(_DistorionPointX, _DistorionPointY);
				float2 newUV = float2(uv.x, uv.y);
				if (_Ratio < 1)
				{
					newOriginUV = float2(_DistorionPointX*_Ratio, _DistorionPointY);
					newUV = float2(uv.x*_Ratio, uv.y);
				}
				else if (_Ratio > 1) {
					newOriginUV = float2(_DistorionPointX, _DistorionPointY / _Ratio);
					newUV = float2(uv.x, uv.y / _Ratio);
				}

				///////////////////////////////////////////////////////

				float ys = newUV.y - newOriginUV.y;
				ys = min(ys, radiusA);
				ys = max(ys, radiusA*-1) / radiusA; //-1  1
				ys = 1 - abs(ys);//1-0
				//ys = pow(ys,0.5);

				float xs = newUV.x - newOriginUV.x;
				xs = min(xs, radiusA);
				xs = max(xs, radiusA*-1) / radiusA;   //-1  1
				xs = 1 - abs(xs);//1-0
				//xs = pow(xs, 0.5);

				newUV = float2(newUV.x + xAdd * ys*xs, newUV.y + yAdd * xs*ys);

				///////////////////////////////////////////////////////

				float absDis = distance(newUV, newOriginUV);

				float2 direction = normalize(newUV - newOriginUV);

				float2 pointToScal = newOriginUV + direction * radius;

				float dir2 = newUV - pointToScal;
				float dis2 = distance(newUV, pointToScal);
				float rat = dis2 / radius;
				rat = 1 - min(rat, 1);
				//rat = pow(rat, 2);

				if (absDis > radius)
				{
					float yv = 0;
					float xv = 0;
					if (newUV.y > pointToScal.y)
					{
						yv = newUV.y - pointToScal.y;
					}
					if (newUV.x > pointToScal.x) 
					{
						xv = newUV.x - pointToScal.x;
					}

					rat = rat* pow((1 - yv)*(1 - xv),10)*0.5;
				}
				
				//rat = pow(rat, 2);

				return newUV + rat * (pointToScal - newUV)*upvalue;
			}

            fixed4 frag (v2f i) : SV_Target
            {
				float2 uv = distortionUV_1(i.uv);
                // sample the texture
                fixed4 col = tex2D(_MainTex, uv);
                return col;
            }
            ENDCG
        }
    }
}
