using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Player player;
    public static LevelManager instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        if (player == null)
            throw new MissingReferenceException("Referenciar player em cena.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {

    }
}
