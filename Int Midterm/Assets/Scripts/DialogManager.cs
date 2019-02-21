
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{

    public TextMeshProUGUI dialogText;

    //Like an Array, but Queue uses FIFO
    //Think in Homestuck: John's Inventory was First in, First Out
    //It was limited, but it fits for what I am trying to do.
    public Queue<string> _sentences =  new Queue<string>(); 

    public void StartDialog (Dialog convoToShow)
    {
        Debug.Log("Start the Convo");
        
    
	        foreach (string sentence in convoToShow.sentences)
	        {
		        _sentences.Enqueue(sentence);
	        }

	        _sentences.Clear();
     
        

      
        DisplayNextSentence();
        
    }

    public void DisplayNextSentence()
    {
		//End dialogue if there are no sentences left
		//This is somewhat of an artifact method though-The dialogue box is always active anyway.
        if (_sentences.Count == 0)
        {
            EndDialog();
            return;
        }

        string sentence = _sentences.Dequeue();

		
		//Displays the sentence in game while typing it
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
        Debug.Log("Convo Ends");
    }
}
