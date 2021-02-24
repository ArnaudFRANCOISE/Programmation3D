using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private GameObject Ammo;
    //[SerializeField] private GameObject Player;
    [SerializeField] private float PlayerDamage;
    [SerializeField] private AudioSource gunfire_sound;
    [SerializeField] private float range;
    [SerializeField] private Camera fpsCam;
    [SerializeField] private Slider Ammoslider;
    [SerializeField] private ParticleSystem muzzleflash;
    // Start is called before the first frame update
    RaycastHit hit_info;
    private float magazine = 20;
    [SerializeField] private Color color = new Color(0.91f, 0f, 0.17f);
    [SerializeField] private Color colorfullammo = new Color(0.01f, 0.39f, 0.91f);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (magazine > 0)
        {
            Ammoslider.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = colorfullammo;
            if (Input.GetButtonDown("Fire1"))
            {
                Debug.Log("play sound");
                //unfire_sound.Stop();

                //StopAllCoroutines();
                gunfire_sound.Play();
                //StartCoroutine(playsound());
            
                Shoot();
                magazine -= 1;
                Ammoslider.value = magazine;
            }
        }

        if (Ammo.GetComponent<ammo>().isreloading)
        {
            Debug.Log("full magazine");
            //getmunition
            magazine = 20;
            Ammo.GetComponent<ammo>().isreloading = false;
        }

        if (magazine==0)
        {
            Ammoslider.gameObject.transform.Find("Fill Area").Find("Fill").GetComponent<Image>().color = color;
        }

    }
    /*
    IEnumerator playsound()
    {
        
        yield return null;
    }*/
    
    
    void Shoot()
    {
        muzzleflash.Play();
        //shoot a ray from our camera
        
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit_info, range)) // if we shoot something
        {
            //Debug.Log(hit_info.transform.name);
            ZombieManager target = hit_info.transform.GetComponent<ZombieManager>();
            if (target != null)
            {
                
               target.ZombieTakeDamage(PlayerDamage);
            }
        }
    }
}
