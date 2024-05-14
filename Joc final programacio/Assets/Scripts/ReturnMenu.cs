using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ReturnMenu : MonoBehaviour
{
    [SerializeField] Button btn;
    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(ClickTask);
    }

    public void ClickTask()
    {
        
        SceneManager.LoadScene("Menu");
    }
}
