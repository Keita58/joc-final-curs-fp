using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mostra : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> jugadorList;

    // Start is called before the first frame update
    void Start()
    {
        jugadorList = InfoCompartida.jugadorsGameObjects;
        float x = -8.5f;
        for(int i = 0; i < InfoCompartida.jugadorsGameObjects.Count; i++)
        {
            InfoCompartida.jugadorsGameObjects[i].gameObject.transform.position = new Vector2(x, -4.5f);
            x++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
