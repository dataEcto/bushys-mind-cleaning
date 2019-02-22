using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

//This is code from another game I was attempting
//Some of the captilzation is off, so I apologize
public class ProgressBar : MonoBehaviour {
    /// <summary>
    /// Set Up Variables
    /// </summary>
    public float currentProgress { get; set; }
    public float maxProgress { get; set; }

    public TextMeshProUGUI progressBarText;
   // public Animator animator;


   /// <summary>
   /// In Game used Variables
   /// </summary>
   public Slider progressBar;

   public bool shouldFill;
     
	void Start ()
    {
        //can be any value of course
        maxProgress = 100f;

        //Start at 0 progress for each item.
        currentProgress = 0;

        //Get the value of the slider 
        //set it to calculate progress
        progressBar.value = CalculateProgress();
    
 
        
       //Set to true for now for testing purposes
       //This should be set to false usually
        shouldFill = true;

    }
	

	void Update ()
    {

        if (Input.GetKeyDown(KeyCode.F) && shouldFill == true)
        {
            addProgress(3);
        }
       
	}


    void DealDamage(float damageValue)
    {

        //Deal damage to the progress bar
        currentProgress -= damageValue;
        //Same as from start
        progressBar.value = CalculateProgress();

            
    }

    void addProgress(float progressGained)
    {
        Debug.Log("Adding Progress");
        currentProgress += progressGained;
        progressBar.value = CalculateProgress();

        //Prevent the player from restoring past full health
        if (currentProgress >= maxProgress)
        {
            currentProgress -= 1;
            Debug.Log("Progress is full. Will no longer add more");
        }
        
           
    }

    float CalculateProgress()
    {
        return currentProgress / maxProgress;
    }

    
}
