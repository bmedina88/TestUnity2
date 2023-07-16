using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoventEsqueleto : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform ControlSueloEsqueleto;
    [SerializeField] private float distanciaEsqueleto;
    [SerializeField] private bool movimientoDerechaEsqueleto;

    private Rigidbody2D rb2d;
    private Animator animator;


    public void EliminarRigibody()
    {
        Destroy(GetComponent<Rigidbody2D>());
    }
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        RaycastHit2D informacionSuelo = Physics2D.Raycast(ControlSueloEsqueleto.position, Vector2.down, distanciaEsqueleto);

        if (rb2d != null)
        {
            animator.SetBool("MovimientoEsqueleto", true);
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);

        }
        if (informacionSuelo == false)
        {
            animator.SetBool("MovimientoEsqueleto", false);
            Girar();
        }
    }
    private void Girar()
    {
        movimientoDerechaEsqueleto = !movimientoDerechaEsqueleto;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        speed *= -1;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(ControlSueloEsqueleto.transform.position, ControlSueloEsqueleto.transform.position + Vector3.down * distanciaEsqueleto);
    }
}
