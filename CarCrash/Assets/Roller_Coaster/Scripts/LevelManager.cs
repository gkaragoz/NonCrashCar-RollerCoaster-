using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public CameraMovement cameraMovement;
    public ParticleSystem[] vfx;
    int sceneCount;
    [Header("DEBUG DONT CHANGE")]



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
        sceneCount = UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;
        Debug.Log(sceneCount);
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

    public void RestartLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(currentLevelIndex);
        SceneManager.LoadSceneAsync(currentLevelIndex + 1, LoadSceneMode.Additive);
        cameraMovement.GoToLevel(currentLevelIndex);
    }

    public void FinishLevel()
    {
        Debug.Log(currentLevelIndex);


        if (currentLevelIndex == sceneCount - 2)
        {
            currentLevelIndex = Random.Range(1, currentLevelIndex - 2);
            SceneManager.LoadScene(currentLevelIndex);
            cameraMovement.GoToLevel(currentLevelIndex);

            return;
        }
        else
        {
            currentLevelIndex += 1;

            cameraMovement.GoToLevel(currentLevelIndex);


            StopVFX();
        }


    }

}
