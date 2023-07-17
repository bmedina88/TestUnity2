using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Meincharacte : MonoBehaviour
{
    public int coin = 0;

    public AudioSource recibirdañojugador;
    public AudioSource deadCharcter;
    public event EventHandler MuertePlayer;
    //public event EventHandler WinPlayer;
    

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


    public void TomarDaño(int daño)
    {
        vida -= daño;

        barraVida.CambiarVidaActual(vida);

        animator.SetTrigger("RecibirDaño");
        recibirdañojugador.Play();
        StartCoroutine(PerderControl());
        movimiento.Retroceso(new Vector2(-1,0) );

        if (vida <= 0)
        {
            MuerteChar();
            MuertePlayer?.Invoke(this, EventArgs.Empty);
            deadCharcter.Play();
        }
    }

    public void TomarDaño(int daño, Vector2 posicion)
    {
        vida -= daño;

        barraVida.CambiarVidaActual(vida);

        animator.SetTrigger("RecibirDaño");
        recibirdañojugador.Play();
        StartCoroutine(PerderControl());


        if (vida <= 0)
        {
            MuerteChar();
            MuertePlayer?.Invoke(this, EventArgs.Empty);
            deadCharcter.Play();
        }
    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.gameObject.layer == 6)
    //    {
    //        WinPlayer?.Invoke(this, EventArgs.Empty);
    //    }
    //}

    

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

