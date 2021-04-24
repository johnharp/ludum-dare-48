using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    [SerializeField]
    private GameObject explosionPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject explosion = Instantiate(
                explosionPrefab,
                gameObject.transform.position,
                gameObject.transform.transform.rotation);

            Destroy(gameObject);
        }
    }
}
