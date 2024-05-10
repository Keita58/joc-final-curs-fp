using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class a : MonoBehaviour
{
    public Button Btn;
    public GameObject g;
    void Start()
    {
        Button btn = Btn.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (g.activeSelf == true)
        {
            g.SetActive(false);
        }
        else
        {
            g.SetActive(true);
        }
    }
}
