using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int damage = 1;
    public GameObject hitParticles;

    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            if (other.CompareTag("Player"))
            {
                Player player = other.gameObject.GetComponent<Player>();
                player.TakeDamage(damage);

                if (hitParticles != null)
                    Instantiate(hitParticles);

                Destroy(gameObject);
            }
        }
    }
}
