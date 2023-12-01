using UnityEngine;
using UnityEngine.UI;

public class PositionLerp : MonoBehaviour
{
    public Transform startPosition; // Set start position from an empty object in the scene
    public Transform endPosition; // Set end position from an empty object in the scene
    public Slider speedSlider; // Reference the slider in the Unity Editor

    private float lerpDuration = 2f;
    private float currentLerpTime = 0f;
    private bool isLerping = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            // Toggle the lerping flag
            isLerping = !isLerping;

            // If lerping is started, initialize the lerp time and duration
            if (isLerping)
            {
                currentLerpTime = 0f;

                // Get the speed value from the slider
                float speed = speedSlider.value;

                // Calculate lerp duration based on speed
                lerpDuration = Vector3.Distance(startPosition.position, endPosition.position) / speed;
            }
        }

        // Check if lerping is active
        if (isLerping)
        {
            // Increment the lerp time based on the elapsed time since the last frame
            currentLerpTime += Time.deltaTime;

            // Ensure the lerp time doesn't exceed the specified duration
            if (currentLerpTime > lerpDuration)
            {
                currentLerpTime = 0f; // Reset lerp time for the next loop
            }

            // Calculate the interpolation factor between 0 and 1
            float t = currentLerpTime / lerpDuration;

            // Lerp the position between the start and end positions
            transform.position = Vector3.Lerp(startPosition.position, endPosition.position, t);
        }
    }
}