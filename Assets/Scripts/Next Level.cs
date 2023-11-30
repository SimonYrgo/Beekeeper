using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{

    public bool levelFinished = false;


    private void Start()
    {
        


    }


    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Så far Så good");
        Debug.Log(levelFinished);

        if (levelFinished)
        {
            SceneManager.LoadScene(0);
        }

        
    }



}
