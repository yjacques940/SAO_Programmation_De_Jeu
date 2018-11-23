using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {
    public int sceneIndex;
    private void OnCollisionEnter(Collision collision)
    {
        //SceneController.loadSelectedScene(sceneIndex);
    }
}
