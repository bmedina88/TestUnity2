using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Golbin : MonoBehaviour, Enemigos<float>
{
    BoxCollider2D BoxCollider;

    Rigidbody2D rb2d;

    [SerializeField] public float vida;

    private bool isDamage = false;

    private Animator animator;
    private AudioSource audioSource;
    
    [SerializeField] private Transform ControladorAtakeGoblin;

    [SerializeField] private float radioAttackGoblin;

    [SerializeField] private float DañoAttackGoblin;



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
        
        animator.SetTrigger("HitGoblin");
        audioSource.Play();


        if (vida <= 0)
        {
            Muerte();
        }
    }
    private void Golpe()
    {
        

        Collider2D[] objeto = Physics2D.OverlapCircleAll(ControladorAtakeGoblin.position, radioAttackGoblin);

        foreach (Collider2D collider in objeto)
        {
            if (collider.CompareTag("Player"))
            {
                animator.SetTrigger("ataqueGoblin");
                collider.transform.GetComponent<Meincharacte>().TomarDaño((int) DañoAttackGoblin);

            }
        }
    }
    
    private void Muerte()
    {

        animator.SetBool("Muerte", true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        transform.GetComponent<MovimientoGoblin>().EliminarRigibody();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(ControladorAtakeGoblin.position, radioAttackGoblin);
    }

 
}
