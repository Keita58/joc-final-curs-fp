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
    [SerializeField]
    Tilemap collisionTilemap;
    int preu;
    [SerializeField] TextMeshProUGUI monedes;
    // Start is called before the first frame update
    void Start()
    {
        creat = false;
        text.text = "0";
        botoMes.onClick.AddListener(suma);
        botoMenys.onClick.AddListener(resta);
        botoComprar.onClick.AddListener(compra);
        textBotoComprar = botoComprar.GetComponentInChildren<TextMeshProUGUI>();
        preu = 0;
        textBotoComprar.text = preu + " G";
        print(InfoCompartida.monedes);
        monedes.text = "Monedes: " + InfoCompartida.monedes + " G";
    }

    public void resta()
    {
        if (int.Parse(text.text) > 0)
        {
            botoMenys.enabled = true;
            int a = int.Parse(text.text);
            a--;
            text.text = a.ToString();
            preu -= quantitat;
            textBotoComprar.text = preu + " G";
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
            preu += quantitat;
            textBotoComprar.text = preu + " G";
        }
    }

    //TODO Afegir el cost dels objectes!!! 
    public void compra()
    {
        if(!creat && int.Parse(text.text) > 0 && InfoCompartida.monedes >= preu)
        {
            GameObject aliat = Instantiate(copy);
            aliat.name = copy.name;
            aliat.transform.position = new Vector3(this.transform.position.x, -2, this.transform.position.z);
            aliat.AddComponent<Grab>();
            aliat.GetComponent<Grab>().groundTilemap = map;
            aliat.GetComponent<Jugador>().enabled = false;
            GameObject num = Instantiate(nums[int.Parse(text.text) - 1], aliat.transform);
            num.name = (int.Parse(text.text)).ToString();
            num.transform.position = new Vector3(aliat.transform.position.x + 0.1f, aliat.transform.position.y - 0.15f, 0);
            creat = true;
            text.text = "0";
            textBotoComprar.text = "0 G";
            DontDestroyOnLoad( aliat );
            InfoCompartida.monedes -= preu;
            preu = 0;
            monedes.text = "Monedes: " + InfoCompartida.monedes + " G";
        }
    }
}
