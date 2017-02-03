using UnityEngine;
using System.Collections;

public class GenWorld {
	
	// Update is called once per frame
	public static float GenBiomeMap (float scale, int seed, Vector2 offset){
        float biomeMap = 0;

        System.Random randomGen = new System.Random(seed);
        float OffsetX = randomGen.Next(-100000, 100000);
        float OffsetY = randomGen.Next(-100000, 100000);

        if (scale <= 0)
        {
            scale = 0.0001f;
        }
        float sampleX = offset.x / scale + OffsetX;
        float sampleY = offset.y / scale + OffsetY;

        float perlinNoise = Mathf.PerlinNoise(sampleX, sampleY);
        biomeMap = perlinNoise;
        return biomeMap;
    }
}
