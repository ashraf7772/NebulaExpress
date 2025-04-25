using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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
        if (cargoMessageText != null)
            cargoMessageText.gameObject.SetActive(false);
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

            // Add to score
            if (ScoreManager_StoryMode.Instance != null)
                ScoreManager_StoryMode.Instance.AddScore(100);

            // Only load next level if not in Level2
            if (SceneManager.GetActiveScene().name != "Level2")
            {
                StartCoroutine(LoadNextLevelAfterDelay(2f));
            }
        }
    }

    private IEnumerator HideMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (cargoMessageText != null)
            cargoMessageText.gameObject.SetActive(false);
    }

    private IEnumerator LoadNextLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("Level2");
    }
}
