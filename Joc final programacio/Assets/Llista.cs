using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Llista : MonoBehaviour
{
    public List<GameObject> listSoldats;
    public bool possible;
    // Start is called before the first frame update
    void Start()
    {
        possible = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(listSoldats.Count == 0)
        {
            listSoldats.Add(collision.gameObject);
            print(collision.gameObject.GetComponent<Grab>().moure);
            GameObject crea = GameObject.Find(collision.gameObject.name);
            crea.GetComponent<Buy>().creat = false;
            collision.gameObject.GetComponent<Grab>().moure = false;
        }
        else 
        { 
            for(int i = 0; i < listSoldats.Count; i++) {
                if (listSoldats[i].transform.position == collision.transform.position) {
                    possible = false;
                }
            }
            if(possible)
            {
                listSoldats.Add(collision.gameObject);
                print(collision.gameObject.GetComponent<Grab>().moure);
                GameObject crea = GameObject.Find(collision.gameObject.name);
                crea.GetComponent<Buy>().creat = false;
                collision.gameObject.GetComponent<Grab>().moure = false;
            }
            possible = true;
        }
        
    }
}
