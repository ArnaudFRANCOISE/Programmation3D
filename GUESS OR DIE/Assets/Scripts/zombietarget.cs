using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.AI;

public class zombietarget : MonoBehaviour
{
    
    [SerializeField] private float health;
    [SerializeField] private Animator zombie_animator;
    [SerializeField] private GameObject whotofollow;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private AudioSource makegrrr;

    [SerializeField] private float zombiedamage;
    // GroundChecker is a virtual sphere checking if zombie is near player 
    [SerializeField] private Transform PlayerChecker;
    [SerializeField] private float PlayerDistance = 0.4f;
    [SerializeField] LayerMask PlayerMask;
    private bool isnear_player;
    private void Start()
    {
        makegrrr.Play();
        zombie_animator.ResetTrigger("isdead");
        whotofollow = GameObject.FindWithTag("Player");
        agent = this.GetComponent<NavMeshAgent>();
        
    }

    private void Update()
    {
        if (zombie_animator.GetBool("isdead") == false)
        {
            
            agent.SetDestination(whotofollow.transform.position);

            isnear_player = Physics.CheckSphere(PlayerChecker.position, PlayerDistance, PlayerMask); // on the ground True or False
            if (isnear_player )
            {
               SendDamage(zombiedamage);
            }
            
        }
        //Debug.Log(health);
        
    }

    public void TakeDamage(float amount)
    {
        Debug.Log(amount);
        health -= amount;
        Debug.Log(health.ToString());
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        makegrrr.Stop();
        zombie_animator.SetTrigger("isdead");
        Debug.Log("Dead");
    }
    
    public void SendDamage(float damage)
    {
        PlayerMouvement playerhealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMouvement>();
        //playerhealth.TakeDamage(damage);
   
    }
}
