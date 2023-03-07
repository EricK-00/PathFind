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

    //! Awake Ÿ�ӿ� �ʱ�ȭ �� ������ ��ӹ��� Ŭ�������� �������Ѵ�.
    public virtual void InitAwake(MapBoard mapBoard_)
    {
        mapBoard = mapBoard_;
        tilemap = gameObject.FindChildComponent<Tilemap>(tilemapObjName);

        //���簢�� ���·� �ʱ�ȭ �� Ÿ���� ĳ���ؼ� ������ �ִ´�.
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