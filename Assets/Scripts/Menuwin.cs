//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System;
//using UnityEngine.SceneManagement;

//public class Menuwin : MonoBehaviour
//{
//    [SerializeField] private GameObject menuWin;

    
//    private Meincharacte winer;

//    private void Start()
//    {
//        winer = GameObject.FindGameObjectWithTag("Player").GetComponent<Meincharacte>();
//        winer.MuertePlayer += ActivarMenu;
//    }
    
//    private void ActivarMenu(object sender, EventArgs e)
//    {
//        winer.SetActive(true);


//    }
//    public void Reiniciar()
//    {
//        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
//    }

//    public void MenuInicial(string win)
//    {
//        SceneManager.LoadScene(win);
//    }
//    public void salir()
//    {
//        //UnityEditor.EditorApplication.isPlaying = false;
//        Application.Quit();
//    }



//}
