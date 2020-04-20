using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEmpty : MonoBehaviour
{
    public bool isEpmty = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        isEpmty = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        isEpmty = false;
    }
    private void OnTriggerExit(Collider other)
    {
        isEpmty =true;
    }
}
