using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DistanceDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text distanceText;
    [SerializeField] private TMP_Text highScoreText;
    public float distanceScore;
    private float highScore;

    // Start is called before the first frame update
    void Start()
    {
        distanceScore = 0;
        highScore = PlayerPrefs.GetFloat("HighScore", 0);
        highScoreText.text = "HI " + highScore.ToString("00000");
    }

    // Update is called once per frame
    void Update()
    {
        distanceScore = Mathf.FloorToInt(Time.timeSinceLevelLoad * 10);

        UpdateDistanceScore();
    }

    void UpdateDistanceScore()
    {
        distanceText.text = distanceScore.ToString("00000");
    }

    public void CheckHighScore()
    {
        if (distanceScore > highScore)
        {
            PlayerPrefs.SetFloat("HighScore", distanceScore);
            highScore = distanceScore;
            highScoreText.text = "HI " + highScore.ToString("00000");
        }
    }
}
