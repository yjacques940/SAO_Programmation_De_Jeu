using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour {
    public const int MonstersToKill = 5;
    public Text text;
    // Use this for initialization
    void Start () {
        text.text = "Tuer des champignons :"+ Environment.NewLine + 0 + " / " + MonstersToKill;
    }

    public void UpdateText(int monstersKilled)
    {
        if(BossDoorHasSpawn(monstersKilled))
        {
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
            GameObject bossDoor = new GameObject();           
            bossDoor.transform.position = this.transform.position;
            bossDoor.transform.Translate(new Vector3(10, 0, 5), Space.World);
            bossDoor = Instantiate(Resources.Load("BossDoor")) as GameObject;
            return true;
        }
        else
        {
            return false;
        }
        
        
    }
}
