using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private GameObject Player = null;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode arg1)
    {
        // The player prefab is placed on each level
        // and doesn't persist across levels
        // On each level load, find the player
        Player = GameObject.Find("Player");

    }

    public void GoToTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
