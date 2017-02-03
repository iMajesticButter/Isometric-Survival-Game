using UnityEngine;
using System.Collections;

public class RenderMap : MonoBehaviour {

    public Renderer textureRenderer;

    public void CreateMap(float[,] biomeMap)
    {
        Texture2D tex = new Texture2D(40, 40);
        tex.wrapMode = TextureWrapMode.Clamp;
        tex.filterMode = FilterMode.Point;
        Color[] colorMap = new Color[64 * 64];
        for (int i = 0; i < 40; ++i)
        {
            for (int l = 0; l < 40; ++l)
            {
                if (biomeMap[l, i] < 0.2)
                {
                    colorMap[i * 40 + l] = Color.blue;
                }
                if (biomeMap[l, i] < 0.3 && biomeMap[l, i] > 0.2)
                {
                    colorMap[i * 40 + l] = Color.yellow;
                }
                if (biomeMap[l, i] < 0.7 && biomeMap[l, i] > 0.3)
                {
                    colorMap[i * 40 + l] = Color.green;
                }
                if (biomeMap[l, i] > 0.7)
                {
                    colorMap[i * 40 + l] = Color.gray;
                }
            }
        }
        tex.SetPixels(colorMap);
        tex.Apply();

        textureRenderer.sharedMaterial.mainTexture = tex;
    }
}
