using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private SoundManager soundManager;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreGameOver;
    public TextMeshProUGUI highScoreTextGO;
    public TextMeshProUGUI highScoreTextT;

    public GameObject player;
    public GameObject titleScreen;
    public GameObject spawnManager;
    public GameObject gameOverScreen;

    public float timeRemaining;
    public bool isGameActive;
    public int score;

    void Start()
    {
        highScoreTextT.text = "High Score:     " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        soundManager = GameObject.Find("Sound Manager").GetComponent<SoundManager>();
    }


    void Update()
    {

        Timer();
        BackToMenu();
        RestartGame();
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
    public void GameOver()
    {
        
        gameOverScreen.SetActive(true);
        if(score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
        highScoreTextGO.text = "High Score:     " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        scoreGameOver.text = "Your Score:     " + score;

        isGameActive = false;
    }
    private void Timer()
    {
        if (isGameActive)
        {
            if(timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                if (score > PlayerPrefs.GetInt("HighScore", 0))
                {
                    soundManager.OnHighScore();
                }
                else
                {
                    soundManager.OnTimeEnd();
                }
                GameOver();
                
            }
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format($"Time: {seconds}");
    }
    void BackToMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    public void StartGame()
    {
        isGameActive = true;
        score = 0;
        timeRemaining = 60;
        AddScore(0);
        DisplayTime(60);

        titleScreen.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
        timeText.gameObject.SetActive(true);
        spawnManager.SetActive(true);
    }
    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        highScoreTextT.text = "High Score:     0";
        highScoreTextGO.text = "High Score:     0";
    }
    void RestartGame()
    {
        if(Input.GetKeyDown(KeyCode.R) && isGameActive == false)
        {
            isGameActive = true;
            score = 0;
            timeRemaining = 60;
            AddScore(0);
            DisplayTime(60);
            gameOverScreen.SetActive(false);
            player.SetActive(true);
            player.transform.position = new Vector3(0, 1, -8);
        }
        
    }
}
