using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog convo;
    public DialogManager dialogManager;
 
    public void Start()
    {
	    dialogManager = FindObjectOfType<DialogManager>().GetComponent<DialogManager>();
		TriggerDialog();
		
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
		  dialogManager.DisplayNextSentence();
        }
    
    }
    
    public void TriggerDialog()
    {
	    dialogManager.StartDialog(convo);
    }

    public void ContinueDialogue()
    {
	    dialogManager.DisplayNextSentence();
    }



}
