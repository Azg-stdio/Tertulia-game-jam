void DistancePos_half(in float3 playerPos, in float3 worldPos, in float radius, in float4 primaryTexture, in float4 secondaryTexture, out float4 Out )
{
	if (distance(playerPos.xyz, worldPos.xyz) > radius)
	{
		Out = primaryTexture;
	}
	else if (distance(playerPos.xyz, worldPos.xyz) > radius -0.03)
	{ 
		Out = float4 (1,1,1,1);
	}
	else
	{
		Out = secondaryTexture;
	}
}