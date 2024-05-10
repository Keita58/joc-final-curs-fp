using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject enemic1;
    [SerializeField] GameObject enemic2;
    [SerializeField] GameObject enemic3;
    [SerializeField] GameObject enemic4;
    [SerializeField] GameObject enemic5;
    [SerializeField] GameObject enemic6;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int num = Random.Range(0, 10);
    }
}
