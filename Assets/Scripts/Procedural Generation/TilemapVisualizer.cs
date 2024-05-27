using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapVisualizer : MonoBehaviour
{
    [SerializeField]
    private Tilemap floorTileMap, wallTilemap;
    [SerializeField]
    private TileBase floorTile,wallTop;


    public void PaintFloorTiles(IEnumerable<Vector2> floorPostitions)
    {
        PaintFloor(floorPostitions, floorTileMap, floorTile);
    }

    private void PaintFloor(IEnumerable<Vector2> floorPositions, Tilemap TileMap, TileBase Tile)
    {
        foreach (var position in floorPositions)
        {
            PaintSingleTile(TileMap, Tile, position);
        }
    }

    private void PaintSingleTile(Tilemap tilemap, TileBase tile, Vector2 position)
    {
        var tilePosition = tilemap.WorldToCell((Vector3)position);
        tilemap.SetTile(tilePosition, tile);

    }

    public void Clear()
    {
        floorTileMap.ClearAllTiles();
        wallTilemap.ClearAllTiles();
    }

    internal void PaintSingleBasicWall(Vector2 position)
    {
        PaintSingleTile(wallTilemap, wallTop, position);
    }
}
