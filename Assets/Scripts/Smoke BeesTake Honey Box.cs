using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SmokeBeesTakeHoneyBox : MonoBehaviour
{

    public TMP_Text messageBoard;

    public WindZone windSmoke;

    Smoker smoker; // skapar dold slot där det får plats ett Smoker objekt

    BeeBehavoiur beeBehavoiur;

    bool canSmokeBees;

    bool hasSmokedBees;

    
    void Start()
    {
        smoker = GameObject.FindObjectOfType<Smoker>(); // fyller dold slot med ett Smoker object

        beeBehavoiur = GameObject.FindObjectOfType<BeeBehavoiur>();

        canSmokeBees = false;

        hasSmokedBees = false;

        windSmoke.windMain = 0; // Sätter Vinden till O  

    }

    
    void Update()
    {
        if (canSmokeBees) // Kollar om man trycker P för att smokea bina
        {

            if (Input.GetKeyDown(KeyCode.P))
            {
                // Debug.Log("P nedtryckt");
                windSmoke.windMain = 1;
                Invoke(nameof(DisableWind), 1);
                hasSmokedBees = true;
                beeBehavoiur.beesSmoked = true; // sätter boolen i BeeBehavoiurscriptet till true
                canSmokeBees = false;



            }

        }

        if (hasSmokedBees)
        {
            messageBoard.text = "The Bees seem calmer, now extinguish Smoker with C";

            if (Input.GetKeyDown(KeyCode.C))
            {
                smoker.smokeParticleSystem.Stop();
                smoker.smokerLighted = false; // kan kanske användas senare

                messageBoard.text = "Move Away To Drop Smoker";

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


    private void OnTriggerExit(Collider player) 
    {

        if (player.tag == "Player" && hasSmokedBees && !smoker.smokerLighted)
        {
            {   

                smoker.canDropSmoker = true;  // Skickar vidare till Smokerscriptet för att kunna droppa smokern

                Debug.Log("Så far så good " + smoker.canDropSmoker);


            }

        }

    }





}
