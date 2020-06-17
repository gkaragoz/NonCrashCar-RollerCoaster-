using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI txtDiamondCount;
    public TextMeshProUGUI txtTapToPlay;

    public GameObject VfxParent;
    public PathFollower[] players;
    public GameObject[] golds;

    public GameObject failPanel;
    public GameObject succesPanel;


    int index = 0;
    int totalGoldCount = 0;
    int currentGoldCount = 0;


    private void Start()
    {
        totalGoldCount = golds.Length;
        txtDiamondCount.text = currentGoldCount + " / " + totalGoldCount;
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            txtTapToPlay.gameObject.SetActive(false);
            MovePlayer();
        }
    }


    public void CollectGold()
    {

        currentGoldCount += 1;
        txtDiamondCount.text = currentGoldCount + " / " + totalGoldCount;
        if (currentGoldCount == totalGoldCount)
        {
            OpenSuccesPanel();
            VfxParent.SetActive(true);
        }
    }

    public void MovePlayer()
    {
        if (index == players.Length)
        {
            return;
        }
        players[index].startButton = true;
        index++;
    }

    public void OpenFailPanel()
    {
        failPanel.SetActive(true);
    }

    public void CloseFailPanel()
    {
        failPanel.SetActive(false);
    }

    public void OpenSuccesPanel()
    {
        succesPanel.SetActive(true);
    }

    public void CloseSuccesPanel()
    {
        succesPanel.SetActive(false);
    }



}
