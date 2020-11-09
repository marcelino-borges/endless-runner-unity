using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    public static GameOverPanel instance;
    private const int MAIN_MENU_INDEX = 0;
    public GameObject gameOverPanel;

    private void Start()
    {
        instance = this;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(MAIN_MENU_INDEX);
        SoundManager.instance.PlaySound(SoundManager.instance.buttonClickSfx);
    }

    public void ShowPanel()
    {
        StartCoroutine(ShowPanelCo());
    }

    private IEnumerator ShowPanelCo()
    {
        yield return new WaitForSeconds(2f);
        gameOverPanel.SetActive(true);
    }
}
