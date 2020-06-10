using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    float score = 0;
    float startTime = 10;
    float timeLeft;
    float bound = 30;
    int maxBombs = 10;
    int numBombs = 0;
    public bool isGameActive = false;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject titleScreen;
    [SerializeField] GameObject bombPrefab;
    [SerializeField] GameObject powerupPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive)
        {
            timeText.text = "Time: " + Mathf.Round(timeLeft);
            if (timeLeft < 0)
            {
                GameOver();
            }
            timeLeft -= Time.deltaTime;

        }
    }

    public void Powerup()
    {
        if (numBombs < maxBombs)
        {
            numBombs++;
            Instantiate(bombPrefab, RandomSpawnPos(), bombPrefab.transform.rotation);
        }
        Instantiate(powerupPrefab, RandomSpawnPos(), bombPrefab.transform.rotation);
        timeLeft = startTime;
        score++;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        isGameActive = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame()
    {
        isGameActive = true;
        score = -1;
        Powerup();
        titleScreen.SetActive(false);
    }

    Vector3 RandomSpawnPos()
    {
        float x = Random.Range(0, bound);
        float y = Random.Range(0, bound);
        float z = Random.Range(0, bound);
        return new Vector3(x, y, z);
    }
}
