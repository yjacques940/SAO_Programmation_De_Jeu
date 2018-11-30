using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuHandler : MonoBehaviour {

    public GameObject menu;

    void Update()
    {
        if (Input.GetKeyDown("escape"))
            changeActiveState();

        if (menu.activeSelf)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0;
        }
        else Time.timeScale = 1;
    }

    public void changeActiveState()
    {
        menu.SetActive(!menu.activeSelf);
    }
}
