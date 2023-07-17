using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    
    public float speed;
    public float rotationSpeed = 0;
    public bool isGrounded = true;
    public float jumpforce = 10f;
    Rigidbody2D Rigi2D;
    [SerializeField] private Vector2 VelocidadRebote;
    [SerializeField] private float m_movementSpeed;
    private Animator m_animator;
    private AudioSource jump;
    [SerializeField] public bool SepuedeMover = true;





    public void EliminarRigibody()
    {
        Destroy(GetComponent<Rigidbody2D>());
    }

    void Start()
    {

        Rigi2D = GetComponent<Rigidbody2D>();

        m_animator = GetComponent<Animator>();

        jump = GetComponent<AudioSource>();
    }

    void Update()
    {
       
        if (!m_animator.GetBool("DeadChar"))
        {


            if (SepuedeMover)
            {
                float l_horizontal = Input.GetAxis("Horizontal");

                Rigi2D.velocity = new Vector3(l_horizontal * speed + Rigi2D.velocity.x, Rigi2D.velocity.y, 0);
                Girar(l_horizontal);
                Mover(l_horizontal);
                Saltar();
            }



        }
    }






    public void Mover(float movent)
    {



        transform.position += Vector3.right * (movent * m_movementSpeed * Time.deltaTime);

        bool l_movimiento = movent != 0;

        m_animator.SetBool("Movimiento", l_movimiento);


    }
    public void Girar(float movent)
    {
        if (movent > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (movent < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
    public void Retroceso(Vector2 posicion)
    {
        Rigi2D.velocity = new Vector2(-VelocidadRebote.x * posicion.x, VelocidadRebote.y);
    }
    public void Saltar()
    {
        m_animator.SetBool("Ensuelo", isGrounded);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            Rigi2D.AddForce(new Vector3(0, jumpforce, 0), ForceMode2D.Impulse);
            isGrounded = false;
            jump.Play();

        }
    }
   

    public bool getSePuedeMover()
    {
        return SepuedeMover;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            isGrounded = true;
        }
    }

    

}
