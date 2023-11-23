using System.Collections;
using System.Collections.Generic;
// using System.Diagnostics;
using UnityEngine;
using TMPro;

/*
 * 
 * 
 */






public class RemoveLid : MonoBehaviour
{

    public TMP_Text messageBoard; // Skapar slot f�r att kunna skriva meddelanden i Game Message TMP-Textobjektet

    bool pickUpAble;

    public bool grabbed;

    bool canDropLid;


    public Transform grabbingPointTransform; // ser om jag kan l�gga ett gameobjekt h�r i, som jag kan sno en Transform fr�n sen

    public GameObject boxLid; // skapar slot f�r boxLid f�r att kunna manipulera dess tranform sen

    private Rigidbody boxLidRb; // m�ste skapa en Rigidbody-variabel f�r att kunna h�nvisa till boxLids Rigidbody


    void Start()
    {
        pickUpAble = false;

        grabbed = false;

        canDropLid = false;

        boxLidRb = boxLid.GetComponent<Rigidbody>(); // h�mtar Rigidbodyn fr�n GameObjectet i sloten boxLid
    }

    
    private void OnTriggerEnter(Collider player) // verkar referera till Objektet som g�r in i triggern via dess collider 
    {

        // if-sats som kollar taggen p� objektet, vars collider gick i i triggern

        if (player.tag == "Player")
        {

            messageBoard.gameObject.SetActive(true);

            pickUpAble = true;
            

        }


    }

    private void Update() 
    {
        if(pickUpAble)
        {
            if (Input.GetKeyDown(KeyCode.R)) // Varf�r detta funkar h�r och inte i OnTriggerEnter vet jag inte
            {
                
                grabbed = true;

            
            }
        }

        if (grabbed) // ska det inte vara while h�r i st�llet?  Verkar ju funka iofs
        {
            boxLidRb.MovePosition(grabbingPointTransform.position); // S�tter boxLids tranform + rotation till grabbingPointens. Hade kanske varit enklare att childa boxLid till Player (som Nose) ? 
            boxLidRb.MoveRotation(grabbingPointTransform.rotation);


            boxLidRb.useGravity = false;

            

            if (Input.GetKeyDown(KeyCode.E) && canDropLid) // funktion f�r att sl�ppa boxLid p� marken n�r man g�tt ur TriggerCollidern vid kupan
            {
                grabbed = false;

                boxLidRb.useGravity = true;

                messageBoard.text = "The bees seem angry, maybe you should try some smoke? ";

                canDropLid = false;
                
                GetComponent<Collider>().enabled = false; // st�nger av Collidern p� detta gameobjectet, inte riktigt det jag ville men funkar f�r att inte tjata om Remove Lid.
                                                          // .. Kan ju ocks� f�rst�ra textPanelerna eter hand men d� f�r man kanske error om man inte k�r Try Set Active el liknande. 
            }


        }


    }


    private void OnTriggerExit(Collider player) 
    {

        if (player.tag == "Player")
        {
            

            canDropLid = true;

            


            if (grabbed)
            {
                messageBoard.text = "Good, now drop lid on ground (E)";

                


            }

            

        }

    }


}
