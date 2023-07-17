using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaSiguienteNivel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.CompareTag("Player"))
        {
            if (GameObject.Find("llave").GetComponent<abrirPuerta>().getLlave()==1)
            {
                Debug.Log("pasooo");
            }
            
        }
    }
}
