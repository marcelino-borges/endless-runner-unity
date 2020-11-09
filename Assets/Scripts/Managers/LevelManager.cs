using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Player player;
    public static LevelManager instance;
    public bool isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        instance = this;

        if (player == null)
            throw new MissingReferenceException("Referenciar player em cena.");
    }

    public void GameOver()
    {
        GameOverPanel.instance.ShowPanel();
        isGameOver = true;
    }
}
