using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {
    public int sceneIndex;

    private void OnTriggerEnter(Collider other)
    {
        SceneController SceneController = new SceneController();
        SceneController.loadSelectedScene(sceneIndex);
    }
}
