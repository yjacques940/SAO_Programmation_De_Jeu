using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entities : MonoBehaviour, ISpawnable
{
    virtual public string getNameOfSpawnable()
    {
        return "en";
    }

    virtual public string getTypeofSpawnable()
    {
        return "en";
    }
}
