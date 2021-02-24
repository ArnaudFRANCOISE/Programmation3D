using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "New Zombie Preset", menuName = "Zombie Preset ")]
public class ZombiePreset : ScriptableObject
{

    [SerializeField] private float zombiehealth;

    [SerializeField] private float zombiedamage;
    
    [FormerlySerializedAs("Distance to hit Player")] [SerializeField] private float playerDistance;

    public float ZombieHealth => zombiehealth;
    public float ZombieDamage => zombiedamage;
    public float PlayerDistance => playerDistance;
    

}

