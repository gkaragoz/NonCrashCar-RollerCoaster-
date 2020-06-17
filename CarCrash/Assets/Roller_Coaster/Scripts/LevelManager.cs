using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{



    [Header("DEBUG DONT CHANGE")]
    [SerializeField]
    private int _maxLevel = 0;

    public static LevelManager instance;

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


        _maxLevel = SceneManager.sceneCountInBuildSettings - 1;

        //LoadLevel(1);
    }

    private void UnloadCurrentLevel(int currentLevel)
    {
        Debug.Log("Unloading level " + currentLevel);
        SceneManager.UnloadSceneAsync(currentLevel);
    }

    private void LoadLevel(int nextLevel)
    {
        if (nextLevel > _maxLevel)
        {
            Debug.LogWarning("There is no level to open in build settings.");
            return;
        }

        Debug.Log("Level " + nextLevel + " is loaded.");
        SceneManager.LoadScene(nextLevel, LoadSceneMode.Single);

        int preparationLevel = nextLevel + 1;

        if (preparationLevel > _maxLevel)
        {
            Debug.LogWarning("No more new levels. Not gonna prepare new scenes.");
            return;
        }

        Debug.Log("Level " + preparationLevel + " is also prepared.");
        SceneManager.LoadSceneAsync(preparationLevel, LoadSceneMode.Additive);
    }

    private void NextLevel()
    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(currentLevel);
        int nextLevel = currentLevel + 1;

        if (currentLevel == _maxLevel)
        {
            Debug.LogWarning("Last level is completed.");
            return;
        }
        UnloadCurrentLevel(currentLevel);

        LoadLevel(nextLevel);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            LoadLevel(1);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            NextLevel();
        }
    }

}
