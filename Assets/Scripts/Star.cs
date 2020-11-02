using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public int value = 1;
    public GameObject collectParticles;

    private void OnTriggerEnter(Collider other)
    {
        if(other != null)
        {
            if(other.CompareTag("Player"))
            {
                Player player = other.gameObject.GetComponent<Player>();
                player.CollectCoin(value);

                if(collectParticles != null)
                    Instantiate(collectParticles);
                
                Destroy(gameObject);
            }
        }
    }
}
