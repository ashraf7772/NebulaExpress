using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager_StoryMode : MonoBehaviour
{
    public GameObject pauseMenuUI;

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        pauseMenuUI.SetActive(isPaused);
        Time.timeScale = isPaused ? 0f : 1f;

        Cursor.visible = isPaused;
        Cursor.lockState = isPaused ? CursorLockMode.None : CursorLockMode.Locked;
    }

    public void ResumeGame()
    {
        isPaused = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void QuitToMainMenu()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("StoryModeMenu");
    }

    public void SaveGame()
    {
        ScoreManager_StoryMode.Instance.SaveScore(); 
    }

    public void ResetSave()
    {
    PlayerPrefs.DeleteKey("Story_Score");
    PlayerPrefs.Save();
    }
}
