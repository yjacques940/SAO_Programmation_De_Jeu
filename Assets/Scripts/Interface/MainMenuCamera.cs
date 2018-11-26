using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCamera : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;

    public Vector3 offSet;
    private float rotateSpeed = 5;


    private float speedMod = -10.0f;//a speed modifier
    private Vector3 point;//the coord to the point where the camera looks at
    private void FixedUpdate()
    {

        if (true)
        {
            //Set up things on the start method
            point = target.transform.position;//get target's coords
            transform.LookAt(point);
            transform.RotateAround(point, new Vector3(0.0f, 1.0f, 0.0f), 10 * Time.deltaTime * speedMod);
            Vector3 desiredPosition = target.position + offSet;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            //transform.position = smoothedPosition;
            //transform.LookAt(target);
        }
        else rotateSpeed = 0;
        //else
        //{
        //    //Follow Player
        //    Vector3 desiredPosition = target.position + offSet;
        //    Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        //    transform.position = smoothedPosition;
        //    transform.LookAt(target);
        //}
    }

}
