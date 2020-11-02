using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerDataUI : MonoBehaviour
{
    public TextMeshProUGUI starsTxt, healthTxt;

    public void SetStars(int stars)
    {
        starsTxt.text = stars.ToString();
    }

    public void SetHealth(int health)
    {
        healthTxt.text = health.ToString();
    }
}
