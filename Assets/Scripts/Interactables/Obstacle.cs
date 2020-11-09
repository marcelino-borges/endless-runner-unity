using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int damage = 1;
    public GameObject puffParticles;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            if (other.CompareTag("Player"))
            {
                Player player = other.gameObject.GetComponent<Player>();

                //Counts the damage of this obstacle to the player
                player.TakeDamage(damage);

                //Spawns particles for the damage
                if (puffParticles != null)
                    Instantiate(puffParticles, gameObject.transform.position, Quaternion.identity);
            }
        }
    }
}
