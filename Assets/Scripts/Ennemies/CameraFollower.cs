using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraFollower : MonoBehaviour
{

    public Camera cameraToLookAt;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
    void Update()
    {
        transform.LookAt(cameraToLookAt.transform);
        transform.Rotate(new Vector3(0, 180, 0));
    }
}
