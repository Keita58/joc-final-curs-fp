using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Grab : MonoBehaviour
{
    public Tilemap groundTilemap;
    public bool moure;
    public List<GameObject> llista;
    // Start is called before the first frame update
    void Start()
    {
        moure = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseDrag()
    {
        // Moviment del GameObject segons el ratolí
        
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(((mousePos.x < 10 && mousePos.x > -10) && (mousePos.y < 5 && mousePos.y > -5)) && moure)
        {
            this.transform.position = new Vector3(mousePos.x, mousePos.y, 0);
            transform.position = new Vector3(groundTilemap.WorldToCell((Vector3)Camera.main.ScreenToWorldPoint(Input.mousePosition)).x + 0.5f, groundTilemap.WorldToCell((Vector3)Camera.main.ScreenToWorldPoint(Input.mousePosition)).y + 0.5f, groundTilemap.WorldToCell((Vector3)Camera.main.ScreenToWorldPoint(Input.mousePosition)).z);
        }
    }
}
