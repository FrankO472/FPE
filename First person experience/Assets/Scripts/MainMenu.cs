using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    void Start ()
    {
       main.enabled = true;
       options.enabled = false;
    }


    public Canvas main;
    public Canvas options;

    public void OnPlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OnOptions()
    {
        main.enabled = false;
        options.enabled = true;
    }

    public void OnExit()
    {
       Application.Quit();
    }

    public void OnBackToMain()
    {
      main.enabled = true;
      options.enabled = false;
    }

   
}
