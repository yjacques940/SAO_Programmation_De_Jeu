using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item {

    [SerializeField]
    int damage = 1;

    public int Damage {
        get { return damage; }
    }

}
