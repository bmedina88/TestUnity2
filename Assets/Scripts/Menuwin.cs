using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Menuwin : MonoBehaviour
{
    [SerializeField] private GameObject menuWin;


    private Meincharacte winer;

    private void Start()
    {
        winer = GameObject.FindGameObjectWithTag("Player").GetComponent<Meincharacte>();
        winer.MuertePlayer += ActivarMenu;
    }

    public void ActivarMenu(object sender, EventArgs e)
    {
        menuWin.SetActive(true);
        Time.timeScale = 0f;

    }
    public void ActivarMenu()
    {
        menuWin.SetActive(true);
        Time.timeScale = 0f;

    }
    public void Reiniciar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void salir()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;

    }



}
