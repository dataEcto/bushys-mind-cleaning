

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastBehavior : MonoBehaviour
{

    public float maxDistance;
    public ProgressBar progressScript;
  

    private void Start()
    {
        progressScript = FindObjectOfType<ProgressBar>().GetComponent<ProgressBar>();
       
    }

    void Update()
    {

 
        Ray playerRay = new Ray(this.transform.position, this.transform.forward);

        Debug.DrawRay(playerRay.origin, playerRay.direction * maxDistance, Color.green);

        RaycastHit hit;

        if (Physics.Raycast(playerRay.origin, playerRay.direction, out hit, maxDistance))
        {
            Debug.Log("I got something, chief!");
            
            if (hit.transform.gameObject.tag == "Cleaning Object 1")
            {
                progressScript.oneStart = true;
                Debug.Log("Set one to true");
            }
            
            if (hit.transform.gameObject.tag == "Cleaning Object 2")
            {
                progressScript.twoStart = true;
                Debug.Log("Set two to true");
            }

            if (hit.transform.gameObject.tag == "damage game")
            {
                progressScript.threeStart = true;
                Debug.Log("Set 3 to true now");
            }
            
        }

        else
        {
            Debug.Log("This aint it.");
        }
    }
}
