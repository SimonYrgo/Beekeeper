using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) // OM jag trycker "I" g�r detta:
        {
            RaycastHit hitInfo = new RaycastHit(); // skapar en ny RayCastHit som man kan lagra info om det RayCasten tr�ffar i. 

            bool hit = Physics.Raycast(transform.position, transform.forward, out hitInfo, 5f); // Skapar bool som skjuter en Raycast och kollar: tr�ffar jag n�got? > 
                                                                                                // > transform.position, transform.forward = ta reda p� detta fr�n objektet jag tr�ffar, eller skjut h�rifr�n i denna riktning? >
                                                                                                // > lagra info om det jag tr�ffar i hitInfo
                                                                                                // > skjut RayCast-str�len 5f l�ng

            Debug.DrawRay(transform.position, transform.forward, Color.red, 1); // g�r en Debug Raycast (man hinner se om man �r snabb? )

            if (hit) // om hit-bool = true (dvs RayCasten tr�ffar ngt), g�r detta:
            {
                Interactable interactable; // skapa koppling till scriptet Interactable och lagra i variabeln interactable

                hitInfo.transform.TryGetComponent<Interactable>(out interactable); // ta objekt lagrat i hitInfo och kplla om den ett Interactable script p� sig. S�tt detta gameObject = interactable variabeln
                                                                                   // detta fyller interactable variabeln med ngt, och �r som "new"-factoryn eller att dra till slot? 

                if (interactable != null) // om INTE interactable = null, dvs ngt FINNS lagrat i interactable:
                {
                    interactable.OnInteraction(); // k�r denna metoden i Interactable scriptet
                }
                else
                {
                    Debug.Log("Not interactable");
                }
            }
        }
    }
}