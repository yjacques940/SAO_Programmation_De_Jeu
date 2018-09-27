using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image CurrentHealthBar;
    public Text RatioText;
    public Vector3 healthBarWorldPosition;
    public NavMeshAgent Monster;
    public Camera cam;

    private float hitPoint = 150;
    private float maxHitPoint = 150;

    private void Start()
    {
        Monster = gameObject.GetComponent<NavMeshAgent>();

        
    }

    private void Update()
    {
        SetPositionOfHealthBar();
        UpdateHealthBar();
        //TakeDamage(0.1);
    }
    private void SetPositionOfHealthBar()
    {
       // healthBarWorldPosition = Monster.transform.position + new Vector3(0, Monster.height, 0);
        //healthBarScreenPosition = Camera.main.WorldToScreenPoint(healthBarWorldPosition);
    }

    private void UpdateHealthBar()
    {
        Vector3 viewPos = cam.WorldToViewportPoint(Monster.transform.position);
        viewPos.z = 0;
        viewPos = viewPos * 535;
        print("ALLO"+Monster.transform.position);
        print("TEST" + viewPos);
        CurrentHealthBar.transform.position = viewPos;
        var ratio = hitPoint / maxHitPoint;
       // CurrentHealthBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        RatioText.text = (ratio*100).ToString("0");
    }

    private void TakeDamage(float damage)
    {
        hitPoint -= damage;
        if(hitPoint<0)
        {
            hitPoint = 0;
            Debug.Log("Dead!");
            
        }
        UpdateHealthBar();
    }

    private void HealDamage(float heal)
    {

    }
}
