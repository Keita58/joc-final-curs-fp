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
    TextMeshProUGUI textBotoComprar;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] GameObject copy;
    [SerializeField] int quantitat;
    [SerializeField] GameObject[] nums;
    bool creat = false;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "0";
        botoMes.onClick.AddListener(suma);
        botoMenys.onClick.AddListener(resta);
        botoComprar.onClick.AddListener(compra);
        textBotoComprar = botoComprar.GetComponentInChildren<TextMeshProUGUI>();
        textBotoComprar.text = "0 G";
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
            string[] values = textBotoComprar.text.Split(" ");
            textBotoComprar.text = (int.Parse(values[0]) - quantitat).ToString() + " " + values[1];
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
            string[] values = textBotoComprar.text.Split(" ");
            textBotoComprar.text = (int.Parse(values[0]) + quantitat).ToString() + " " + values[1];
        }
        else
        {
            //botoMenys.enabled = false;
        }
    }

    //TODO Afegir el cost dels objectes!!! 
    public void compra()
    {
        if(!creat && int.Parse(text.text) > 0)
        {
            GameObject aliat = Instantiate(copy);
            aliat.transform.position = new Vector3(this.transform.position.x, -2, this.transform.position.z);
            GameObject num = Instantiate(nums[int.Parse(text.text) - 1], aliat.transform);
            num.transform.position = new Vector3(aliat.transform.position.x + 0.1f, aliat.transform.position.y - 0.15f, 0);
            creat = true;
        }
    }
}
