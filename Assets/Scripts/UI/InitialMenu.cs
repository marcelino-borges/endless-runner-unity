using UnityEngine;
using UnityEngine.SceneManagement;

public class InitialMenu : MonoBehaviour
{
    private const string LEVEL1_NAME = "MainLevel";

    public void StartGame()
    {
        SceneManager.LoadScene(LEVEL1_NAME);
        PlayButtonClick();
    }

    public void QuitGame() 
    {
        Application.Quit();
        PlayButtonClick();
    }

    public void PlayButtonClick()
    {
        SoundManager.instance.PlaySound(SoundManager.instance.buttonClickSfx);
    }
}
