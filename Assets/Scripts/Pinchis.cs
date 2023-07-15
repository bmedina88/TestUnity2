using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinchis : MonoBehaviour
{
    [SerializeField] private float TiempodelDaño;

    private float TiempoSiguienteDaño;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            TiempoSiguienteDaño -= Time.deltaTime;
            if(TiempoSiguienteDaño <= 0)
            {
               other.GetComponent<Meincharacte>().TomarDaño(20);
                TiempoSiguienteDaño = TiempodelDaño;
            }
            
        }
    }
}
