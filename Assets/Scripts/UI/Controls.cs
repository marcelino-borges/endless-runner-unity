using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public PlayerController player;
    private bool isShowingTip = true;
    private int movementDirection = 0;
    public GameObject buttonLeft, buttonRight;

    private void FixedUpdate()
    {
#if UNITY_ANDROID
        player.Move(movementDirection);
#endif

        if(Input.anyKeyDown)
        {
            StopTipAnimation();
        }
    }

    /// <summary>
    /// Each button on UI passes the direction parameter, which controls the player movement
    /// </summary>    
    public void ControlOnClick(int direction)
    {
        movementDirection = direction;
        player.Run();

        if(isShowingTip)
            StopTipAnimation();
    }

    /// <summary>
    /// Stops the animation of the tip with the hands showing how to play
    /// </summary>
    private void StopTipAnimation()
    {
        GetComponent<Animator>().SetTrigger("stop");
        isShowingTip = false;
    }

    /// <summary>
    /// Deactivates the input buttons from UI
    /// </summary>
    public void DeactivateButtons()
    {
        buttonLeft.SetActive(false);
        buttonRight.SetActive(false);
    }
}
