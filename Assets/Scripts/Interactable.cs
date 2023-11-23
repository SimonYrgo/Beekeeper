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
        textPanel.SetActive(true); // sätt på textPanel

        Invoke(nameof(DisableText), 2); // vill ha en string som input och en float.
                                        // nameof = trodde man kan ändra namn på Metoden man Invokar och den ändras här med (..not..) 2 = 2s
                                        // Sammantaget: Jag vill köra metoden DisableText efter 2 s
    }


    private void DisableText() // metoden stänger av textPanel
    {
        textPanel.SetActive(false); 
    }


}



