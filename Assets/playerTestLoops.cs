using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTestLoops : MonoBehaviour {

    int experience;
    int skillPoints;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //receiveExperienceAndSkillPoints();
        Debug.Log("I have " + experience + " and " + skillPoints + " skillpoints");
    }

    public void receiveLoot(GameObject arg_loot)
    {
        Debug.Log("I have received the following item: " +arg_loot.name);
    }

    public void ReceiveRewards(int arg_experience, int arg_skill_points, GameObject arg_item_loot)
    {
        experience += arg_experience;
        skillPoints += arg_skill_points;
        receiveLoot(arg_item_loot);
    }
}
