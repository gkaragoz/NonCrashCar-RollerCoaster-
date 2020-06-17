using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{


    public PathFollower[] players;
    public GameObject[] golds;
    private int levelIndex = -1;

    int playerIndex = 0;
    int totalGoldCount = 0;
    int currentGoldCount = 0;

    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Start()
    {
        totalGoldCount = golds.Length;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode arg1)
    {
        if (levelIndex == -1)
        {
            levelIndex = scene.buildIndex;
        }
    }

    private void Update()
    {
        if (LevelManager.currentLevelIndex == levelIndex)
        {
            UIManager.instance.SetDiamondText(currentGoldCount + " / " + totalGoldCount);

        }

        if (Input.GetMouseButtonDown(0) && LevelManager.currentLevelIndex == levelIndex)
        {
            UIManager.instance.CloseTabToPlay();
            MovePlayer();
        }
    }


    public void CollectGold()
    {
        currentGoldCount += 1;
        UIManager.instance.SetDiamondText(currentGoldCount + " / " + totalGoldCount);
        if (currentGoldCount == totalGoldCount)
        {
            UIManager.instance.OpenSuccesPanel();
            LevelManager.instance.PlayVFX();
        }
    }

    public void MovePlayer()
    {
        if (playerIndex == players.Length)
        {
            return;
        }
        players[playerIndex].startButton = true;
        playerIndex++;
    }




}
