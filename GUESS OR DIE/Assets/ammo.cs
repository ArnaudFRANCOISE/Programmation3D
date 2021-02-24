using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammo : MonoBehaviour
{
    public bool isreloading = false;




    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Ammo: PlayerOnAmmo");
            isreloading = true;
        }
    }
}
