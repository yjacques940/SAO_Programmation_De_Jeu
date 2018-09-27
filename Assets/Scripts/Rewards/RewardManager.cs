using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//------Rework when other classes are ready

public class RewardManager : MonoBehaviour {
   
    [SerializeField] player player;
    GameObject loot;


    void Start () {
        loot = new GameObject();
        loot.name = "epee";      
    }
	
	void Update () {
        rewardPlayer(15,1, loot);
	}

    void rewardPlayer(int experienceRecue, int skillPointsReceived, GameObject itemReceived)
    {    
        player.ReceiveRewards(experienceRecue, skillPointsReceived, itemReceived);     
    }

    /*GameObject getPlayer()
    {
        return GameObject.FindWithTag("Player");
    }*/
}
