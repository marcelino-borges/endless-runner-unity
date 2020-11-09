using UnityEngine;

public class PlatformReachedEndDetection : MonoBehaviour
{
    public Platform parentPlatform;

    private void OnTriggerExit(Collider other)
    {
        if(other != null)
        {
            if(other.gameObject.CompareTag("Player"))
            {
                SetPlatformAsFirst();
                parentPlatform.AssembleAll();
            }
        }
    }

    /// <summary>
    /// Takes this platform and moves it to the front of the platforms line
    /// </summary>
    private void SetPlatformAsFirst()
    {
        int totalPlatformModels = PlatformsManager.instance.platforms.Count;
        float endPosition = parentPlatform.transform.position.z + PlatformsManager.instance.platformOffset * totalPlatformModels;
        parentPlatform.transform.position = new Vector3(parentPlatform.transform.position.x, parentPlatform.transform.position.y, endPosition);
    }
}
