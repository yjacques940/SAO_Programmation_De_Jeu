using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

    public static SceneController sceneControl;

    //private void Awake() {
    //    if (sceneControl == null) {
    //        DontDestroyOnLoad(gameObject);
    //        sceneControl = this;
    //    }
    //    else if (sceneControl != this) {
    //        Destroy(gameObject);
    //    }
    //}
    
    public void ReloadCurrentScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void loadSelectedScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
