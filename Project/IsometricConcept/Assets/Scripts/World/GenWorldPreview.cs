using UnityEngine;
using System.Collections;

public class GenWorldPreview{

    // Update is called once per frame
    public static float[,] GenBiomeMap(float scale, int seed, Vector2 offset)
    {
        float[,] biomeMap = new float[40,40];

        System.Random randomGen = new System.Random(seed);
        float OffsetX = randomGen.Next(-100000, 100000) + offset.x;
        float OffsetY = randomGen.Next(-100000, 100000) + offset.y;

        if (scale <= 0)
        {
            scale = 0.0001f;
        }
        for (int i = 0; i < 40; ++i)
        {
            for (int l = 0; l < 40; ++l)
            {
                float sampleX = l / scale + OffsetX;
                float sampleY = i / scale + OffsetY;

                float perlinNoise = Mathf.PerlinNoise(sampleX, sampleY);
                biomeMap[l,i] = perlinNoise;
            }
        }
        return biomeMap;
    }
}
