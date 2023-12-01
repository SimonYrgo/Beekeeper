using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BenchInteract : MonoBehaviour
{

    public TMP_Text messageBoard; // Skapar slot för att kunna skriva meddelanden i Game Message TMP-Textobjektet

    public Transform boxPlaceOnBench; // Hit ska HoneyBox sättas, till en emptys Transform

    public GameObject honeyBox; // skapar slot för honeyBox för att kunna manipulera dess transform sen

    private Rigidbody honeyBoxRb; // måste skapa en Rigidbody-variabel för att kunna hänvisa till honeyBox Rigidbody

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

            if (hitInfo.transform == boxPlaceOnBench) // förutsätter att obketet har en collider för att kunna träffas av raycast
            {
                Debug.Log("Raycast HiT!");
            }

           
        }
    }
}

   

