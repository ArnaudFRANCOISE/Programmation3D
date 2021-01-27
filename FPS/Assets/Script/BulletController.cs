using System;
using System.Collections;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private const float lifeSpan = 3f;

    private void Start()
    {
        StartCoroutine(DestroyIn3Seconds());
    }
    

    private IEnumerator DestroyIn3Seconds()
    {
        yield return new WaitForSeconds(lifeSpan);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("entered trigger");
        if (other.gameObject.tag == "hitbox")
        {
            Destroy(other.gameObject);
        }
        
    }
}
