using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BenchInteract : MonoBehaviour
{

    public TMP_Text messageBoard; // Skapar slot f�r att kunna skriva meddelanden i Game Message TMP-Textobjektet

    public Transform boxPlaceOnBench; // Hit ska HoneyBox s�ttas, till en emptys Transform

    public GameObject honeyBox; // skapar slot f�r honeyBox f�r att kunna manipulera dess transform sen

    private Rigidbody honeyBoxRb; // m�ste skapa en Rigidbody-variabel f�r att kunna h�nvisa till honeyBox Rigidbody

    private Collider honeyBoxCollider;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hitInfo = new RaycastHit();
        bool hit = Physics.Raycast(transform.position, transform.forward, out hitInfo, 2f);

        if (hit)
        {

            if (hitInfo.transform == boxPlaceOnBench) // f�ruts�tter att obketet har en collider f�r att kunna tr�ffas av raycast
            {
                Debug.Log("Raycast HiT!");
            }

           
        }
    }
}

   

