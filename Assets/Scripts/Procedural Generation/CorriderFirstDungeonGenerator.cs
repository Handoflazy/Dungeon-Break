using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class CorriderFirstDungeonGenerator : SimpleRandomWalkDungeonGenerator
{
    [SerializeField]
    private int corridorLength = 14, corridorCount = 5;
    [SerializeField, Range(0.1f, 1)]
    private float roomPercent = 0.8f;

    protected override void RunProceduralGenerator()
    {
        CorriderFirstDungeonGeneration();
    }

    private void CorriderFirstDungeonGeneration()
    {
        HashSet<Vector2> floorPositions = new HashSet<Vector2>();
        HashSet<Vector2> potentialRoomPositions = new HashSet<Vector2>();
        List<List< Vector2>> corridors = CreateCorridors(floorPositions, potentialRoomPositions);

        HashSet<Vector2> roomPositions = CreateRooms(potentialRoomPositions);
        List<Vector2> deadEnds = FindAllDeadEnds(floorPositions);

        CreateRoomAtDeadEnd(deadEnds, roomPositions);
        for (int i = 0; i < corridors.Count; i++)
        {
            corridors[i] = IncreaseCorridorWitdhByOne(corridors[i]);
            floorPositions.UnionWith(corridors[i]);
        }
        floorPositions.UnionWith(roomPositions);
        tilemapVisualizer.PaintFloorTiles(floorPositions);
        WallGenerator.CreateWalls(floorPositions, tilemapVisualizer);
    }

    private List<Vector2> IncreaseCorridorWitdhByOne(List<Vector2> corridor)
    {
        List<Vector2> newCorridor = new List<Vector2>();
        Vector2 previewDirection = Vector2.zero;
        for (int i = 1; i < corridor.Count; i++)
        {
            Vector2 directionFromCell = corridor[i]- corridor[i-1];
            if(previewDirection != Vector2.zero&& directionFromCell != previewDirection)
            {
                for (int x = -1; x < 2; x++)
                {
                    for (int y = -1; y < 2; y++)
                    {
                        newCorridor.Add(corridor[i - 1] + new Vector2(x, y)*0.16f);
                    }
                }
                previewDirection = directionFromCell;
            }
            else
            {
                Vector2 newCorridorTileOffset = GetDirection90From(directionFromCell.normalized);
                newCorridor.Add(corridor[i - 1]);
                newCorridor.Add(corridor[i - 1] + newCorridorTileOffset*0.16f); 
                
            }
        }
        return newCorridor;
    }

    private Vector2 GetDirection90From(Vector2 directionFromCell)
    {
        if(directionFromCell == Vector2.up)
            return Vector2.right;
        if(directionFromCell == Vector2.right)  
            return Vector2.down;
        if (directionFromCell == Vector2.down)
            return Vector2.left;
        if (directionFromCell == Vector2.left)
            return Vector2.up;
        return Vector2.zero;
    }

    private void CreateRoomAtDeadEnd(List<Vector2> deadEnds, HashSet<Vector2> roomFloors)
    {
        foreach (var pos in deadEnds)
        {
            if (roomFloors.Contains(pos) == false)
            {
                var roomFloor = RunRandomWalk(randomWalkParameters, pos);
                roomFloors.UnionWith(roomFloor);
            }
        }
    }

    private List<Vector2> FindAllDeadEnds(HashSet<Vector2> floorPositions)
    {
        List<Vector2> deadEnds = new List<Vector2>();
        foreach (Vector2 position in floorPositions)
        {
            int neighboursCount = 0;
            foreach (var direction in Direction2D.cardinalDirectionList)
            {
                if (floorPositions.Contains(position + direction))
                    neighboursCount++;

            }
            if (neighboursCount == 1)
            {
                deadEnds.Add(position);
              
            }
           
        }
        return deadEnds;
    }

    private HashSet<Vector2> CreateRooms(HashSet<Vector2> potentialRoomPositions)
    {
        HashSet<Vector2> roomPositions = new HashSet<Vector2>();
        int roomToCreateCount = Mathf.RoundToInt(potentialRoomPositions.Count * roomPercent);
        List<Vector2> roomsToCreate = potentialRoomPositions.OrderBy(x => Guid.NewGuid()).Take(roomToCreateCount).ToList();
        foreach (var roomPosition in roomsToCreate)
        {

            var roomFloor = RunRandomWalk(randomWalkParameters, roomPosition);
            roomPositions.UnionWith(roomFloor);
        }
        return roomPositions;
    }

    private List<List<Vector2>> CreateCorridors(HashSet<Vector2> floorPositions, HashSet<Vector2> potentialRoomPosition)
    {
        List<List<Vector2>> corridors = new List<List<Vector2>>();
       var currentPosition = startPosition;
        potentialRoomPosition.Add(currentPosition);
        for (int i = 0; i < corridorCount; i++)
        {
            var corrider = ProceduralGenerationAlgorithm.RandomWalkCorridor(currentPosition, corridorLength);
            currentPosition = corrider[corrider.Count - 1];
            corridors.Add(corrider);
            potentialRoomPosition.Add(currentPosition);
            floorPositions.UnionWith(corrider);
        }
        return corridors;
    }
}
