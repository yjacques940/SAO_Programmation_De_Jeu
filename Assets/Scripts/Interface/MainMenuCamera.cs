using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCamera : MonoBehaviour
{
    public Transform target;

    private float smoothSpeed = 0.125f;

    public Vector3 offSet;
    public float rotateSpeed = -5;
    
    private Vector3 point;//the coord to the point where the camera looks at
    private void FixedUpdate()
    {
        if (rotateSpeed < 0.01f)
        {
            //Set up things on the start method
            point = target.transform.position;//get target's coords
            transform.LookAt(new Vector3(point.x - 1, point.y + 0.75f, point.z));
            transform.RotateAround(point, new Vector3(0.0f, 1.0f, 0.0f), 10 * Time.deltaTime * rotateSpeed);
            Vector3 desiredPosition = target.position + offSet;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            rotateSpeed += 0.05f;
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
