using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaGuillotina : MonoBehaviour

{
    [SerializeField]public GameObject puerta;
    [SerializeField]private SpriteRenderer puertaRender;
    void Start()
    {
        puertaRender = GetComponent<SpriteRenderer>();
        if (puertaRender)
        {
            puertaRender.sortingOrder = -1;
        }
        GetComponent<BoxCollider2D>().enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void cerrarPuerta()
    {
        if (puertaRender)
        {
            puertaRender.sortingOrder = 1;
        }
        GetComponent<BoxCollider2D>().enabled = true;
    }
}
