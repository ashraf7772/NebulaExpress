using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuController : MonoBehaviour
{
  private AudioSource audioSource;

  void Start()
{
    audioSource = GetComponent<AudioSource>();
}

    public void ButtonHandlerPlay()
    {
        StartCoroutine(LoadGameScene());
    }

    IEnumerator LoadGameScene()
    {
        audioSource.Play(); // Play the sound
        yield return new WaitForSeconds(audioSource.clip.length);
        AsyncOperation operation = SceneManager.LoadSceneAsync(1); // This loads scene by Build Index
        while (!operation.isDone)
        {
            yield return null; // This waits until the scene fully loads
        }
    }
}