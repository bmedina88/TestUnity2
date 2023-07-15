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

    private Animator m_animator;
    public AudioSource ataque;

    private void Start()
    {
        m_animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ataque.Play();
            Golpe();
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
                
                collider.transform.GetComponent<Golbin>().TomarDaño(DañoAttack);
                
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(ControladorAtake.position, radioAttack);
    }

}
