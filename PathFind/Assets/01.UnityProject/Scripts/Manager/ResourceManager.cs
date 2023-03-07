using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : GSingleton<ResourceManager>
{
    private const string PATH__PREFAB__TERRAIN = "Prefabs/ObjectTiles/Terrains/";
    private const string PATH__PREFAB__OBSTACLE = "Prefabs/ObjectTiles/Obstacles/";

    public Dictionary<string, GameObject> terrainPrefabs = default;
    public Dictionary<string , GameObject> obstaclePrefabs = default;

    protected override void Init()
    {
        base.Init();

        terrainPrefabs = new Dictionary<string, GameObject>();
        obstaclePrefabs = new Dictionary<string , GameObject>();

        terrainPrefabs.AddObjs(Resources.LoadAll<GameObject>(PATH__PREFAB__TERRAIN));
        obstaclePrefabs.AddObjs(Resources.LoadAll<GameObject>(PATH__PREFAB__OBSTACLE));
    }
}