using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class StoryCutsceneController : MonoBehaviour
{
    public Text dialogueText;
    public Transform cameraTransform;
    public Transform cameraTarget;
    public GameObject ship;
    public string gameSceneName = "Level1";
    //public AudioSource launchSound;


    public Cinemachine.CinemachineVirtualCamera cutsceneCam;

    void OnEnable()
    {
        if (cutsceneCam != null)
        {
            cutsceneCam.gameObject.SetActive(true);
            Camera.main.clearFlags = CameraClearFlags.Skybox;
            ship.SetActive(true);
        }
            

        StartCoroutine(PlayCutscene());
    }

    IEnumerator PlayCutscene()
    {
        dialogueText.text = "In a galaxy fractured by rival factions...";
        dialogueText.color = new Color(1, 1, 1, 0);
        dialogueText.DOFade(1f, 1f);
        yield return new WaitForSeconds(3f);

        dialogueText.text = "You are the newest pilot of Nebula Express.";
        dialogueText.color = new Color(1, 1, 1, 0);
        dialogueText.DOFade(1f, 1f);
        yield return new WaitForSeconds(3f);

        //launchSound.Play(); // make sure this is assigned in the Inspector
        ship.transform.DOMoveZ(100f, 3f).SetEase(Ease.InOutSine);
        yield return new WaitForSeconds(3f);

        // Fade out or load next scene
        dialogueText.DOFade(0f, 1f);
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene("Level1");
    }
}
