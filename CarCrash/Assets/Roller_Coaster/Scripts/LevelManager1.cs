using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagerTest : MonoBehaviour
{



    [Header("DEBUG DONT CHANGE")]
    [SerializeField]
    public GameObject[] Levels;
    int levelIndex;
    public static LevelManagerTest instance;

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
        levelIndex = PlayerPrefs.GetInt("LevelIndex");

    }

    private void Start()
    {

    }




}
