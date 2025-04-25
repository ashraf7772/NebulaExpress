using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(AudioSource), typeof(Collider))]
public class CargoCollector_StoryMode : MonoBehaviour
{
    public GameObject cargoVisibility;
    public TMP_Text cargoMessageText;
    [SerializeField] private string playerShipTag = "PlayerShip";
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (cargoMessageText != null) cargoMessageText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerShipTag))
        {
            if (cargoVisibility != null)
            {
                var meshRenderer = cargoVisibility.GetComponent<MeshRenderer>();
                if (meshRenderer != null) meshRenderer.enabled = false;
            }

            if (cargoMessageText != null)
            {
                cargoMessageText.gameObject.SetActive(true);
                cargoMessageText.text = "Cargo Collected!";
                StartCoroutine(HideMessageAfterDelay(3f));
            }

            if (audioSource != null) audioSource.Play();

            // ADD TO SCORE
            if (ScoreManager_StoryMode.Instance != null)
                ScoreManager_StoryMode.Instance.AddScore(100);
        }
    }

    private System.Collections.IEnumerator HideMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (cargoMessageText != null) cargoMessageText.gameObject.SetActive(false);
    }
}
