using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFacingDirection : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.eulerAngles = new Vector3(
                transform.eulerAngles.x,
                180,
                0);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.eulerAngles = new Vector3(
                transform.eulerAngles.x,
                0,
                0);
        }
    }
}
