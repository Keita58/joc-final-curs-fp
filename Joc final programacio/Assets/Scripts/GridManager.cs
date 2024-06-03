using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public List<Jugador> list;
    [SerializeField]
    List<Enemic> listEnemic;
    [SerializeField]
    TextMeshProUGUI textMesh;
    public int torn = 0;
    int count;
    int count2;
    void Start()
    {
        count = 0;
        count2 = 0;
    }

    private void OnEnable()
    {
        for (int i = 0; i < SceneManager.GetSceneByName(SceneManager.GetActiveScene().name).GetRootGameObjects().Length; i++)
        {
            GameObject a = SceneManager.GetSceneByName(SceneManager.GetActiveScene().name).GetRootGameObjects()[i];
            if (a.transform.tag == "Enemic")
            {
                this.listEnemic.Add(a.transform.GetComponent<Enemic>());
            }
            else if (a.transform.tag == "Jugador")
            {
                Destroy(a.gameObject.GetComponent<Grab>());
                this.list.Add(a.transform.GetComponent<Jugador>());
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (this.torn == 0)
            textMesh.text = "Torn: Blau";
        else
            textMesh.text = "Torn: Vermell";

        
        for(int i = 0; i < listEnemic.Count; i++)
        {
            if (listEnemic[i].IsDestroyed())
                count++;
        }
        if (listEnemic.Count == count)
        {
            SceneManager.LoadScene("SelectMap");
        }

        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].IsDestroyed())
                count2++;
        }
        if (list.Count == count2)
        {
            SceneManager.LoadScene("SelectMap");
        }
    }
    private void OnMouseDown()
    {
        if (torn == 0)
        {
            for (int x = 0; x < list.Count; x++)
            {
                if (list[x] != null)
                {
                    print("Tinc aliats");
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
