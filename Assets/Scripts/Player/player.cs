using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    int experience;
    int skillpoints;
    int level;
    public GameObject sword;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //EquipWeapon();
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

    /*void EquipWeapon()
    {
        Transform item;
        item = this.gameObject.transform.GetChild(5);
        Instantiate(sword,im);
        print(item.name);
    }*/
}
