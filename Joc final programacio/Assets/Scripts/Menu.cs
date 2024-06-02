using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject list;
    public void GotoMenu()
    {
        InfoCompartida.jugadorsGameObjects = new List<GameObject>();
        for (int i = 0; i < list.gameObject.GetComponent<Llista>().listSoldats.Count; i++)
        {
            InfoCompartida.jugadorsGameObjects.Add(list.gameObject.GetComponent<Llista>().listSoldats[i]);
        }
        SceneManager.LoadScene("SelectMap");
    }
}
