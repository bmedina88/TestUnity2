using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public class Meincharacte : MonoBehaviour
{
    public int coin = 0;

    public AudioSource recibirdaņojugador;
    public AudioSource deadCharcter;
    public event EventHandler MuertePlayer;

    private Movimiento movimiento;
    [SerializeField] private float tiempoFueradeControl;

    [SerializeField] float vida;
    [SerializeField] int maximaVida;
    [SerializeField] private BarradeVida barraVida;


    private Animator animator;

    
    void Start()
    {
        vida = maximaVida;
        barraVida.IniciarBarraVida(vida);
        AddCoin(0);
        animator = GetComponent<Animator>();
        movimiento = transform.GetComponent<Movimiento>();
    }


    public void TomarDaņo(int daņo)
    {
        vida -= daņo;

        barraVida.CambiarVidaActual(vida);

        animator.SetTrigger("RecibirDaņo");
        recibirdaņojugador.Play();
        StartCoroutine(PerderControl());
        movimiento.Retroceso(new Vector2(-1,0) );

        if (vida <= 0)
        {
            MuerteChar();
            MuertePlayer?.Invoke(this, EventArgs.Empty);
            deadCharcter.Play();
        }
    }
    public void TomarDaņo(int daņo, Vector2 posicion)
    {
        vida -= daņo;

        barraVida.CambiarVidaActual(vida);

        animator.SetTrigger("RecibirDaņo");
        recibirdaņojugador.Play();
        StartCoroutine(PerderControl());


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
        movimiento.EliminarRigibody();
    }
    
    public void Curar(float curacion)
    {
        if ((vida + curacion) > maximaVida)
        {
            vida = maximaVida;
        }
        else
        {
            vida += curacion;

        }
        barraVida.CambiarVidaActual(vida);
    }
    

    public void AddCoin(int p_amount)
    {
        coin += p_amount;
    }
    
    private IEnumerator PerderControl()
    {
        movimiento.SepuedeMover = false;
        yield return new WaitForSeconds(tiempoFueradeControl);
        movimiento.SepuedeMover = true;
    }
}

