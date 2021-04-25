using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float thrustImpulse = 1.0f;

    private Rigidbody rigidBody;

    private Vector3 thrust = Vector3.zero;
    float thrustTimer = 0f;
    float ThrustDuration = 0.2f;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ApplyEngines();
    }

    private void ApplyEngines()
    {
        Vector3 thrustDirection = Vector3.zero;


        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            thrustDirection = Vector3.up;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            thrustDirection = Vector3.down;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            thrustDirection = Vector3.right;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            thrustDirection = Vector3.left;
        }

        if (thrustDirection != Vector3.zero)
        {
            thrust = thrustDirection * thrustImpulse;
            thrustTimer = ThrustDuration;
        }
    }





    void FixedUpdate()
    {
        if (thrustTimer > 0f)
        {
            rigidBody.AddForce(thrust);
            thrustTimer -= Time.fixedDeltaTime;
        }
    }

}
