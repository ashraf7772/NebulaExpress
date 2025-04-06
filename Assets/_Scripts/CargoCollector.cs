using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CargoCollector : MonoBehaviour
{
    // Reference to the visual sphere representing cargo
    public GameObject cargoVisibility;

    // Reference to the TextMeshPro object for the on-screen message
    public TMP_Text cargoMessageText;

    // The tag on your player ship. Adjust as needed.
    [SerializeField] private string playerShipTag = "PlayerShip";

    private void Start()
    {
        // Make sure the cargo message is disabled at the start
        if (cargoMessageText != null)
        {
            cargoMessageText.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the player ship
        if (other.CompareTag(playerShipTag))
        {
            // Disable the cargo visibility sphere
            if (cargoVisibility != null)
            {
                cargoVisibility.SetActive(false);
            }

            // Enable and update the TextMeshPro message
            if (cargoMessageText != null)
            {
                cargoMessageText.gameObject.SetActive(true);
                cargoMessageText.text = "Cargo Collected!";

                // Hide the message again after 3 seconds
                StartCoroutine(HideMessageAfterDelay(3f));
            }
        }
    }

    private IEnumerator HideMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (cargoMessageText != null)
        {
            cargoMessageText.gameObject.SetActive(false);
        }
    }
}
