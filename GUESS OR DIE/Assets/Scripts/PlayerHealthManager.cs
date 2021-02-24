using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{

    [SerializeField] private GameManager gameManager;
    
    // use a slider as a health bar
    [SerializeField] private Slider healthBar;
    
    public float PlayerHealth
    {
        get => gameManager.PlayerHealth;
        set
        {
            if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value));
            PlayerHealth = value;
        }
    }
    /*


    */

    private void Start()
    {
        
        
    }

    private void Update()
    {
        healthBar.value = PlayerHealth;
        //Debug.Log("PHM: "+ PlayerHealth.ToString());
        
    }
}
