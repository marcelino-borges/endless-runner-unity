using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitialMenu : MonoBehaviour
{
    private const int LEVEL1_INDEX = 1;

    public void StartGame()
    {
        SceneManager.LoadScene(LEVEL1_INDEX);
    }

    public void QuitGame() 
    {
        Application.Quit();
    }
}
