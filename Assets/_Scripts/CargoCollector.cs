using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(AudioSource), typeof(Collider))]
public class CargoCollector : MonoBehaviour
{
    // 
    public GameObject cargoVisibility;
    // 
    public TMP_Text cargoMessageText;
    // 
    [SerializeField] private string playerShipTag = "PlayerShip";
    
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // 
        if (cargoMessageText != null)
        {
            cargoMessageText.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // 
        if (other.CompareTag(playerShipTag))
        {
            // 
            if (cargoVisibility != null)
            {
                MeshRenderer meshRenderer = cargoVisibility.GetComponent<MeshRenderer>();
                if (meshRenderer != null)
                {
                    meshRenderer.enabled = false;
                }
            }

            // 
            if (cargoMessageText != null)
            {
                cargoMessageText.gameObject.SetActive(true);
                cargoMessageText.text = "Cargo Collected!";
                StartCoroutine(HideMessageAfterDelay(3f));
            }

            // 
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
