using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    // Starting time in seconds (15 seconds for your level)
    public float timeRemaining = 15f;
    
    // Reference to the Text component that will display the timer
    private Text timerText;

    void Start()
    {
        // Get the Text component attached to this GameObject
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
            // Decrease timeRemaining by the elapsed time since last frame
            timeRemaining -= Time.deltaTime;
            UpdateTimerDisplay();
        }
        else
        {
            // Clamp timeRemaining to 0 and update the display
            timeRemaining = 0;
            UpdateTimerDisplay();
            
            // Time is up – load the main menu scene.
            // Make sure the scene name "Menu" matches the actual scene name in your Build Settings.
            SceneManager.LoadScene("Menu");
        }
    }

    // Update the timer display to show whole seconds
    void UpdateTimerDisplay()
    {
        if (timerText != null)
        {
            timerText.text = Mathf.CeilToInt(timeRemaining).ToString();
        }
    }
}
