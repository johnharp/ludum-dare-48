using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private int maxEnemies = 16;
    private float minSpawnDistance = -90f;
    private float maxSpawnDistance = -30f;
    private float minX = -30;
    private float maxX = 30;

    private GameController GameController = null;
    private GameObject Player = null;

    [SerializeField]
    GameObject[] enemyPrefabs;

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
        int numEnemies = GameObject.FindGameObjectsWithTag(
            "Enemy").Length;

        if (numEnemies < maxEnemies)
        {
            SpawnNewEnemy();
        }
    }

    private void SpawnNewEnemy()
    {
        float spawnDistance = Random.Range(minSpawnDistance, maxSpawnDistance);
        Vector3 pos = new Vector3(
            Random.Range(minX, maxX),
            Player.transform.position.y + spawnDistance,
            0);

        GameObject enemyPrefab = enemyPrefabs[0];

        GameObject newEnemy = Instantiate(
            enemyPrefab,
            pos,
            Quaternion.identity);

    }
}
