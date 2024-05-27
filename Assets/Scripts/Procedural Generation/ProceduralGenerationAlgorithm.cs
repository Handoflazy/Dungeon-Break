using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public static class ProceduralGenerationAlgorithm
{
    public static HashSet<Vector2> SimpleRandomWalk(Vector2 startPosition, int walkLengtht)
    {
        HashSet<Vector2> path = new HashSet<Vector2>
        {
            startPosition
        };
        var previousPosition = startPosition;
        for(int i = 0;i< walkLengtht; i++)
        {
           
            var newPosition = previousPosition + Direction2D.GetRandomCardinalDirection();
            path.Add(newPosition);
            previousPosition = newPosition;
        }
        return path;
    }
    public static List<Vector2> RandomWalkCorridor(Vector2 startPosition, int CorridorLength)
    {
        List<Vector2> corrider = new List<Vector2>();
        var currentPosition = startPosition;
        var direction = Direction2D.GetRandomCardinalDirection();
        corrider.Add(currentPosition);
        for (int i = 0; i <CorridorLength; i++)
        {
            currentPosition += direction;
            corrider.Add(currentPosition);
        }
        return corrider;
    }

}

public static class Direction2D
{
    public static List<Vector2> cardinalDirectionList = new List<Vector2>()
    {
        new Vector2(0,0.16f),
        new Vector2(0.16f,0),
        new Vector2(0,-0.16f),
        new Vector2(-0.16f,0),

    };
    public static Vector2 GetRandomCardinalDirection()
    {
        return cardinalDirectionList[Random.Range(0, cardinalDirectionList.Count)];
    }
}
