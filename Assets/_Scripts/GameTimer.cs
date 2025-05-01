using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    // Starting time in seconds (15 seconds)
    public float timeRemaining = 15f;
    
    // Reference to the Text component that will display the timer
    private Text timerText;

    void Start()
    {
        // Get Text component attached to GameObject
        timerText = GetComponent<Text>();
        if (timerText == null)
        {
            Debug.LogError("TimerText component not found on this GameObject.");
        }
        UpdateTimerDisplay();
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            // 
            timeRemaining -= Time.deltaTime;
            UpdateTimerDisplay();
        }
        else
        {
            // 
            timeRemaining = 0;
            UpdateTimerDisplay();
            
            // 
            // Ma
            SceneManager.LoadScene("Menu");
        }
    }

    // 
    void UpdateTimerDisplay()
    {
        if (timerText != null)
        {
            timerText.text = Mathf.CeilToInt(timeRemaining).ToString();
        }
    }
}
