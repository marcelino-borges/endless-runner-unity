using UnityEngine;

public class Star : MonoBehaviour
{
    public int value = 1;
    public GameObject collectParticles;
    public float rotationSpeed = 100f;
    public float verticalAnimDeslocation = .5f;
    public AudioClip sfxCollect;

    private void Update()
    {
        //Rotates the star along the Y axis during the time
        transform.GetChild(0).Rotate(0, 0, Time.deltaTime * rotationSpeed);        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other != null)
        {
            if(other.CompareTag("Player"))
            {
                Player player = other.gameObject.GetComponent<Player>();
                
                //Adds this star value to player bag
                player.CollectCoin(value);

                //Spawns particles when the star is collected
                if (collectParticles != null)
                {
                    GameObject particles = Instantiate(collectParticles, transform.position, Quaternion.identity);
                    Destroy(particles, .5f);
                }

                //Plays collect sfx
                if(sfxCollect != null)
                    SoundManager.instance.PlaySound(sfxCollect);

                gameObject.SetActive(false);
            }
        }
    }
}
