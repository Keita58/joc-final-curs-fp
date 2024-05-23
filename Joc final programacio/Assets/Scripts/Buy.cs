using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;
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
    public bool creat;
    [SerializeField] Tilemap map;
    [SerializeField]
    Llista jugadors;
    // Start is called before the first frame update
    void Start()
    {
        creat = false;
        text.text = "0";
        botoMes.onClick.AddListener(suma);
        botoMenys.onClick.AddListener(resta);
        botoComprar.onClick.AddListener(compra);
        textBotoComprar = botoComprar.GetComponentInChildren<TextMeshProUGUI>();
        textBotoComprar.text = "0 G";
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
    }

    //TODO Afegir el cost dels objectes!!! 
    public void compra()
    {
        if(!creat && int.Parse(text.text) > 0)
        {
            GameObject aliat = Instantiate(copy);
            aliat.name = copy.name;
            aliat.transform.position = new Vector3(this.transform.position.x, -2, this.transform.position.z);
            aliat.AddComponent<Grab>();
            aliat.GetComponent<Grab>().groundTilemap = map;
            aliat.GetComponent<Grab>().llista = jugadors.listSoldats;
            GameObject num = Instantiate(nums[int.Parse(text.text) - 1], aliat.transform);
            num.transform.position = new Vector3(aliat.transform.position.x + 0.1f, aliat.transform.position.y - 0.15f, 0);
            creat = true;
            text.text = "0";
            textBotoComprar.text = "0 G";
        }
    }
}
