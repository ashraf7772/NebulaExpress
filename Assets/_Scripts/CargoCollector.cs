using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(AudioSource), typeof(Collider))]
public class CargoCollector : MonoBehaviour
{
    // The GameObject that contains the visible cargo (i.e., its MeshRenderer)
    public GameObject cargoVisibility;
    // The UI text element to display the message from the Canvas
    public TMP_Text cargoMessageText;
    // The tag that must match the player ship's tag
    [SerializeField] private string playerShipTag = "PlayerShip";
    
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Ensure the message is hidden at start
        if (cargoMessageText != null)
        {
            cargoMessageText.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player ship
        if (other.CompareTag(playerShipTag))
        {
            // Instead of disabling the entire GameObject, disable only its MeshRenderer
            if (cargoVisibility != null)
            {
                MeshRenderer meshRenderer = cargoVisibility.GetComponent<MeshRenderer>();
                if (meshRenderer != null)
                {
                    meshRenderer.enabled = false;
                }
            }

            // Display the cargo collected message
            if (cargoMessageText != null)
            {
                cargoMessageText.gameObject.SetActive(true);
                cargoMessageText.text = "Cargo Collected!";
                StartCoroutine(HideMessageAfterDelay(3f));
            }

            // Play the cargo collected audio clip
            if (audioSource != null)
            {
                audioSource.Play();
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
