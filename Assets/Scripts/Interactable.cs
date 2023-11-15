using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script is for GameObjects that the player
 * will interact with.
 */


public class Interactable : MonoBehaviour
{
    public GameObject textPanel;


    // This method is called when PlayerInteract tries to interact with this object
    public void OnInteraction()
    {
        textPanel.SetActive(true);

        Invoke(nameof(DisableText), 2); // vill ha en string som pinput och en float, nameof = att man kan ändra namn på Metoden man Invokar och den ändras här med. 2 = 2s
    }


    private void DisableText()
    {
        textPanel.SetActive(false); 
    }


}



