using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class GFunc
{
    //! Dictionary에 오브젝트 프리팹을 캐싱하는 함수
    public static void AddObjs(this Dictionary<string, GameObject> dict_, GameObject[] prefabs_)
    {
        foreach (var prefab in prefabs_)
        {
            dict_.Add(prefab.name, prefab);
        }
    }

    //! 리스트를 섞는 함수
    public static void Shuffle<T>(this List<T> targetList, int shuffleCnt = 0)
    {
        if (shuffleCnt.Equals(0))
        {
            shuffleCnt = (int)(targetList.Count * 2.0f);
        }

        int sourIdx = 0;
        int destIdx = 0;
        T tempVar = default(T);

        for (int i = 0; i < shuffleCnt; i++)
        {
            sourIdx = Random.Range(0, targetList.Count);
            destIdx = Random.Range(0, targetList.Count);

            tempVar = targetList[sourIdx];
            targetList[sourIdx] = targetList[destIdx];
            targetList[destIdx] = tempVar;
        }
    }       //Shuffle()

    //! 리스트의 원소를 다른 값과 Swap하는 함수
    public static void Swap<T>(this List<T> targetList, ref T swapValue, int swapIdx)
    {
        T tempValue = targetList[swapIdx];
        targetList[swapIdx] = swapValue;
        swapValue = tempValue;
    }       //Swap()

    public static bool IsInRange(this int targetValue, int minInclude, int maxExclude)
    {
        return (minInclude <= targetValue && targetValue < maxExclude);
    }       //IsInRange()

    //! float 비교 함수
    public static bool IsEquals(this float targetValue, float compareValue)
    {
        bool isEqual = Mathf.Approximately(targetValue, compareValue);
        return isEqual;
    }       //isEquals()

    #region A star function
    //! 두 노드가 중복인지 검사하는 함수
    public static AStarNode FindNode(this List<AStarNode> nodeList, AStarNode compareNode)
    {
        if (nodeList.IsValid() == false)
            return default;

        AStarNode resultNode = default;
        foreach (var node_ in nodeList)
        {
            if (node_.Terrain == default || node_.Terrain == null)
                continue;
            else if (compareNode.Terrain == default || compareNode.Terrain == null)
                continue;

            if (node_.Terrain.TileIdx1D.Equals(compareNode.Terrain.TileIdx1D))
            {
                resultNode = node_;
            }
            else { continue; }
        }       // loop: 노드 리스트를 순회하는 루프

        return resultNode;
    }       // FindNode()
    #endregion      // A star function
}