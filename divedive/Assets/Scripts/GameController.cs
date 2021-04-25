using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Text DepthText = null;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private UnityEngine.UI.RawImage HullStatusRawImage = null;

    [SerializeField]
    private Texture[] HullStatusImages = null;

    private GameObject Player = null;
    public GameObject GetPlayerGameObject()
    {
        return Player;
    }

    private int hullStatus = 4;


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

    public void UpdateDepthText()
    {
        if (Player == null) return;

        float depth = Player.transform.position.y;

        if (depth >= 0) depth = 0;
        else depth = -depth;

        string depthStr;

        if (depth >= 1000)
        {
            depthStr = $"{(depth/1000).ToString("#,###.00")} km";
        }
        else
        {
            depthStr = $"{depth.ToString("N0")} m";
        }

        DepthText.text = depthStr;
    }

    public void Update()
    {
        UpdateDepthText();
    }

    public void Harm(int v)
    {
        hullStatus -= v;
        hullStatus = Mathf.Max(hullStatus, 0);

        UpdateHullStatus();

        if (hullStatus == 0)
        {
            //AudioSource.PlayClipAtPoint(DeathSound, transform.position, 1f);
            Player.SetActive(false);
            StartCoroutine(GoToGameOver());
        }

    }

    public IEnumerator GoToGameOver()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("GameOverScene");
    }



    private void UpdateHullStatus()
    {
        Texture t = HullStatusImages[hullStatus];
        HullStatusRawImage.texture = t;
    }
}
