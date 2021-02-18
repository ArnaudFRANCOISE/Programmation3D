using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMouvement : MonoBehaviour
{
    [SerializeField] private CharacterController controller;

    [SerializeField] private float mouvementSpeed = 12f;

    [SerializeField] private float jumpHeight = 2;
    // GroundChecker is a virtual sphere checking if we are on the ground or not
    [SerializeField] private Transform groundChecker;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] LayerMask groundMask;
    private bool ontheground;

    [SerializeField] private Animator fpsanim;
    
    
    
    [SerializeField] private float gravity = -9.81f;
    private Vector3 _velocity;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
 
        ontheground = Physics.CheckSphere(groundChecker.position, groundDistance, groundMask); // on the ground True or False
        if (ontheground && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }
        //Debug.Log(_velocity);
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        //don't use the following line
        // The character will move without taking considering where he is looking
        // Vector3 move = new Vector3(x, 0f, z);
        
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * (mouvementSpeed * Time.deltaTime));
        
        if (Input.GetButtonDown("Jump"))
        {
            _velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }       
        //Let's add GRAVITY to our body
        _velocity.y += gravity * Time.deltaTime; 
        controller.Move(_velocity * Time.deltaTime); //thanks Newton: y = 1/2*velocity*t² 
        // Set animation
        fpsanim.SetFloat("vertical", z);
        fpsanim.SetFloat("horizontal", x);   


        
    }
}
