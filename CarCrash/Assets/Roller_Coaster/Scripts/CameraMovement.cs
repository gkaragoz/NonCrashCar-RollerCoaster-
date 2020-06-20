using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public LeanTweenType easeType;
    public GameObject cameraParent;
    public float levelChangeSpeed = 1;
    int sceneCount;

    public void GoToLevel(int index)
    {

        Vector3 nextPos = new Vector3(cameraParent.transform.position.x, cameraParent.transform.position.y, (200 * index + 10) - 200);

        if (Vector3.Distance(cameraParent.transform.position, nextPos) < 211)
        {
            LeanTween.move(cameraParent, nextPos, levelChangeSpeed).setEase(easeType).setOnComplete(() =>
            {
                LevelManager.UnloadLevel(LevelManager.currentLevelIndex - 1);
                LevelManager.LoadLevel(LevelManager.currentLevelIndex + 1);
            });
        }
        else
        {
            LevelManager.LoadLevel(LevelManager.currentLevelIndex + 1);
            cameraParent.transform.position = nextPos;
        }

    }
}
