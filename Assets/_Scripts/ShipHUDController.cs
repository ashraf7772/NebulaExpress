using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShipHUDController : MonoBehaviour
{
    public TextMeshProUGUI timeText; // The UI text component
    private float elapsedTime = 0f;

    void Update()
    {
        elapsedTime += Time.deltaTime; // Track playtime
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds); // Display as MM:SS
    }
}

