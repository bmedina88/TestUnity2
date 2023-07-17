using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPuntos : MonoBehaviour
{
    [SerializeField] private float puntos;
    public static ControladorPuntos Instance;
    private void Awake()
    {
        if (ControladorPuntos.Instance == null)
        {
            ControladorPuntos.Instance = this;
            DontDestroyOnLoad(this.gameObject);
            Debug.Log("no se rompio");
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("se rompio");
        }
    }

    public void setearPuntos(float puntos)
    {
        this.puntos = puntos;
    }
    public float getPuntos()
    {
        return puntos;
    }
}
