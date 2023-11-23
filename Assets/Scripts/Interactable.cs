using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script is for GameObjects that the player
 * will interact with.
 */


public class Interactable : MonoBehaviour
{
    public GameObject textPanel; // skapar en textPanel som "Funkar"-texten finns i 


    // This method is called when PlayerInteract tries to interact with this object
    public void OnInteraction()
    {
        textPanel.SetActive(true); // s�tt p� textPanel

        Invoke(nameof(DisableText), 2); // vill ha en string som input och en float.
                                        // nameof = trodde man kan �ndra namn p� Metoden man Invokar och den �ndras h�r med (..not..) 2 = 2s
                                        // Sammantaget: Jag vill k�ra metoden DisableText efter 2 s
    }


    private void DisableText() // metoden st�nger av textPanel
    {
        textPanel.SetActive(false); 
    }


}



