using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public List<Obstacle> obstacles = new List<Obstacle>();
    public List<Star> stars = new List<Star>();

    public float minDistanceObstacles = 4f;
    public int maxObstaclesInPlatform = 1;

    private void Start()
    {
        AssembleAll();
    }

    public void AssembleAll()
    {
        AssembleObstacles();
    }

    private void AssembleStars()
    {

    }

    /// <summary>
    /// Assembles the obstacles in this platform
    /// </summary>
    private void AssembleObstacles()
    {
        foreach(Obstacle obstacle in obstacles)
        {
            bool activate = SortActivate();
            print(activate);
            obstacle.gameObject.SetActive(activate);
            if (obstacle.enabled)
            {
                Vector3 currentPosition = obstacle.gameObject.transform.position;
                obstacle.gameObject.transform.position.Set(SortXPosition(), currentPosition.y, currentPosition.z);
            }
        }
    }

    /// <summary>
    /// Sorts true-false
    /// </summary>
    private bool SortActivate()
    {
        return Random.Range(0, 2) == 1;
    }

    /// <summary>
    /// Sorts an index of the 2 possible positions in the street (left or right)
    /// </summary>
    private int SortXPosition()
    {
        return Random.Range(0, 1) == 0 ? -1 : 1;
    }
}
