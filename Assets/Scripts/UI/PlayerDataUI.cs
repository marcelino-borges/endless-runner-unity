using TMPro;
using UnityEngine;

public class PlayerDataUI : MonoBehaviour
{
    public TextMeshProUGUI starsTxt, healthTxt;

    /// <summary>
    /// Sets an amount of stars to the UI text field
    /// </summary>    
    public void SetStars(int stars)
    {
        starsTxt.text = stars < 10 ? ("0" + stars.ToString()) : stars.ToString();
    }

    /// <summary>
    /// Sets an amount of health to the UI text field
    /// </summary>
    public void SetHealth(int health)
    {
        healthTxt.text = health < 10 ? ("0" + health.ToString()) : health.ToString();
    }
}
