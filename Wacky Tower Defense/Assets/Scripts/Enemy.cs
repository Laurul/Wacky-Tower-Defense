using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int health = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Enemy has " + health + " hp");
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject== "pellet")
    //    {
    //        DestroySelf pellet = other.gameObject.GetComponent<DestroySelf>();
    //        health -= pellet.returnDamage();
    //    }
    //}
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 11)
        {
            DestroySelf pellet = collision.gameObject.GetComponent<DestroySelf>();
            health -= pellet.returnDamage();
        }
    }
}
