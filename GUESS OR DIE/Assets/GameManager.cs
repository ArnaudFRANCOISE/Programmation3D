using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Serialization;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //[SerializeField] private PlayerPreset playerPreset;
    //[SerializeField] private ZombiePreset zombiePreset;
    [SerializeField] private float playerHealth;
    [SerializeField] private float mouvementSpeed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private float zombiehealth;
    
    [SerializeField] private float zombiedamage;
    //[SerializeField] private ZombieManager _zombieManager;
    [FormerlySerializedAs("Distance to hit Player")] [SerializeField] private float playerDistance;
    [SerializeField] private GameObject spawnpoint1;
    [SerializeField] private GameObject spawnpoint2;
    [SerializeField] private GameObject spawnpoint3;
    [SerializeField] private GameObject spawnpoint4;
    [SerializeField] private GameObject gameovercanvas;

    public GameObject Spawnpoint1 => spawnpoint1;
    public GameObject Spawnpoint2 => spawnpoint2;
    public GameObject Spawnpoint3 => spawnpoint3;
    public GameObject Spawnpoint4 => spawnpoint4;

    public float ZombieHealth
    {
        get => zombiehealth;
        set => zombiehealth = value;
    }
     
    public bool zombiealive = false;
    
    public float ZombieDamage => zombiedamage;
    public float PlayerDistance => playerDistance;
    public float PlayerHealth
    {
        get => playerHealth;
        set => playerHealth = value;
    }

    public float PlayerMouvementSpeed
    {
        get => mouvementSpeed;
        set => mouvementSpeed = value;
    }


    public float JumphHeight
    {
        get => jumpHeight;
        set => jumpHeight = value;
    }

    private void Start()
    {
        zombiealive = true;
        
    }

    //##################################################################################################################
    // Player Status
    private bool _isAlivePlayer = false;

    public void set_player_to_life()
    {
        _isAlivePlayer = true;
    }

    public void kill_player()
    {
        _isAlivePlayer = false;
    }

    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="damage"></param>
    public void PlayerTakeDamage(float damage)
    {

        PlayerHealth -= damage;
        Debug.Log("Health= "+ PlayerHealth.ToString());
    }
    
    //###################################################################################################################
    // Zombie Status
    /*
    public void ZombieTakeDamage(float amount)
    {
        ZombieManager popo;
        popo = FindObjectOfType<ZombieManager>();
        popo.ZombieTakeDamage(amount);
        
    }*/
    //##################################################################################################################
    // Game Status

    private void Update()
    {
        if (PlayerHealth <= 0)
        {
            Invoke("GameOver", 1f);
        }
    }

    private bool gamehasended = false;
    void GameOver()
    {
        if (gamehasended == false)
        {
            //Invoke("Restart", 2f);
            gamehasended = true;
            Debug.Log("GameOver");
            gameovercanvas.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Survive");
    }
}



