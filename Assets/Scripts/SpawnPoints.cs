using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : MonoBehaviour {

    [SerializeField] Entities itemToSpawn;

    private void Awake()
    {
        SpawnItem();
    }

    private void SpawnItem()
    {
        GameObject spawnedItem;
        string typeOf = itemToSpawn.getTypeofSpawnable();
        string nameOf = itemToSpawn.getNameOfSpawnable();
        print(typeOf + "/" + nameOf); ;      
        spawnedItem = Instantiate(Resources.Load(typeOf+"/"+ nameOf)) as GameObject;
        spawnedItem.transform.position = this.transform.position;

    }

    private string GetTypeOfMonsterToLoad()
    {
        var monsterToLoad = UnityEngine.Random.Range(1, 4);
        string typeOfMonster;
        switch (monsterToLoad)
        {
            case 1:
                typeOfMonster = "Ennemies/RedMushroom";
                break;
            case 2:
                typeOfMonster = "Ennemies/GreenMushroom";
                break;
            case 3:
                typeOfMonster = "Ennemies/BlueMushroom";
                break;
            default:
                typeOfMonster = "Ennemies/RedMushroom";
                break;
        }
        return typeOfMonster;
    }
}
