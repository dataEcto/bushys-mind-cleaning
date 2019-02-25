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
    public float ProgressRefillRate;

    //public TextMeshProUGUI progressBarText;
    public Animator animator;

    /// <summary>
    /// In Game used Variables
    /// </summary>
    public Slider progressBar;

    public GameObject player;

    public GameObject objectOne;
    private bool oneDone;
    public GameObject objectTwo;
    private bool twoDone;
    public GameObject objectThree;
    private bool threeDone;


    public bool shouldFill;

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
        twoDone = false;
        threeDone = false;
    }


    void Update()
    {
        //Object One
        if (Vector3.Distance(objectOne.transform.position, player.transform.position) < 2f)
        {
            shouldFill = true;
            animator.SetBool("shouldAppear", true);
        }

        if (Input.GetKeyDown(KeyCode.Space) && shouldFill)
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


        if (oneDone == true)
        {
            //Object Two
            if (Vector3.Distance(objectTwo.transform.position, player.transform.position) < 2f)
            {
                Debug.Log("Object Two");

                shouldFill = true;
                animator.SetBool("shouldAppear", true);
            }

            if (Input.GetKeyDown(KeyCode.Space) && shouldFill)
            {
                addProgress(10);
            }
            else if (Input.GetKeyDown(KeyCode.Space) && shouldFill == false)
            {
                Debug.Log("Don't Fill");
            }

            if (currentProgress >= 99f && twoDone == false)
            {
                twoDone = true;
                currentProgress = 0;
                animator.SetBool("shouldAppear", false);
                objectTwo.GetComponent<Animator>().SetBool("isCleanTwo", true);
            }
            else if (twoDone == true)
            {
                animator.SetBool("shouldAppear", false);
            }

            if (twoDone == true)
            {
                //Object Three
                if (Vector3.Distance(objectThree.transform.position, player.transform.position) < 2f)
                {
                    Debug.Log("Object Three");

                    shouldFill = true;
                    animator.SetBool("shouldAppear", true);
                }

                if (Input.GetKeyDown(KeyCode.Space) && shouldFill)
                {
                    addProgress(10);
                }
                else if (Input.GetKeyDown(KeyCode.Space) && shouldFill == false)
                {
                    Debug.Log("Don't Fill");
                }

                if (currentProgress >= 99f && twoDone == false)
                {
                    threeDone = true;
                    currentProgress = 0;
                    animator.SetBool("shouldAppear", false);
                    objectTwo.GetComponent<Animator>().SetBool("isCleanTwo", true);
                }
                else if (threeDone == true)
                {
                    animator.SetBool("shouldAppear", false);
                }


            }

        }

    }

    float CalculateProgress()
    {
        return currentProgress / maxProgress;
    }

    void addProgress(float progressGained)
    {
        Debug.Log("Adding Progress");
        progressGained = ProgressRefillRate;
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
        currentProgress -= damageValue;
        //Same as from start
        progressBar.value = CalculateProgress();


    }
}





