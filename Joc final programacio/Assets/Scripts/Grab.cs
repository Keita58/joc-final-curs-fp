using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Grab : MonoBehaviour
{
    [SerializeField] Tilemap groundTilemap;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDrag()
    {
        // Moviment del GameObject segons el ratolí
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.transform.position = new Vector3(mousePos.x, mousePos.y, 0);
        transform.position = new Vector3(groundTilemap.WorldToCell((Vector3)Camera.main.ScreenToWorldPoint(Input.mousePosition)).x + 0.5f, groundTilemap.WorldToCell((Vector3)Camera.main.ScreenToWorldPoint(Input.mousePosition)).y + 0.5f, groundTilemap.WorldToCell((Vector3)Camera.main.ScreenToWorldPoint(Input.mousePosition)).z);
    }
}
