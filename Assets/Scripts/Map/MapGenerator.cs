using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer), typeof(MeshCollider))]
public class MapGenerator : MonoBehaviour
{
    #region Variables
    private AnimationCurve heightCurve;
    public bool giganticMap;
    public GameObject[] objects;
    public GameObject nestPrefab;
    [SerializeField] private Gradient gradient;
    private static GameObject nestObject;

    // TODO
    [SerializeField] private bool gizmosOn = false;
    [SerializeField] private bool forestOn = true;
    [SerializeField] private static bool updateOn = false;

    // internal variables
    private Mesh mesh;
    private int octaves = 5;
    private int vertices_n;
    private Vector3[] vertices;
    private int[] triangles;
    private System.Random prng;
    private Vector2[] octaveOffsets;
    private int MESH_SCALE = 10;
    private Color[] colors;
    private float yMinTerrain, yMaxTerrain;
    private List<GameObject> trees = new List<GameObject>();
    public static TreeWithNest treeWithNest;
    public static TreeWithNest TreeWithNest { get => treeWithNest; set => treeWithNest = value; }
    public static GameObject NestObject { get => nestObject; set => nestObject = value; }
    public static bool UpdateOn { get => updateOn; set => updateOn = value; }

    // private ForestSpawner forestSpawner = new ForestSpawner(mesh);
    #endregion

    #region Main Methods

    void Start()
    {
        heightCurve = AnimationCurve.Linear(0, 0, 1f, 1f);
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        CreateNewMap();
        if (forestOn)
            SpawnForest();
        SpawnNest();
    }

    private void Update()
    {
        if (!updateOn)
            return;
        if (!DataBase.Settings.GamePause || (SimulationMenu.settingsMenu.activeInHierarchy && DataBase.Settings.InteractiveMode))
        {
            CreateNewMap();
            if (forestOn)
            {
                UpdateTreesPos();
                unhideTrees();
            }
            else
                hideTrees();
        }
    }
    #endregion

    #region Mesh Methods
    public void CreateNewMap()
    {
        CreateMeshShape();
        CreateTriangles();
        ColorMap();
        UpdateMesh();
    }

    /******* MESH PART *******/
    private void CreateMeshShape()
    {
        // seed
        Vector2[] octaveOffsets = GetOffsetSeed();
        vertices_n = (DataBase.Settings.XSize + 1) * (DataBase.Settings.ZSize + 1);
        vertices = new Vector3[vertices_n];
        for (int i = 0, z = 0; z <= DataBase.Settings.ZSize; z++)
        {
            for (int x = 0; x <= DataBase.Settings.XSize; x++, i++)
            {
                float y = GenerateNoiseHeight(z, x, octaveOffsets);
                vertices[i] = new Vector3(x, y, z);
                if (y > yMaxTerrain)
                    yMaxTerrain = y;
                if (y < yMinTerrain)
                    yMinTerrain = y;
            }
        }
        DataBase.Settings.MaxHeight = yMaxTerrain + 15f;
    }

    private Vector2[] GetOffsetSeed()
    {
        prng = new System.Random(DataBase.Settings.MeshSeed);
        octaveOffsets = new Vector2[octaves];
        for (var i = 0; i < octaves; i++)
        {
            float offsetX = prng.Next(-100000, 100000);
            float offsetY = prng.Next(-100000, 100000);
            octaveOffsets[i] = new Vector2(offsetX, offsetY);
        }
        return octaveOffsets;
    }

    private float GenerateNoiseHeight(int z, int x, Vector2[] octaveOffsets)
    {
        float amplitude = 12;
        float frequency = 1;
        float persistence = 0.5f;
        float noiseHeight = 0;

        for (var y = 0; y < octaves; y++)
        {
            float mapZ = z / DataBase.Settings.Scale * frequency + octaveOffsets[y].y;
            float mapX = x / DataBase.Settings.Scale * frequency + octaveOffsets[y].x;

            // *2-1 flat floor level
            float perlinValue = Mathf.PerlinNoise(mapX, mapZ) * 2 - 1;
            noiseHeight += heightCurve.Evaluate(perlinValue) * amplitude;
            frequency *= DataBase.Settings.Lacunarity;
            amplitude *= persistence;
        }
        return noiseHeight;
    }

