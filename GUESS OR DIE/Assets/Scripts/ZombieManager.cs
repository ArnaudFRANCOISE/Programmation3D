using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class ZombieManager : MonoBehaviour
{
    
    //[SerializeField] private float health;100
    
    //[SerializeField] private GameManager gameManager;
    [SerializeField] private Animator zombie_animator;
    [SerializeField] private GameObject whotofollow;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private AudioSource makegrrr;

    //[SerializeField] private float zombiedamage;10
    // GroundChecker is a virtual sphere checking if zombie is near player 
    [SerializeField] private Transform PlayerChecker;
    //[SerializeField] private float PlayerDistance = 0.4f;
    [SerializeField] LayerMask PlayerMask;
   
    
    private bool _isnearPlayer;


    private GameManager gameManager;

    [SerializeField] private  float ZombieHealth;

    private bool zombiealive;

    //public float health => gameManager.
    private void Start()
    {
        zombiealive = true;
        makegrrr.Play();
        zombie_animator.ResetTrigger("isdead");
        //gameManager.zombiealive = true;
        //StartCoroutine(SendDamage(gameManager.ZombieDamage));
        //gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        gameManager = FindObjectOfType<GameManager>();
        whotofollow = GameObject.FindWithTag("Player");
        agent = this.GetComponent<NavMeshAgent>();
        //Debug.Log("Zombie state : " + zombie_animator.GetBool("isdead") );
        //StartCoroutine(SendDamage(gameManager.ZombieDamage));

    }

 
    
    private void Update()
    {
        if (zombiealive)
        {
            //Debug.Log("inside if");
            agent.SetDestination(whotofollow.transform.position);

            _isnearPlayer = Physics.CheckSphere(PlayerChecker.position, gameManager.PlayerDistance, PlayerMask); 
            //_isnearPlayer = Physics.CheckSphere(PlayerChecker.position, 5, PlayerMask); 
            if (_isnearPlayer )
            {
                Debug.Log("ZM: Is nearPlayer");
                StartCoroutine(SendDamage(gameManager.ZombieDamage));
                //gameManager.PlayerTakeDamage(gameManager.ZombieDamage);
            }
        }
        
        else
        {
            
            zombiealive = false;
            Die();
        }
        //Debug.Log(health);
        
    }
    
    public void Die()
    {
        makegrrr.Stop();
        zombie_animator.SetTrigger("isdead");
        
        //Debug.Log("Dead");
        //Destroy(itself);
    }
    

    public IEnumerator SendDamage(float damage)
    {
        Debug.Log("before while");
 

        //PlayerMouvement playerhealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMouvement>();
        //playerhealth.TakeDamage(damage);

        //gameManager.TakeDamage(damage);
        //PlayerHealth -= damage;

        Debug.Log("Is nearPlayer");
        gameManager.PlayerTakeDamage(damage);
        yield return new WaitForSeconds(5f);
        Debug.Log("ZM: Player health: -" + damage);
        
    }
    
    public void ZombieTakeDamage(float amount)
    {
        //Debug.Log(amount);
        ZombieHealth -= amount;
        Debug.Log("ZM: Zombie Health: " + ZombieHealth.ToString());
        if (ZombieHealth <= 0f)
        {
            zombiealive = false;
            
            Die();
        }
    }


}
