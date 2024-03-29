using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public int highScore;
    public Text scoreText;
    public Text highScoreText;
    public GameObject gameOverScreen;
    public bool gameOver = true;
    
    public AudioSource[] sfx;
    private bool _audioPlayed;

    // Start is called before the first frame update
    void Start()
    {
        // Index 0 = ding, 1 = gameOver
        sfx = GetComponents<AudioSource>();
        
        highScore = PlayerPrefs.GetInt("highScore");
        highScoreText.text = $"Best: {highScore.ToString()}";
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else             
            Application.Quit();
#endif
        }
    }

    public void AddScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
        sfx[0].Play();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
    
    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        gameOver = false;
        gameOverScreen.SetActive(true);
        if (_audioPlayed) return;
        sfx[1].Play();
        _audioPlayed = true;

        if (playerScore <= highScore) return;
        highScore = playerScore;
        PlayerPrefs.SetInt("highScore", playerScore);
        highScoreText.text = $"Best: {highScore.ToString()}";
    }
}