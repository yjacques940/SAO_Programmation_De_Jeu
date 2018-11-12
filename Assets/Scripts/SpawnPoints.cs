using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour {
    
    private void Awake()
    {
        LoadEnnemies();
    }

    private void LoadEnnemies()
    {
        GameObject monster;
            monster = Instantiate(Resources.Load("Ennemies/MushroomMon")) as GameObject;
            monster.transform.position = this.transform.position;
    }
}
