using System.Collections.Generic;
using UnityEngine;

public class TerrainController : MonoBehaviour
{
    public const string NAME__GO__TILE_FRONT_RENDERER = "FrontRenderer";

    private TerrainType terrainType = TerrainType.NONE;

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
        defaultColor = frontRenderer.color;
    }



}       //TerrainController