using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    List<Jugador> list;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        for(int x = 0; x < list.Count; x++)
        {
            if (list[x].selected)
            {
                list[x].Move(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }
        }

        //  j.Paint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
    }
}
