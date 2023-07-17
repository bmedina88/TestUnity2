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
    [SerializeField] private float hp=1000;
    [SerializeField] private BarradeVida barraVidaBoss;
    [Header("Ataque")]
    [SerializeField] private Transform controladorAtaque;
    [SerializeField] private float dañoAtaque;
    [SerializeField] private float radioAtaque;


    // Start is called before the first frame update
    void Start()
    {
        bossRB = GetComponent<Rigidbody2D>();
        jugador = GameObject.Find("Meincharacte");
        jugadorTransform = jugador.GetComponent<Transform>();
        ani = GetComponent<Animator>();
        posicionInicial = transform.position;
        barraVidaBoss.IniciarBarraVida(hp);

    }

    // Update is called once per frame
    void Update()
    {
        distancia = Vector2.Distance(transform.position, jugadorTransform.position);
        ani.SetFloat("Distancia", distancia);
        
    }



    public void comportamiento()
    {

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
        hp -= daño;
        barraVidaBoss.CambiarVidaActual(hp);

        ani.SetTrigger("Hited");


        if (hp <= 0)
        {
            ani.SetTrigger("Muerte");
        }
    }

    private void Muerte()
    {
        Destroy(gameObject);
        Destroy(GameObject.Find("BarradeVidaBoss"));
    }
}
