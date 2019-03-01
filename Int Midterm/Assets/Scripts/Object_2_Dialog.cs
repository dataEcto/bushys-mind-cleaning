using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_2_Dialog : MonoBehaviour
{
    private bool isTriggered;
    public Dialog convo;
    public DialogManager dialogManager;
    public ProgressBar progressScript;

    // Start is called before the first frame update
    void Start()
    {
        isTriggered = true;
        dialogManager = FindObjectOfType<DialogManager>().GetComponent<DialogManager>();
        TriggerDialog();
        progressScript = FindObjectOfType<ProgressBar>().GetComponent<ProgressBar>();

    }

    // Update is called once per frame
    void Update()
    {
        if (progressScript.twoDone == true)
        {
            if (isTriggered == true)
            {
                TriggerDialog();
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    ContinueDialogue();
                }

                isTriggered = false;
            }
          

         
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
