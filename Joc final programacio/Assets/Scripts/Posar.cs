using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Posar : MonoBehaviour
{
    public List<GameObject> listSoldats = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach(GameObject soldat in InfoCompartida.jugadorsGameObjects)
        {
            if(soldat.name == collision.gameObject.name)
            {
                InfoCompartida.jugadorsGameObjects.Remove(soldat);
                SceneManager.MoveGameObjectToScene(soldat, SceneManager.GetActiveScene());
                break;
            }    
        }
        listSoldats.Add(collision.gameObject);
    }
}
