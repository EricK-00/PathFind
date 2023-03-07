using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftUIButtons : MonoBehaviour
{
    private PathFinder pathFinder;

    private void Awake()
    {
        pathFinder = GetComponent<PathFinder>();
    }

    public void OnClickAStarFindBtn()
    {
        PathFinder.Instance.FindPath_AStar();
    }       // OnClickAStarFindBtn()
}