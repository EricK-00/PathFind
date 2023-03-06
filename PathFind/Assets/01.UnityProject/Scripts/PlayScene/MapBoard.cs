using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBoard : MonoBehaviour
{
    private const string NAME__GO__TERRAIN_MAP = "TerrainMap";

    public Vector2Int MapCellSize { get; private set; } = default;
    public Vector2 MapCellGap { get; private set; } = default;

    private TerrainMap terrainMap = default;

    private void Awake()
    {
        // { 각종 매니저를 모두 초기화한다.
        ResourceManager.Instance.Create();
        // } 각종 매니저를 모두 초기화한다.

        // 맵에 지형을 초기화하여 배치한다.
        terrainMap = gameObject.FindChildComponent<TerrainMap>(NAME__GO__TERRAIN_MAP);
        terrainMap.InitAwake(this);
        MapCellSize = terrainMap.GetCellSize();
        MapCellGap = terrainMap.GetCellGap();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
