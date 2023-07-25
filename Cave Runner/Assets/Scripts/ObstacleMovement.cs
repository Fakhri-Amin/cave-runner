using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    [SerializeField] float additionalSpeed;
    private ObstacleSpawner os;


    // Start is called before the first frame update
    void Start()
    {
        os = FindObjectOfType<ObstacleSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * (os.currentSpeed + additionalSpeed) * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("SpawnPoint"))
        {
            os.SpawnObstacle();
        }

        if (other.gameObject.CompareTag("DestroyPoint"))
        {
            Destroy(gameObject);
        }
    }
}
