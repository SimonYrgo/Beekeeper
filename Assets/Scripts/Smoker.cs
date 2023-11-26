using System.Collections;
using System.Collections.Generic;
// using System.Diagnostics;
using UnityEngine;
using TMPro;

/*
 *  Fixat TriggerCollider bara p� marken f�r smokern annars kan man ju aldrig g� ur den..
 * 
 */





public class Smoker : MonoBehaviour
{

    public TMP_Text messageBoard; // Skapar slot f�r att kunna skriva meddelanden i Game Message TMP-Textobjektet


    bool pickUpAble;

    bool grabbed;

    bool canDropSmoker;

    bool smokerDropped;


    RemoveLid isLidDropped;

    



    public Transform grabbingPointTransform; // ser om jag kan l�gga ett gameobjekt h�r i, som jag kan sno en Transform fr�n sen

    public GameObject smoker; // skapar slot f�r smoker f�r att kunna manipulera dess tranform sen

    private Rigidbody smokerRb; // m�ste skapa en Rigidbody-variabel f�r att kunna h�nvisa till smoker Rigidbody



    void Start()
    {
        isLidDropped = GameObject.FindObjectOfType<RemoveLid>();

        pickUpAble = false;

        grabbed = false;

        canDropSmoker = false;

        smokerDropped = false;

        smokerRb = smoker.GetComponent<Rigidbody>(); // h�mtar Rigidbodyn fr�n GameObjectet i sloten smoker

        
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
        if (pickUpAble)
        {
            if (Input.GetKeyDown(KeyCode.P)) // Varf�r detta funkar h�r och inte i OnTriggerEnter vet jag inte
            {

                grabbed = true;


            }
        }

        if (grabbed) // ska det inte vara while h�r i st�llet?  Verkar ju funka iofs
        {
            smokerRb.MovePosition(grabbingPointTransform.position); // S�tter smoker tranform + rotation till grabbingPointens. Hade kanske varit enklare att childa till Player (som Nose) ? 

            // smokerRb.transform.position = smokerRb.transform.position - new Vector3 (0, 0.01f, 0);  // Denna rad gjorde ngt konstigt,  fattar inte riktigt vad?


            smokerRb.MoveRotation(grabbingPointTransform.rotation);


            smokerRb.useGravity = false;



            if (Input.GetKeyDown(KeyCode.E) && canDropSmoker) // funktion f�r att sl�ppa smoker p� marken n�r man g�tt ur TriggerCollidern vid kupan. Detta ska inte h�nda �nnu. 
            {
                grabbed = false;

                smokerRb.useGravity = true;

                messageBoard.text = "The bees seem angry, maybe you should try some smoke? ";

                canDropSmoker = false;

                pickUpAble = false; // s� att man inte kan plocka upp lid igen n�r den �r p� marken

                // GetComponent<Collider>().enabled = false; // st�nger av Collidern p� detta gameobjectet, inte riktigt det jag ville men funkar f�r att inte f� fel meddelanden i loggen.
                // .. Kan ju ocks� f�rst�ra textPanelerna eter hand men d� f�r man kanske error om man inte k�r Try Set Active el liknande. 

                smokerDropped = true; // testar detta s� kan jag beh�lla Collidern p� ist�llet. 
            }


        }


    }


    private void OnTriggerExit(Collider player) // H�r m�ste vi �ndra i kedjan f�r vad som ska h�nda
    {

        if (player.tag == "Player")
        {


            canDropSmoker = true;




            if (grabbed)
            {
                messageBoard.text = "Good, now drop lid on ground (E)";




            }



        }

    }


}

