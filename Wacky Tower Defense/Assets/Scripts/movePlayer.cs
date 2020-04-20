using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayer : MonoBehaviour
{
    float x;
    float z;
    
    Vector3 move;
    Vector3 velocity;

    bool isGrounded;

    [SerializeField] float speed;
    [SerializeField] float gravity=-9.8f;
    [SerializeField] CharacterController controller;
    [SerializeField] Transform ground;
    [SerializeField] float groundDistance = 0.3f;
    [SerializeField] LayerMask groundMask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(ground.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        x = Input.GetAxis("Horizontal");
       z = Input.GetAxis("Vertical");
        move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity*Time.deltaTime);
    }
}
