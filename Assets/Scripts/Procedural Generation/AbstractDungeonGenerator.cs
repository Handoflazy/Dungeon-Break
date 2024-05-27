using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractDungeonGenerator : MonoBehaviour
{
    [SerializeField]
    protected TilemapVisualizer tilemapVisualizer = null;

    [SerializeField]
    protected Vector2 startPosition = Vector2.zero;

    public void GeneateDungeon()
    {
      //  tilemapVisualizer.Clear();
        RunProceduralGenerator();
    }
    public void ClearDungeon()
    {
        tilemapVisualizer.Clear();
    }

    protected abstract void RunProceduralGenerator();
}
