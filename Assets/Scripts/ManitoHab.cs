using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManitoHab : MonoBehaviour
{

    [SerializeField] private float daño;
    [SerializeField] private float tiempo;
    [SerializeField] private Vector2 rango;
    [SerializeField] private Transform posicion;


    // Start is called before the first frame update

    public void Ataque()
    {
        Collider2D[] entidades = Physics2D.OverlapBoxAll(posicion.position, rango, 0f);
        foreach (var entidad in entidades)
        {
            if (entidad.CompareTag("Player"))
            {
                entidad.GetComponent<Meincharacte>().TomarDaño((int)daño);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(posicion.position, rango);
    }


}
