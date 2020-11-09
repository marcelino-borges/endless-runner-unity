using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [Header("Placeholders")]
    public List<Transform> obstaclesPlaceHolders = new List<Transform>();
    public List<Transform> starsPlaceHolders = new List<Transform>();
    [Header("Prefabs Referencing")]
    public List<GameObject> obstaclesPrefabs = new List<GameObject>();
    public GameObject starPrefab;
    [Header("Objects instantiated")]
    public List<GameObject> obstaclesInstantiated = new List<GameObject>();
    public List<GameObject> starsInstantiated = new List<GameObject>();

    private void Start()
    {
        InstantiateAll();
        AssembleAll();
    }

    public void InstantiateAll()
    {
        InstantiateObstacles();
        InstantiateStars();
    }

    /// <summary>
    /// Instantiates all obstacles in the current platform
    /// </summary>
    private void InstantiateObstacles()
    {
        foreach (Transform obstacle in obstaclesPlaceHolders)
        {
            GameObject newObstacle = Instantiate(SortPrefab(obstaclesPrefabs), obstacle.position, Quaternion.identity, transform.Find("Obstacles"));
            obstaclesInstantiated.Add(newObstacle);
        }
    }

    /// <summary>
    /// Instantiates all stars in the current platform
    /// </summary>
    private void InstantiateStars()
    {
        foreach (Transform star in starsPlaceHolders)
        {
            GameObject newStar = Instantiate(starPrefab, star.position, Quaternion.identity, transform.Find("Stars"));
            starsInstantiated.Add(newStar);
        }
    }

    /// <summary>
    /// Assembles all obstacles and stars in this platform
    /// </summary>
    public void AssembleAll()
    {
        AssembleObstacles();
        AssembleStars();
    }

    /// <summary>
    /// Assembles all stars in thsi platform
    /// </summary>
    private void AssembleStars()
    {
        foreach (GameObject star in starsInstantiated)
        {
            star.SetActive(SortActivate());

            if (star.activeSelf)
            {
                Vector3 currentPosition = star.transform.position;
                //Obstacles can be placed on position.x equals -1, 0 or 1
                star.transform.position = new Vector3(Sort(-1, 1), currentPosition.y, currentPosition.z);
            }
        }
    }

    /// <summary>
    /// Assembles the obstacles in this platform
    /// </summary>
    private void AssembleObstacles()
    {
        foreach(GameObject obstacle in obstaclesInstantiated)
        {
            obstacle.SetActive(SortActivate());

            if (obstacle.activeSelf)
            {
                Vector3 currentPosition = obstacle.transform.position;
                //Obstacles can be placed only on position.x equals -1 or 1
                obstacle.transform.position = new Vector3(Sort(0, 1) == 0f ? -1f : 1f, currentPosition.y, currentPosition.z);
            }
        }
    }

    /// <summary>
    /// Sorts true-false
    /// </summary>
    private bool SortActivate()
    {
        return Sort(0, 1) == 1;
    }
    
    /// <summary>
    /// Sorts between the min and max parameters (compensating the original Random.Range [max] excludent parameter)
    /// </summary>
    private float Sort(int min, int max)
    {
        return Random.Range(min, max + 1);
    }

    /// <summary>
    /// Sorts a random element in an array of prefabs
    /// </summary>
    private GameObject SortPrefab(List<GameObject> prefabs)
    {
        int sortedIndex = Random.Range(0, prefabs.Count);
        return prefabs[sortedIndex];
    }
}
