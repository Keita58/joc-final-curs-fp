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
    [SerializeField] GameObject enemic7;
    [SerializeField] GameObject enemic8;
    [SerializeField] GameObject enemic9;
    [SerializeField] GameObject enemic10;
    [SerializeField] GameObject enemic11;
    [SerializeField] GameObject enemic12;
    [SerializeField] GameObject enemic13;
    ArrayList enemics = new ArrayList();

    // Start is called before the first frame update
    void Start()
    {
        enemics.Add(enemic1);
    }

    // Update is called once per frame
    void Update()
    {
        int num = Random.Range(0, 10);
    }
}
