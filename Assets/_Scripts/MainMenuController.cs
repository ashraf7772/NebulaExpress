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

    // Called by the "Start" button
    public void ButtonHandlerPlay()
    {
        StartCoroutine(LoadGameScene());
    }

    // Called by the "Story Mode" button
    public void ButtonHandlerStoryMode()
    {
        StartCoroutine(LoadStoryModeScene());
    }

    IEnumerator LoadGameScene()
    {
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        AsyncOperation operation = SceneManager.LoadSceneAsync(1); // By build index
        while (!operation.isDone)
        {
            yield return null;
        }
    }

    IEnumerator LoadStoryModeScene()
    {
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        AsyncOperation operation = SceneManager.LoadSceneAsync("StoryModeMenu"); // By name
        while (!operation.isDone)
        {
            yield return null;
        }
    }
}
