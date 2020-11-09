using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int stars;
    public int Coins { get => stars; }

    private int currentHealth;
    public int CurrentHealth { get => currentHealth; }

    public int maxHealth = 5;
    public float damageCooldown = 1f;

    private bool canTakeDamage = true;

    public PlayerDataUI playerDataUI;
    public PlayerController controller;

    public AudioClip damageSfx, dieSfx;

    private void Start()
    {
        if (playerDataUI == null)
            throw new MissingReferenceException("Referenciar o objeto PlayerDataUI na cena.");
        if (controller == null)
            throw new MissingReferenceException("Referenciar o script controller no Player.");

        currentHealth = maxHealth;
        SetHealthOnUI(currentHealth);
    }

    /// <summary>
    /// Increments the coins count
    /// </summary>
    /// <param name="amount">Amount of coins to increase the counter</param>
    /// <returns>Coins amount after the operation</returns>
    public int CollectCoin(int amount)
    {
        stars += amount;
        SetStarsOnUI(stars);
        return stars;
    }

    /// <summary>
    /// Deals with any amount of damage taken
    /// </summary>
    /// <param name="damage">Amount of damage to decrease from player's health</param>
    /// <returns>Player's health left</returns>
    public int TakeDamage(int damage)
    {
        if (canTakeDamage && currentHealth > 0)
        {
            currentHealth -= damage;
            canTakeDamage = false;
            StartCoroutine(CountDamageCooldown());

            if(damageSfx != null)
                SoundManager.instance.PlaySound(damageSfx);

            if(currentHealth <= 0)
            {
                currentHealth = 0;
                controller.Die();

                if (dieSfx != null)
                    SoundManager.instance.PlaySound(dieSfx);
            }
            SetHealthOnUI(currentHealth);
        }
        return currentHealth;
    }

    /// <summary>
    /// Sets current stars value to UI
    /// </summary>
    /// <param name="amount">Value to be set on UI</param>
    public void SetStarsOnUI(int amount)
    {
        if (playerDataUI != null)
            playerDataUI.SetStars(amount);
    }

    /// <summary>
    /// Sets current health value to UI
    /// </summary>
    /// <param name="health">Value to be set on UI</param>
    public void SetHealthOnUI(int health)
    {
        if (playerDataUI != null)
            playerDataUI.SetHealth(health);
    }

    /// <summary>
    /// Waits for [damageCooldown] seconds before enabling the [canTakeDamage]
    /// </summary>    
    private IEnumerator CountDamageCooldown()
    {
        yield return new WaitForSeconds(damageCooldown);
        canTakeDamage = true;
    }
}
