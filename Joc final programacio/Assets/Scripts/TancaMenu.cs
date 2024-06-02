using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class TancaMenu : MonoBehaviour
{
    [SerializeField] Tilemap menu;
    [SerializeField] GameObject menu2;
    [SerializeField] TextMeshProUGUI click;
    [SerializeField] GameObject personatges;
    bool amagat = false;
    public void Tanca()
    {
        if(!amagat)
        {
            click.text = "Obre";
            menu.GetComponent<TilemapRenderer>().enabled = false;
            menu2.gameObject.SetActive(false);
            personatges.gameObject.SetActive(false);
            amagat = true;
        }
        else
        {
            click.text = "Tanca";
            menu.GetComponent<TilemapRenderer>().enabled = true;
            menu2.gameObject.SetActive(true);
            personatges.gameObject.SetActive(true);
            amagat = false;
        }
    }
}
