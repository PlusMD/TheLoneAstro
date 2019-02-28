using UnityEngine;

public class TerrainGen : MonoBehaviour
{

    public int depth = 3;

    public int width = 256;
    public int height = 256;

    public float scale = 20f;

    public float offsetX = 100f;
    public float offsetY = 100f;



    void Start()
    {

        offsetX = Random.Range(0f, 999999f);
        offsetY = Random.Range(0f, 999999f);


        Terrain terrain = GetComponent<Terrain>();
        terrain.terrainData = GenerateTerrain(terrain.terrainData);
    }

    TerrainData GenerateTerrain(TerrainData terrainData)
    {
        terrainData.heightmapResolution = width + 1;

        terrainData.size = new Vector3(width, depth, height);
        terrainData.SetHeights(0, 0, GenHeights());
        return terrainData;
    }

    float[,] GenHeights()
    {
        float[,] heights = new float[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                heights[x, y] = CalcHeight(x, y);
            }
        }

        return heights;
    }

    float CalcHeight(int x, int y)
    {
        float xCo = (float)x / width * scale + offsetX;
        float yCo = (float)y / height * scale + offsetY;

        return Mathf.PerlinNoise(xCo, yCo);
    }

}
