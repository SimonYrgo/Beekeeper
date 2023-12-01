using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class StartCarryingBox : MonoBehaviour
{

    public TMP_Text messageBoard; // Skapar slot f�r att kunna skriva meddelanden i Game Message TMP-Textobjektet


    public Transform grabbingPointTransform; // ser om jag kan l�gga ett gameobjekt h�r i, som jag kan sno en Transform fr�n sen

    public GameObject honeyBox; // skapar slot f�r honeyBox f�r att kunna manipulera dess tranform sen

    private Rigidbody honeyBoxRb; // m�ste skapa en Rigidbody-variabel f�r att kunna h�nvisa till honeyBoxs Rigidbody

    private Collider honeyBoxCollider;



    void Start()
    {
       
       //  messageBoard = GetComponent<TMP_Text>();

        BeginMessage();

        honeyBoxRb = honeyBox.GetComponent<Rigidbody>(); // h�mtar Rigidbodyn fr�n GameObjectet i sloten boxLid

        honeyBoxCollider = honeyBox.GetComponent<Collider>();

        honeyBoxRb.transform.position = grabbingPointTransform.position;   // samma som min kod tror jag 
        honeyBoxRb.transform.rotation = grabbingPointTransform.rotation;   // samma som min kod tror jag 
        honeyBox.transform.parent = grabbingPointTransform;                // S�tter boxLid som child till parent, varf�r vet jag inte riktigt �n varf�r det skulle vara bra
        honeyBoxRb.isKinematic = true;                                     // S�tter boxlid till Kinematic = den har ingen graivty och kan inte flyttas av collisions
        honeyBoxCollider.isTrigger = true;                                 // F�rutom att g�ra till en Trigger -  har ingen fysik och kan inte flytta saker? = om jag har den h�r p� smokerscriptet s� kommer den inet att flytta p� mig. 
    }


    void  BeginMessage()
    {

        messageBoard.text = "Put Honey Box on bench";
    }

}
