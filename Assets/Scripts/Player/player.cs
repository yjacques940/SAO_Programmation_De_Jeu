using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    int experience;
    int skillpoints;
    int level;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ReceiveRewards(int experienceReceived,int skillPointsReceived, GameObject itemReceived)
    {
        ReceiveExperiencePoints(experienceReceived);
        ReceiveSkillPoints(skillPointsReceived);
        AddItemToInventory(itemReceived);
    }

    void ReceiveExperiencePoints(int experienceReceived)
    {
        experience += experienceReceived;
    }

    void ReceiveSkillPoints(int skillPointsReceived)
    {
        skillpoints += skillPointsReceived;
    }

    void AddItemToInventory(GameObject itemReceived)
    {
        //complete when inventory system is defined
        print(itemReceived.name);
    }
}
