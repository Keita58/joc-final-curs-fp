using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        for (int i = 0; i < SceneManager.GetSceneByName(SceneManager.GetActiveScene().name).GetRootGameObjects().Length; i++)
        {
            GameObject a = SceneManager.GetSceneByName(SceneManager.GetActiveScene().name).GetRootGameObjects()[i];
            if (a.transform.tag == "Enemic")
            {
                a.GetComponent<Enemic>().enabled = false;
                a.GetComponent<Enemic>().enabled = true;
            }
            else if (a.transform.tag == "Jugador")
            {
                a.GetComponent<Jugador>().enabled = false;
                a.GetComponent<Jugador>().enabled = true;
            }
        }
        for (int i = 0; i < personatges.GetComponent<Mostra>().jugadorList.Count; i++)
        {
            personatges.GetComponent<Mostra>().jugadorList[i].SetActive(false);
        }
        click.gameObject.SetActive(false);
        menu.GetComponent<TilemapRenderer>().enabled = false;
        mapa.GetComponent<GridManager>().enabled = false;
        mapa.GetComponent<GridManager>().enabled = true;
    }
}
