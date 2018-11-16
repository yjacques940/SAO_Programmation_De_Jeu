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
        string typeOfMonster;
        if (gameObject.CompareTag("BossSpawnPoint"))
        {
            print("CECI EST UN BOSS");
            typeOfMonster = "Ennemies/Boss";
        }
        else
        {

            typeOfMonster = GetTypeOfMonsterToLoad();
        }
        
        monster = Instantiate(Resources.Load(typeOfMonster)) as GameObject;
        monster.transform.position = this.transform.position;
    }

    private string GetTypeOfMonsterToLoad()
    {
        var monsterToLoad = UnityEngine.Random.Range(1, 4);
        string typeOfMonster;
        switch (monsterToLoad)
        {
            case 1:
                typeOfMonster = "Ennemies/MushroomMon";
                break;
            case 2:
                typeOfMonster = "Ennemies/MushroomMon1";
                break;
            case 3:
                typeOfMonster = "Ennemies/MushroomMon2";
                break;
            case 4:
                typeOfMonster = "Ennemies/MushroomMon3";
                break;
            default:
                typeOfMonster = "Ennemies/MushroomMon";
                break;
        }
        return typeOfMonster;
    }
}
