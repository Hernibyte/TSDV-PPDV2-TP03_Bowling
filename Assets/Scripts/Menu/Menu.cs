using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void PlayButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void newGamemodeButton()
    {
        SceneManager.LoadScene("Game02");
    }

    public void creditsButton()
    {
        SceneManager.LoadScene("Credits");
    }

    public void menuAccess()
    {
        SceneManager.LoadScene("Menu");
    }
}
