using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour {
    public GameObject portal;
    public const int MonstersToKill = 5;
    public Text text;
    // Use this for initialization
    void Start () {
        portal = GameObject.FindGameObjectWithTag("Portal");
        portal.SetActive(false);
        text.text = "Tuer des champignons :"+ Environment.NewLine + 0 + " / " + MonstersToKill;
    }

    public void UpdateText(int monstersKilled)
    {
        if(BossDoorHasSpawn(monstersKilled))
        {
            portal.SetActive(true);
            text.text = "La porte du boss" + Environment.NewLine + "est apparue!" + Environment.NewLine + "Trouvez la et tuez le boss!";
        }
        else
        {
           text.text = "Tuer des champignons :" + Environment.NewLine + monstersKilled + "/" + MonstersToKill;
        }
        

    }

    public bool BossDoorHasSpawn(int monstersKilled)
    {
        if (monstersKilled >= MonstersToKill)
        {
            return true;
        }
        else
        {
            return false;
        }
        
        
    }
}
