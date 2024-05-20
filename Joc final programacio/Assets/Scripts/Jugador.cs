using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class Jugador : MonoBehaviour
{
    [SerializeField]
    Tilemap groundTilemap;
    [SerializeField]
    Tilemap collisionTilemap;
    [SerializeField] int moviment;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(Vector2 direction)
    {
        print(CanMove(direction));
        if (CanMove(direction))
        {
            transform.position = new Vector3(groundTilemap.WorldToCell((Vector3)direction).x+0.5f, groundTilemap.WorldToCell((Vector3)direction).y+0.5f, groundTilemap.WorldToCell((Vector3)direction).z) ;
        }
    }
    private bool CanMove(Vector2 direction)
    {
        if (Vector3Int.Distance(groundTilemap.WorldToCell((Vector3)direction), groundTilemap.WorldToCell(this.transform.position))<=moviment)
        {
            Vector3Int gridPosition = groundTilemap.WorldToCell((Vector3)direction);
            if (!groundTilemap.HasTile(gridPosition) || collisionTilemap.HasTile(gridPosition)) return false;
            return true;
        }
        return false;
    }
    public void Paint(Vector2 direction)
    {
        print(CanPaint(direction));
        if (CanPaint(direction))
        {
            
            groundTilemap.SetColor(groundTilemap.WorldToCell((Vector3)direction), Color.red);
            collisionTilemap.SetColor(groundTilemap.WorldToCell((Vector3)direction), Color.red);
        }
    }
    private bool CanPaint(Vector2 direction)
    {
        for (int x = groundTilemap.cellBounds.min.x; x < groundTilemap.cellBounds.max.x; x++)
        {
            for (int y = groundTilemap.cellBounds.min.y; y < groundTilemap.cellBounds.max.y; y++)
            {
                for (int z = groundTilemap.cellBounds.min.z; z < groundTilemap.cellBounds.max.z; z++)
                {
                    if (Vector3Int.Distance(new Vector3Int(x, y, z), groundTilemap.WorldToCell(this.transform.position)) <= moviment)
                    {
                        groundTilemap.SetTileFlags(new Vector3Int(x, y, z), TileFlags.None);
                        groundTilemap.SetColor(groundTilemap.WorldToCell(new Vector3(x, y, z)), Color.red);
                    }
                    else
                    {
                        groundTilemap.SetColor(groundTilemap.WorldToCell(new Vector3(x, y, z)), Color.white);
                    }
                }
            }

        }

        Vector3Int gridPosition = groundTilemap.WorldToCell((Vector3)direction);
            if (!groundTilemap.HasTile(gridPosition) || collisionTilemap.HasTile(gridPosition)) return false;
            return true;

    }
  /*  private bool canPaintRecursiu(Vector3 pos, int moviments)
    {
        if(moviments)
        return canPaintRecursiu();
    }*/
}
