using TMPro;
using UnityEngine;

public class PlayerDataUI : MonoBehaviour
{
    public TextMeshProUGUI starsTxt, healthTxt;

    public void SetStars(int stars)
    {
        starsTxt.text = stars < 10 ? ("0" + stars.ToString()) : stars.ToString();
    }

    public void SetHealth(int health)
    {
        healthTxt.text = health < 10 ? ("0" + health.ToString()) : health.ToString();
    }
}
