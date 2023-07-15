using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public class Meincharacte : MonoBehaviour
{
    private bool isGrunded;
    public float currentSpeed;    
    public int damage;
    public float jumHeigth;
    public string characterName;
    public int coin = 0;
    private float m_currentTime;
    public AudioSource recibirdañojugador;
    public AudioSource deadCharcter;



    [SerializeField] int vida;
    [SerializeField] int maximaVida;
    private Movimiento Movimiento;
    [SerializeField] private float FueradeControl;
    [SerializeField] private BarradeVida barraVida;

    public event EventHandler MuertePlayer;
    private Animator animator;

    
    void Start()
    {
        vida = maximaVida;
        barraVida.IniciarBarraVida(vida);
        AddCoin(0);
        animator = GetComponent<Animator>();
    }

    bool dead = false;

    public void TomarDaño(int daño)
    {
        vida -= daño;

        barraVida.CambiarVidaActual(vida);

        animator.SetTrigger("RecibirDaño");
        recibirdañojugador.Play();

        if (vida <= 0)
        {
            MuerteChar();
            MuertePlayer?.Invoke(this, EventArgs.Empty);
            deadCharcter.Play();
        }
    }

    private void MuerteChar()
    {
        animator.SetBool("DeadChar", true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        transform.GetComponent<Movimiento>().EliminarRigibody();
    }
    
    public void Curar(float curacion)
    {
        if ((vida + curacion) > maximaVida)
        {
            vida = maximaVida;
        }
        else
        {
            vida += (int)curacion;

        }
        barraVida.CambiarVidaActual(vida);
    }
    

    public void AddCoin(int p_amount)
    {
        coin += p_amount;
    }
}

