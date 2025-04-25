using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TutorialPromptTrigger : MonoBehaviour
{
    public TextMeshProUGUI tutorialText;
    public string messageToShow = "Use arrowkeys to move and space to shoot. Go collect the cargo.";

    private void Start()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        // Change message based on level
        if (currentScene == "Level2")
        {
            messageToShow = "This is now Level 2. Collect all 6 Cargos to proceed to Level 3.";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerShip") && tutorialText != null)
        {
            tutorialText.text = messageToShow;
            tutorialText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerShip") && tutorialText != null)
        {
            tutorialText.gameObject.SetActive(false);
        }
    }
}