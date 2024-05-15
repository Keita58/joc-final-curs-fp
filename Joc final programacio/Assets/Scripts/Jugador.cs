using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Tilemaps;

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
        if(transform.position.x - moviment >= direction.x && transform.position.x + moviment <= direction.x)
        {
            Vector3Int gridPosition = groundTilemap.WorldToCell((Vector3)direction);
            if (!groundTilemap.HasTile(gridPosition) || collisionTilemap.HasTile(gridPosition)) return false;
            return true;
        }
        return false;
    }
}
