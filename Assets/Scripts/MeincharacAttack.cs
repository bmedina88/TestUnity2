using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class MeincharacAttack : MonoBehaviour
{
    public bool atacando = false;
    [SerializeField] private Transform ControladorAtake;

    [SerializeField] private float radioAttack;

    [SerializeField] private float DañoAttack;

    [SerializeField] private float cooldownFijo;
    [SerializeField] private float cooldownActual;


    private Animator m_animator;
    public AudioSource ataque;

    private void Start()
    {
        m_animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (cooldownActual > 0)
        {
            cooldownActual -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.R) && cooldownActual<=0 && GetComponent<Movimiento>().getSePuedeMover() )
        {
            ataque.Play();
            Golpe();
            cooldownActual = cooldownFijo;
        }
    }
    private void Golpe()
    {

        m_animator.SetTrigger("Golpe");

        Collider2D[] objeto = Physics2D.OverlapCircleAll(ControladorAtake.position, radioAttack); 
        
        foreach (Collider2D collider in objeto)
        {
            if (collider.CompareTag("Enemigo"))
            {
                
                collider.GetComponent<Enemigos<float>>().TomarDaño(DañoAttack);
                
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(ControladorAtake.position, radioAttack);
    }

}
