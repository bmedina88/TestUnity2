using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    public GameObject sinllave;
    public GameObject conllave;
    public GameObject botonPuerta;
    public AudioSource sounkey;

    public Animator onPuerta;

    private void Start()
    {
        if (botonPuerta!= null)
        {
            conllave.SetActive(false);
            sinllave.SetActive(false);
            botonPuerta.SetActive(false);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("key"))
        {
            abrirPuerta.llave += 1;
            Destroy(collision.gameObject);
            
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (botonPuerta != null)
        {
            if (collision.tag.Equals("puerta") && abrirPuerta.llave == 0)
            {
                sinllave.SetActive(true);
            }

            if (collision.tag.Equals("puerta") && abrirPuerta.llave == 1)
            {
                conllave.SetActive(true);
                botonPuerta.SetActive(true);
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (botonPuerta != null)
        {
            if (collision.tag.Equals("puerta") && abrirPuerta.llave == 0)
            {
                sinllave.SetActive(false);
            }

            if (collision.tag.Equals("puerta") && abrirPuerta.llave == 1)
            {
                conllave.SetActive(false);
                botonPuerta.SetActive(false);
            }
        }

    }

    public void btonPuerta()
    {
        onPuerta.SetTrigger("abrir");
        GameObject.Find("puertaCerrada").GetComponent<BoxCollider2D>().enabled = false;
    }
    
}
