using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapController : MonoBehaviour
{
    protected string tilemapObjName = default;

    protected MapBoard mapBoard = default;
    protected Tilemap tilemap = default;
    protected List<GameObject> tileList = default;

    //! Awake 타임에 초기화 할 내용을 상속받은 클래스별로 재정의한다.
    public virtual void InitAwake(MapBoard mapBoard_)
    {
        mapBoard = mapBoard_;
        tilemap = gameObject.FindChildComponent<Tilemap>(tilemapObjName);

        //직사각형 형태로 초기화 된 타일을 캐싱해서 가지고 있는다.
        tileList = tilemap.gameObject.GetChildrenObjs();
        if (tileList.IsValid())
        {
            tileList.Sort(GFunc.CompareTileObjToLocalPos2D);
        }
        else
        {
            tileList = new List<GameObject>();
        }

        /* Todo */
    }       // InitAwake()



}       // TilemapController