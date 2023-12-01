using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.CompilerServices;

public class ToggleObject : MonoBehaviour
{

    public Slider slider;

    private float extractorSpeed;

    float previousSliderValue;



    private void Start()
    {
        previousSliderValue = slider.value;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // objectToToggle.SetActive(!objectToToggle.activeSelf) // - om det bara �r ett vanligt allm�nt gameobject kan man g�ra s� h�r..

            slider.gameObject.SetActive(!slider.gameObject.activeSelf); // ..men med en slider f�r man g�ra s� h�r = s�tt bool till motsats (om objektet p�, st�ng av - och tv�rtom)


        }

        // Debug.Log(slider.value);



        if (slider.value != previousSliderValue)
        {
            // Log the new value to the console
            Debug.Log("Slider value changed to: " + slider.value);

            // Update the previousSliderValue with the current value
            previousSliderValue = slider.value;
        }
    }

    public void ChangeSpeed (float speed)
    {
        

    }


}
