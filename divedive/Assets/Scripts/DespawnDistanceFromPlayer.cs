using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnDistanceFromPlayer : MonoBehaviour
{
    private GameController GameController = null;
    private GameObject Player = null;

    private float despawnDistance = 100f;

    // Start is called before the first frame update
    void Start()
    {
        GameObject controllers = GameObject.Find("Controllers");
        GameController = controllers.GetComponent<GameController>();
        Player = GameController.GetPlayerGameObject();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Mathf.Abs(
            Player.transform.position.y -
            transform.position.y);

        if (dist > despawnDistance)
        {
            Destroy(gameObject);
        }
    }
}
