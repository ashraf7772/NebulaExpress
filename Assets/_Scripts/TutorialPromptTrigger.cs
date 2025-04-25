using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialPromptTrigger : MonoBehaviour
{
    public TextMeshProUGUI tutorialText;
    public string messageToShow = "Use arrowkeys to move and space to shoot. Go collect the cargo.";

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
