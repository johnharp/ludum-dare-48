using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatUpward : MonoBehaviour
{
    private float minSpeed = 3f;
    private float maxSpeed = 10f;

    private float speed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(
            0, speed * Time.deltaTime, 0));
    }
}
