using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    public static UIManager instance;


    public GameObject tapToPlay;
    public TextMeshProUGUI txtDiamondCount;

    public TxtLevelCompletedTween txtSuccessMsg;
    public TxtLevelFailedTween txtFailTween;

    public GameObject failPanel;


    bool isFailActive;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(instance);


    }

    public void SetDiamondText(string input)
    {
        txtDiamondCount.text = input;
    }

    public void CloseTabToPlay()
    {
        tapToPlay.SetActive(false);
    }

    public void CloseSuccesPanel()
    {
        txtSuccessMsg.Hide();

    }
    public void OpenSuccesPanel()
    {
        txtSuccessMsg.Show();
    }

    public void OpenFailPanel()
    {
        if (isFailActive == false)
        {
            Debug.Log("Fail çalıştı");

            failPanel.SetActive(true);
            txtFailTween.Show();
            isFailActive = true;
        }
    }
    public void RestartScene()
    {
        isFailActive = false;
        CloseFailPanel();
        LevelManager.instance.RestartLevel();
    }
    public void CloseFailPanel()
    {
        txtFailTween.Hide();

        failPanel.SetActive(false);
    }

    public void NextLevel()
    {
        CloseSuccesPanel();
        LevelManager.instance.FinishLevel();
    }
}
