using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class fps : MonoBehaviour
{
    [SerializeField] private Transform selfTransform;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Transform sphereHolderTransform;
    [SerializeField] private Transform SpawnPointTransform;
    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] private float bullet_speed = 0;
    [SerializeField]private float movementSpeed = 0.1f;
    [SerializeField]private float cameraSensibility= 0.1f;
    
    
    private void Awake(){
        
    }
    
    // Start is called before the first frame update
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    

    // Update is called once per frame
    private void Update()
    {
        MovePlayer();
        RotateCamera();
        Shoot();
    }

    private void MovePlayer()
    {
        Vector3 cameraRight = cameraTransform.right;
        Vector3 cameraForward = cameraTransform.forward;
        Vector3 deltaPosition = (new Vector3(cameraRight.x,
                                     0f,
                                     cameraRight.z) * Input.GetAxis("Horizontal")
                                 + new Vector3(cameraForward.x,
                                     0f,
                                     cameraForward.z)* Input.GetAxis("Vertical"));

        playerRigidbody.MovePosition(
            playerRigidbody.position + deltaPosition * movementSpeed);
    }

    private void RotateCamera()
    {

        float pitch = -Input.GetAxis("Mouse Y");
        pitch = Mathf.Clamp(pitch, -90f, 90f);

        transform.localEulerAngles += new Vector3(pitch ,
            Input.GetAxis("Mouse X"),
            0f) * cameraSensibility;
    }

    private void Shoot()
    {
        
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject sphere = (GameObject) Instantiate(Resources.Load("Sphere"),
                SpawnPointTransform.position,
                Quaternion.identity,
                sphereHolderTransform);
            sphere.GetComponent<Rigidbody>().AddForce(cameraTransform.forward * 5000f);
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
