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
        if (GameObject.Find("ControladorPuntos")!=null)
        {
            puntos = GameObject.Find("ControladorPuntos").GetComponent<ControladorPuntos>().getPuntos();
        }
        
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (textMesh != null) {
            textMesh.text = puntos.ToString("0");
        }
        
        
            
    }
     public void SumarPuntos(float puntosTotal)
    {
        puntos += puntosTotal;
        if (GameObject.Find("ControladorPuntos") != null)
        {
            GameObject.Find("ControladorPuntos").GetComponent<ControladorPuntos>().setearPuntos(puntos);
        }
        
    }
}
