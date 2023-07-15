using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Meincharacte : MonoBehaviour
{
    private bool isGrunded;
    public float currentSpeed;    
    public int damage;
    public float jumHeigth;
    public string characterName;
    public int coin = 0;
    private float m_currentTime;
    
    

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

        if (vida <= 0)
        {            
            dead = true;
            animator.SetBool("DeadChar", dead);
            MuertePlayer?.Invoke(this, EventArgs.Empty);

        }
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
    void Update()
    {
       

    }

    public void AddCoin(int p_amount)
    {
        coin += p_amount;
    }
}

