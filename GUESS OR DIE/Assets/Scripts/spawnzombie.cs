using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class spawnzombie : MonoBehaviour
{
    //[SerializeField] private GameManager _gameManager;
    [SerializeField] private  float spawntime;
    [SerializeField] private Transform spawnpoint;
    [SerializeField] private GameObject zombiePrefab;
    //[SerializeField] private ZombieManager _zombieManager;
    [SerializeField] private int numberofzombies;
    // Start is called before the first frame update
    private Walltrigger walltrigger;

    public Transform Spawnpoint => spawnpoint;


    void Start()
    {
        ZombieManager zombieManager = gameObject.GetComponent<ZombieManager>();
        walltrigger = GameObject.FindWithTag("WallCheckerPlayer").GetComponent<Walltrigger>();
       
    }
    
    
    // Update is called once per frame
    void Update()
    {
        /*
        if (walltrigger.playerEntered)
        {
            StartCoroutine(InstantiateZombies());

            
        }*/
    }

    public IEnumerator InstantiateZombies()
    {
        Debug.Log("Yolo");
        for (int i = 0; i < numberofzombies; i++)
        {
            Instantiate(zombiePrefab, spawnpoint.transform.position, Quaternion.identity);
            //StopAllCoroutines();
            //StartCoroutine(_zombieManager.SendDamage(_gameManager.ZombieDamage));
        }

        yield return new WaitForSeconds(5f);
    }
}
