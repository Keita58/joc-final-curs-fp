using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Buy : MonoBehaviour
{
    [SerializeField] Button botoMes;
    [SerializeField] Button botoMenys;
    [SerializeField] Button botoComprar;
    [SerializeField] TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "0";
        botoMes.onClick.AddListener(suma);
        botoMenys.onClick.AddListener(resta);
        //botoMes.onClick.AddListener(suma);
    }

    public void resta()
    {
        if (int.Parse(text.text) > 0)
        {
            botoMenys.enabled = true;
            int a = int.Parse(text.text);
            a--;
            text.text = a.ToString();
        }
        else
        {
            //botoMenys.enabled = false;
        }
    }

    // Update is called once per frame
    public void suma()
    {
        if(int.Parse(text.text) < 9)
        {
            botoMenys.enabled = true;
            int a = int.Parse(text.text);
            a++;
            text.text = a.ToString();
        }
        else
        {
            //botoMenys.enabled = false;
        }
    }
}
