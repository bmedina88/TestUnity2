using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MovimientoGoblin : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private Transform ControladorSuelo;

    [SerializeField] private float distancia;

    [SerializeField] private bool movimientoDerecha;

    private Rigidbody2D rb2d;

    private Animator animator;
    

    public void EliminarRigibody()
    {
        Destroy(GetComponent<Rigidbody2D>());
    }
    private void Start()
    {
        rb2d =  GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();

        

    }

    private void FixedUpdate()
    {
        RaycastHit2D informacionSuelo = Physics2D.Raycast(ControladorSuelo.position, Vector2.down, distancia);
        
        if (rb2d != null)
        {
            animator.SetBool("MovimientoEnemigo", true);
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
            
        }
        if (informacionSuelo == false)
        {
            animator.SetBool("MovimientoEnemigo", false);
            Girar();
            
        }

        
    }
     private void Girar()
    {
        movimientoDerecha = !movimientoDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        speed *= -1;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(ControladorSuelo.transform.position, ControladorSuelo.transform.position + Vector3.down * distancia);
    }
}
