using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Puntaje : MonoBehaviour
{
    [SerializeField] private float puntos;
    private TextMeshProUGUI textMesh;

    private void Start()
    {
        puntos = GameObject.Find("ControladorPuntos").GetComponent<ControladorPuntos>().getPuntos();
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        textMesh.text = puntos.ToString("0");
        
            
    }
     public void SumarPuntos(float puntosTotal)
    {
        puntos += puntosTotal;
        GameObject.Find("ControladorPuntos").GetComponent<ControladorPuntos>().setearPuntos(puntos);
    }
}
