using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entities : MonoBehaviour
{
    virtual public string getTypeofSpawnable()
    {
        return "";
    }

    virtual public void Respawn()
    {
    }
}
