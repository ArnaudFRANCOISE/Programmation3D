using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // use a slider as a health bar
    [SerializeField] private Slider healthBar;
    PlayerMouvement playerhealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMouvement>(); 

    private void Start()
    {
        
        
    }

    private void Update()
    {
        
        //healthBar.value = playerhealth.get_health();
    }
}
