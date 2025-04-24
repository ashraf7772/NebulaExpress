using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryMenuController : MonoBehaviour
{
    public GameObject cutsceneController; // Drag the CutsceneController object here
    public GameObject menuUI; 

    public void OnNewGamePressed()
    {
        // Activate the cutscene when New Game is clicked
        Debug.Log("New Game pressed!");
        menuUI.SetActive(false); 
        cutsceneController.SetActive(true);
    }

    public void OnLoadGamePressed()
    {
        // Add load logic here later
        Debug.Log("Load Game pressed (functionality coming soon)");
    }
}
