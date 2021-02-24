using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Walltrigger : MonoBehaviour
{

  [SerializeField] private GameManager _gameManager;
  [SerializeField] private GameObject zombiePrefab;
  [SerializeField] private float numberofzombies;
  

  private void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Player"))
    {
          Debug.Log("Player entered");
         
        
      
          for (int i = 0; i < (int)Math.Round(numberofzombies/4); i++)
          {
            Instantiate(zombiePrefab, _gameManager.Spawnpoint1.transform.position, Quaternion.identity);
            //StopAllCoroutines();
            //StartCoroutine(_zombieManager.SendDamage(_gameManager.ZombieDamage));
          }
          for (int i = 0; i < (int)Math.Round(numberofzombies/4); i++)
          {
            Instantiate(zombiePrefab, _gameManager.Spawnpoint2.transform.position, Quaternion.identity);
            //StopAllCoroutines();
            //StartCoroutine(_zombieManager.SendDamage(_gameManager.ZombieDamage));
          }
          for (int i = 0; i < (int)Math.Round(numberofzombies/4); i++)
          {
            Instantiate(zombiePrefab, _gameManager.Spawnpoint3.transform.position, Quaternion.identity);
            //StopAllCoroutines();
            //StartCoroutine(_zombieManager.SendDamage(_gameManager.ZombieDamage));
          }
          for (int i = 0; i < (int)Math.Round(numberofzombies/4); i++)
          {
            Instantiate(zombiePrefab, _gameManager.Spawnpoint4.transform.position, Quaternion.identity);
            //StopAllCoroutines();
            //StartCoroutine(_zombieManager.SendDamage(_gameManager.ZombieDamage));
          }
    }

    
  }
  
}
