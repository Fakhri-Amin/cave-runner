using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverUI;
    [SerializeField] AudioSource gameAudio;

    // Start is called before the first frame update
    void Start()
    {
        if (!gameOverUI) return;
        gameOverUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
        gameAudio.GetComponent<AudioSource>().enabled = false;
        Time.timeScale = 0;
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void MenuGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void RetryGame()
    {
        Time.timeScale = 1;
        FindObjectOfType<DistanceDisplay>().distanceScore = 0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
