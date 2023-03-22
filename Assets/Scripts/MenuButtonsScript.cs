using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonsScript : MonoBehaviour
{
    public void GoPlay()
    {
        SceneManager.LoadScene(2);
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene(0); 
    }

    public void GoToAbout()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToExit()
    {
        SceneManager.LoadScene(-1);
    }
}
