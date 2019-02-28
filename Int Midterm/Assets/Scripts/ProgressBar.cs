using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

//This is code from another game I was attempting
//Some of the captilzation is off, so I apologize
public class ProgressBar : MonoBehaviour
{
    /// <summary>
    /// Set Up Variables
    /// </summary>
    public float currentProgress { get; set; }

    public float maxProgress { get; set; }
    //public float ProgressRefillRate;

    //public TextMeshProUGUI progressBarText;
    public Animator animator;

    /// <summary>
    /// In Game used Variables
    /// </summary>
    public Slider progressBar;
    public Graphic fillbar;
   

    public GameObject player;

    public GameObject objectOne;
    public bool oneDone;
    public bool oneStart;
    
    public GameObject objectTwo;
    public bool twoDone;
    public bool twoStart;
    
    public GameObject objectThree;
    public bool threeDone;
    public bool threeStart;

    //Other Minigames to fill up bar trigger
    bool dealingDamage;
    public Color damageColor;


    public bool shouldFill;

    //Prototype Stuff
    public Dialog convo;
    public DialogManager dialogManager;

    void Start()
    {
        //can be any value of course
        maxProgress = 100f;

        //Start at 0 progress for each item.
        currentProgress = 0;

        //Get the value of the slider 
        //set it to calculate progress
        progressBar.value = CalculateProgress();

        oneDone = false;
        oneStart = false;
        twoDone = false;
        twoStart = false;
        threeDone = false;
        twoStart = false;

        dealingDamage = false;
        damageColor = Color.blue;
    }


    void Update()
    {

        
        //Object One
        if (oneStart)
        {
            shouldFill = true;
            animator.SetBool("shouldAppear", true);
            Debug.Log("Run function");
            CleanObjectOne();
            oneStart = false;

        }


        //Object Two
        if (oneDone)
        {


            if (twoStart)
            {
                Debug.Log("Object Two");
                shouldFill = true;
                CleanObjectTwo();
                animator.SetBool("shouldAppear", true);
            }

        }
        
        
        //Object Three
        if (twoDone == true)
        {
            animator.SetBool("shouldAppear", false);
            
            fillbar.color = damageColor;

            if (dealingDamage == false)
            {
                currentProgress = 50;
                dealingDamage = true;
            }

            if (threeStart)
            {
                shouldFill = true;
                animator.SetBool("shouldAppear", true);
                CleanObjectThree();
                DealDamage(15);
            }

        }

        if (threeDone == true)
        {
            animator.SetBool("shouldAppear", false);
        }


    }

    float CalculateProgress()
    {
        return currentProgress / maxProgress;
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

    void DealDamage(float damageValue)
    {

        //Deal damage to the progress bar
        currentProgress -= damageValue * Time.deltaTime;
        //Same as from start
        progressBar.value = CalculateProgress();


    }

    void CleanObjectOne()
    {
       
        if (Input.GetKeyDown(KeyCode.Space) && shouldFill && oneDone == false)
        {
            addProgress(10);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && shouldFill == false)
        {
            Debug.Log("Don't Fill");
        }

        if (currentProgress >= 99f && oneDone == false)
        {
            oneDone = true;
            shouldFill = false;
            currentProgress = 0;
            animator.SetBool("shouldAppear", false);
            objectOne.GetComponent<Animator>().SetBool("isClean", true);
            
        }
        else if (oneDone == true)
        {
            animator.SetBool("shouldAppear", false);
            

        }
    }

    void CleanObjectTwo()
    {
           if (Input.GetKeyDown(KeyCode.Space) && shouldFill && twoDone == false)
           {
                        addProgress(10);
           }
           else if (Input.GetKeyDown(KeyCode.Space) && shouldFill == false)
           {
                Debug.Log("Don't Fill");
           }
        
            if (currentProgress >= 95f && twoDone == false)
            {
                        twoDone = true;
                        currentProgress = 0;
                        animator.SetBool("shouldAppear", false);
                        objectTwo.GetComponent<Animator>().SetBool("isCleanTwo", true);
            }
            else if (twoDone == true)
            {
                        animator.SetBool("shouldAppear", false);
                        Debug.Log("Go away!");
            }
    }

    void CleanObjectThree()
    {
        if (Input.GetKeyDown(KeyCode.Space) && shouldFill && dealingDamage)
        {
            Debug.Log("Refill Less");
            addProgress(6);
            DealDamage(20);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && shouldFill == false)
        {
            Debug.Log("Don't Fill");
        }

        if (currentProgress >= 99f && threeDone == false)
        {
            threeDone = true;
            currentProgress = 0;
            animator.SetBool("shouldAppear", false);
            objectThree.GetComponent<Animator>().SetBool("isCleanThree", true);
            TriggerDialog();

        }
        else if (threeDone == true)
        {
            animator.SetBool("shouldAppear", false);
        }
        
    }

    //Prototype stuff, not efficient to copy paste dialogtrigger

    public void TriggerDialog()
    {
        dialogManager.StartDialog(convo);
    }
}





