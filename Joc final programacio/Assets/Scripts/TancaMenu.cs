using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class TancaMenu : MonoBehaviour
{
    [SerializeField] Tilemap menu;
    [SerializeField] Tilemap mapa;
    [SerializeField] Button click;
    [SerializeField] GameObject personatges;
    public void Tanca()
    {
        click.gameObject.SetActive(false);
        menu.GetComponent<TilemapRenderer>().enabled = false;
        mapa.GetComponent<GridManager>().enabled = false;
        mapa.GetComponent<GridManager>().enabled = true;
        for (int i = 0; i < personatges.GetComponent<Mostra>().jugadorList.Count; i++)
        {
            personatges.GetComponent<Mostra>().jugadorList[i].SetActive(false);
        }
    }
}
