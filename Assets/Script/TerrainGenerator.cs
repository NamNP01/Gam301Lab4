using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    public Terrain terrain; // Gán Terrain trong Inspector
    public float scale = 20f; // Điều chỉnh độ chi tiết của địa hình
    public float offsetX = 0f; // Dịch chuyển theo trục X
    public float offsetY = 0f; // Dịch chuyển theo trục Y

    void Start()
    {
        GenerateTerrain();
    }

    void GenerateTerrain()
    {
        TerrainData terrainData = terrain.terrainData;

        int width = terrainData.heightmapResolution;
        int height = terrainData.heightmapResolution;
        float[,] heights = GenerateHeights(width, height);

        terrainData.SetHeights(0, 0, heights);
    }

    float[,] GenerateHeights(int width, int height)
    {
        float[,] heights = new float[width, height];

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                float xCoord = (float)i / width * scale + offsetX;
                float yCoord = (float)j / height * scale + offsetY;
                heights[i, j] = Mathf.PerlinNoise(xCoord, yCoord); // Tạo độ cao bằng Perlin Noise
            }
        }

        return heights;
    }
}
