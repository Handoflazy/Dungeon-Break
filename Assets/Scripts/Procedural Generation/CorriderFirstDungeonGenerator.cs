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
        CreateCorridors(floorPositions, potentialRoomPositions);

        HashSet<Vector2> roomPositions = CreateRooms(potentialRoomPositions);
        List<Vector2> deadEnds = FindAllDeadEnds(floorPositions);

        CreateRoomAtDeadEnd(deadEnds, roomPositions);

        floorPositions.UnionWith(roomPositions);
        tilemapVisualizer.PaintFloorTiles(floorPositions);
        WallGenerator.CreateWalls(floorPositions, tilemapVisualizer);
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

    private void CreateCorridors(HashSet<Vector2> floorPositions, HashSet<Vector2> potentialRoomPosition)
    {
        var currentPosition = startPosition;
        potentialRoomPosition.Add(currentPosition);
        for (int i = 0; i < corridorCount; i++)
        {
            var corrider = ProceduralGenerationAlgorithm.RandomWalkCorridor(currentPosition, corridorLength);
            currentPosition = corrider[corrider.Count - 1];
            potentialRoomPosition.Add(currentPosition);
            floorPositions.UnionWith(corrider);
        }
    }
}
