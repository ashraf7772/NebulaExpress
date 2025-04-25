using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryMenuController : MonoBehaviour
{
    public GameObject cutsceneController;
    public GameObject menuUI;

    public void OnNewGamePressed()
    {
        Debug.Log("New Game pressed!");

        // Clear saved score
        PlayerPrefs.DeleteKey("Story_Score");
        PlayerPrefs.Save();

        menuUI.SetActive(false);
        cutsceneController.SetActive(true);
    }

    public void OnLoadGamePressed()
    {
        Debug.Log("Load Game pressed!");
        
        if (PlayerPrefs.HasKey("Story_Score"))
        {
            SceneManager.LoadScene("Level1");
        }
        else
        {
            Debug.LogWarning("No save found! Starting fresh or disable Load Game.");
            // Optionally show a message to the player here
        }
    }
}