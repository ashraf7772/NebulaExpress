using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager_StoryMode : MonoBehaviour
{
    public static ScoreManager_StoryMode Instance;
    public TextMeshProUGUI scoreText;

    private int score = 0;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("Story_Score"))
            LoadScore();  //Yo remind yourself, this loads the saved score when the scene starts

            string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "Level2")
        {
            score = 100; // Start with 100 for dev
            UpdateScoreUI();
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("Story_Score", score);
        PlayerPrefs.Save();
    }

    public void LoadScore()
    {
        score = PlayerPrefs.GetInt("Story_Score", 0);
        UpdateScoreUI();
    }
}
