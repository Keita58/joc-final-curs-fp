using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    List<Jugador> list;
    [SerializeField]
    List<Enemic> listEnemic;
    [SerializeField]
    TextMeshProUGUI textMesh;
    public int torn = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.torn == 0)
            textMesh.text = "Torn: Blau";
        else
            textMesh.text = "Torn: Vermell";
    }
    private void OnMouseDown()
    {
        if (torn == 0)
        {
            for (int x = 0; x < list.Count; x++)
            {
                if (list[x] != null)
                {
                    if (list[x].selected)
                    {
                        list[x].Move(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                    }
                }
            }
        }
        else
        {
            for (int x = 0; x < listEnemic.Count; x++)
            {
                if (listEnemic[x] != null)
                {
                    if (listEnemic[x].selected)
                    {
                        listEnemic[x].Move(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                    }
                }
            }
        }
    }
}
