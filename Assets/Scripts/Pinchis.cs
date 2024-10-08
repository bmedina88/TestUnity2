using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinchis : MonoBehaviour
{
    [SerializeField] private float TiempodelDaņo;

    private float TiempoSiguienteDaņo;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            TiempoSiguienteDaņo -= Time.deltaTime;
            if(TiempoSiguienteDaņo <= 0)
            {
               other.GetComponent<Meincharacte>().TomarDaņo(20);
                TiempoSiguienteDaņo = TiempodelDaņo;
            }
            
        }
    }
}
