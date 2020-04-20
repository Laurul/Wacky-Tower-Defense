using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    [SerializeField] float timer = 1.0f;
    [SerializeField] int damage = 5;
    float coutndown;
    // Start is called before the first frame update
    void Start()
    {
        coutndown = timer;   
    }

    // Update is called once per frame
    void Update()
    {
        coutndown -= Time.deltaTime;
        if (coutndown <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
    public int returnDamage()
    {
        return damage;
    }
}
