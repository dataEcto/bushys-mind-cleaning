using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object1Trigger : MonoBehaviour
{
    public Dialog convo;
    public Transform player;
    private bool _isTriggered;
    
    
	
    public void TriggerDialog()
    {
        FindObjectOfType<DialogManager>().StartDialog(convo);
    }

    public void Start()
    {
		
	
	}

    public void Update()
    {

	    if (Vector3.Distance(player.transform.position, transform.position) < 2f)
	    {
		    //Interesting thought I just had
		    //in the beginner's guide, the text didnt go away when you walked in front of an object to clean it
		    //it just stayed there untill it was clean
		    //Do i still need this script? 
		    //Most likely no
		    
	    }
	    
        if (Input.GetKeyDown(KeyCode.Space))
        {
			
				FindObjectOfType<DialogManager>().DisplayNextSentence();
         
		}

	}


}
