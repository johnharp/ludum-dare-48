using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    [SerializeField]
    private GameObject explosionPrefab;

    private GameController GameController = null;

    private void Start()
    {
        GameObject controllers = GameObject.Find("Controllers");
        GameController = controllers.GetComponent<GameController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            GameController.Harm(1);

            GameObject explosion = Instantiate(
                explosionPrefab,
                gameObject.transform.position,
                gameObject.transform.transform.rotation);

            Destroy(gameObject);
        }
    }
}
