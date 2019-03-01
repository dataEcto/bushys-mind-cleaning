
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour
{

    public TextMeshProUGUI dialogText;
    public Animator anim;
    
    //Currently there is a glitch where 
    //Even though I prevent the sentence from being show
    //It is still going through the queue
    //Gotta fix that! But for now I cant stop at every tiny glitch
    public DialogTrigger dialogTrigger;

    //Like an Array, but Queue uses FIFO
    //Think in Homestuck: John's Inventory was First in, First Out
    //It was limited, but it fits for what I am trying to do.
    public Queue<string> _sentences =  new Queue<string>();

    private void Start()
    {
	    dialogTrigger = GetComponent<DialogTrigger>();
    }

    public void StartDialog (Dialog convoToShow)
    {
        Debug.Log("Start the Convo");
        anim.SetBool("isOpen",true);
        
        _sentences.Clear();
        
       
	        foreach (string sentence in convoToShow.sentences)
	        {
		        _sentences.Enqueue(sentence);
	        }

	        DisplayNextSentence();
   
	    
    }

    public void DisplayNextSentence()
    {
	
		//End dialogue if there are no sentences left
        if (_sentences.Count == 0 )
        {
            EndDialog();
            return;
        }
      

        string sentence = _sentences.Dequeue();

		//Displays the sentence in game while typing it
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
		
     
    }

	IEnumerator TypeSentence (string sentence)
	{
		dialogText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogText.text += letter;
			yield return null;
		}
	}

    public void EndDialog()
    {
	    anim.SetBool("isOpen",false);
    
    }
}