    private void CreateTriangles()
    {
        int vert = 0;
        int tris = 0;

        int nb_triangles = DataBase.Settings.XSize * DataBase.Settings.ZSize * 6;
        triangles = new int[nb_triangles];

        for (var z = 0; z < DataBase.Settings.ZSize; z++)
        {
            for (var x = 0; x < DataBase.Settings.XSize; x++)
            {
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + DataBase.Settings.XSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + DataBase.Settings.XSize + 1;
                triangles[tris + 5] = vert + DataBase.Settings.XSize + 2;

                vert++;
                tris += 6;
            }
            vert++;
        }
    }

    void ColorMap()
    {
        colors = new Color[vertices_n];
        for (int i = 0; i < vertices_n; i++)
        {
            float height = Mathf.InverseLerp(yMinTerrain, yMaxTerrain, vertices[i].y);
            colors[i] = gradient.Evaluate(height);
        }
    }

    private void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        mesh.RecalculateTangents();
        mesh.colors = colors;
        GetComponent<MeshCollider>().sharedMesh = mesh;
        if (giganticMap)
            gameObject.transform.localScale = new Vector3(MESH_SCALE, MESH_SCALE, MESH_SCALE);
    }
    #endregion

    #region Trees Methods
    private void SpawnForest()
    {
        int separationNoiseMax = DataBase.Settings.SpaceBetweenTrees / 2;
        int separationNoiseMin = 0;

        for (int x = 3; x <= DataBase.Settings.XSize - 3; x += DataBase.Settings.SpaceBetweenTrees)
        {
            for (int z = 3; z <= DataBase.Settings.ZSize - 3; z += DataBase.Settings.SpaceBetweenTrees)
            {
                int xOffset = x + UnityEngine.Random.Range(separationNoiseMin, separationNoiseMax);
                int zOffset = z + UnityEngine.Random.Range(separationNoiseMin, separationNoiseMax);

                GameObject treeToSpawn = objects[UnityEngine.Random.Range(0, objects.Length)];
                GameObject tree = Instantiate(treeToSpawn);

                Vector3 verticeWithTreeToSpawn = mesh.vertices[verticeIndexFromXZ(xOffset, zOffset)];
                tree.transform.position = posTreeOnMap(xOffset, zOffset, verticeWithTreeToSpawn);

                tree.transform.rotation = Quaternion.AngleAxis(UnityEngine.Random.Range(0, 360), Vector3.up);
                trees.Add(tree);
            }
        }
    }
    private int verticeIndexFromXZ(int x, int z)
    {
        return z * (DataBase.Settings.XSize + 1) + x;
    }

    private Vector3 posTreeOnMap(int x, int z, Vector3 verticePos)
    {
        float y = transform.TransformPoint(verticePos).y - 0.2f;
        return new Vector3(x, y, z);
    }

    private void UpdateTreesPos()
    {
        for (int i = 0; i < trees.Count; i++)
        {
            GameObject tree = trees[i];
            int x = (int)tree.transform.position.x;
            int z = (int)tree.transform.position.z;
            Vector3 verticeWithTreeToMove = mesh.vertices[verticeIndexFromXZ(x, z)];
            tree.transform.position = posTreeOnMap(x, z, verticeWithTreeToMove);
        }
        TreeWithNest tn = treeWithNest;
        tn.update(trees[tn.Id]);
    }

    private void SpawnNest()
    {
        int id = UnityEngine.Random.Range(0, trees.Count);
        nestObject = Instantiate(nestPrefab);
        TreeWithNest tn = new TreeWithNest(id, trees[id], nestObject);
        treeWithNest = tn;
        Debug.Log(tn.toString());
    }

    private void unhideTrees()
    {
        toggleTrees(true);
    }

    private void hideTrees()
    {
        toggleTrees(false);
    }

    private void toggleTrees(bool hide)
    {
        foreach (var tree in trees)
        {
            tree.SetActive(hide);
        }
    }
    #endregion

    /******* GIZMOS PART *******/
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        if (vertices == null)
            return;

        if (gizmosOn)
            for (var i = 0; i < vertices_n; i++)
                Gizmos.DrawSphere(vertices[i], .1f);

    }
}
