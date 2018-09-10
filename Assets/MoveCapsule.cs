using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCapsule : MonoBehaviour {
    private Rigidbody rigidBody;
    // Use this for initialization
    [SerializeField] public float ForceToRight = 25;
    [SerializeField] public float ForceToLeft = 25;
    [SerializeField] public float ForceToUp = 25;
    [SerializeField] public float ForceToBack = -25;
    void Start () {
        rigidBody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 200.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 5.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
    }
}
