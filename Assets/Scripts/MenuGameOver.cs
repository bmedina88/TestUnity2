using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MenuGameOver : MonoBehaviour
{
    [SerializeField] private GameObject menuGameOver;

    private Meincharacte combateCharacter;

    private void Start()
    {
        combateCharacter = GameObject.FindGameObjectWithTag("Player").GetComponent<Meincharacte>();
        combateCharacter.MuertePlayer += ActivarMenu;
    }


    private void ActivarMenu(object sender, EventArgs e)
    {
        menuGameOver.SetActive(true);
    }
    public void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MenuInicial(string nombre)
    {
        SceneManager.LoadScene(nombre);
    }
    public void salir()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit(); 
    }
}
