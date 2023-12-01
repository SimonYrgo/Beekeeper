using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class StartCarryingBox : MonoBehaviour
{

    public TMP_Text messageBoard; // Skapar slot för att kunna skriva meddelanden i Game Message TMP-Textobjektet


    public Transform grabbingPointTransform; // ser om jag kan lägga ett gameobjekt här i, som jag kan sno en Transform från sen

    public GameObject honeyBox; // skapar slot för honeyBox för att kunna manipulera dess tranform sen

    private Rigidbody honeyBoxRb; // måste skapa en Rigidbody-variabel för att kunna hänvisa till honeyBoxs Rigidbody

    private Collider honeyBoxCollider;



    void Start()
    {
       
       //  messageBoard = GetComponent<TMP_Text>();

        BeginMessage();

        honeyBoxRb = honeyBox.GetComponent<Rigidbody>(); // hämtar Rigidbodyn från GameObjectet i sloten boxLid

        honeyBoxCollider = honeyBox.GetComponent<Collider>();

        honeyBoxRb.transform.position = grabbingPointTransform.position;   // samma som min kod tror jag 
        honeyBoxRb.transform.rotation = grabbingPointTransform.rotation;   // samma som min kod tror jag 
        honeyBox.transform.parent = grabbingPointTransform;                // Sätter boxLid som child till parent, varför vet jag inte riktigt än varför det skulle vara bra
        honeyBoxRb.isKinematic = true;                                     // Sätter boxlid till Kinematic = den har ingen graivty och kan inte flyttas av collisions
        honeyBoxCollider.isTrigger = true;                                 // Förutom att göra till en Trigger -  har ingen fysik och kan inte flytta saker? = om jag har den här på smokerscriptet så kommer den inet att flytta på mig. 
    }


    void  BeginMessage()
    {

        messageBoard.text = "Put Honey Box on bench";
    }

}
