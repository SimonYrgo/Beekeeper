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

    public TMP_Text messageBoard; // Skapar slot för att kunna skriva meddelanden i Game Message TMP-Textobjektet

    bool pickUpAble;

    public bool grabbed;

    bool canDropLid;


    public Transform grabbingPointTransform; // ser om jag kan lägga ett gameobjekt här i, som jag kan sno en Transform från sen

    public GameObject boxLid; // skapar slot för boxLid för att kunna manipulera dess tranform sen

    private Rigidbody boxLidRb; // måste skapa en Rigidbody-variabel för att kunna hänvisa till boxLids Rigidbody


    void Start()
    {
        pickUpAble = false;

        grabbed = false;

        canDropLid = false;

        boxLidRb = boxLid.GetComponent<Rigidbody>(); // hämtar Rigidbodyn från GameObjectet i sloten boxLid
    }

    
    private void OnTriggerEnter(Collider player) // verkar referera till Objektet som går in i triggern via dess collider 
    {

        // if-sats som kollar taggen på objektet, vars collider gick i i triggern

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
            if (Input.GetKeyDown(KeyCode.R)) // Varför detta funkar här och inte i OnTriggerEnter vet jag inte
            {
                
                grabbed = true;

            
            }
        }

        if (grabbed) // ska det inte vara while här i stället?  Verkar ju funka iofs
        {
            boxLidRb.MovePosition(grabbingPointTransform.position); // Sätter boxLids tranform + rotation till grabbingPointens. Hade kanske varit enklare att childa boxLid till Player (som Nose) ? 
            boxLidRb.MoveRotation(grabbingPointTransform.rotation);


            boxLidRb.useGravity = false;

            

            if (Input.GetKeyDown(KeyCode.E) && canDropLid) // funktion för att släppa boxLid på marken när man gått ur TriggerCollidern vid kupan
            {
                grabbed = false;

                boxLidRb.useGravity = true;

                messageBoard.text = "The bees seem angry, maybe you should try some smoke? ";

                canDropLid = false;
                
                GetComponent<Collider>().enabled = false; // stänger av Collidern på detta gameobjectet, inte riktigt det jag ville men funkar för att inte tjata om Remove Lid.
                                                          // .. Kan ju också förstöra textPanelerna eter hand men då får man kanske error om man inte kör Try Set Active el liknande. 
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
