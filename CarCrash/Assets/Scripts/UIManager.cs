using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public TextMeshProUGUI txtTapToPlay;
    public TextMeshProUGUI txtDiamondCount;

    public GameObject succesPanel;
    public GameObject failPanel;

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
        txtTapToPlay.gameObject.SetActive(false);
    }

    public void CloseSuccesPanel()
    {
        succesPanel.SetActive(false);

    }
    public void OpenSuccesPanel()
    {
        succesPanel.SetActive(true);

    }

    public void NextLevel()
    {
        CloseSuccesPanel();
        LevelManager.instance.FinishLevel();
    }
}
