using TMPro;
using UnityEngine;

public class WaxShaver : MonoBehaviour
{
    public string targetTagA = "Capped"; // Set your target tag in the Unity Editor

    public string targetTagB = "UnCapped"; // Set your target tag in the Unity Editor

    public TMP_Text messageBoard;

    bool canUncapFrame = false;

    public bool frameUncapped = false;



    TakeFrameHoneybox takeFrameHoneybox;

    public Transform frame;         







    void Start()
    {

        takeFrameHoneybox = GameObject.FindObjectOfType<TakeFrameHoneybox>();

    }




    private void Update()
    {

        if (canUncapFrame)
        {
            if (Input.GetKeyUp(KeyCode.U))
            {
                DeactivateChildrenByTag();

                ActivateChildrenByTag();

                canUncapFrame = false;

                frameUncapped = true;

                

            }

        }

        if (frameUncapped) 
        {
            messageBoard.text = "Press P to pick up uncapped frame";

            if(Input.GetKeyDown(KeyCode.P)) 
            {
                Debug.Log("Snart hemma med framen");
            }

        }
    }


        
            
    





    private void OnTriggerEnter(Collider player)
    {



        if (player.tag == "Player" && takeFrameHoneybox.framePutOnStand && !frameUncapped) 

        {
            canUncapFrame = true;
            messageBoard.text = "Press U to uncap Honeyframe";
            

        }
        
        if (player.tag == "Player" && frameUncapped)
        {
            messageBoard.text = "Press P to pick up uncapped frame";
        }
        
    }


    private void OnTriggerStay(Collider player) 
    {
        if (player.tag == "Player" && takeFrameHoneybox.framePutOnStand && !frameUncapped)

        {
            canUncapFrame = true;
            messageBoard.text = "Press U to uncap Honeyframe";
            

        }

        

        if (player.tag == "Player" && frameUncapped)
        {
            messageBoard.text = "Press P to pick up uncapped frame";
        }
        

    }

    private void OnTriggerExit(Collider player)
    {



        if (player.tag == "Player" && takeFrameHoneybox.framePutOnStand && frameUncapped)

        {
            canUncapFrame = false;
            messageBoard.text = "";
            

        }
    }






    void DeactivateChildrenByTag()
    {
        // Iterate through all child objects of the current GameObject
        for (int i = 0; i < frame.childCount; i++)
        {
            // Get the i-th child object
            Transform child = frame.GetChild(i);

            // Check if the child's tag matches the target tag - samma sak som if (child.tag == "nånting")  fast man bestämmer nånting i variabeln ovan 
            if (child.CompareTag(targetTagA))                                        
            {
                // Deactivate the child object
                child.gameObject.SetActive(false);
            }
        }
    }

    void ActivateChildrenByTag()
    {
        // Iterate through all child objects of the current GameObject
        for (int i = 0; i < frame.childCount; i++)
        {
            // Get the i-th child object
            Transform child = frame.GetChild(i);

            // Check if the child's tag matches the target tag
            if (child.CompareTag(targetTagB))
            {
                // Activate the child object
                child.gameObject.SetActive(true);
            }
        }
    }
}


