using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject[] bubblePrefabs;

    private float spawnDistance = -40f;

    //private float despawnDistance = 100f;

    private float nextSpawnTime = 0.0f;
    private float minSpawnInterval = 0.1f;
    private float maxSpawnInterval = 2f;

    private GameController GameController = null;
    private GameObject Player = null;

    void Start()
    {
        GameObject controllers = GameObject.Find("Controllers");
        GameController = controllers.GetComponent<GameController>();
        Player = GameController.GetPlayerGameObject();
    }

    // Update is called once per frame
    void Update()
    {
        //destroyBubbles();

        if (Time.time >= nextSpawnTime)
        {
            int index = Random.Range(0, bubblePrefabs.Length);
            GameObject bubblePrefab = bubblePrefabs[index];
            float x = Random.Range(-20, 20);

            Vector3 pos = new Vector3(
                x,
                Player.transform.position.y + spawnDistance, 0);
            GameObject newBubble = Instantiate(
                bubblePrefab,
                pos,
                Quaternion.identity);
            //bubbles.Add(newBubble);
            chooseNewNextSpawnTime();
        }
    }


    private void chooseNewNextSpawnTime()
    {
        nextSpawnTime = Time.time +
            Random.Range(minSpawnInterval, maxSpawnInterval);
    }
}
