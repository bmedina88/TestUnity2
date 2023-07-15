using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            Meincharacte mc = other.gameObject.GetComponent<Meincharacte>();
            if (mc)
            {
                mc.Curar(10);
                Destroy(gameObject);

            }
        }
    }
}
