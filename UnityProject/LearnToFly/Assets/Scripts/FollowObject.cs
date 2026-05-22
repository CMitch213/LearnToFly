using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public GameObject target;
    public float smoothRate;
    public Vector3 offset;


    // Update is called once per frame
    void FixedUpdate()
    {
        //Make offset do stuff
        Vector3 desiredLoc = target.transform.position + offset;

        //Move what this is attached to towards object
        transform.position = Vector3.Lerp(transform.position, desiredLoc, smoothRate * Time.deltaTime);
    }
}
