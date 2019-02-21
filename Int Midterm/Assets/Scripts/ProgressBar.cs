using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ProgressBar : MonoBehaviour {
    /// <summary>
    /// Set Up Variables
    /// </summary>
    public float currentProgress { get; set; }
    public float maxProgress { get; set; }
   // public Text progressBarText;
  //  public Text timerText;
   // public Animator animator;
   // private string levelToLoad;

    /// <summary>
    /// In Game used Variables
    /// </summary>
    public Slider progressBar;
   // public float timer = 10;
   // public float damageTimer = 30;
    public bool shouldFill = true;
     
	void Start ()
    {
        //can be any value of course
        maxProgress = 100f;

        //Start at 0 prog
        currentProgress = 0;

        //Get the value of the slider 
        //set it to calculate progress
        progressBar.value = CalculateHealth();

      //  progressBarText.text = "Progress " + currentProgress;
     //   timerText.text = "Start mashing in..." + timer;

    

	}
	

	void Update ()
    {

       // timer -= 1 * Time.deltaTime;
      //  progressBarText.text = "Progress: " + Mathf.Round(currentProgress);

 
     //   if (timer >= 0)
     //   {
     //       timerText.text = "Start mashing in..." + Mathf.Round(timer);
     //   }
     
     /*   else 
        {
            timerText.text = "Press Space to fill up that bar!";
            shouldFill = true;
            damageTimer -= 0.1f;

            //Check if the Damage Timer is above 0.
            //If not, stop dealing damage and disable the healing function
            if (damageTimer >= 0)
            {
                DealDamage(0.5f);
            }
            else
            {
                shouldFill = false;
                Debug.Log("Stopped dealing damage");
            }

            //Alternatively, if the player dies before the timer runs out, stop the healing function as well.
            if (currentProgress <= 0)
            {
                shouldFill = false;
             }
       */     
          
        

        if (Input.GetKeyDown(KeyCode.F) && shouldFill == true)
        {
            RestoreHealth(3);
        }
       
	}


    void DealDamage(float damageValue)
    {


        //Deal damage to the health bar
        currentProgress -= damageValue;
        //Same as from start
        progressBar.value = CalculateHealth();

        //If the character is out of health, they die
        if (currentProgress <= 0)
        {
            Die("GameOver");
        }
            
    }

    void RestoreHealth(float healthGained)
    {
        Debug.Log("Healing");
        //Deal damage to the health bar
        currentProgress += healthGained;
        progressBar.value = CalculateHealth();

        //Prevent the player from restoring full health
        if (currentProgress >= maxProgress)
        {
            currentProgress -= 1;
            Debug.Log("Health has been restored to full");
        }
        
           
    }


    float CalculateHealth()
    {
        return currentProgress / maxProgress;
    }

    void Die(string gameOver)
    {
     //   currentProgress = 0;
       // levelToLoad = gameOver;
       // animator.SetTrigger("FadeOut");
       // Debug.Log("Transition to game over scene, then reload");
    }

    //This function is called upon via Animation Events!
    public void OnFadeComplete()
    {
       // SceneManager.LoadScene(levelToLoad);
    }
}
