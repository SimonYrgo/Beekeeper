using System.Collections;
using System.Collections.Generic;
// using System.Diagnostics;
using UnityEngine;
using TMPro;

/*
 *  Fixa Invoke metod s� man bara kan puffa r�k i en sekund och sen st�nga av Wind. Ex p� Invoke finns i Interactable scriptet. 
 *  // canDropSmoker = true;   // se l�ngst ner just nu, denna ska inte bli sann �nnu var ska vi l�gga den? 
 */





public class Smoker : MonoBehaviour
{

    public TMP_Text messageBoard; // Skapar slot f�r att kunna skriva meddelanden i Game Message TMP-Textobjektet

    public ParticleSystem smokeParticleSystem; 


    bool pickUpAble;

    bool grabbed;

    bool smokerLighted;

    // bool canDropSmoker; ska anv�ndas senare

    bool smokerDropped;


    RemoveLid isLidDropped;

    



    public Transform grabbingPointTransform; // ser om jag kan l�gga ett gameobjekt h�r i, som jag kan sno en Transform fr�n sen

    public GameObject smoker; // skapar slot f�r smoker f�r att kunna manipulera dess tranform sen

    public WindZone windSmoke;

    private Rigidbody smokerRb; // m�ste skapa en Rigidbody-variabel f�r att kunna h�nvisa till smoker Rigidbody

    private Collider smokerCollider;



    void Start()
    {
        isLidDropped = GameObject.FindObjectOfType<RemoveLid>();

        pickUpAble = false;

        grabbed = false;

        smokerLighted = false;

        // canDropSmoker = false; ska anv�ndas senare

        smokerDropped = false;

        smokerRb = smoker.GetComponent<Rigidbody>(); // h�mtar Rigidbodyn fr�n GameObjectet i sloten smoker

        smokerCollider = smoker.GetComponent<Collider>();

        smokeParticleSystem = smokeParticleSystem.GetComponent<ParticleSystem>(); // m�ste man g�ra det? kanske .. 

        smokeParticleSystem.Stop();

        windSmoke.windMain = 1; // S�tter Vinden till O  

       



}


    private void OnTriggerEnter(Collider player) // verkar referera till Objektet som g�r in i triggern via dess collider 
    {

        // if-sats som kollar taggen p� objektet, vars collider gick i i triggern mfl villkor

        if (player.tag == "Player" && !smokerDropped && isLidDropped.lidDropped) // Om Player g�r in h�r -- OCH smoker inte �r Dropped -- OCH lid �r dropped (man ska inte kunna plocka upp smoker innan lid) 
        {

            //messageBoard.gameObject.SetActive(true);

            messageBoard.text = "To pick up smoker press P";

            pickUpAble = true;




        }

        
    }

    private void Update()
    {
        if (pickUpAble) // om man kan plocka upp smoker >
        {
            if (Input.GetKeyDown(KeyCode.P)) //  > Trycker man P? 
            {

                grabbed = true;              //  > s�tt grabbed till True


            }
        }

        if (grabbed) // > s�tt is� fall grabbed till trur och flytta p� smokers position 
        {
            //smokerRb.MovePosition(grabbingPointTransform.position); // min kod k�r Carls nedan ist�llet. 
            //smokerRb.MoveRotation(grabbingPointTransform.rotation);
            // smokerRb.useGravity = false;


            smokerRb.transform.position = grabbingPointTransform.position;   // samma som min kod tror jag 
            smokerRb.transform.rotation = grabbingPointTransform.rotation;   // samma som min kod tror jag 
            smoker.transform.parent = grabbingPointTransform;                // S�tter boxLid som child till parent, varf�r vet jag inte riktigt �n varf�r det skulle vara bra
            smokerRb.isKinematic = true;                                     // S�tter boxlid till Kinematic = den har ingen graivty och kan inte flyttas av collisions
            smokerCollider.isTrigger = true;                                 // F�rutom att g�ra till en Trigger -  har ingen fysik och kan inte flytta saker? = om jag har den h�r p� smokerscriptet s� kommer den inet att flytta p� mig. 


            if (Input.GetKeyDown(KeyCode.L))                                // Drar ig�ng smokeParticleSystem och s�tter boolen smokerLighted till true
            {

                smokeParticleSystem.Play();                                  
                smokerLighted = true;
                messageBoard.text = "Smoker lighted, go give bees smoke. To Puff Smoke press P";


            }








            /*

            if (Input.GetKeyDown(KeyCode.E) && canDropSmoker) // funktion f�r att sl�ppa smoker p� marken n�r man g�tt ur TriggerCollidern vid kupan. Detta ska inte h�nda �nnu s� koden �r utkommenterad. 
            {
                grabbed = false;

                smoker.transform.parent = null;                
                smokerRb.isKinematic = false;                                    
                smokerCollider.isTrigger = false;

                messageBoard.text = "Smoker Dropped ";

                canDropSmoker = false;

                pickUpAble = false; 

                smokerDropped = true; 
            }
            */

        }


    }


    private void OnTriggerExit(Collider player) // H�r m�ste vi �ndra i kedjan f�r vad som ska h�nda
    {

        if (player.tag == "Player")
        {


            // canDropSmoker = true;   // denna ska inte bli sann �nnu var ska vi l�gga den? 




            if (grabbed)
            {
                messageBoard.text = "To l�ght Smoker press L";


                

            }



        }

    }


}

