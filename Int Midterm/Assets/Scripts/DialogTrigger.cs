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
      
        if (Input.GetKeyDown(KeyCode.Mouse0) )
        {
		  dialogManager.DisplayNextSentence();
	
        }
        
      

    }
    
    public void TriggerDialog()
    {
	    dialogManager.StartDialog(convo);
    }



}
