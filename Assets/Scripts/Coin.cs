using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class Coin : MonoBehaviour
{

    private float nextActionTime = 0.0f;
    public float period = 0.1f;

    private AudioSource audioSource;
    [SerializeField] private float cantidadPunto;
    [SerializeField] private Puntaje puntaje;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            puntaje.SumarPuntos(cantidadPunto);
            Meincharacte mc = other.gameObject.GetComponent<Meincharacte>();
            if (mc)
            {
                mc.AddCoin(1);
                Destroy(gameObject);

            }
        }
    }
    void Update() 
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            transform.Rotate(new Vector3(0, 50, 0));
        }
    }
}
