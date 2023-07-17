using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss1 : MonoBehaviour, Enemigos<float>
{
    [SerializeField] private Rigidbody2D bossRB;
    [SerializeField] public Animator ani;
    public GameObject jugador;
    public Transform jugadorTransform;

    public int rutina;
    public bool atacando;
    //
    private bool mirandoDerecha = false;
    private float distancia;
    private Vector3 posicionInicial;
    //
    [Header("Vida")]
    [SerializeField] private float hp;
    private float hpMax;
    [SerializeField] private BarradeVida barraVidaBoss;
    [SerializeField] private bool invencible=false;

    [Header("Ataque")]
    [SerializeField] private Transform controladorAtaque;
    [SerializeField] private float dañoAtaque;
    [SerializeField] private float radioAtaque;

    [SerializeField] private GameObject manitos;
    [SerializeField] private bool habEnCd=false;
    [SerializeField] private float tiempoEnCd;


    // Start is called before the first frame update
    void Start()
    {
        bossRB = GetComponent<Rigidbody2D>();
        jugador = GameObject.Find("Meincharacte");
        jugadorTransform = jugador.GetComponent<Transform>();
        ani = GetComponent<Animator>();
        posicionInicial = transform.position;
        barraVidaBoss.IniciarBarraVida(hp);
        hpMax = hp;

        manitos = GameObject.Find("Manitos");
        ocultarHab();



    }

    // Update is called once per frame
    void Update()
    {
        distancia = Vector2.Distance(transform.position, jugadorTransform.position);
        ani.SetFloat("Distancia", distancia);
        comportamientoHabilidad();

    }




    public void comportamientoHabilidad()
    {
        if (this.hp <= (this.hpMax / 2) && habEnCd==false)
        {
            ani.SetTrigger("habManito");
            invencible = true;
            StartCoroutine(SilenceoHab());

            
        }
    }
    public void ocultarHab()
    {
        this.manitos.SetActive(false);
    }
    public void mostrarHab()
    {
        manitos.SetActive(true);
    }
    public void esInvencible()
    {
        this.invencible = true;
    }
    public void noEsInvencible()
    {
        this.invencible = false;
    }



    public void moverse(int velocidad)
    {
        transform.Translate(Vector3.right * velocidad * Time.deltaTime);
    }

    public void Girar()
    {
        if ((jugadorTransform.position.x > transform.position.x && !mirandoDerecha) || (jugadorTransform.position.x < transform.position.x && mirandoDerecha))
        {
            mirandoDerecha = !mirandoDerecha;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        }
    }

    public void Ataque()
    {
        Collider2D[] entidades = Physics2D.OverlapCircleAll(controladorAtaque.position, radioAtaque);
        foreach (var entidad in entidades)
        {
            if (entidad.CompareTag("Player"))
            {
                entidad.GetComponent<Meincharacte>().TomarDaño((int)dañoAtaque);
            }
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorAtaque.position, radioAtaque);
    }

    public void TomarDaño(float daño)
    {
        if (!invencible)
        {
            hp -= daño;
            barraVidaBoss.CambiarVidaActual(hp);

            ani.SetTrigger("Hited");


            if (hp <= 0)
            {

                ani.SetTrigger("Muerte");
            }
        }

    }

    private IEnumerator SilenceoHab()
    {
        habEnCd = true;
        yield return new WaitForSeconds(tiempoEnCd);
        habEnCd = false;
    }

    private void Muerte()
    {
        Destroy(gameObject);
        Destroy(GameObject.Find("BarradeVidaBoss"));
        abrirPuertaVictoria();
    }
    
    
    
    
    
    public void CerrarPuertaGuillotina()
    {
        GameObject.Find("PuertaGuillotina").GetComponent<PuertaGuillotina>().cerrarPuerta();    
    }
    public void abrirPuertaVictoria()
    {
        GameObject.Find("PuertaVictoria").GetComponent<BoxCollider2D>().enabled = false;
    }
}

