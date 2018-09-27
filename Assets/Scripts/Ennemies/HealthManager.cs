using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthManager : MonoBehaviour
{

    public Image HealthBar;
    public float Fill;
	// Use this for initialization
	void Start ()
	{
	    Fill = 1f;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    HealthBar.fillAmount = Fill;
	}
}
