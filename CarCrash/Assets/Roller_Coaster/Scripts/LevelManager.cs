using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public CameraMovement cameraMovement;
    public ParticleSystem[] vfx;

    [Header("DEBUG DONT CHANGE")]
    [SerializeField]
    private int _maxLevel = 0;


    public static int currentLevelIndex = 0;
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


    }

    private void Start()
    {
        currentLevelIndex = 1;// PlayerPrefs.GetInt("LevelIndex");
        LoadLevel(currentLevelIndex);
        cameraMovement.GoToLevel(currentLevelIndex);
    }

    public static void UnloadLevel(int levelIndex)
    {
        Debug.Log("Unloading level " + levelIndex);
        SceneManager.UnloadSceneAsync(levelIndex);
    }

    public static void LoadLevel(int levelIndex)
    {
        Debug.Log("Level " + levelIndex + " is also prepared.");
        SceneManager.LoadSceneAsync(levelIndex, LoadSceneMode.Additive);
    }






    public void PlayVFX()
    {
        foreach (var item in vfx)
        {
            item.Play();
        }
    }

    public void StopVFX()
    {
        foreach (var item in vfx)
        {
            item.Stop();
        }
    }

    public void FinishLevel()
    {
        currentLevelIndex += 1;
        cameraMovement.GoToLevel(currentLevelIndex);
        StopVFX();

    }

}
