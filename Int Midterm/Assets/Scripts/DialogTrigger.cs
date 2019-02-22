using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog convo;
    public DialogManager dialogManager;
        
    //The Player + Cleaning Objects on screen
    //Figure out way to disable them, and also enable
    public GameObject player;
    public GameObject objectOne;
    public GameObject objectTwo;
    public GameObject objectThree;
    
    //Bools for checking when to continue conversation
    public bool isTalking;
    public bool oneComplete = false;
    public bool twoComplete = false;
    public bool threeComplete = false;
    
  
    public void Start()
    {
	    dialogManager = FindObjectOfType<DialogManager>().GetComponent<DialogManager>();
		TriggerDialog();


    }

    public void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.Space) && isTalking )
        {
	        dialogManager.DisplayNextSentence();
        }
        
        //Object One
        if (Vector3.Distance(player.transform.position, objectOne.transform.position) < 3f && isTalking == false)
        {
	        oneComplete = true;
	        if (oneComplete == true)
	        {
		        dialogManager.DisplayNextSentence();
		        oneComplete = false;
		        Debug.Log("Show next line");   
	        }
		       
	        
        }

	}
    
    public void TriggerDialog()
    {
	    dialogManager.StartDialog(convo);
    }



}
