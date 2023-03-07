using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainMap : TilemapController
{
    private const string NAME__GO__TERRAIN_TILEMAP = "TerrainTilemap";

    private Vector2Int mapCellSize = default;
    private Vector2 mapCellGap = default;

    private List<TerrainController> terrainList = default;

    int a = 1, b = 2;


    public override void InitAwake(MapBoard mapBoard)
    {
        this.tilemapObjName = NAME__GO__TERRAIN_TILEMAP;
        base.InitAwake(mapBoard);

        terrainList = new List<TerrainController>();

        // { 타일의 x축 갯수와 전체 타일의 수로 맵의 가로, 세로 사이즈를 연산한다.
        mapCellSize = Vector2Int.zero;
        float tempTileY = tileList[0].transform.localPosition.y;
        for (int i = 0; i < tileList.Count; i++)
        {
            if (tempTileY.IsEquals(tileList[i].transform.localPosition.y) == false)
            {
                mapCellSize.x = i;
                break;
            }       // if: 첫 번째 타일의 y 좌표와 달라지는 지점 전까지가 맵의 가로 셀 크기이다.
        }
        // 전체 타일의 수를 맵의 가로 셀 크기로 나눈 값이 맵의 세로 셀 크기이다.
        mapCellSize.y = Mathf.FloorToInt(tileList.Count / mapCellSize.x);

        // } 타일의 x축 갯수와 전체 타일의 수로 맵의 가로, 세로 사이즈를 연산한다.

        // { x축 상의 두 타일과, y축 상의 두 타일 사이의 로컬 포지션으로 타일 갭을 연산한다.
        mapCellGap = Vector2.zero;
        mapCellGap.x = tileList[1].transform.localPosition.x -
            tileList[0].transform.localPosition.x;
        mapCellGap.y = tileList[mapCellSize.x].transform.localPosition.y -
            tileList[0].transform.localPosition.y;
        // } x축 상의 두 타일과, y축 상의 두 타일 사이의 로컬 포지션으로 타일 갭을 연산한다.
    }

    private void Start()
    {
        // { 타일맵의 일부를 일정 확률로 다른 타일로 교체하는 로직
        GameObject changeTilePrefab = ResourceManager.Instance.terrainPrefabs[RDefine.PREFAB__TERRAIN_OCEAN];

        // 타일맵 중에 어느 정도를 바다로 교체할 것인지 선택한다.
        const float CHANGE_PERCENTAGE = 15.0f;
        float correctChangePercentage = tileList.Count * (CHANGE_PERCENTAGE / 100.0f);
        // 바다로 교체할 타일의 정보를 리스트 형태로 생성해서 섞는다.
        List<int> changeTileResult = GFunc.CreateList(tileList.Count, 1);
        changeTileResult.Shuffle();

        GameObject tempChangeTile = default;
        for (int i = 0; i < tileList.Count;  i++)
        {
            if (correctChangePercentage <= changeTileResult[i])
                continue;

            //프리팹을 인스턴스화해서 교체할 타일의 트랜스폼을 카피한다.
            tempChangeTile = Instantiate(changeTilePrefab, tilemap.transform);
            tempChangeTile.name = changeTilePrefab.name;
            tempChangeTile.SetLocalScale(tileList[i].transform.localScale);
            tempChangeTile.SetLocalPos(tileList[i].transform.localPosition);

            tileList.Swap(ref tempChangeTile, i);
            tempChangeTile.DestroyObj();

        }       // loop: 위에서 연산한 정보로 현재 타일맵에 바다를 적용하는 루프
        // } 타일맵의 일부를 일정 확률로 다른 타일로 교체하는 로직

        // { 기존에 존재하는 타일의 순서를 조정하고, 커늩롤러를 캐싱하는 로직
        TerrainController tempTerrain = default;
        TerrainType terrainType = TerrainType.NONE;

        int loopCnt = 0;
        foreach(GameObject tile_ in tileList)
        {
            tempTerrain = tile_.GetComponent<TerrainController>();
            switch (tempTerrain.name)
            {
                case RDefine.PREFAB__TERRAIN_PLAIN:
                    terrainType = TerrainType.PLAIN_PASS;
                    break;
                case RDefine.PREFAB__TERRAIN_OCEAN:
                    terrainType = TerrainType.OCEAN_BLOCK;
                    break;
                default:
                    terrainType = TerrainType.NONE;
                    break;
            }       //switch: 지형별로 다른 설정을 한다.

            tempTerrain.SetUpTerrain(mapBoard, terrainType, loopCnt);
            tempTerrain.transform.SetAsFirstSibling();
            terrainList.Add(tempTerrain);
            ++loopCnt;
        }       // loop: 타일의 이름과 렌더링 순서대로 정렬하는 루프
        // } 기존에 존재하는 타일의 순서를 조정하고, 커늩롤러를 캐싱하는 로직

    }       // Start()

    //! 초기화된 타이르이 정보를 연산한 맵의 가로, 세로 크기를 리턴한다.
    public Vector2Int GetCellSize() { return mapCellSize; }

    //! 초기화된 타일의 정보로 연산한 타일 사이의 갭을 리턴한다.
    public Vector2 GetCellGap() { return mapCellGap; }

    //! 인덱스에 해당하는 타일을 리턴한다.
    public TerrainController GetTile(int tileIdx1D)
    {
        if (terrainList.IsValid(tileIdx1D))
            return terrainList[tileIdx1D];

        return default;
    }

    private void Update()
    {
        //(int, int) tuple = (a, b);
        //GFunc.Swap(ref tuple);
        //Debug.Log($"{a} {b}");
    }
}