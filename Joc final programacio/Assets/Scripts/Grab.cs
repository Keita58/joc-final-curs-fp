using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class Grab : MonoBehaviour
{
    public Tilemap groundTilemap;
    public bool moure;
    public List<GameObject> llista;
    bool creaJugador = false;
    // Start is called before the first frame update
    void Start()
    {
        moure = true;
    }

    // Update is called once per frame
    void Update()
    {
        if ((SceneManager.GetActiveScene().name == "Mapa1") || (SceneManager.GetActiveScene().name == "Mapa2") && !creaJugador)
        {
            moure = true;
            creaJugador = true;
            for (int i = 0; i < SceneManager.GetSceneByName(SceneManager.GetActiveScene().name).GetRootGameObjects().Length; i++)
            {
                GameObject a = SceneManager.GetSceneByName(SceneManager.GetActiveScene().name).GetRootGameObjects()[i];
                if (a.name == "Grid")
                {
                    for (int x = 0; x < a.transform.childCount; x++)
                    {
                        if (a.transform.GetChild(x).name == "Mapa")
                        {
                            this.groundTilemap = a.transform.GetChild(x).GetComponent<Tilemap>();
                        }
                    }
                }
            }
        }

    }

    public void OnMouseDrag()
    {
        // Moviment del GameObject segons el ratolí
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (((mousePos.x < 9 && mousePos.x > -9) && (mousePos.y < 5 && mousePos.y > -5)) && moure)
        {
            print("Em moc");
            this.transform.position = new Vector3(mousePos.x, mousePos.y, 0);
            transform.position = new Vector3(groundTilemap.WorldToCell((Vector3)Camera.main.ScreenToWorldPoint(Input.mousePosition)).x + 0.5f, groundTilemap.WorldToCell((Vector3)Camera.main.ScreenToWorldPoint(Input.mousePosition)).y + 0.5f, groundTilemap.WorldToCell((Vector3)Camera.main.ScreenToWorldPoint(Input.mousePosition)).z);
        }
    }
}
