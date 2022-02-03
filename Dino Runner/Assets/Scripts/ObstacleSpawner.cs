using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> obstacles;
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;
    public float speedMultiplier;
    public float currentSpeed;

    [SerializeField] private float minRandomNum;
    [SerializeField] private float maxRandomNum;
    private DistanceDisplay distanceDisplay;
    private int amount;

    private void Awake()
    {
        distanceDisplay = FindObjectOfType<DistanceDisplay>();
    }

    private void Start()
    {
        amount = obstacles.Count - 6;
        currentSpeed = minSpeed;
        Invoke(nameof(SpawnObstacle), 1f);
    }

    public void SpawnObstacle()
    {
        Invoke(nameof(Spawn), Random.Range(minRandomNum, maxRandomNum));
    }

    private void Spawn()
    {
        int randomObstacle = Random.Range(0, amount);
        Instantiate(obstacles[randomObstacle], transform.position, Quaternion.identity);
    }

    private void Update()
    {
        if (currentSpeed < maxSpeed)
        {
            currentSpeed += speedMultiplier * Time.deltaTime;

            // if (currentSpeed > 4 / 5f * maxSpeed)
            // {
            //     maxRandomNum = 0.3f;
            // }
        }

        // if (currentSpeed > 4 / 5 * maxSpeed)
        // {
        //     maxRandomNum = 0.5f;
        // }

        switch (distanceDisplay.distanceScore)
        {
            case 100:
                amount = obstacles.Count - 5;
                break;
            case 200:
                amount = obstacles.Count - 4;
                break;
            case 300:
                amount = obstacles.Count - 2;
                break;
            case 400:
                amount = obstacles.Count - 1;
                break;
            case 500:
                amount = obstacles.Count;
                break;
            default:
                break;
        }
    }

    void AddObstacle(GameObject obstacle)
    {
        obstacles.Add(obstacle);
    }
}
