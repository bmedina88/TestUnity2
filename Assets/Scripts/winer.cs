using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public class winer : MonoBehaviour
{
    //[SerializeField] private float cantidadPunto;
    //[SerializeField] private Puntaje puntaje;
    public event EventHandler WinPlayer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            Meincharacte mc = other.gameObject.GetComponent<Meincharacte>();
            if (mc)
            {
                Debug.Log("segundo if");
                WinPlayer?.Invoke(this, EventArgs.Empty);
                GameObject.Find("Canvas").GetComponent<Menuwin>().ActivarMenu();

            }
        }
    }
}
