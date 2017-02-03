using UnityEngine;
using System.Collections;

public class MapGen : MonoBehaviour {

    public float scale;
    public int seed;
    public Vector2 offset;
    public bool autoUpdate;

    public void GenAllMap(){
        float[,] biomeMap = GenWorldPreview.GenBiomeMap(scale, seed, offset);

        RenderMap display = FindObjectOfType<RenderMap>();
        display.CreateMap(biomeMap);
    }
}
