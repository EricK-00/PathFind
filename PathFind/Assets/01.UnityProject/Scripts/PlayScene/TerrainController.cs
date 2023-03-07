using System.Collections.Generic;
using UnityEngine;

public class TerrainController : MonoBehaviour
{
    public const string NAME__GO__TILE_FRONT_RENDERER = "FrontRenderer";

    private TerrainType terrainType = TerrainType.NONE;
    private MapBoard mapBoard = default;

    public bool IsPassable { get; private set; } = false;
    public int TileIdx1D { get; private set; } = -1;
    public Vector2Int TileIdx2D { get; private set; } = default;

    #region 길찾기 알고리즘을 위한 변수
    private SpriteRenderer frontRenderer = default;
    private Color defaultColor = default;
    private Color selectedColor = default;
    private Color searchColor = default;
    private Color inactiveColor = default;
    #endregion

    private void Awake()
    {
        frontRenderer = gameObject.FindChildComponent<SpriteRenderer>(NAME__GO__TILE_FRONT_RENDERER);
        GFunc.Assert(frontRenderer != null || frontRenderer != default);

        defaultColor = new Color(1f, 1f, 1f, 1f);
        selectedColor = new Color(236f / 255f, 130f / 255f, 20f / 255f, 1f);
        searchColor = new Color(0f, 192f / 255f, 0, 1f);
        inactiveColor = new Color(128f / 255f, 128f / 255f, 128f / 255f, 1f);
    }       // Awake()

    //! 지형정보를 초기 설정한다.
    public void SetUpTerrain(MapBoard mapBoard_, TerrainType type_, int tileIdx1D_)
    {
        terrainType = type_;
        mapBoard = mapBoard_;
        TileIdx1D = tileIdx1D_;
        TileIdx2D = mapBoard.GetTileIdx2D(TileIdx1D);

        string prefabName = string.Empty;
        switch (terrainType)
        {
            case TerrainType.PLAIN_PASS:
                prefabName = RDefine.PREFAB__TERRAIN_PLAIN;
                IsPassable = true;
                break;
            case TerrainType.OCEAN_BLOCK:
                prefabName = RDefine.PREFAB__TERRAIN_OCEAN;
                IsPassable = false;
                break;
            default:
                prefabName = "Tile_Default";
                IsPassable = false;
                break;
        }       // switch: 타일의 타입 별로 다른 설정을 한다.

        this.name = string.Format("{0}_{1}", prefabName, TileIdx1D);
    }       // SetUpTerrain()

    //! 지형의 Front 색상을 변경한다.
    public void SetTileActiveColor(RDefine.TileStatusColor tileStatus)
    {
        switch (tileStatus)
        {
            case RDefine.TileStatusColor.SELECTED:
                frontRenderer.color = selectedColor;
                break;
            case RDefine.TileStatusColor.SEARCH:
                frontRenderer.color = searchColor;
                break;
            case RDefine.TileStatusColor.INACTIVE:
                frontRenderer.color = inactiveColor;
                break;
            default:
                frontRenderer.color = defaultColor;
                break;
        }
    }       // SetTileActiveColor()

}       // class TerrainController