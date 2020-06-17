using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI txtDiamondCount;

    public GameObject VfxParent;
    public PathFollower[] players;
    public GameObject[] golds;

    int index = 0;
    int totalGoldCount = 0;
    int currentGoldCount = 0;


    private void Start()
    {
        golds = GameObject.FindGameObjectsWithTag("Gold");
        totalGoldCount = golds.Length;
        txtDiamondCount.text = currentGoldCount + " / " + totalGoldCount;
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MovePlayer();
        }
    }


    public void CollectGold()
    {

        currentGoldCount += 1;
        txtDiamondCount.text = currentGoldCount + " / " + totalGoldCount;
        if (currentGoldCount == totalGoldCount)
        {
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


}
