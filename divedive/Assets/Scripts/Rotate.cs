using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    private float XRate = 0.0f;
    [SerializeField]
    private float YRate = 0.0f;
    [SerializeField]
    private float ZRate = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(
            XRate * Time.deltaTime,
            YRate * Time.deltaTime,
            ZRate * Time.deltaTime);
    }
}
