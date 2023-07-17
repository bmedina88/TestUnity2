using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuertaSiguienteNivel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.CompareTag("Player"))
        {
            if (GameObject.Find("llave").GetComponent<abrirPuerta>().getLlave()==1 && GameObject.Find("puertaCerrada").GetComponent<BoxCollider2D>().enabled == false)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
            }
            
        }
    }
}
