using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class Jugador : MonoBehaviour
{
    [SerializeField]
    Tilemap groundTilemap;
    [SerializeField] List<Jugador> list;
    [SerializeField]
    Tilemap collisionTilemap;
    [SerializeField] int moviment;
    [SerializeField] public bool selected = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.QuitarSelect();
    }

    public void Move(Vector2 direction)
    {
        print(CanMove(direction));
        print("Selected en moviment: " + selected);
        if (this.selected)
        {
            print("entro");
            if (CanMove(direction))
            {
                transform.position = new Vector3(groundTilemap.WorldToCell((Vector3)direction).x + 0.5f, groundTilemap.WorldToCell((Vector3)direction).y + 0.5f, groundTilemap.WorldToCell((Vector3)direction).z);
            }
            for (int x = groundTilemap.cellBounds.min.x; x < groundTilemap.cellBounds.max.x; x++)
            {
                for (int y = groundTilemap.cellBounds.min.y; y < groundTilemap.cellBounds.max.y; y++)
                {
                    for (int z = groundTilemap.cellBounds.min.z; z < groundTilemap.cellBounds.max.z; z++)
                    {
                        groundTilemap.SetColor(groundTilemap.WorldToCell(new Vector3(x, y, z)), Color.white);
                    }
                }

            }
            this.selected = false;
        }
    }
    private bool CanMove(Vector2 direction)
    {
        if (Vector3Int.Distance(groundTilemap.WorldToCell((Vector3)direction), groundTilemap.WorldToCell(this.transform.position)) <= moviment)
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
    void QuitarSelect()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3Int gridPosition = groundTilemap.WorldToCell(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            for (int x = 0; x < list.Count; x++)
            {
                if (groundTilemap.WorldToCell(list[x].transform.position) == gridPosition) this.selected = false;
            }
        }
    }
    /*   private void canPaintRecursiu(Vector3Int pos, int moviments)
       {
           if (moviments > 0)
           {
               groundTilemap.SetTileFlags(new Vector3Int(pos.x, pos.y, pos.z), TileFlags.None);
               groundTilemap.SetColor(groundTilemap.WorldToCell(new Vector3(pos.x, pos.y, pos.z)), Color.red);
               if (Vector3Int.Distance(new Vector3Int(pos.x + 1, pos.y, pos.z), groundTilemap.WorldToCell(this.transform.position)) <= moviment)
               {
                   canPaintRecursiu(new Vector3Int(pos.x + 1, pos.y, pos.z), moviments--);
               }
               else if ((Vector3Int.Distance(new Vector3Int(pos.x - 1, pos.y, pos.z), groundTilemap.WorldToCell(this.transform.position)) <= moviment))
               {
                   canPaintRecursiu(new Vector3Int(pos.x - 1, pos.y, pos.z), moviments--);
               }
               else if ((Vector3Int.Distance(new Vector3Int(pos.x, pos.y + 1, pos.z), groundTilemap.WorldToCell(this.transform.position)) <= moviment))
               {
                   canPaintRecursiu(new Vector3Int(pos.x, pos.y + 1, pos.z), moviments--);
               }
               else if ((Vector3Int.Distance(new Vector3Int(pos.x, pos.y - 1, pos.z), groundTilemap.WorldToCell(this.transform.position)) <= moviment))
               {
                   canPaintRecursiu(new Vector3Int(pos.x, pos.y - 1, pos.z), moviments--);
               }
           }
       }*/
    private void OnMouseDown()
    {
        this.Paint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        if (!this.selected) this.selected = true;
        else
        {
            for (int x = groundTilemap.cellBounds.min.x; x < groundTilemap.cellBounds.max.x; x++)
            {
                for (int y = groundTilemap.cellBounds.min.y; y < groundTilemap.cellBounds.max.y; y++)
                {
                    for (int z = groundTilemap.cellBounds.min.z; z < groundTilemap.cellBounds.max.z; z++)
                    {
                        groundTilemap.SetColor(groundTilemap.WorldToCell(new Vector3(x, y, z)), Color.white);
                    }
                }

            }
            this.selected = false;
        }
        print(this.selected);
    }
}