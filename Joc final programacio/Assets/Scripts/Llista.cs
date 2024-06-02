using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class Llista : MonoBehaviour
{
    public List<GameObject> listSoldats = new List<GameObject>();
    public bool possible;
    public Tilemap groundTilemap;

    // Start is called before the first frame update
    void Start()
    {
        if(InfoCompartida.jugadorsGameObjects.Count > 0)
        {
            listSoldats = InfoCompartida.jugadorsGameObjects;
            float x = -2.5f;
            for (int i = 0; i < InfoCompartida.jugadorsGameObjects.Count; i++)
            {
                InfoCompartida.jugadorsGameObjects[i].gameObject.transform.position = new Vector2(x, -4.5f);
                x++;
            }
        }
        possible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (listSoldats.Count == 0)
        {
            listSoldats.Add(collision.gameObject);
            //print(collision.gameObject.GetComponent<Grab>().moure);
            GameObject.Find(collision.gameObject.name + "Static").GetComponent<Buy>().creat = false;
            collision.gameObject.GetComponent<Grab>().moure = false;
        }
        else
        {
            for (int i = 0; i < listSoldats.Count; i++)
            {
                Vector3 posSoldat = new Vector3(groundTilemap.WorldToCell(listSoldats[i].transform.position).x + 0.5f, groundTilemap.WorldToCell(listSoldats[i].transform.position).y + 0.5f, groundTilemap.WorldToCell(listSoldats[i].transform.position).z);
                if (posSoldat == collision.transform.position)
                {
                    possible = false;
                }
            }
            if (possible)
            { 
                listSoldats.Add(collision.gameObject);
                //print(collision.gameObject.GetComponent<Grab>().moure);
                GameObject.Find(collision.gameObject.name + "Static").GetComponent<Buy>().creat = false;
                collision.gameObject.GetComponent<Grab>().moure = false;
            }
            possible = true;
        }
    }
}
