using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private float PlayerDamage;

    [SerializeField] private float range;
    [SerializeField] private Camera fpsCam;

    [SerializeField] private ParticleSystem muzzleflash;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        muzzleflash.Play();
        //shoot a ray from our camera
        RaycastHit hit_info;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit_info, range)) // if we shoot something
        {
            Debug.Log(hit_info.transform.name);
            zombietarget target = hit_info.transform.GetComponent<zombietarget>();
            if (target != null)
            {
                target.TakeDamage(PlayerDamage);
            }
        }
    }
}
