using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GirlBehaviour : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Animator girl_animator;
    [SerializeField] private GameObject whotofollow;
    [SerializeField] private NavMeshAgent agent;
    // Start is called before the first frame update
    private bool girlisalive;
    void Start()
    {
        girlisalive = true;
        girl_animator.ResetTrigger("isdead");
        //gameManager.zombiealive = true;
        //StartCoroutine(SendDamage(gameManager.ZombieDamage));
        //gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        gameManager = FindObjectOfType<GameManager>();
        whotofollow = GameObject.FindWithTag("Player");
        agent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (girlisalive)
        {
            //Debug.Log("inside if");
            agent.SetDestination(whotofollow.transform.position);
        }
    }
}
