using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGrenade : MonoBehaviour
{
    [SerializeField] float throwForce = 30.0f;
    public GameObject grenade;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Throw();
        }
    }

    void Throw()
    {
       GameObject grenadePrefab= Instantiate(grenade, transform.position, transform.rotation);
        Rigidbody rb = grenadePrefab.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce,ForceMode.VelocityChange);
    }
}
