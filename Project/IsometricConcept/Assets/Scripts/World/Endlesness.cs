using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum TileObj { none, lilipad, driftwood, rock, grass, tree };


public class Endlesness : MonoBehaviour {

    public const float maxViewDist = 7;
    public Transform viewer;
    public int seed;
    public float scale;

    public GameObject water;
    public GameObject sand;
    public GameObject forest;
    public GameObject solidRock;
    public GameObject rock;
    public GameObject grass;
    public GameObject tree;
    public GameObject lilipad;
    public GameObject driftwood;

    public static Vector2 viewerPos;
    int chunkSize;
    int chunksVisinViewDst;

    

    Dictionary<Vector2, TerrainTile> tileDictionary = new Dictionary<Vector2, TerrainTile>();
    List<TerrainTile> tilesVisableLastUpdate = new List<TerrainTile>();

    void Start()
    {

        chunkSize = 1;
        chunksVisinViewDst = Mathf.RoundToInt(maxViewDist / chunkSize);
        TileObjectStor.ObjDict = SaveLoad.LoadObjDict("Save.save");
        
    }

    void Update()
    {
        SaveLoad.SaveObjDict(TileObjectStor.ObjDict, "Save.save");
        viewerPos = new Vector2(viewer.position.x, viewer.position.y);
        UpdateVisChunks();
    }

    void UpdateVisChunks()
    {

        for (int i = 0; i < tilesVisableLastUpdate.Count; i++)
        {
            tilesVisableLastUpdate[i].SetVis(false);
        }
        tilesVisableLastUpdate.Clear();

        int currentChunkCoordX = Mathf.RoundToInt(viewerPos.x / chunkSize);
        int currentChunkCoordY = Mathf.RoundToInt(viewerPos.y / chunkSize);

        for (int yOffset = -chunksVisinViewDst; yOffset <= chunksVisinViewDst; yOffset++)
        {
            for (int xOffset = -chunksVisinViewDst; xOffset <= chunksVisinViewDst; xOffset++)
            {
                Vector2 viewedChunkCoord = new Vector2(currentChunkCoordX + xOffset, currentChunkCoordY + yOffset);

                if (tileDictionary.ContainsKey(viewedChunkCoord))
                {
                    tileDictionary[viewedChunkCoord].UpdateTerrainChunk(maxViewDist, viewerPos);
                    if(tileDictionary [viewedChunkCoord].IsVis())
                    {
                        tilesVisableLastUpdate.Add(tileDictionary[viewedChunkCoord]);
                    }

                }
                else
                {
                    tileDictionary.Add(viewedChunkCoord, new TerrainTile(viewedChunkCoord, chunkSize, scale, seed, water, sand, forest, solidRock, rock, grass, tree, lilipad, driftwood));
                }
            }
        }
    }

    
}
public class TerrainTile
{
    GameObject sprite;
    GameObject TileObject;
    Vector2 pos;
    Bounds bounds;

