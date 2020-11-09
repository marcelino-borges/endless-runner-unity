using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTip : MonoBehaviour
{
    public GameObject tipPanel;

    private void Start()
    {
        tipPanel.SetActive(true);
    }

    public void CloseTip()
    {
        tipPanel.SetActive(false);
    }
}
