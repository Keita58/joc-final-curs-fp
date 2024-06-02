using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartController : MonoBehaviour
{
    public Button Btn;

    void Start()
    {
        Button btn = Btn.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        InfoCompartida.monedes = 20;
        print(InfoCompartida.monedes);
        SceneManager.LoadScene("SelectMap");
    }
}
