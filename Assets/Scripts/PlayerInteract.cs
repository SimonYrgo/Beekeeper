using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) // OM jag trycker "I" gör detta:
        {
            RaycastHit hitInfo = new RaycastHit(); // skapar en ny RayCastHit som man kan lagra info om det RayCasten träffar i. 

            bool hit = Physics.Raycast(transform.position, transform.forward, out hitInfo, 5f); // Skapar bool som skjuter en Raycast och kollar: träffar jag något? > 
                                                                                                // > transform.position, transform.forward = ta reda på detta från objektet jag träffar, eller skjut härifrån i denna riktning? >
                                                                                                // > lagra info om det jag träffar i hitInfo
                                                                                                // > skjut RayCast-strålen 5f lång

            Debug.DrawRay(transform.position, transform.forward, Color.red, 1); // gör en Debug Raycast (man hinner se om man är snabb? )

            if (hit) // om hit-bool = true (dvs RayCasten träffar ngt), gör detta:
            {
                Interactable interactable; // skapa koppling till scriptet Interactable och lagra i variabeln interactable

                hitInfo.transform.TryGetComponent<Interactable>(out interactable); // ta objekt lagrat i hitInfo och kplla om den ett Interactable script på sig. Sätt detta gameObject = interactable variabeln
                                                                                   // detta fyller interactable variabeln med ngt, och är som "new"-factoryn eller att dra till slot? 

                if (interactable != null) // om INTE interactable = null, dvs ngt FINNS lagrat i interactable:
                {
                    interactable.OnInteraction(); // kör denna metoden i Interactable scriptet
                }
                else
                {
                    Debug.Log("Not interactable");
                }
            }
        }
    }
}