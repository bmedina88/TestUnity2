using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinchis : MonoBehaviour
{
    [SerializeField] private float TiempodelDa�o;

    private float TiempoSiguienteDa�o;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            TiempoSiguienteDa�o -= Time.deltaTime;
            if(TiempoSiguienteDa�o <= 0)
            {
               other.GetComponent<Meincharacte>().TomarDa�o(20);
                TiempoSiguienteDa�o = TiempodelDa�o;
            }
            
        }
    }
}
