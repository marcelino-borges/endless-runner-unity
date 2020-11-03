using System.Collections.Generic;
using UnityEngine;

public class PlatformsManager : MonoBehaviour
{
    public float platformOffset = 48f;
    public static PlatformsManager instance;
    public List<Transform> platforms = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }
}
