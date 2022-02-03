using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    [Range(0, 1)] [SerializeField] private float scrollingSpeed;
    [SerializeField] private float startPos;
    [SerializeField] private float endPos;
    private ObstacleSpawner os;

    // Start is called before the first frame update
    void Start()
    {
        os = FindObjectOfType<ObstacleSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * os.currentSpeed * scrollingSpeed * Time.deltaTime);
        if (transform.position.x < endPos)
        {
            transform.position = new Vector2(startPos, transform.position.y);
        }
    }
}
