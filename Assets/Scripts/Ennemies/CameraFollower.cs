using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraFollower : MonoBehaviour
{

    GameObject cameraToLookAt;
	// Use this for initialization
	void Start () {
        cameraToLookAt = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
    void Update()
    {
        transform.LookAt(cameraToLookAt.transform);
        transform.Rotate(new Vector3(0, 180, 0));
    }
}
