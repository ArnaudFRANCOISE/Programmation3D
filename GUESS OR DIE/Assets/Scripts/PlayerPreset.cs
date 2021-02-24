using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Player Preset", menuName="Player Preset ")]
public class PlayerPreset :ScriptableObject{
       [SerializeField] private float playerHealth;
       [SerializeField] private float mouvementSpeed;
       [SerializeField] private float jumpHeight;

        public float PlayerHealth => playerHealth;

        public float MouvementSpeed => mouvementSpeed;
        

        public float JumphHeight => jumpHeight;
}
