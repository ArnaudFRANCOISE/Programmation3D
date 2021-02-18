using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // use a slider as a health bar
    [SerializeField] private Slider healthBar;
    private PlayerHealth _playerHealth;

    private void Start()
    {
        _playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        healthBar.value = _playerHealth.health;
    }
}
