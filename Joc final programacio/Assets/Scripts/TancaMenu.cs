using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TancaMenu : MonoBehaviour
{
    [SerializeField] Tilemap menu;
    [SerializeField] GameObject menu2;
    bool amagat = false;
    public void Tanca()
    {
        if(!amagat)
        {
            menu.GetComponent<TilemapRenderer>().enabled = false;
            menu2.gameObject.SetActive(false);
            amagat = true;
        }
        else
        {
            menu.GetComponent<TilemapRenderer>().enabled = true;
            menu2.gameObject.SetActive(true);
            amagat = false;
        }
    }
}
