using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esqueleto : MonoBehaviour
{
    BoxCollider2D BoxCollider;
    Rigidbody2D rb2d;
    [SerializeField] public float vida;

    private bool isDamage = false;
    private Animator animator;
    private AudioSource audioSource;

    [SerializeField] private Transform ControladorAtakeEsqueleto;
    [SerializeField] private float radioAttackEsqueleto;
    [SerializeField] private float DañoAttackEsqueleto;

    private void Start()
    {
        BoxCollider = GetComponent<BoxCollider2D>();
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }


    private void Update()
    {
        Golpe();
    }

    public void TomarDaño(float daño)
    {
        vida -= daño;

        animator.SetTrigger("HitEsqueleto");
        audioSource.Play();


        if (vida <= 0)
        {
            Muerte();
        }
    }
    private void Golpe()
    {
        Collider2D[] objeto = Physics2D.OverlapCircleAll(ControladorAtakeEsqueleto.position, radioAttackEsqueleto);

        foreach (Collider2D collider in objeto)
        {
            if (collider.CompareTag("Player"))
            {
                animator.SetTrigger("AtackEsqueleto");
                collider.transform.GetComponent<Meincharacte>().TomarDaño((int)DañoAttackEsqueleto);
            }
        }
    }

    private void Muerte()
    {
        animator.SetBool("MuerteEsqueleto", true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        transform.GetComponent<MovimientoGoblin>().EliminarRigibody();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(ControladorAtakeEsqueleto.position, radioAttackEsqueleto);
    }
}
