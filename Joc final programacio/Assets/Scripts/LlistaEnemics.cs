using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LlistaEnemics : MonoBehaviour
{
    [SerializeField] List<Enemic> llistaEnemics;

    void Start()
    {
        InfoCompartida.enemics = llistaEnemics;
    }
}
