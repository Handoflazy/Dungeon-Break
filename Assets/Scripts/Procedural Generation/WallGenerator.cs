using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WallGenerator
{ 
    public static void CreateWalls(HashSet<Vector2> floorPositions, TilemapVisualizer tilemapVisualizer)
    {
        var basicWallPositions = FindWallsDirections(floorPositions, Direction2D.cardinalDirectionList);
        foreach (var position in basicWallPositions)
        {
            tilemapVisualizer.PaintSingleBasicWall(position);
        }
    }

    private static HashSet<Vector2> FindWallsDirections(HashSet<Vector2> floorPositions, List<Vector2> directionList)
    {
        HashSet<Vector2> wallPositions = new HashSet<Vector2>();

        foreach (var position in floorPositions)
        {
            foreach (var direction in directionList)
            {
                var neighbourPosition = position + direction;
                if(floorPositions.Contains(neighbourPosition)==false)
                    wallPositions.Add(neighbourPosition);

            }
           
        }
        return wallPositions;
    }
}
