using System.Collections;
using System.Collections.Generic;
// using System.Diagnostics;
using UnityEngine;
using TMPro;

/*
 *  Fixat TriggerCollider bara på marken för smokern annars kan man ju aldrig gå ur den..
 * 
 */





public class Smoker : MonoBehaviour
{

    public TMP_Text messageBoard; // Skapar slot för att kunna skriva meddelanden i Game Message TMP-Textobjektet


    bool pickUpAble;

    bool grabbed;

    bool canDropSmoker;

    bool smokerDropped;


    RemoveLid isLidDropped;

    



    public Transform grabbingPointTransform; // ser om jag kan lägga ett gameobjekt här i, som jag kan sno en Transform från sen

    public GameObject smoker; // skapar slot för smoker för att kunna manipulera dess tranform sen

    private Rigidbody smokerRb; // måste skapa en Rigidbody-variabel för att kunna hänvisa till smoker Rigidbody



    void Start()
    {
        isLidDropped = GameObject.FindObjectOfType<RemoveLid>();

        pickUpAble = false;

        grabbed = false;

        canDropSmoker = false;

        smokerDropped = false;

        smokerRb = smoker.GetComponent<Rigidbody>(); // hämtar Rigidbodyn från GameObjectet i sloten smoker

        
    }


    private void OnTriggerEnter(Collider player) // verkar referera till Objektet som går in i triggern via dess collider 
    {

        // if-sats som kollar taggen på objektet, vars collider gick i i triggern mfl villkor

        if (player.tag == "Player" && !smokerDropped && isLidDropped.lidDropped) // Om Player går in här -- OCH smoker inte är Dropped -- OCH lid är dropped (man ska inte kunna plocka upp smoker innan lid) 
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
            if (Input.GetKeyDown(KeyCode.P)) // Varför detta funkar här och inte i OnTriggerEnter vet jag inte
            {

                grabbed = true;


            }
        }

        if (grabbed) // ska det inte vara while här i stället?  Verkar ju funka iofs
        {
            smokerRb.MovePosition(grabbingPointTransform.position); // Sätter smoker tranform + rotation till grabbingPointens. Hade kanske varit enklare att childa till Player (som Nose) ? 

            // smokerRb.transform.position = smokerRb.transform.position - new Vector3 (0, 0.01f, 0);  // Denna rad gjorde ngt konstigt,  fattar inte riktigt vad?


            smokerRb.MoveRotation(grabbingPointTransform.rotation);


            smokerRb.useGravity = false;



            if (Input.GetKeyDown(KeyCode.E) && canDropSmoker) // funktion för att släppa smoker på marken när man gått ur TriggerCollidern vid kupan. Detta ska inte hända ännu. 
            {
                grabbed = false;

                smokerRb.useGravity = true;

                messageBoard.text = "The bees seem angry, maybe you should try some smoke? ";

                canDropSmoker = false;

                pickUpAble = false; // så att man inte kan plocka upp lid igen när den är på marken

                // GetComponent<Collider>().enabled = false; // stänger av Collidern på detta gameobjectet, inte riktigt det jag ville men funkar för att inte få fel meddelanden i loggen.
                // .. Kan ju också förstöra textPanelerna eter hand men då får man kanske error om man inte kör Try Set Active el liknande. 

                smokerDropped = true; // testar detta så kan jag behålla Collidern på istället. 
            }


        }


    }


    private void OnTriggerExit(Collider player) // Här måste vi ändra i kedjan för vad som ska hända
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

