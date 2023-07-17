using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abrirPuerta : MonoBehaviour
{
    public static int llave;

    private void Start()
    {
        llave = 0;       
    }

    public int getLlave()
    {
        return llave;
    }
}
