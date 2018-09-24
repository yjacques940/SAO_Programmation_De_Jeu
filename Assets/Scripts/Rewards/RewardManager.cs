using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//------Rework when other classes are ready

public class RewardManager : MonoBehaviour {
   
    [SerializeField] playerTestLoops player;
    [SerializeField] GameObject loot;


    void Start () {
        loot = new GameObject();
        loot.name = "epee";      
    }
	
	void Update () {
        rewardPlayer(15,1, loot);
	}

    void rewardPlayer(int arg_experience, int arg_skill_points, GameObject arg_loot_item)
    {    
        player.ReceiveRewards(arg_experience, arg_skill_points, loot);     
    }

    /*GameObject getPlayer()
    {
        return GameObject.FindWithTag("Player");
    }*/
}
