using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SmokeBeesTakeHoneyBox : MonoBehaviour
{

    public TMP_Text messageBoard;

    public WindZone windSmoke;

    Smoker smoker; // skapar dold slot där det får plats ett Smoker objekt

    bool canSmokeBees;

    bool hasSmokedBees;

    
    void Start()
    {
        smoker = GameObject.FindObjectOfType<Smoker>(); // fyller dold slot med ett Smoker object

        canSmokeBees = false;

        hasSmokedBees = false;

        windSmoke.windMain = 0; // Sätter Vinden till O  

    }

    
    void Update()
    {
        if (canSmokeBees)
        {

            if (Input.GetKeyDown(KeyCode.P))
            {
                // Debug.Log("P nedtryckt");
                windSmoke.windMain = 1;
                Invoke(nameof(DisableWind), 1);
                hasSmokedBees = true;

            }

        }

    }

    
    private void DisableWind() // metoden stänger windSmoke efter 1s när man puffar rök 
    {
            windSmoke.windMain = 0;
    }

    


    private void OnTriggerEnter(Collider player) 

    {  

        if (player.tag == "Player" && smoker.smokerLighted)
        {
            canSmokeBees = true;

            //messageBoard.gameObject.SetActive(true);

            messageBoard.text = "To To Puff Smoke press P";

        }

    }


    private void OnTriggerExit(Collider player) // Här måste vi ändra i kedjan för vad som ska hända
    {

        if (player.tag == "Player")
        {

            canSmokeBees = false;
            
            if (hasSmokedBees)
            {
                smoker.canDropSmoker = true;

                messageBoard.text = "So far so good";
            }


        }

    }



}
