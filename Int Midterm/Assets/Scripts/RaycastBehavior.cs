

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastBehavior : MonoBehaviour
{

    public float maxDistance = .5f;


    void Update()
    {

        // 1 define the ray
        Ray roombaRay = new Ray(this.transform.position, this.transform.forward);

        // 2 define the max distance

        // 3 draw debug

        Debug.DrawRay(roombaRay.origin, roombaRay.direction * maxDistance, Color.red);

        RaycastHit roombatHit;

        if (Physics.Raycast(roombaRay.origin, roombaRay.direction, out roombatHit, maxDistance))
        {
            Debug.Log("I got something, chief!");
        }

        else
        {
            Debug.Log("This aint it.");
        }
    }
}
