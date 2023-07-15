using Mono.Cecil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private Animator animator;
    public Rigidbody2D rb2d;
    public Transform Character;
    private bool mirandoDerecha = true;

    [SerializeField] private float vida;
    [SerializeField] private BarradeVida barradeVida;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        barradeVida.IniciarBarraVida(vida);
        Character = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>()
;    }

    public void TomarDaño(float daño)
    {
        vida -= daño;
        barradeVida.CambiarVidaActual(vida); 

        if (vida <0)
        {
            animator.SetTrigger("Muerte");
        }
    }

    private void Muerte()
    {
        Destroy(gameObject);
    }

    public void MirarJugador()
    {
        if((Character.position.x > transform.position.x && !mirandoDerecha) || (Character.position.x < transform.position.x && mirandoDerecha))
        {
            mirandoDerecha = !mirandoDerecha;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        }
    }
}
