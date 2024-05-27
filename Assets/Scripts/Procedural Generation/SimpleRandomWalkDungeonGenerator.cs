using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class SimpleRandomWalkDungeonGenerator : AbstractDungeonGenerator
{
    [SerializeField]
    protected SimpleRandomWalkSO randomWalkParameters;

    protected override void RunProceduralGenerator()
    {
        HashSet<Vector2> flootPositions = RunRandomWalk(randomWalkParameters,startPosition);
        tilemapVisualizer.PaintFloorTiles(flootPositions);
        WallGenerator.CreateWalls(flootPositions, tilemapVisualizer);
 
      
    }



    protected HashSet<Vector2> RunRandomWalk(SimpleRandomWalkSO randomWalkParameters, Vector2 position)
    {
        var currentPosition = position;
        HashSet<Vector2> floorPosition = new HashSet<Vector2>();
        for (int i = 0; i < randomWalkParameters.iteration; i++)
        {
            var path = ProceduralGenerationAlgorithm.SimpleRandomWalk(currentPosition, randomWalkParameters.walkLength);
            floorPosition.UnionWith(path);
            if (randomWalkParameters.startRandomlyEachIteration)
            {
                currentPosition = floorPosition.ElementAt(Random.Range(0, floorPosition.Count));
            }
        }
        return floorPosition;
    }

   


}
[CustomEditor(typeof(AbstractDungeonGenerator),true)]
public class SimplePRWGGeneratorEdit: Editor
{
    AbstractDungeonGenerator generator;
    private void Awake()
    {
        generator = (AbstractDungeonGenerator)target;
    }
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        

        EditorGUILayout.BeginHorizontal();
        if(GUILayout.Button("Generate Dungeon"))
        {
            generator.GeneateDungeon();
        }

        if (GUILayout.Button("Clear"))
        {
            generator.ClearDungeon();
        }
        EditorGUILayout.EndHorizontal();
    }
}