    public TerrainTile(Vector2 coord, int size, float scale, int seed, GameObject water, GameObject sand, GameObject forest, GameObject solidRock, GameObject rock, GameObject grass, GameObject tree, GameObject lilipad, GameObject driftwood)
    {
        pos = coord * size;
        bounds = new Bounds(pos, Vector2.one * size);
        Vector3 posV3 = new Vector3(pos.x, pos.y, 0);
        float biome = GenWorld.GenBiomeMap(scale, seed, coord);

        //set type of the tile
        if (biome < 0.2)
        {
            sprite = GameObject.Instantiate(water);
        }
        if (biome < 0.3 && biome > 0.2)
        {
            sprite = GameObject.Instantiate(sand);
        }
        if (biome < 0.7 && biome > 0.3)
        {
            sprite = GameObject.Instantiate(forest);
        }
        if (biome > 0.7)
        {
            sprite = GameObject.Instantiate(solidRock);
        }

        sprite.transform.position = posV3;
        sprite.transform.localScale = Vector3.one * size;
        float rand = Random.Range(0, 3);
        Mathf.RoundToInt(rand);
        if (rand == 1)
        {
            sprite.transform.Rotate(0, 0, 90);
        }
        else if (rand == 2)
        {
            sprite.transform.Rotate(0, 0, 180);
        }
        else if (rand == 3)
        {
            sprite.transform.Rotate(0, 0, 270);
        }
        //tile object generating and loading
        if (!TileObjectStor.ObjDict.ContainsKey(coord))
        {
            rand = Random.Range(0, 10);
            Mathf.RoundToInt(rand);
            if (rand <= 1)
            {
                posV3 = new Vector3(pos.x, pos.y, -1);
                if (biome < 0.2)
                {
                    rand = Random.Range(0, 1);
                    if (rand < 0.8)
                    {
                        TileObject = GameObject.Instantiate(lilipad);
                        BoxCollider boxCol = sprite.GetComponent<BoxCollider>();
                        boxCol.enabled = false;
                        TileObjectStor.ObjDict.Add(coord, TileObj.lilipad);
                    }
                    else
                    {
                        TileObject = GameObject.Instantiate(driftwood);
                        TileObjectStor.ObjDict.Add(coord, TileObj.driftwood);
                    }
                }
                if (biome < 0.3 && biome > 0.2)
                {
                    TileObject = GameObject.Instantiate(rock);
                    TileObjectStor.ObjDict.Add(coord, TileObj.rock);
                }
                if (biome < 0.7 && biome > 0.3)
                {
                    rand = Random.Range(0, 3);
                    Mathf.RoundToInt(rand);
                    if (rand == 0)
                    {
                        TileObject = GameObject.Instantiate(rock);
                        TileObjectStor.ObjDict.Add(coord, TileObj.rock);
                    }
                    else if (rand == 1)
                    {
                        posV3 = new Vector3(pos.x, pos.y, -15);
                        TileObject = GameObject.Instantiate(tree);
                        TileObjectStor.ObjDict.Add(coord, TileObj.tree);
                    }
                    else
                    {
                        TileObject = GameObject.Instantiate(grass);
                        TileObjectStor.ObjDict.Add(coord, TileObj.grass);
                    }
                }
                if (biome < 0.7)
                {
                    TileObject.transform.position = posV3;
                    TileObject.transform.localScale = Vector3.one * size;

                }
            }
            else
            {
                TileObjectStor.ObjDict.Add(coord, TileObj.none);
            }
        }
        else
        {
            posV3 = new Vector3(pos.x, pos.y, -1);
            //load saved tileobj
            Debug.Log(coord);
            if (TileObjectStor.ObjDict[coord] == TileObj.driftwood)
            {
                Debug.Log("Drift Wood");
                TileObject = GameObject.Instantiate(driftwood);
            }
            else if (TileObjectStor.ObjDict[coord] == TileObj.grass)
            {
                Debug.Log("Long Grass");
                TileObject = GameObject.Instantiate(grass);
            }
            else if (TileObjectStor.ObjDict[coord] == TileObj.lilipad)
            {
                Debug.Log("Lilipad");
                TileObject = GameObject.Instantiate(lilipad);
            }
            else if (TileObjectStor.ObjDict[coord] == TileObj.none)
            {
                Debug.Log("Nothing");
            }
            else if (TileObjectStor.ObjDict[coord] == TileObj.rock)
            {
                Debug.Log("Rock");
                TileObject = GameObject.Instantiate(rock);
            }
            else if (TileObjectStor.ObjDict[coord] == TileObj.tree)
            {
                Debug.Log("Tree");
                TileObject = GameObject.Instantiate(tree);
                posV3 = new Vector3(pos.x, pos.y, -15);
            }
            if (TileObject != null)
            {
                TileObject.transform.position = posV3;
                TileObject.transform.localScale = Vector3.one * size;
            }
        }
        SetVis(false);
    }
    public void UpdateTerrainChunk(float maxViewDist, Vector2 viewerPos)
    {
        float viewDSTFromNerEdge = Mathf.Sqrt(bounds.SqrDistance(viewerPos));
        bool visible = viewDSTFromNerEdge <= maxViewDist;
        SetVis(visible);

    }
    public void SetVis(bool vis)
    {
        sprite.SetActive(vis);
        if (TileObject != null)
        {
            TileObject.SetActive(vis);
        }
    }

    public bool IsVis()
    {
        return sprite.activeSelf;
    }
}
