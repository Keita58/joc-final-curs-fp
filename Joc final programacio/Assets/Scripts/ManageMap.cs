using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageMap : MonoBehaviour
{
    int pos = 0;
    public List<GameObject> list;
    // Start is called before the first frame update
    void Start()
    {
        for(int i  = 0; i < list.Count; i++)
        {
            list[i].SetActive(false);
        }
        list[pos].SetActive(true);
    }
    public void cambioDerecha()
    {
        if(pos < list.Count - 1)
        {
            list[pos].SetActive(false);
            pos++;
            list[pos].SetActive(true);
        }
        else
        {
            list[pos].SetActive(false);
            pos = 0;
            list[pos].SetActive(true);
        }
    }
    public void cambioIzquierda()
    {
        if (pos > 0)
        {
            list[pos].SetActive(false);
            pos--;
            list[pos].SetActive(true);
        }
        else
        {
            list[pos].SetActive(false);
            pos = list.Count-1;
            list[pos].SetActive(true);
           
        }
    }
    // Update is called once per frame
    public void LoadMap()
    {
        for(int i = 0; i < list.Count; i++)
        {
            if (list[i] != null && list[i].active == true)
            {
                SceneManager.LoadScene(list[i].name);
            }
        }
    }
    public void GoToShop()
    {
        SceneManager.LoadScene("Shop");
    }
}
