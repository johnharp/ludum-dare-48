using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject[] wallPrefabs;

    private float leftWallX = -30f;
    private float rightWallX = 30f;
    private float tileYsize = 20f;

    private int slidingWindowSize = 2;

    private GameController GameController = null;
    private GameObject Player = null;

    private List<GameObject> leftWalls = new List<GameObject>();
    private List<GameObject> rightWalls = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        GameObject controllers = GameObject.Find("Controllers");
        GameController = controllers.GetComponent<GameController>();
        Player = GameController.GetPlayerGameObject();


    }

    private int computeTileNum(GameObject obj)
    {
        float y = obj.transform.position.y;

        return (int) (y / tileYsize);
    }


    void Update()
    {
        int tileNum = computeTileNum(Player);


        destroyWallsOutsideOfWindow(tileNum, leftWalls);
        destroyWallsOutsideOfWindow(tileNum, rightWalls);

        createMissingWalls(tileNum, leftWalls, leftWallX);
        createMissingWalls(tileNum, rightWalls, rightWallX);

    }

    private int countWallsWithTileNum(int tileNum, List<GameObject> walls)
    {
        int count = 0;

        foreach (var wall in walls)
        {
            int wallTileNum = computeTileNum(wall);
            if (wallTileNum == tileNum) count++;
        }

        return count;
    }

    private void destroyWallsOutsideOfWindow(int tileNum, List<GameObject> walls)
    {
        List<GameObject> wallsToDestroy = new List<GameObject>();

        foreach (var wall in walls)
        {
            int wallTileNum = computeTileNum(wall);
            if (wallTileNum < tileNum - slidingWindowSize ||
                wallTileNum > tileNum + slidingWindowSize)
            {
                wallsToDestroy.Add(wall);
            }
        }

        foreach(var wall in wallsToDestroy)
        {
            walls.Remove(wall);
            Destroy(wall);
        }
    }

    private void createMissingWalls(int tileNum, List<GameObject> walls, float wallX)
    {
        for (int i = -slidingWindowSize; i <= slidingWindowSize; i++)
        {
            if (countWallsWithTileNum(tileNum+i, walls) == 0)
            {
                Vector3 pos = new Vector3(
                           wallX,
                            (tileNum+i) * tileYsize, 0);
                GameObject newWall = Instantiate(
                    chooseRandomWall(),
                    pos,
                    Quaternion.identity);
                walls.Add(newWall);
            }
        }
    }

    private GameObject chooseRandomWall()
    {
        int i = Random.Range(0, wallPrefabs.Length);
        return wallPrefabs[i];
    }
}
