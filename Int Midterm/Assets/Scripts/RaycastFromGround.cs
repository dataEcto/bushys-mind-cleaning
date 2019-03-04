using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastFromGround : MonoBehaviour
{

    public float rayDistance;
  
    void Start()
    {
      
    }

    
    void Update()
    {
        Ray myRay = new Ray(this.transform.position, Vector3.down);
        
        Debug.DrawRay(myRay.origin, new Vector3(0,-rayDistance,0),Color.green);

        RaycastHit myHit;
        
        if (Physics.Raycast(myRay.origin,myRay.direction, out myHit, rayDistance)
        {
           print("This hit th " + myHit.rigidbody.transform.name); 
        }
    }
}
