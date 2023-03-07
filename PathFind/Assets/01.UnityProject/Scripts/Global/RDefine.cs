using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RDefine : MonoBehaviour
{
    public const string PREFAB__TERRAIN_OCEAN = "Terrain_Ocean";
    public const string PREFAB__TERRAIN_PLAIN = "Terrain_Plain";
    public const string PREFAB__OBSTACLE_PLAIN_CASTLE = "Obstacle_PlainCastle";

    public enum TileStatusColor
    {
        DEFAULT, SELECTED, SEARCH, INACTIVE
    }
}