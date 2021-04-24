using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private float XVelocity = 0f;
    private float YVelocity = 0f;

    [SerializeField]
    private float ThrustImpulse = 1.0f;
    [SerializeField]
    private float Dampening = 0.3f;
    [SerializeField]
    private float MaxVelocity = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ApplyEngines();
        ClampMaxVelocity();
        Vector3 velocity = new Vector3(XVelocity, YVelocity, 0);
        transform.Translate(velocity * Time.deltaTime);
        DampenVelocity();
    }

    private void ApplyEngines()
    {
        float xImpulse = 0;
        float yImpulse = 0;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            yImpulse = ThrustImpulse;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            yImpulse = -ThrustImpulse;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            xImpulse = ThrustImpulse;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            xImpulse = -ThrustImpulse;
        }

        XVelocity += xImpulse;
        YVelocity += yImpulse;
    }

    private void ClampMaxVelocity()
    {


        if (XVelocity > MaxVelocity) XVelocity = MaxVelocity;
        if (XVelocity < -MaxVelocity) XVelocity = -MaxVelocity;
        if (YVelocity > MaxVelocity) YVelocity = MaxVelocity;
        if (YVelocity < -MaxVelocity) YVelocity = -MaxVelocity;
    }

    private void DampenVelocity()
    {
        float d = Dampening * Time.deltaTime;

        if (XVelocity > -d && XVelocity < d) XVelocity = 0f;
        else if (XVelocity > d) XVelocity -= d;
        else if (XVelocity < -d) XVelocity += d;

        if (YVelocity > -d && YVelocity < d) YVelocity = 0f;
        else if (YVelocity > d) YVelocity -= d;
        else if (YVelocity < -d) YVelocity += d;
    }

}
