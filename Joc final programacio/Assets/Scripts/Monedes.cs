using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Monedes : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_TextMeshProUGUI;
    // Start is called before the first frame update
    void Start()
    {
        m_TextMeshProUGUI.text = "Monedes: " + InfoCompartida.monedes;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
