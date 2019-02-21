using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog convo;
	
    public void TriggerDialog()
    {
        FindObjectOfType<DialogManager>().StartDialog(convo);
    }

    public void Start()
    {
    
		TriggerDialog();
	


	}

    public void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.Space))
        {
			
				FindObjectOfType<DialogManager>().DisplayNextSentence();
         
		}

	}


}
